using Gnc2.DB;
using Gnc2.DB.Virtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvUsers : BaseService<Users>, IBaseService<Users>
    {

        DateTime toDay = DateTime.Today; 

        public Users GetByMsisdn(string Msisdn)
        {
            using (c = new Context())
            {
                return c.Users.Where(m => m.Msisdn == Msisdn).FirstOrDefault();
            }
        }

        public Users GetByFbId(string FbId)
        {
            using (c = new Context())
            {
                return c.Users.Where(m => m.FbId == FbId).FirstOrDefault();
            }
        }

        public Users GetByEmail(string Email)
        {
            using (c = new Context())
            {
                return c.Users.Where(m => m.Email == Email).FirstOrDefault();
            }
        }

        public IEnumerable<Users> GetGender(Gnc2.DB.Virtual.Enums.Genders GetGender)
        {
            using (c = new Context())
            {
                return c.Users.Where(m => m.Gender == (int)GetGender).ToList();
                
            }
        }

        //Register Sorgulamaları - - - - - - - - - - - - - - - - - -

       
        public IEnumerable<Users> GetToDayRecord(Enums.UserOrderType GetToDayRecord)
        { 
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

            var result = (from a in c.Users where (a.CreateDate >= toDay && a.CreateDate <= endDateTime) select a).Where(p => p.IsActive == true && p.IsDeleted == false).ToList();
            return result;
          
        }

        public IEnumerable<Users> GetToThisWeekRecord(Enums.UserOrderType GetToThisWeekRecord)
        {
           
            DateTime week;

            week =  toDay.AddDays(-7);

            var result = (from a in c.Users where (a.CreateDate >= toDay && a.CreateDate <= week) select a).Where(p => p.IsActive == true && p.IsDeleted == false).ToList();
           
            return result;
        }

        public IEnumerable<Users> GetToThisMonthRecord(Enums.UserOrderType GetToThisMonthRecord)
        {
            DateTime month;

            month = toDay.AddDays(-30);

            var result = (from a in c.Users where (a.CreateDate >= toDay && a.CreateDate <= month) select a).Where(p => p.IsActive == true && p.IsDeleted == false).ToList();

            return result;
        }


        public IEnumerable<Users> GetToLastFacebookRecord(Enums.UserOrderType GetToLastFacebookRecord)
        {

            return c.Users.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CreateDate == toDay).ToList();
        }


        //Login Sorgulamaları - - - - - - - - - - - - - - - - - -

        public IEnumerable<Users> GetToDayLogin(Enums.UserOrderType GetToDayLogin)
        {
            return c.Users.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CreateDate == toDay).ToList();
        }

        public IEnumerable<Users> GetToLastWeekLogin(Enums.UserOrderType GetToLastWeekLogin)
        {
            return c.Users.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CreateDate == toDay).ToList();
        }

        public IEnumerable<Users> GetToLastMonthLogin()
        {
            return c.Users.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CreateDate == toDay).ToList();
        }

        public IEnumerable<Users> GetToLastFacebookLogin()
        {
            return c.Users.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CreateDate == toDay).ToList();
        }

        public IEnumerable<Users> GetDisableUser(Enums.UserOrderType DisableUser)
        {
            return c.Users.Where(p => p.IsActive == false).ToList();
        }


        public void UpdateLastLogin(Users u)
        {
            u.LoginDate = DateTime.Now;
            Save(u);
        }
    }
}
