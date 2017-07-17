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
    
    public partial class ModelType
    {
        public ModelType()
        {
            this.Computers = new HashSet<Computer>();
            this.PhoneDongles = new HashSet<PhoneDongle>();
            this.VOIPs = new HashSet<VOIP>();
        }
    
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public Nullable<int> UnitType { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual ICollection<Computer> Computers { get; set; }
        public virtual UnitType UnitType1 { get; set; }
        public virtual ICollection<PhoneDongle> PhoneDongles { get; set; }
        public virtual ICollection<VOIP> VOIPs { get; set; }
    }
}
