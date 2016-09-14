using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnc2.Admin.Models
{
   
        public class PromoCodeBounded
        {
            public int Id { get; set; }
            public string PromoCodeName { get; set; }
            public string CatalogName { get; set; }
        }

        public class CatalogCategoriesBounded
        {
            public int Id { get; set; }
            public string CategoryName { get; set; }
          
        }

        public class CatalogBounded
        {
            public int Id { get; set; }
            public string Header { get; set; }
            public string CatalogName { get; set; }
            public string CatalogFeautures { get; set; }
            public int CatalogPoint { get; set; }
            public DateTime CatalogStartDate { get; set; }
            public DateTime CatalogEndDate { get; set; }
            public string CatalogImage { get; set; }
            public string CatalogCondition { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
            public string CatalogCategoriesName { get; set; }
        }

        public class PromoCodeTypeBounded
        {
            public int Id { get; set; }
            public string PromoCodeTypeName { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        
        }

        public class CatalogTypeBounded
        {
            public int Id { get; set; }
            public string CatalogTypeName { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }

        }


    
}