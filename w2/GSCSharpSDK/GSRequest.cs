/*
 * Copyright (C) 2011 Gigya, Inc.
 */

using System;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;


namespace Gigya.Socialize.SDK
{

    /// <summary>
    /// A Request to Gigya Socialize API 
    /// </summary>
    public class GSRequest
    {
        public const String version = "2.15.3";

        /// <summary>
        /// This flag tells the SDK to try and reuse connections to the gigya servers, in order to lower the overheads
        /// associated with creating new connections, and to reduce latency. The drawback of long-lived connections is
        /// that they may become stale after a while, failing the next request sent on top of them. The SDK attempts to
        /// avoid that problem by purging old connections and re-issuing failed requests (just once). If, however, you
        /// encounter many failed requests to the Gigya API, you can try turning this feature off.
        /// </summary>
        public static bool EnableConnectionPooling = true;


        /// <summary>
        /// The maximum number of concurrent connections that can remain open to the Gigya servers, assuming
        /// EnableConnectionPooling was enabled (above). Default: 100.
        /// </summary>
        public static int  MaxConcurrentConnections
        {
            # region set/get
            get {
                return maxConcurrentConnections;
            }
            set {
                if (maxConcurrentConnections != value) {
                    maxConcurrentConnections = value;
                    // Note: existing requests will release the previous semaphore (they cache it). Creating this new
                    // semaphore can cause new requests to be queued temporarily, until existing requests are completed.
                    semaphore = new Semaphore(value, value);
                }
            }
            #endregion
        }



        /// <summary>
        /// When all connections are in use (i.e. actively sending a request or receiving a response) and you attempt to
        /// send a new request, the SDK will perform one of two things:
        /// 
        /// If BlockWhenConnectionsExhausted is set to true, the SDK will block your thread until a connection frees up.
        /// Disadvantage: This entails using a semaphore, which adds a bit of overhead per request.
        /// 
        /// If BlockWhenConnectionsExhausted is set to false, .Net will queue your requests (at least as of .Net 3.5).
        /// Disadvantages:
        /// 1. Queued requests are stored in memory, and if you send requests significantly faster than the connections
        ///    pool is able to handle, you risk running out of memory eventually.
        /// 2. Queued requests are delayed significantly (could even reach hours), which may be unacceptable to you.
        /// 
        /// Default: true (block).
        /// </summary>
        public static bool BlockWhenConnectionsExhausted = true;

        /// <summary>
        /// When accessing different gigya data centers (e.g. eu.gigya.com), you may override the default "gigya.com"
        /// suffix using this member.
        /// </summary>
        public string APIDomain
        {
            get
            {
                return apiDomain;
            }
            set
            {
                if (value != null && value != "")
                    apiDomain = value;
            }
        }

        #region Private Members
        private string domain;
        private string path;
        private string method;
        private string apiKey;
        private string secretKey;
        private GSObject dictionaryParams;
        private bool useHTTPS;
        private string format;
        private GSLogger logger = new GSLogger();
        private static string unreservedCharsstring = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        private static char[] unreservedChars;
        private GSResponse immediateFailureResponse = null;
        private GSResponse asyncResponse = null;
        private string apiDomain = "gigya.com";

        private static int nonceCounter = 0;
        static int maxConcurrentConnections = 100;
        static Semaphore semaphore = new Semaphore(MaxConcurrentConnections, MaxConcurrentConnections);

        /// <summary>
        /// The delta between our clock and Gigya's servers. We use it to correct the timestamp we put on outgoing
        /// signed requests (non-HTTPS). Otherwise if the drift between our clock and Gigya's servers' is too great
        /// (as of now over +-2 minutes), the requests will fail. We continuously adjust this value based on server
        /// responses timestamp.
        /// </summary>
        private static long timeCorrection = 0;


        IAsyncResult _asyncResult = null; // For asynchronous operation
        #endregion

        #region Contructors

        /// <summary>
        /// Static constructor
        /// </summary>
        static GSRequest()
        {
            unreservedChars = unreservedCharsstring.ToCharArray();
            Array.Sort(unreservedChars);
        }

