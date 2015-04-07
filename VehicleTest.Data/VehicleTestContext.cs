using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTest.Data
{
    
    
    public class VehicleTestContext : DbContext
    {
        public VehicleTestContext()
               :base("name=VehicleDataConnectionString")
        {
            //stuff


        }

        static VehicleTestContext()
        {
            Database.SetInitializer<VehicleTestContext>(null); 
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(VehicleTestContext).Assembly);            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
