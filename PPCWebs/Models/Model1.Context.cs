//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPCWebs.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AD25Team21Entities : DbContext
    {
        public AD25Team21Entities()
            : base("name=AD25Team21Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<FullContract> FullContracts { get; set; }
        public virtual DbSet<InstallmentContract> InstallmentContracts { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyService> PropertyServices { get; set; }
        public virtual DbSet<PropertyStatu> PropertyStatus { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
    }
}
