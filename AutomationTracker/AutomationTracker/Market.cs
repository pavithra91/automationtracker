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
    
    public partial class Market
    {
        public Market()
        {
            this.Users = new HashSet<User>();
        }
    
        public int MarketID { get; set; }
        public string MarketName { get; set; }
        public Nullable<int> CompanyID { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
