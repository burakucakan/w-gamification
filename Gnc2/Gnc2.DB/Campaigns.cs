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
    
    public partial class Campaigns
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string ExternalUrl { get; set; }
        public bool IsUserCampaigns { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
