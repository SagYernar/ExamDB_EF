﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class Supplier
    {
        public Guid? SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }

    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            HasKey(p => p.SupplierID);
            Property(p => p.SupplierID).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CompanyName).HasMaxLength(30).IsRequired();
            Property(p => p.ContactName).HasMaxLength(30).IsRequired();
            Property(p => p.ContactTitle).HasMaxLength(20).IsRequired();
            Property(p => p.Address).HasMaxLength(50).IsRequired();
            Property(p => p.City).HasMaxLength(20).IsRequired();
            Property(p => p.Region).HasMaxLength(20).IsRequired();
            Property(p => p.PostalCode).HasMaxLength(20).IsRequired();
            Property(p => p.Country).HasMaxLength(20).IsRequired();
            Property(p => p.Phone).HasMaxLength(20).IsRequired();
            Property(p => p.Fax).HasMaxLength(20).IsRequired();
            Property(p => p.HomePage).HasMaxLength(20).IsRequired();

            HasMany(p => p.Products)
                .WithOptional(p => p.Supplier)
                .HasForeignKey(p => p.SupplierID);
        }
    }
}