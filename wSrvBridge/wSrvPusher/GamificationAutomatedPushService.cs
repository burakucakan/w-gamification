using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using System.Timers;
using wSrvBridge.DB;
using wSrvBridge.Logger;
using wSrvBridge.Lib;

namespace wSrvPusher
{
    public partial class GamificationAutomatedPushService : ServiceBase
    {
        private Timer _jobTimer;
        private readonly int _pushInterval;
        private static DateTime _timerStart;

        public GamificationAutomatedPushService()
        {
            InitializeComponent();

            _pushInterval = ServiceConfigurationManager.PushInterval;
            _jobTimer = new Timer();
            _jobTimer.Interval = 60000; //Invoke every 1 minute
            _jobTimer.Elapsed += _jobTimer_Elapsed;
        }

        public void StartService()
        {
            OnStart(null);
        }

        public void StopService()
        {
            OnStop();
        }

        public void InitiateGamificationPush()
        {
            //Stored procedure cagrisi ve ardindan Gigya push islemleri
            try
            {
                using (var context = new srvBridgeDbContainer(ServiceConfigurationManager.ActiveDbConnection))
                {
                    List<uspGetMeteringTransactions_Result> meteringResults = context.GetMeteringData();

                    var pushData = (from m in meteringResults
                                    join o in context.QDBOfferList on m.OFFER_ID equals o.OfferId
                                    where o.FilterStatus == true
                                    select new
                                    {
                                        Msisdn = m.BSSOSS_MSISDN,
                                        OfferId = m.OFFER_ID,
                                        OfferName = o.OfferUniqueName
                                    }).ToList();


                    string msisdns = string.Join(",", meteringResults.Select(f => f.BSSOSS_MSISDN));
                    string logResult = String.Format("Metering data count {0}, MSISDN List: {1}", meteringResults.Count, msisdns);

                    var log = Logger.CreateNotificationLog(LogLevel.Service, "Service Timed Invoke");
                    log.Naming = WebServiceNaming.wsWindowsPushService.ToString();
                    log.Operation = "TimerInvoke";
                    log.ResponseData = logResult;
                    Logger.Save(log);
                }
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Service, exc);
                log.Naming = WebServiceNaming.wsWindowsPushService.ToString();
                log.Operation = "TimerInvoke";
                Logger.Save(log);
            }
        }

        private void _jobTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime signalTime = e.SignalTime;
            
            //Event'in tetiklendigi saat ile, sayacin basladigi saat arasindaki dakika farkini alip
            //_pushInterval ile karsilastirarak istedigimiz aralikta tetikleme saglayabiliriz.
            TimeSpan interval = signalTime.Subtract(_timerStart);
            if (interval.Minutes >= _pushInterval)
            {
                InitiateGamificationPush();

                _timerStart = signalTime;
            }
        }

        protected override void OnStart(string[] args)
        {
            //Servis basladiginda log atalim.
            var log = Logger.CreateNotificationLog(LogLevel.Service, "Push Service Started");
            log.Naming = WebServiceNaming.wsWindowsPushService.ToString();
            log.Operation = "OnStart";
            Logger.Save(log);

            _jobTimer.Enabled = true;
            _timerStart = DateTime.Now;

        }

        protected override void OnStop()
        {
            var log = Logger.CreateNotificationLog(LogLevel.Service, "Push Service Stopped");
            log.Naming = WebServiceNaming.wsWindowsPushService.ToString();
            log.Operation = "OnStop";
            Logger.Save(log);

            _jobTimer.Stop();
        }
    }
}
