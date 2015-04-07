using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTest.Data.Mappings
{
    public class VehicleModelMapping : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelMapping()
        {
            ToTable("VehModels");

            HasKey(t => t.ModelId);

            Property(t => t.ModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.MakeId).HasColumnName("VehMakeId");
            Property(t => t.ModelName).HasColumnName("VehModel");

            HasRequired(t => t.Make).WithMany(t => t.Models).HasForeignKey(t => t.MakeId);




        }
    }
}
