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
    
    public partial class Company
    {
        public Company()
        {
            this.Computers = new HashSet<Computer>();
            this.PhoneDongles = new HashSet<PhoneDongle>();
            this.VOIPs = new HashSet<VOIP>();
            this.Users = new HashSet<User>();
        }
    
        public int CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
    
        public virtual ICollection<Computer> Computers { get; set; }
        public virtual ICollection<PhoneDongle> PhoneDongles { get; set; }
        public virtual ICollection<VOIP> VOIPs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}