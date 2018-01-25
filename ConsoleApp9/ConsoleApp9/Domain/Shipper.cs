using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class Shipper
    {
        public Guid? ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Shipper()
        {
            Orders = new List<Order>();
        }
    }

    public class ShipperConfiguration : EntityTypeConfiguration<Shipper>
    {
        public ShipperConfiguration()
        {
            HasKey(p => p.ShipperID);
            Property(p => p.ShipperID).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CompanyName).HasMaxLength(20).IsRequired();
            Property(p => p.Phone).HasMaxLength(20).IsRequired();
 

            HasMany(p => p.Orders)
                .WithOptional(p => p.Shipper)
                .HasForeignKey(p => p.ShipVia);
        }
    }
}