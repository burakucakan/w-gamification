using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wSrvBridge.TestConsole.PermissionServiceReference;
using wSrvBridge.TestConsole.SmsServiceReference;
using wSrvBridge.TestConsole.ClubMembershipServiceReference;
using wSrvBridge.TestConsole.GsmTransactionServiceReference;
using wSrvPusher;

namespace wSrvBridge.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var cn = new GamificationAutomatedPushService();
            cn.InitiateGamificationPush();

            Console.ReadKey();
        }

        private void BeginWebServiceTests()
        {
            //Izin sorgulama servisi remote test
            using (var permissionServiceClient = new PermissionQueryServiceClient())
            {
                PermissionQueryResult permissionResult = permissionServiceClient.GetServicePermission("5323308474");
                if (permissionResult.Success == true)
                {
                    Console.WriteLine("Veri isleme izni sorgusu:");
                    Console.WriteLine(permissionResult.Permission);
                    Console.WriteLine(permissionResult.Message);
                }
                else
                {
                    Console.WriteLine("Veri isleme izni sorgusu basarisiz:");
                    Console.WriteLine(permissionResult.Permission);
                    Console.WriteLine(permissionResult.Message);
                }
            }

            //Sms gonder servisi remote test
            using (var smsServiceClient = new SmsServiceClient())
            {
                SmsServiceResult smsResult = smsServiceClient.SendSms("1", "5323308474", "Penna SMS Test");
                if (smsResult.Success == true)
                {
                    Console.WriteLine("SMS gonderim servisi:");
                    Console.WriteLine(smsResult.Message);
                }
                else
                {
                    Console.WriteLine("SMS gonderim basarisiz:");
                    Console.WriteLine(smsResult.Message);
                }
            }

            //Bulk klüp sorgulama servisi remote test
            using (var clubMembershipServiceClient = new ClubMembershipQueryServiceClient())
            {
                string[] msisdnList = new string[5] { "5323308474", "5321258280", "5326363280", "5323358168", "5358881131" };
                ClubMembershipQueryResult clubResult = clubMembershipServiceClient.BulkClubSearch(msisdnList, 1);

                if (clubResult.Success == true)
                {
                    Console.WriteLine("Asagidaki numaralar gnctrkcll üyesi:");
                    foreach (var msisdn in clubResult.MembersMsisdnList)
                    {
                        Console.WriteLine(msisdn);
                    }
                }
                else
                {
                    Console.WriteLine("Klüp sorgulama servisi basarisiz");
                }
            }
        }
    }
}
