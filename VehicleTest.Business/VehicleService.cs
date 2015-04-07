using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTest.Business.Interfaces;
using VehicleTest.Data;
using System.Data.Entity;

namespace VehicleTest.Business
{
    public class VehicleService : IVehicleService
    {

        public IEnumerable<Data.VehicleMake> GetMakes()
        {
            using(var context = new VehicleTestContext())
            {
                return context.VehicleMakes.ToList();
            }
        }

        public Data.VehicleMake GetMake(int id)
        {
            using (var context = new VehicleTestContext())
            {
                return context.VehicleMakes.SingleOrDefault(t => t.MakeId == id);                
            }
        }

        public int AddMake(Data.VehicleMake vehicleMake)
        {
            using (var context = new VehicleTestContext())
            {
                context.VehicleMakes.Add(vehicleMake);
                context.SaveChanges();
                return vehicleMake.MakeId;
            }
        }

        public void UpdateMake(Data.VehicleMake vehicleMake)
        {
            using (var context = new VehicleTestContext())
            {
                var oldMake = context.VehicleMakes.SingleOrDefault(t => t.MakeId == vehicleMake.MakeId);
                context.Entry(oldMake).CurrentValues.SetValues(vehicleMake);
                context.SaveChanges();
            }
        }

        public void DeleteMake(int id)
        {
            using (var context = new VehicleTestContext())
            {
                var oldMake = context.VehicleMakes.SingleOrDefault(t => t.MakeId == id);
                context.VehicleMakes.Remove(oldMake);
                context.SaveChanges();
            }
        }

        public IEnumerable<Data.VehicleModel> GetModels()
        {
            using(var context = new VehicleTestContext())
            {
                return context.VehicleModels.Include(t => t.Make).OrderBy(t => t.MakeId).ThenBy(t => t.ModelName).ToList();
            }

        }

        public Data.VehicleModel GetModel(int id)
        {
            using (var context = new VehicleTestContext())
            {
                return context.VehicleModels.Include(t => t.Make).SingleOrDefault(t => t.ModelId == id);
            }
        }

        public int AddModel(Data.VehicleModel vehicleModel)
        {
            using (var context = new VehicleTestContext())
            {
                context.VehicleModels.Add(vehicleModel);
                context.SaveChanges();
                return vehicleModel.ModelId;
            }
        }

        public void UpdateModel(Data.VehicleModel vehicleModel)
        {
            using (var context = new VehicleTestContext())
            {
                var oldModel = context.VehicleModels.Include(t => t.Make).SingleOrDefault(t => t.ModelId == vehicleModel.ModelId);
                context.Entry(oldModel).CurrentValues.SetValues(vehicleModel);
                context.SaveChanges();
            }
        }

        public void DeleteModel(int id)
        {
            using (var context = new VehicleTestContext())
            {
                var oldModel = context.VehicleModels.Include(t => t.Make).SingleOrDefault(t => t.ModelId == id);
                context.VehicleModels.Remove(oldModel);
                context.SaveChanges();
            }
        }
    }
}
