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
    
    public partial class CatalogType
    {
        public CatalogType()
        {
            this.Catalogs = new HashSet<Catalogs>();
        }
    
        public int Id { get; set; }
        public string CatalogTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<Catalogs> Catalogs { get; set; }
    }
}