        /// <summary>
        /// Constructs a request using an access token that was earlier obtained in the login proccess.
        /// The way to acuire the access token is beyond the scope of this class, but usualy it requires to 
        /// redirect the user to the login url, retrieve the "code" parameter and the exchange it for an access token (in some
        /// cases it is possible to get the access token in one step as a fragment parameter, e.g. www.example.com/callback#access_token=...)
        /// This kind of operation must be done over a secure connection (https).
        /// </summary>
        /// <param name="accessToken">the access token that was earlier obtained in the login proccess</param>        
        /// <param name="apiMethod">The API method (including namespace) to call. For example: socialize.getUserInfo
        /// If namespaces is not supplied "socialize" is assumed</param>
        public GSRequest(string accessToken, string apiMethod)
            : this(accessToken, /*secretKey*/ null, apiMethod, /*clientParams*/ null, /*useHttps*/ true) { }

        /// <summary>
        /// Constructs a request using an access token that was earlier obtained in the login proccess.
        /// The way to acuire the access token is beyond the scope of this class, but usualy it requires to 
        /// redirect the user to the login url, retrieve the "code" parameter and the exchange it for an access token (in some
        /// cases it is possible to get the access token in one step as a fragment parameter, e.g. www.example.com/callback#access_token=...)
        /// This kind of operation must be done over a secure connection (https).
        /// </summary>
        /// <param name="accessToken">the access token that was earlier obtained in the login proccess</param>        
        /// <param name="apiMethod">The API method (including namespace) to call. For example: socialize.getUserInfo
        /// If namespaces is not supplied "socialize" is assumed</param>
        /// <param name="clientParams">The request parameters</param>        
        public GSRequest(string accessToken, string apiMethod, GSObject clientParams)
            : this(accessToken, /*secretKey*/ null, apiMethod, clientParams, /*useHttps*/ true) { }

        /// <summary>
        /// Constructs a request using an apiKey and secretKey.
        /// Suitable for calling our old REST API
        /// </summary>
        /// <param name="apiKey">Gigya's API key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="secretKey">Secret Key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="apiMethod">The API method (including namespace) to call. For example: socialize.getUserInfo
        /// If namespaces is not supplied "socialize" is assumed</param>
        public GSRequest(string apiKey, string secretKey, string apiMethod)
            : this(apiKey, secretKey, apiMethod, /*clientParams*/ null, /*useHttps*/ false) { }

        /// <summary>
        /// Constructs a request using an apiKey and secretKey.
        /// Suitable for calling our old REST API
        /// </summary>
        /// <param name="apiKey">Gigya's API key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="secretKey">Secret Key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="apiMethod">The API method (including namespace) to call. For example: socialize.getUserInfo
        /// If namespaces is not supplied "socialize" is assumed</param>        
        /// <param name="useHTTPS">Set this to true if you want to use HTTPS.
        /// The library uses HTTP by default (the request is signed with the secret key) 
        /// but you can use this parameter to override the default</param>
        public GSRequest(string apiKey, string secretKey, string apiMethod, bool useHTTPS)
            : this(apiKey, secretKey, apiMethod, /*clientParams*/ null, useHTTPS) { }

        /// <summary>
        /// Constructs a request using an apiKey and secretKey.
        /// Suitable for calling our old REST API
        /// </summary>
        /// <param name="apiKey">Gigya's API key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="secretKey">Secret Key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="apiMethod">The API method (including namespace) to call. For example: socialize.getUserInfo
        /// If namespaces is not supplied "socialize" is assumed</param>
        /// <param name="clientParams">The request parameters</param>
        /// The library uses HTTP by default (the request is signed with the secret key) 
        /// but you can use this parameter to override the default</param>
        public GSRequest(string apiKey, string secretKey, string apiMethod, GSObject clientParams)
            : this(apiKey, secretKey, apiMethod, clientParams, /*useHttps*/ false) { }

