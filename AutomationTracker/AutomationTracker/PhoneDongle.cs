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
    
    public partial class PhoneDongle
    {
        public int AUOTID { get; set; }
        public Nullable<int> UnitType { get; set; }
        public Nullable<int> ModelType { get; set; }
        public Nullable<int> Provider { get; set; }
        public string AssestNo { get; set; }
        public string SerialNo { get; set; }
        public Nullable<int> ConnectionNo { get; set; }
        public Nullable<int> SimNo { get; set; }
        public Nullable<int> EMEINo1 { get; set; }
        public Nullable<int> EMEINo2 { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<int> Company { get; set; }
        public Nullable<int> ActualAssignee { get; set; }
        public Nullable<System.DateTime> DisposeDate { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
    
        public virtual Company Company1 { get; set; }
        public virtual ModelType ModelType1 { get; set; }
        public virtual Provider Provider1 { get; set; }
        public virtual UnitType UnitType1 { get; set; }
    }
}
