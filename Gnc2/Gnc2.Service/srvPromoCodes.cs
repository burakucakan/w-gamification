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
    public class srvPromoCodes : BaseService<PromoCodes>, IBaseService<PromoCodes>
    {
        public IEnumerable<PromoCodeTypes> GetPromoCodeType()
        {
             return c.PromoCodeTypes.Where(p => p.IsDeleted == false).ToList();
        }

        public int SaveMultipleCodes(List<int> Codes, int CatalogId, int PromoCodeTypeId)
        {
            foreach (int code in Codes)
            {
                PromoCodes pc = new PromoCodes();
                pc.CatalogsId = CatalogId;
                pc.IsUsed = false;
                pc.PromoCodeName = code.ToString();
                pc.PromoCodeTypeId = PromoCodeTypeId;                
                c.PromoCodes.Add(pc);
            }
            if (c.SaveChanges() > 0)
                return Codes.Count;
            else return 0;
        }
    }
}