        /// <summary>
        /// Constructs a request using an apiKey and secretKey.
        /// Suitable for calling our old REST API
        /// </summary>
        /// <param name="apiKey">Gigya's API key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="secretKey">Secret Key obtained from Site-Setup page on the Gigya website</param>
        /// <param name="apiMethod">The API method (including namespace) to call. For example: socialize.getUserInfo
        /// If namespaces is not supplied "socialize" is assumed</param>
        /// <param name="clientParams">The request parameters</param>
        /// <param name="useHTTPS">Set this to true if you want to use HTTPS.
        /// The library uses HTTP by default (the request is signed with the secret key) 
        /// but you can use this parameter to override the default</param>
        /// 
        /// 
        public GSRequest(string apiKey, string secretKey, string apiMethod, GSObject clientParams, bool useHTTPS)
        {
            if (apiMethod == null || apiMethod == "")
                return;

            this.apiKey = apiKey;
            this.secretKey = secretKey;
            this.method = apiMethod;


            if (clientParams == null)
                this.dictionaryParams = new GSObject();
            else
                this.dictionaryParams = clientParams.Clone();

            this.useHTTPS = useHTTPS;

            // Write to traceLog
            logger.Write("apiMethod", apiMethod);
            if (secretKey != null)
                logger.Write("apiKey", apiKey);
            else
                logger.Write("accessToken", apiKey);
            logger.Write("clientParams", dictionaryParams.ToJsonString());

        }

 
        private void BuildURI(string apiMethod)
        {
            if (apiMethod.StartsWith("/"))
                apiMethod = apiMethod.Substring("/".Length);

            if (apiMethod.IndexOf(".") == -1)
            {
                this.domain = "socialize" + "." + this.APIDomain;
                this.path = "/socialize." + apiMethod;
            }
            else
            {
                string[] tokens = apiMethod.Split(new char[] { '\\', '.' });
                this.domain = tokens[0] + "." + this.APIDomain;
                this.path = "/" + apiMethod;
            }
        }

        #endregion

        #region Public Methods
        #region - Set Params methods -
        /// <summary>
        ///  Associates the specified parameter with the specified value. 
        ///  If the parameter is already exists, the old value is replaced by the specified value.
        ///  If the parameter does not already exist, it will be inserted as a new parameter.
        /// </summary>
        /// <param name="param">parameter name to set</param>
        /// <param name="value">the value to set for the parameter</param>
        public void SetParam(string param, string value)
        {
            this.dictionaryParams.Put(param, value);
        }
        /// <summary>
        ///  Associates the specified parameter with the specified value. 
        ///  If the parameter is already exists, the old value is replaced by the specified value.
        ///  If the parameter does not already exist, it will be inserted as a new parameter.
        /// </summary>
        /// <param name="param">parameter name to set</param>
        /// <param name="value">the value to set for the parameter</param>
        public void SetParam(string param, long value)
        {
            this.dictionaryParams.Put(param, value);
        }
        /// <summary>
        ///  Associates the specified parameter with the specified value. 
        ///  If the parameter is already exists, the old value is replaced by the specified value.
        ///  If the parameter does not already exist, it will be inserted as a new parameter.
        /// </summary>
        /// <param name="param">parameter name to set</param>
        /// <param name="value">the value to set for the parameter</param>
        public void SetParam(string param, int value)
        {
            this.dictionaryParams.Put(param, value);
        }
        /// <summary>
        ///  Associates the specified parameter with the specified value. 
        ///  If the parameter is already exists, the old value is replaced by the specified value.
        ///  If the parameter does not already exist, it will be inserted as a new parameter.
        /// </summary>
        /// <param name="param">parameter name to set</param>
        /// <param name="value">the value to set for the parameter</param>
        public void SetParam(string param, bool value)
        {
            this.dictionaryParams.Put(param, value);
        }
        /// <summary>
        ///  Associates the specified parameter with the specified value. 
        ///  If the parameter is already exists, the old value is replaced by the specified value.
        ///  If the parameter does not already exist, it will be inserted as a new parameter.
        /// </summary>
        /// <param name="param">parameter name to set</param>
        /// <param name="value">the value to set for the parameter</param>
        public void SetParam(string param, GSObject value)
        {
            this.dictionaryParams.Put(param, value);
        }
        /// <summary>
        ///  Associates the specified parameter with the specified value. 
        ///  If the parameter is already exists, the old value is replaced by the specified value.
        ///  If the parameter does not already exist, it will be inserted as a new parameter.
        /// </summary>
        /// <param name="param">parameter name to set</param>
        /// <param name="value">the value to set for the parameter</param>
        public void SetParam(string param, GSArray value)
        {
            this.dictionaryParams.Put(param, value);
        }
        #endregion

        /// <summary>
        /// Returns a GSObject object containing the parameters of this request.
        /// </summary>
        /// <returns>the params field of this request.</returns>
        public GSObject GetParams()
        {
            return this.dictionaryParams;
        }

