using ConsoleApp9.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Territory> Territory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ShipperConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new TerritoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext() : base("name=ConnectionString")
        {

        }
    }
}
