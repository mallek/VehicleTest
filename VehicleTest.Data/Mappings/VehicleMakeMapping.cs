using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTest.Data.Mappings
{
    public class VehicleMakeMapping : EntityTypeConfiguration<VehicleMake>
    {
        public VehicleMakeMapping()
        {
            ToTable("VehMakes");

            HasKey(t => t.MakeId);
            
            Property(t => t.MakeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Make).HasColumnName("Make");

            HasMany(t => t.Models).WithRequired(t => t.Make).HasForeignKey(t => t.MakeId);

        }
    }
}
