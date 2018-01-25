using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class Employee
    {
        public Guid? EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
        public string PhotoPath { get; set; }
        public byte[] RowVersion { get; set; }
        public Guid? ReportsTo { get; set; }
        public virtual Employee ReportsToEmployee { get; set; }
        public virtual ICollection<Employee> Slaves { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Territory> Territories { get; set; }

        public Employee()
        {
            Slaves = new List<Employee>();
            Orders = new List<Order>();
            Territories = new List<Territory>();
        }
    }

    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.EmployeeID);
            Property(p => p.EmployeeID).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.LastName).HasMaxLength(20).IsRequired();
            Property(p => p.FirstName).HasMaxLength(20).IsRequired();
            Property(p => p.Title).HasMaxLength(20).IsRequired();
            Property(p => p.TitleOfCourtesy).HasMaxLength(20).IsRequired();
            Property(p => p.BirthDate).IsRequired();
            Property(p => p.HireDate).IsOptional();
            Property(p => p.Address).HasMaxLength(20).IsRequired();
            Property(p => p.City).HasMaxLength(20).IsRequired();
            Property(p => p.Region).HasMaxLength(20).IsRequired();
            Property(p => p.PostalCode).HasMaxLength(20).IsRequired();
            Property(p => p.Country).HasMaxLength(20).IsRequired();
            Property(p => p.HomePhone).HasMaxLength(20).IsRequired();
            Property(p => p.Extension).HasMaxLength(20).IsRequired();
            Property(p => p.Photo).HasMaxLength(20).IsRequired();
            Property(p => p.Notes).HasMaxLength(20).IsRequired();
            Property(p => p.PhotoPath).HasMaxLength(20).IsRequired();

            HasMany(p => p.Orders)
                .WithOptional(p => p.Employee)
                .HasForeignKey(p => p.EmployeeID);

            HasMany(p => p.Slaves)
                .WithOptional(p => p.ReportsToEmployee)
                .HasForeignKey(p => p.ReportsTo);

            Property(p => p.RowVersion).IsRowVersion();

            HasMany(p => p.Territories).WithMany(p => p.Employeis).Map(m =>
            {
                m.MapLeftKey("EmployeeID");
                m.MapRightKey("TerritoryID");
                m.ToTable("EmployeeTerritoryTable");
            });

        }
    }
}