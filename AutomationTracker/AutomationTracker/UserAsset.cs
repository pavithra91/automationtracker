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
    
    public partial class UserAsset
    {
        public int AUTOID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> ActualAssignee { get; set; }
        public string PANo { get; set; }
        public Nullable<int> Category { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Category Category1 { get; set; }
    }
}
