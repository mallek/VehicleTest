using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTest.Data
{
    public class VehicleMake
    {
        public int MakeId { get; set; }
        public string Make { get; set; }
        public ICollection<VehicleModel> Models { get; set; }

        public VehicleMake()
        {
            Models = new List<VehicleModel>();
        }
    }
}
