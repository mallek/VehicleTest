using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTest.Data;

namespace VehicleTest.Models.Model
{
    public class CreateViewModel
    {

        private IEnumerable<VehicleMake> _makes;

        public IEnumerable<VehicleMake> Makes
        {
            set
            {
                this._makes = value;
            }
        }
        public SelectList MakeList
        {
            get
            {
                return new SelectList(_makes, "MakeId", "Make", this.MakeId);
            }
        }

        [Required]
        [DisplayName("Model Name")]
        public string ModelName { get; set; }

        [DisplayName("Make")]
        [Required]
        public int MakeId { get; set; }
    }
}