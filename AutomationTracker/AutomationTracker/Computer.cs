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
    
    public partial class Computer
    {
        public int AUOTID { get; set; }
        public Nullable<int> UnitType { get; set; }
        public Nullable<int> ModelType { get; set; }
        public string AssestNo { get; set; }
        public string SerialNo { get; set; }
        public string RAM { get; set; }
        public Nullable<int> OS { get; set; }
        public Nullable<int> OfficeVersion { get; set; }
        public string HDDCapacity { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<System.DateTime> DisposeDate { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<int> Company { get; set; }
        public Nullable<int> ActualAssignee { get; set; }
    
        public virtual Company Company1 { get; set; }
        public virtual ModelType ModelType1 { get; set; }
        public virtual Software Software { get; set; }
        public virtual Software Software1 { get; set; }
        public virtual UnitType UnitType1 { get; set; }
    }
}
