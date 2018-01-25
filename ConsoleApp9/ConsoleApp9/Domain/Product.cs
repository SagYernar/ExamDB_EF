using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid? SupplierID { get; set; }
        public Guid? CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        public string Discontinued { get; set; }

        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.ProductID);
            Property(p => p.ProductID).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.ProductName).HasMaxLength(20).IsRequired();
            Property(p => p.QuantityPerUnit).IsRequired();
            Property(p => p.UnitPrice).IsRequired();
            Property(p => p.UnitsInStock).IsRequired();
            Property(p => p.UnitsOnOrder).IsRequired();
            Property(p => p.ReorderLevel).HasMaxLength(20).IsRequired();
            Property(p => p.Discontinued).HasMaxLength(20).IsRequired();

            HasMany(p => p.OrderDetails)
                .WithRequired(p => p.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}