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
    
    public partial class CatalogVarieties
    {
        public int Id { get; set; }
        public Nullable<int> CatalogId { get; set; }
        public string VarietyName { get; set; }
        public Nullable<int> VarietyStock { get; set; }
        public string VarietyImageUrl { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual Catalogs Catalogs { get; set; }
    }
}
