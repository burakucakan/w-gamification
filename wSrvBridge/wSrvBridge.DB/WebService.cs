//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wSrvBridge.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebService
    {
        public int Id { get; set; }
        public int PlatformType { get; set; }
        public string Naming { get; set; }
        public string ConfigName { get; set; }
        public string ServiceUrl { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
    }
}
