using AutoMapper;
using Carriers.Domain.Entities;
using Carriers.Domain.Interfaces;
using Carriers.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carriers.Mvc.Controllers
{
    public class CarrierController : Controller
    {
        private readonly ICarrierRepository _carrierRepository;

        public CarrierController(ICarrierRepository carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        public ActionResult Index()
        {

            var carriers = _carrierRepository.GetAll();
            var carriersVm = Mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierVm>>(carriers);
            return View(carriersVm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarrierVm carrierViewModel)
        {
            if (ModelState.IsValid)
            {
                var carrier = Mapper.Map<CarrierVm, Carrier>(carrierViewModel);
                _carrierRepository.Add(carrier);

                return RedirectToAction("Index");
            }

            return View(carrierViewModel);
        }

        public ActionResult Edit(int id)
        {
            var carrier = _carrierRepository.GetById(id);
            var carriersVm = Mapper.Map<Carrier, CarrierVm>(carrier);

            return View(carriersVm);
        }

        [HttpPost]
        public ActionResult Edit(CarrierVm carrierViewModel)
        {
            if (ModelState.IsValid)
            {
                var carrier = Mapper.Map<CarrierVm, Carrier>(carrierViewModel);
                _carrierRepository.Update(carrier);

                return RedirectToAction("Index");
            }

            return View(carrierViewModel);
        }

        public ActionResult Details(int id)
        {
            var carrier = _carrierRepository.GetById(id);
            var carriersVm = Mapper.Map<Carrier, CarrierVm>(carrier);

            return View(carriersVm);
        }

        public ActionResult Delete(int id)
        {
            var carrier = _carrierRepository.GetById(id);
            var carriersVm = Mapper.Map<Carrier, CarrierVm>(carrier);

            return View(carriersVm);
        }

        [HttpPost]
        public ActionResult Delete(CarrierVm carrierViewModel)
        {

            //var carrier = Mapper.Map<CarrierVm, Carrier>(carrierViewModel);
            var carrier = _carrierRepository.GetById(carrierViewModel.Id);
            _carrierRepository.Remove(carrier);

            return RedirectToAction("Index");

        }
    }
}