using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Gnc2.Controllers
{
    public class DashboardController : BaseController
    {
        //
        // GET: /Dashboard/

        public PartialViewResult Default()
        {
            if (session.IsLogin)
            {
                return PartialView("Default_AfterLogin");
            }
            else
            {
                return PartialView();
            }
        }

        public PartialViewResult Default_AfterLogin()
        {
            return PartialView();
        }

        public PartialViewResult Summary()
        {
            return PartialView();
        }

        public PartialViewResult LoginSummary()
        {
            ViewBag.Month = DateTime.Now.Month;
            ViewBag.Day = DateTime.Now.Day;
            return PartialView();
        }

        public JsonResult GetAllHowScore(int? Take, int? Month, int? Day)
        {
            List<HowScoreModel> list = new List<HowScoreModel>();
            HowScoreModel model;

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "Kahve Dünyası";
            model.DateTime = DateTime.Now;
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+75";
            model.AdvantageName = "SMS Paketi";
            model.DateTime = DateTime.Now;
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "1 Alana 1 Bedava";
            model.DateTime = DateTime.Now;
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "Kahve Dünyası";
            model.DateTime = DateTime.Now;
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "Kahve Dünyası";
            model.DateTime = Convert.ToDateTime("10.09.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+75";
            model.AdvantageName = "SMS Paketi";
            model.DateTime = Convert.ToDateTime("10.09.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "1 Alana 1 Bedava";
            model.DateTime = Convert.ToDateTime("10.09.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "Kahve Dünyası";
            model.DateTime = Convert.ToDateTime("10.09.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "Kahve Dünyası";
            model.DateTime = Convert.ToDateTime("10.08.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+75";
            model.AdvantageName = "SMS Paketi";
            model.DateTime = Convert.ToDateTime("10.07.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "1 Alana 1 Bedava";
            model.DateTime = Convert.ToDateTime("10.07.2013 15:20");
            list.Add(model);

            model = new HowScoreModel();
            model.Point = "+150";
            model.AdvantageName = "Kahve Dünyası";
            model.DateTime = Convert.ToDateTime("10.07.2013 15:20");
            list.Add(model);

            if (Month != null && Day != null)
            {
                if (Take != 0)
                    return Json(list.ToList().Where(l => l.DateTime.Day == Day && l.DateTime.Month == Month && l.DateTime.Year == DateTime.Now.Year).Take(Convert.ToInt32(Take)), JsonRequestBehavior.AllowGet);
                else
                    return Json(list.ToList().Where(l => l.DateTime.Day == Day && l.DateTime.Month == Month && l.DateTime.Year == DateTime.Now.Year), JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (Take != 0)
                    return Json(list.Where(l => l.DateTime.Year == DateTime.Now.Year).ToList().Take(Convert.ToInt32(Take)), JsonRequestBehavior.AllowGet);
                else
                    return Json(list.Where(l => l.DateTime.Year == DateTime.Now.Year).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetLast5Month()
        {
            List<MonthModel> list = new List<MonthModel>();
            MonthModel model;

            int Month = DateTime.Now.Month;
            DateTime now = DateTime.Now;
            for (int i = Month-3; i < Month+1; i++)
            {
                now = now.AddMonths(i);

                model = new MonthModel();
                model.Id = i;
                model.Name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                list.Add(model);
            }

            return Json(list.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllMonth()
        {
            List<MonthModel> list = new List<MonthModel>();
            MonthModel model;

            DateTime now = DateTime.Now;
            for (int i = 1; i < 13; i++)
            {
                now = now.AddMonths(i);

                model = new MonthModel();
                model.Id = i;
                model.Name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                list.Add(model);
            }
            return Json(list.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllMonthDays(int Month)
        {
            List<DayModel> list = new List<DayModel>();
            DayModel model;

            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, Month); i++)
            {
                string DayName = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)new DateTime(DateTime.Now.Year, Month, i).DayOfWeek];
                model = new DayModel();
                model.Id = i;
                model.Month = Month;
                model.Name = DayName;

                var result = GetAllHowScore(0, Month, i) as JsonResult;
                IEnumerable<HowScoreModel> output = result.Data as IEnumerable<HowScoreModel>;
                List<HowScoreModel> l = new List<HowScoreModel>(output);

                if (l.Count > 0)
                    model.Disable = false;
                else
                    model.Disable = true;
                list.Add(model);
            }

            return Json(list.ToList(), JsonRequestBehavior.AllowGet);
        }

    }

    public class HowScoreModel {
        public string Point { get; set; }
        public string AdvantageName { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class MonthModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DayModel
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
    }
}
