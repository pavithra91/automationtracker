﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OfficeAutomationdbEntities : DbContext
    {
        public OfficeAutomationdbEntities()
            : base("name=OfficeAutomationdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<OutsourceUser> OutsourceUsers { get; set; }
        public DbSet<PhoneDongle> PhoneDongles { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<TransferAssestHistory> TransferAssestHistories { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<UserAsset> UserAssets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VOIP> VOIPs { get; set; }
    }
}
