using Gnc2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvAdmins : BaseService<Admins>, IBaseService<Admins>
    {
        public Admins GetAuth(string Username, string Password)
        {
            using (c = new Context())
            {
                return c.Admins.Where(m => m.Username == Username && m.Password == Password).FirstOrDefault();
            }
        }

        public void SaveWithPermission(Admins Admin, srvAdminAuths adminAuthService, List<string> RequestValues)
        {
            Save(Admin);

            try
            {
                adminAuthService.DestroyByAdminId(Admin.Id);

                if (RequestValues != null)
                    adminAuthService.MultiSave(RequestValues, Admin.Id);
            }
            catch (Exception) { }

            //repository.Commit();
        }

        

    }
}
