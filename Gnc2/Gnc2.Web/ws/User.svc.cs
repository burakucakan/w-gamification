using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Gnc2.Controllers;
using LIB;

namespace Gnc2.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Login" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Login.svc or Login.svc.cs at the Solution Explorer and start debugging.

    public class User : BaseWS, IUser
    {
        
        public LoginResponse Login(LoginRequest request)
        {
            Compability(ref request);
            LoginResponse returnResponse = new LoginResponse();
            if (request == null)
            {
                returnResponse.Status = false;
                return returnResponse;
            }
            /* giriş işlemleri */

            CookieHelper cookie= new CookieHelper();
            cookie.Write("gnc2gecis", 600, request.Msisdn);
            

            /*UserLogin userLogin=new UserLogin();
            userLogin.SessionCreate(request.Msisdn);
            */

    //        HttpWebRequest httpWReq =
    //(HttpWebRequest)WebRequest.Create("http://localhost:18132/Login/SessionCreate");

    //        ASCIIEncoding encoding = new ASCIIEncoding();
    //        string postData = "Msisdn=" + request.Msisdn;
    //        byte[] data = encoding.GetBytes(postData);

    //        httpWReq.Method = "POST";
    //        httpWReq.ContentType = "application/x-www-form-urlencoded";
    //        httpWReq.ContentLength = data.Length;

    //        using (Stream stream = httpWReq.GetRequestStream())
    //        {
    //            stream.Write(data, 0, data.Length);
    //        }

    //        HttpWebResponse httpResponse = (HttpWebResponse)httpWReq.GetResponse();

    //        string responseString = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();


            /* giriş işlemleri */
            returnResponse.Status = true;
            return returnResponse;
        }
        public void Login()
        {
            PrintJson(Login(null));
        }
        public LogoutResponse Logout(LogoutRequest request)
        {
            Compability(ref request);
            LogoutResponse returnResponse = new LogoutResponse();
            if (request == null)
            {
                returnResponse.Status = false;
                return returnResponse;
            }
            /* çıkış işlemleri */

            /* çıkış işlemleri */
            returnResponse.Status = true;
            return returnResponse;
        }
        public void Logout()
        {
            PrintJson(Logout(null));
        }

    }
}