        /// <summary>
        /// Send the request synchronously
        /// </summary>
        /// <returns>a GSResponse object representing Gigya's response</returns>
        public GSResponse Send()
        {
            return this.Send(Timeout.Infinite);
        }

        /// <summary>
        /// Send the request synchronously
        /// </summary>
        /// <param name="timeout">Connection timeout in milliseconds</param>
        /// <returns>a GSResponse object representing Gigya's response</returns>
        public GSResponse Send(int timeout)
        {
            this.format = this.dictionaryParams.GetString("format", "json");

            if (   string.IsNullOrEmpty(this.method)
                || (string.IsNullOrEmpty(this.apiKey) && string.IsNullOrEmpty(this.secretKey)))
            {
                return new GSResponse(this.method, this.dictionaryParams, 400002, logger); // (Missing required parameter)
            }

            try {
                // Set default params
                this.SetParam("format", this.format);
                this.SetParam("httpStatusCodes", "false");

                BuildURI(this.method);
                // Send request by HTTP POST
                GSResponse resp = this.SendRequest("POST", timeout);

                // If we received an error from the server indicating that our clock isn't syncronized with the server's,
                // we adjust the time correction by the time delta and perform one retry.
                if (resp.GetErrorCode() == 403002 && resp.GetHeaders()["Date"] != null) {
                    timeCorrection = (long)(DateTime.Parse(resp.GetHeaders()["Date"]) - DateTime.Now).TotalMilliseconds;
                    resp = this.SendRequest("POST", timeout);
                }

                return resp;
            }
            catch (WebException e) {
                if (e.Status == WebExceptionStatus.Timeout)
                    return new GSResponse(method, dictionaryParams, 504002, "Request Timeout", logger);
                else return new GSResponse(method, dictionaryParams, 500, e.ToString(), logger);
            }
            catch (FormatException) {
                return new GSResponse(method, dictionaryParams, 400006, "Invalid parameter value: secret", logger);
            }
            catch (Exception ex) {
                return new GSResponse(method, dictionaryParams, 500, ex.ToString(), logger);
            }
        }


        /// <summary>
        /// Send the request asynchronously. You can pass an optional callback method to be called when the response
        /// arrives. The state parameter will be passed back to your callback function as IAsyncResult.AsyncState. If
        /// you do not pass a callback function (i.e. pass null), then you need to wait on the resulting
        /// IAsyncResult.AsyncWaitHandle. In either case, once you are signalled of the response, you need to call
        /// EndSend() to receive it.
        /// </summary>
        public IAsyncResult BeginSend(AsyncCallback callback, object state) {
            this.format = this.dictionaryParams.GetString("format", "json");

            if (   string.IsNullOrEmpty(this.method)
                || (string.IsNullOrEmpty(this.apiKey) && string.IsNullOrEmpty(this.secretKey)))
            {
                // Missing required parameter
                return ImmediateAsyncFailure(400002, null, callback, state);
            }

            Semaphore sem = null;
            try {
                // Set default params
                this.SetParam("format", this.format);
                this.SetParam("httpStatusCodes", "false");
                int sendRetries = 0;

                BuildURI(this.method);

                if (BlockWhenConnectionsExhausted) {
                    sem = semaphore; // cache it in case settings change and it is modified
                    sem.WaitOne();
                }

                var reliableRequest = new GSAsyncReliableRequest(

                    // We pass a factory to generate requests
                    (out HttpWebRequest request_, out byte[] requestBody_) => { request_ = PrepareHttpRequest(this, "POST", -1, out requestBody_); },

                    // Once we got a response we create and store the GSResponse object. If we encounter error #403002, we correct the timestamp and
                    // resend the request once.
                    asyncReq => {
                        if (asyncReq.Error != null)
                            asyncResponse = new GSResponse(this.method, dictionaryParams, 500, EncodeJson(asyncReq.Error.ToString()), logger);
                        else {
                            logger.Write("server", asyncReq.Response.Headers["x-server"]);
                            asyncResponse = new GSResponse(this.method, ExtractHeaders(asyncReq.Response.Headers), asyncReq.ResponseBody, logger);
                        }
                        if (asyncResponse.GetErrorCode() == 403002 && asyncResponse.GetHeaders()["Date"] != null) {
                            timeCorrection = (long)(DateTime.Parse(asyncResponse.GetHeaders()["Date"]) - DateTime.Now).TotalMilliseconds;
                            if (sendRetries++ == 0)
                                return true;
                        }
                        return false;
                    },

                    // We pass our own callback that releases the semaphore if needed before calling back the user.
                    ar => {
                        if (sem != null)
                            sem.Release();
                        if (callback != null)
                            callback(ar);
                    },

                    state);

                _asyncResult = reliableRequest;
                reliableRequest.BeginReliableSend(); // Do this AFTER assigning _asyncResult; it may be re-entrant.
                return reliableRequest;
            }
            catch (FormatException) {
                if (sem != null)
                    sem.Release();
                return ImmediateAsyncFailure(400006, "Invalid parameter value: secret", callback, state);
            }
            catch (Exception ex) {
                if (sem != null)
                    sem.Release();
                return ImmediateAsyncFailure(500, EncodeJson(ex.ToString()), callback, state);
            }
        }


