using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class Region
    {
        public Guid RegionID { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }

        public Region()
        {
            Territories = new List<Territory>();
        }

    }

    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            HasKey(p => p.RegionID);
            Property(p => p.RegionID).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.RegionDescription).HasMaxLength(20).IsRequired();

            HasMany(p => p.Territories)
                .WithRequired(p => p.Region)
                .HasForeignKey(p => p.RegionID);
        }
    }

}