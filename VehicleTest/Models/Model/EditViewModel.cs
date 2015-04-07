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
    public class EditViewModel
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

        [DisplayName("Make")]
        [Required]
        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        [DisplayName("Model Name")]
        public string ModelName { get; set; }
    }
}