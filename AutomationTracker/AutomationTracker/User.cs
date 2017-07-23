//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutomationTracker
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public Nullable<int> Company { get; set; }
        public Nullable<int> Market { get; set; }
        public string PANo { get; set; }
        public string SAPNo { get; set; }
        public string NIC { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<bool> IsUserOutSource { get; set; }
    
        public virtual Company Company1 { get; set; }
        public virtual Market Market1 { get; set; }
    }
}
