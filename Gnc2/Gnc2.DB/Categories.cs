//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gnc2.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.PromoCodes = new HashSet<PromoCodes>();
        }
    
        public int Id { get; set; }
        public string CatalogName { get; set; }
        public int CatalogPoint { get; set; }
        public string CatalogFeatures { get; set; }
        public System.DateTime CatalogStartDate { get; set; }
        public System.DateTime CatalogEndDate { get; set; }
        public string CatalogImage { get; set; }
        public string CatalogCondition { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CatalogCategoriesId { get; set; }
        public int ModuleTypeId { get; set; }
    
        public virtual CatalogCategories CatalogCategories { get; set; }
        public virtual ModulTypes ModulTypes { get; set; }
        public virtual ICollection<PromoCodes> PromoCodes { get; set; }
    }
}