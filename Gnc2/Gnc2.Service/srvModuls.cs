using Gnc2.Com.General;
using Gnc2.DB;
using Gnc2.DB.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvModuls : BaseService<Moduls>, IBaseService<Moduls>
    {

        //public List<PanelMenuModel> GetAdminPermissions(Guid AdminId)
        //{
        //    return FillPanelMenuModel(repository.GetAdminModuls(AdminId));
        //}

        Context c=new Context();

        public List<PanelMenuModel> GetPanelMenuList()
        {
            return FillPanelMenuModel(GetListForAdmin().ToList());
        }

        public List<PanelMenuModel> GetAdminPermissions(int AdminId)
        {
            return FillPanelMenuModel(GetAdminModuls(AdminId));
        }

        public IEnumerable<Moduls> GetLiveModuls()
        {
            return c.Moduls.Where(p => p.IsDeleted == false && p.HasLivePage == true)
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }

        public IEnumerable<Moduls> GetListForAdmin()
        {
            return c.Moduls.Where(p => p.IsDeleted == false && p.IsActive == true)
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }

        public IEnumerable<Moduls> GetAdminModuls(int AdminId)
        {
            return c.Moduls.Join(c.AdminAuths.Where(p => p.AdminId == AdminId),
                               m => m.Id,
                               a => a.ModulId,
                               (m, a)
                                  => m)
                        .Where(m => m.IsDeleted == false && m.IsActive == true)
                        .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                        .ThenBy(p => p.Id).ToList();
        }

        private List<PanelMenuModel> FillPanelMenuModel(IEnumerable<Moduls> listModul)
        {
            List<PanelMenuModel> listPanelMenuModel = new List<PanelMenuModel>();

            PanelMenuModel panelMenuModelItem;
            foreach (var item in listModul.ToList())
            {
                panelMenuModelItem = new PanelMenuModel();
                panelMenuModelItem.Id = item.Id;
                panelMenuModelItem.AdminPath = item.AdminPath;
                panelMenuModelItem.Description = item.Description;
                panelMenuModelItem.IsInAdminMenu = item.IsInAdminMenu;
                panelMenuModelItem.IsSubEndItem = item.IsSubEndItem;
                panelMenuModelItem.ParentId = item.ParentId;

                listPanelMenuModel.Add(panelMenuModelItem);
            }

            return listPanelMenuModel;
        }
    }
}
