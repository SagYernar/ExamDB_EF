using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }

    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.UnitPrice).IsRequired();
            Property(p => p.Quantity).IsRequired();
            Property(p => p.Discount).IsRequired();
        }
    }
}