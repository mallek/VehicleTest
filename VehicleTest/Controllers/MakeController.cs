using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTest.Business;
using VehicleTest.Business.Interfaces;
using VehicleTest.Data;

namespace VehicleTest.Controllers
{
    public class MakeController : Controller
    {
        
        private readonly IVehicleService _vehicleService;


        public MakeController(IVehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }

        public MakeController()
            : this(new VehicleService())
        {

        }
        
        // GET: Make
        public ActionResult Index()
        {
            var makes = _vehicleService.GetMakes();
            
            return View(makes);
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Edit(int id)
        {
            var make = _vehicleService.GetMake(id);     

            return View(make);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            var make = _vehicleService.GetMake(id);

            return View(make);
        }

        [HttpPost]
        public ActionResult Create(VehicleMake vehicleMake)
        {

            vehicleMake.MakeId = _vehicleService.AddMake(vehicleMake);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(VehicleMake vehicleMake)
        {
            _vehicleService.UpdateMake(vehicleMake);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(VehicleMake vehicleMake)
        {

            _vehicleService.DeleteMake(vehicleMake.MakeId);

            return View();
        }

    }
}