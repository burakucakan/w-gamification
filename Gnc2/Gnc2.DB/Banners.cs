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
    
    public partial class Banners
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Order { get; set; }
        public Nullable<int> WindowTypeCode { get; set; }
        public int PositionCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
