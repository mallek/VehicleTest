using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTest.Business;
using VehicleTest.Business.Interfaces;
using VehicleTest.Data;
using VehicleTest.Models.Model;

namespace VehicleTest.Controllers
{
    public class ModelController : Controller
    {

        private readonly IVehicleService _vehicleService;


        public ModelController(IVehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }

        public ModelController()
            : this(new VehicleService())
        {

        }

        // GET: Model
        public ActionResult Index()
        {

            var Models = _vehicleService.GetModels();

            return View(Models);
        }

        public ActionResult Create()
        {

            var makes = _vehicleService.GetMakes();

            var viewModel = new CreateViewModel()
            {
                Makes = makes
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var Model = _vehicleService.GetModel(id);
            var makes = _vehicleService.GetMakes();

            var viewModel = new EditViewModel()
            {
                Makes = makes,
                MakeId = Model.MakeId,
                ModelId = Model.ModelId,
                ModelName = Model.ModelName
            };

            return View(viewModel);
        }


        public ActionResult Delete(int id)
        {

            var Model = _vehicleService.GetModel(id);

            return View(Model);
        }


        [HttpPost]
        public ActionResult Create(CreateViewModel vehicleModel)
        {

            vehicleModel.Makes = _vehicleService.GetMakes();

            if(!ModelState.IsValid)
            {
                return View(vehicleModel);
            }

            var model = new VehicleModel()
            {
                MakeId = vehicleModel.MakeId,
                ModelName = vehicleModel.ModelName
            };
            
            model.ModelId = _vehicleService.AddModel(model);

            return View(vehicleModel);
        }


        [HttpPost]
        public ActionResult Edit(EditViewModel vehicleModel)
        {
            vehicleModel.Makes = _vehicleService.GetMakes();

            if(!ModelState.IsValid)
            {
                return View(vehicleModel);
            }

            var model = new VehicleModel()
            {
                MakeId = vehicleModel.MakeId,
                ModelId = vehicleModel.ModelId,
                ModelName = vehicleModel.ModelName
            };

            _vehicleService.UpdateModel(model);

            return View(vehicleModel);
        }

        [HttpPost]
        public ActionResult Delete(VehicleModel vehicleModel)
        {

            _vehicleService.DeleteModel(vehicleModel.ModelId);

            return View();
        }
    }
}