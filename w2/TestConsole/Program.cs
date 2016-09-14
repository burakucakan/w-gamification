using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gigya.Socialize.SDK;
using w2.Service.Gigya.GM;
using TestConsole.PostTransactions;

namespace TestConsole
{
    class Program
    {
        const string ApiKey = "3_4bOfh1SkOiFnuKtGq5zP1vuZJ4kzCWAjI9nofsqKDB2IhJaoj3_Ds34TO3UuOrL4";
        const string SecretKey = "85dQctWxv4zF48qIb64RQmWITzl010Zkbv/x8efmSWA=";
        const bool UseHttps = false;

        private static int nonceCounter = 0;

        static void Main(string[] args)
        {
            //Sms.SmsQueryClient srv = new Sms.SmsQueryClient();
            //Sms.SmsQueryRequest req = new Sms.SmsQueryRequest();
            //req.Key = "A4B38CCC-FDC4-4413-B6F2-085806B327E5";
            //req.Msisdn = "5374119411";
            //Sms.SmsQueryResponse response = srv.GetUserTotalPoints(req);

            

            GsmTransaction();
                      
            Console.ReadLine();

        }

        private static void RestGetUserInfo()
        {
            string nonce = DateTime.Now.ToFileTime().ToString() + "_" + (Interlocked.Increment(ref nonceCounter)).ToString();
            string timestamp = DateTime.UtcNow.ToString();
            //string reqUrl = "https://socialize.gigya.com/socialize.getUserInfo?" +
            //                "apiKey=" + ApiKey +
            //                "&secret=" + SecretKey +
            //    //"&timestamp=" + timestamp +
            //    //"&secret
            //                "&UID=4ed29697-13fa-47e5-b0c7-667948d5cb6b&cid=Gnc2&format=json";

            string reqUrl = "https://socialize.gigya.com/socialize.getUserInfo";

            using (var client = new WebClient())
            {
                
                var json = client.DownloadString(reqUrl);
                Console.WriteLine(json);
            }
        }

        private static void Login()
        {
            string Method = "socialize.notifyLogin";

            var strGuid = Guid.NewGuid().ToString();

            GSRequest Request = new GSRequest(ApiKey, SecretKey, Method, UseHttps);

            Request.SetParam("siteUID", strGuid);
            Request.SetParam("cid", "Gnc2");
            Request.SetParam("sessionExpiration", 0);
            Request.SetParam("newUser", true);

            GSResponse response = Request.Send();

            if (response.GetErrorCode() == 0)
            {
                Console.WriteLine("success GUID: " + strGuid);

                Console.WriteLine("Response Log: " + response.GetLog());
            }
            else
                Console.WriteLine("Got error on setStatus: {0}", response.GetLog());
        }

        private static void GetUserInfo()
        { 
            string Method = "socialize.getUserInfo";

            GSRequest Request = new GSRequest(ApiKey, SecretKey, Method, UseHttps);

            Request.SetParam("UID", "4ed29697-13fa-47e5-b0c7-667948d5cb6b");
            Request.SetParam("cid", "Gnc2");
            Request.SetParam("format", "json");

            GSResponse response = Request.Send();

            if (response.GetErrorCode() == 0)
            {
                Console.WriteLine("success GUID: " + response.GetResponseText());

                Console.WriteLine("Response Log: " + response.GetLog());
            }
            else
                Console.WriteLine("Got error on setStatus: {0}", response.GetLog());
        }

        private static void TestSdkGm()
        {
            //var req = new LeaderboardRequest();
            //req.Challenge = "_default";
            //req.TotalCount = 5;

            //var g = new GigyaRequest(req);
            //var r = g.Send<LeaderboardResponse>();

            //Console.WriteLine(r.Users.Length);

        }

        private static void Testw2()
        {
            //var req = new w2.Service.Gigya.GM.GetTopUsers();
            //req.Challenge = "_default";
            //req.TotalCount = 5;

            //var g = new w2.Service.Gigya.GigyaRequest(req);
            //var r = g.Send<w2.Service.Gigya.GM.GetTopUsersResponse>();


            //Console.WriteLine(r.Users.Length);
        }

        private static void TestGetUserInfo()
        {
            //var req = new w2.Service.Gigya.Socialize.GetUserInfo();

            //req.CID = w2.Com.Params.Context.Gnc2.ToString();

            //var g = new w2.Service.Gigya.GigyaRequest(req);
            //var r = g.Send<w2.Service.Gigya.GM.GetTopUsersResponse>();


            //Console.WriteLine(r.Users.Length);
        }      
        static void PosTransactions()
        {
            PostTransactions.PosTransactionsClient pos = new PosTransactionsClient();
            PostTransactions.PosTransactionModel model = new PosTransactionModel();
            model.Amount = "1";
            model.Campaign = "a";
            model.CampaignType = "1";
            model.Income = "as";
            model.JoinDate = DateTime.Now;
            model.Key = "A4B38CCC-FDC4-4413-B6F2-085806B327E5";
            model.Location = 54;
            model.Msisdn = "5374119411";
            model.TrId = "asdf";
            PosTransactionResponse resp = pos.SendAction(model);
            Console.WriteLine(resp.ErrorCode);
        }

        static void GsmTransaction()
        {
            GsmTrans.GsmTransactionClient srv = new GsmTrans.GsmTransactionClient();
            GsmTrans.GsmTransactionMultipleRequest reqList = new GsmTrans.GsmTransactionMultipleRequest();
            GsmTrans.GsmTransactionResponse[] response = new GsmTrans.GsmTransactionResponse[20];
            GsmTrans.GsmTransactionRequest[] requestlist = new GsmTrans.GsmTransactionRequest[20];

            reqList.Key = "A4B38CCC-FDC4-4413-B6F2-085806B327E5";
            for (int i = 1; i <= 20; i++)
            {
                GsmTrans.GsmTransactionRequest req = new GsmTrans.GsmTransactionRequest();
                req.ActionName = "Test" + i;
                req.Msisdn = (i * 10).ToString();
                req.TransactionId = i;
                req.IsSendSms = true;
                requestlist[i - 1] = req;
            }
            reqList.Actions = requestlist;
            response = srv.SendMultipleAction(reqList);

            foreach (GsmTrans.GsmTransactionResponse item in response)
            {
                Console.WriteLine(item.CallId);
                Console.WriteLine(item.ErrorCode);
                Console.WriteLine(item.TransactionId);
                Console.WriteLine("---");
            }
        }
    }
}