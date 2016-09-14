using Gnc2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnc2.DB.Virtual;

namespace Gnc2.Service
{
    public class srvCatalogs : BaseService<Catalogs>, IBaseService<Catalogs>
    {

        public IEnumerable<Catalogs> GetCategories()
        {
            return c.Catalogs.Where(p => p.IsDeleted == false).ToList();
        }

        public IEnumerable<CatalogCategories> GetCatalogCategories()
        {   
                Context c = new Context();

                return c.CatalogCategories.Where(p => p.IsDeleted == false).ToList();
        }
       
        public IEnumerable<CatalogType> GetModulTypes()
        {
            Context c = new Context();

            return c.CatalogType.Where(p => p.IsDeleted == false).ToList();
        }

       

        //En Son Eklenen  100 Ürün
        public IEnumerable<Catalogs> GetToLast100Catalog(Enums.CatalogOrderType CatalogOrderType)
        {
            return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderByDescending(p => p.Id).Take(2);
        }


        //En Yüksek Puanlı  100 Ürün
        public IEnumerable<Catalogs> GetToLast100TopPoint(Enums.CatalogOrderType CatalogOrderType)
        {
            return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderByDescending(p => p.CatalogPoint).Take(2);
        }

        //En Yüksek Puanlı  100 Ürün
        public IEnumerable<Catalogs> GetToLast100DownPoint(Enums.CatalogOrderType CatalogOrderType)
        {
            return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CatalogPoint).Take(2);
        }


        // Süresi geçmiş ürünler
        public IEnumerable<Catalogs> GetToEndDateCatalog(Enums.CatalogOrderType CatalogOrderType)
        {

            DateTime today = DateTime.Now.AddDays(-1);

            var result = (from a in c.Catalogs where (a.CatalogEndDate < today) select a).Where(p => p.IsActive == true && p.IsDeleted == false).ToList();

            return result;
        }

     
        //Stoğu En Fazla Olan 100 Ürün
        //public IEnumerable<Catalogs> GetAllTopStock(Enums.CatalogOrderType CatalogOrderType)
        //{

        //    IList<CatalogVarieties> query = (from a in c.CatalogVarieties.Include("CatalogCategories") select a).OrderBy(p => p.VarietyStock).ToList();

        //    return query;
           
        //}

        //Stoğu Tükenen Ürünler
        //public IEnumerable<Catalogs> GetAllPublishedByType(Enums.CatalogOrderType CatalogOrderType)
        //{
        //    return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CatalogPoint).ToList();
        //}

        //Kullanımda Olmayan Ürünler
        public IEnumerable<Catalogs> GetAllUnUseCatalog(Enums.CatalogOrderType CatalogOrderType)
        {
            return c.Catalogs.Where(p => p.IsActive == false && p.IsDeleted == false).OrderBy(p => p.CatalogPoint).ToList();
        }


        //En Fazla Satılan Ürünler
        //public IEnumerable<Catalogs> GetAllPublishedByType(Enums.CatalogOrderType CatalogOrderType)
        //{
        //    return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CatalogPoint).ToList();
        //}



        //Puana Göre Sıralama
        public IEnumerable<Catalogs> GetAllPoint(Enums.CatalogOrderType CatalogOrderPoint)
        {
            return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CatalogPoint).ToList();
        }

        //Alfabetik SıralamaA-Z
        public IEnumerable<Catalogs> GetAllGetAllNameAZ(Enums.CatalogOrderType AlfabetikSiralamaAZ)
        {
            return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderBy(p => p.CatalogName).ToList();
        }

        //Alfabetik SıralamaZ-A
        public IEnumerable<Catalogs> GetAllGetAllNameZA(Enums.CatalogOrderType AlfabetikSiralamaZA)
        {
            return c.Catalogs.Where(p => p.IsActive == true && p.IsDeleted == false).OrderByDescending(p => p.CatalogName).ToList();
        }

    }
}