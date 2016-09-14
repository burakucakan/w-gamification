using Gnc2.Com.General;
using Gnc2.DB;
using Gnc2.DB.Virtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvBanners :  BaseService<Banners>, IBaseService<Banners>
    {
        public IEnumerable<Banners> GetBannerPosition(Gnc2.DB.Virtual.Enums.BannerPosition BannerPosition)
        {
            using (c = new Context())
            {
                return c.Banners.Where(m => m.PositionCode == (int)BannerPosition).ToList();
            }
        }

        public IEnumerable<Banners> GetAllPublishedByType(Enums.BannerPosition BannerPositionCode)
        {
            using (c = new Context())
            {
                return c.Banners.Where(p => p.IsActive == true && p.PositionCode == (int)BannerPositionCode && p.IsDeleted == false)
                    .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                    .ThenBy(p => p.Id).ToList();
            }
        }

        public IEnumerable<Banners> GetAllPublishedByTypeTake(Enums.BannerPosition BannerPositionCode, int Take)
        {
            using (c = new Context())
            {
                return c.Banners.Where(p => p.IsActive == true && p.PositionCode == (int)BannerPositionCode && p.IsDeleted == false)
                    .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                    .ThenBy(p => p.Id).Take(Take).ToList();
            }
        }
    }
}
