using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Domain
{
    public class Territory
    {
        public Guid TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public Guid RegionID { get; set; }

        public Region Region { get; set; }

        public virtual ICollection<Employee> Employeis { get; set; }

        public Territory()
        {
            Employeis = new List<Employee>();
        }
    }

    public class TerritoryConfiguration : EntityTypeConfiguration<Territory>
    {
        public TerritoryConfiguration()
        {
            HasKey(p => p.TerritoryID);
            Property(p => p.TerritoryID).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.TerritoryDescription).HasMaxLength(20).IsRequired();
           
        }
    }
}