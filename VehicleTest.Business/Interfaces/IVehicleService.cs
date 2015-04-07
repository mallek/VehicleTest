using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTest.Data;

namespace VehicleTest.Business.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleMake> GetMakes();
        VehicleMake GetMake(int id);
        int AddMake(VehicleMake vehicleMake);
        void UpdateMake(VehicleMake vehicleMake);
        void DeleteMake(int id);


        IEnumerable<VehicleModel> GetModels();
        VehicleModel GetModel(int id);
        int AddModel(VehicleModel vehicleModel);
        void UpdateModel(VehicleModel vehicleModel);
        void DeleteModel(int id);
        
    }
}
