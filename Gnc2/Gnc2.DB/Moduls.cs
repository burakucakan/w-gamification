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
    
    public partial class Moduls
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public string AdminPath { get; set; }
        public bool IsInAdminMenu { get; set; }
        public bool IsSubEndItem { get; set; }
        public bool HasLivePage { get; set; }
        public string LivePageUrl { get; set; }
        public bool IsActive { get; set; }
        public string Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}
