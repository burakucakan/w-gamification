//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wLog.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transactions
    {
        public System.Guid Id { get; set; }
        public string AppName { get; set; }
        public string Operation { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string InnerDetail { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FacebookId { get; set; }
        public string Msisdn { get; set; }
        public string IP { get; set; }
        public string SessionId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string ReturnCallerId { get; set; }
    }
}