        IAsyncResult ImmediateAsyncFailure(int errorCode, string errorMessage, AsyncCallback callback, object state) {
            immediateFailureResponse = new GSResponse(method, dictionaryParams, errorCode, errorMessage, logger);
            _asyncResult = new GSAsync(state, new ManualResetEvent(true), true, true);
            if (callback != null)
                callback(_asyncResult);
            return _asyncResult;
        }


        Dictionary<string, string> ExtractHeaders(WebHeaderCollection headers) {
            var d = new Dictionary<string, string>();
            for (int i=0; i<headers.Count; ++i)
                d.Add(headers.AllKeys[i], headers.Get(i));
            return d;
        }


        public GSResponse EndSend(IAsyncResult iar) {
            if (iar == null) throw new ArgumentNullException("iar");
            if (_asyncResult == null) throw new InvalidOperationException("Cannot call EndSend before calling BeginSend");
            if (_asyncResult != iar) throw new ArgumentException("The IAsyncResult object was not returned from the corresponding asynchronous method on this class.", "iar");

            // If an invalid call to BeginSend() was made, we previously stored a locally-generated reply with error
            // details and now return it to the user (as if it was a real reply from the server).
            if (immediateFailureResponse != null)
                return immediateFailureResponse;

            else return asyncResponse;
        }

        /// <summary>
        /// Aborts an asynchronous request that you previously initiated using BeginSend().
        /// </summary>
        /// <param name="iar"></param>
        public void Abort() {
            if (_asyncResult == null) throw new InvalidOperationException("Cannot call Abort before calling BeginSend");
            if (immediateFailureResponse == null)
                ((GSAsyncReliableRequest)_asyncResult).GSAsyncRequest.Request.Abort();
        }

        /// <summary>
        ///  Converts a GSObject to a query string
        /// </summary>
        /// <param name="addQuestionMark">Set to true if you want the returned string to start with a question mark.</param>
        /// <param name="paramDictionary">the GSObject to get the query string from</param>
        /// <returns></returns>
        public static string BuildQS(bool addQuestionMark, GSObject paramDictionary)
        {
            StringBuilder retQS = new StringBuilder();
            string value;
            if (addQuestionMark)
                retQS.Append("?");

            foreach (string key in paramDictionary.GetKeys()) {
                value = paramDictionary.GetString(key, null);
                if (value != null) {
                    retQS.Append(key);
                    retQS.Append('=');
                    retQS.Append(GSRequest.UrlEncode(value));
                    retQS.Append('&');
                }
            }

            // Remove the '&' at the end by trimming the end of the StringBuilder
            if (retQS[retQS.Length - 1] == '&')
                retQS.Length--;

            return retQS.ToString();
        }

        /// <summary>
        /// Applies URL encoding rules to the String value, and returns the outcome.
        /// </summary>
        /// <param name="value">the string to encode</param>
        /// <returns>the URL encoded string</returns>
        public static string UrlEncode(string value)
        {
            StringBuilder result = new StringBuilder();
            char[] c = new char[1];

            for (int i = 0; i < value.Length; i++) {
                char symbol = value[i];
                if (Array.BinarySearch<char>(unreservedChars, symbol) >= 0)
                    result.Append(symbol);
                else {
                    c[0] = symbol;
                    byte[] bytes = Encoding.UTF8.GetBytes(c);
                    foreach (byte b in bytes)
                        result.Append('%' + String.Format("{0:X2}", (int)b));
                }
            }

            return result.ToString();
        }
        #endregion


