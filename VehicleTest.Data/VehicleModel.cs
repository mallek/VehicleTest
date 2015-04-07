using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTest.Data
{
    public class VehicleModel
    {
        public int ModelId { get; set; }

        public string ModelName { get; set; }

        public int MakeId { get; set; }

        public VehicleMake Make { get; set; }

    }
}
