using Gnc2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvAdminAuths : BaseService<AdminAuths>, IBaseService<AdminAuths>
    {
        public void DestroyByAdminId(int AdminId)
        {
            srvAdminAuths srvAdmins = new Service.srvAdminAuths();
            var entities = srvAdmins.GetByAdminId(AdminId);

           // foreach (var item in entities.ToList())
             //   srvAdmins.Destroy(item);
        }

        public IEnumerable<AdminAuths> GetByAdminId(int AdminId)
        {
            return c.AdminAuths.Where(a => a.AdminId == AdminId).ToList();
        }

        public void MultiSave(List<string> Values, int AdminId)
        {
            List<AdminAuths> AdminAuthEntities = new List<AdminAuths>();
            AdminAuths adminAuthEntity;
            foreach (var item in Values)
            {
                adminAuthEntity = new AdminAuths();
                adminAuthEntity.AdminId = AdminId;
                adminAuthEntity.ModulId = Int32.Parse(item);

                AdminAuthEntities.Add(adminAuthEntity);
            }

            foreach (var item in AdminAuthEntities)
                Save(item);
        }
    }
}