        #region Private Methods

        private static HttpWebRequest PrepareHttpRequest(GSRequest gsReq, string httpMethod, int timeout, out byte[] requestBody)
        {
            gsReq.SetParam("sdk", "dotnet_" + version);
            // Set Protocol and URI
            string protocol =
                (gsReq.useHTTPS || gsReq.secretKey == null) ? "https" : "http";
            string resourceURI = protocol + "://" + gsReq.domain + gsReq.path;

            if (gsReq.secretKey == null) {
                gsReq.SetParam("oauth_token", gsReq.apiKey);
            }
            else // Use apiKey and sign the request using the secretKey
                {
                gsReq.SetParam("apiKey", gsReq.apiKey);

                if (gsReq.useHTTPS) {
                    gsReq.SetParam("secret", gsReq.secretKey);
                }
                else {
                    // Set Timestamp and Nonce
                    long currTime = SigUtils.CurrentTimeMillis() + timeCorrection;
                    string timestamp = (currTime / 1000).ToString();
                    string nonce = DateTime.Now.ToFileTime().ToString() + "_" + (Interlocked.Increment(ref nonceCounter)).ToString();

                    // Set params. DO THIS *BEFORE* CALCULATING THE SIGNATURE 

                    gsReq.SetParam("timestamp", timestamp);
                    gsReq.SetParam("nonce", nonce);

                    // Calculate signature. DO THIS ONLY *AFTER* PUTTING ALL OTHER PARAMS IN DICTIONARY
                    gsReq.dictionaryParams.Remove("sig"); // In case we attempted to send that request already
                    string basestring = SigUtils.CalcOAuth1Basestring(httpMethod, resourceURI, gsReq.dictionaryParams);
                    gsReq.logger.Write("baseString", basestring);
                    string signature = SigUtils.CalcSignature(basestring, gsReq.secretKey);
                    gsReq.SetParam("sig", signature);
                }
            }

            gsReq.logger.Write("serverParams", gsReq.dictionaryParams);
            // Build the query string from the dictionary
            string data = GSRequest.BuildQS(false /*dont add question mark*/, gsReq.dictionaryParams);

            gsReq.logger.Write("URL", resourceURI);
            gsReq.logger.Write("postData", data);

            // Create HttpRequset
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resourceURI);
            request.Timeout = timeout;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = httpMethod;
            request.KeepAlive = EnableConnectionPooling;
            if (EnableConnectionPooling) {
                request.Headers["X-Connection"] = "Keep-Alive";
                request.ServicePoint.ConnectionLimit = MaxConcurrentConnections;
                request.ServicePoint.MaxIdleTime = 180000;
            }
            requestBody = Encoding.UTF8.GetBytes(data);
            request.ContentLength = requestBody.Length;

            return request;
        }


        /// <summary>
        /// Send the actual HTTP/S request
        /// </summary>
        /// <param name="httpMethod">"POST" or "GET"</param>        
        /// <returns></returns>
        private GSResponse SendRequest(string httpMethod, int timeout) {
            byte[] form_body;
            HttpWebRequest request = PrepareHttpRequest(this, httpMethod, timeout, out form_body);

            // Write content to the request.
            using (Stream stream = request.GetRequestStream()) {
                stream.Write(form_body, 0, form_body.Length);
                stream.Close();
            }

            // Get HttpResponse
            using (var webResponse = (HttpWebResponse)request.GetResponse()) {
                logger.Write("server", webResponse.Headers["x-server"]);
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(webResponse.CharacterSet)))
                    return new GSResponse(method, ExtractHeaders(webResponse.Headers), sr.ReadToEnd(), logger);
            }
        }


        // Note: Once we upgrade to .Net 4, use HttpUtility.JavaScriptStringEncode() instead.
        static string EncodeJson(string s) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s) {
                switch (c) {
                    case '\"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\b': sb.Append("\\b");  break;
                    case '\f': sb.Append("\\f");  break;
                    case '\n': sb.Append("\\n");  break;
                    case '\r': sb.Append("\\r");  break;
                    case '\t': sb.Append("\\t");  break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                            sb.AppendFormat("\\u{0:X04}", i);
                        else sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }


        #endregion

    }
}