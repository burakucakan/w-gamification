using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(IBanners))]
    public partial class Banners : BaseEntity<Banners>, IBaseEntity<Banners>
    {
        Context c;

        public IEnumerable<Banners> GetBannerByPositionCode(Virtual.Enums.BannerPosition Position)
        {
            
            using (c = new Context())
            {
                return c.Banners.Where(m => m.PositionCode == (int)Position).ToList();
            }
        }
    }
}
