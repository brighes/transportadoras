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
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICarrierRepository _carrierRepository;

        public RatingController(IRatingRepository ratingRepository, ICarrierRepository carrierRepository)
        {
            _ratingRepository = ratingRepository;
            _carrierRepository = carrierRepository;
        }

        public ActionResult Index()
        {
            var carriers = _carrierRepository.GetAll();
            var carriersVm = Mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierVm>>(carriers);
            return View(carriersVm);
        }

        public ActionResult Create(int id)
        {
            var carrier = _carrierRepository.GetById(id);
            var ratingVm = new RatingVm { IdCarrier = carrier.Id };

            return View("~/Views/Rating/Create.cshtml", ratingVm);
        }

        [HttpPost]
        public ActionResult Create(RatingVm ratingViewModel)
        {
            if (ModelState.IsValid)
            {
                var rating = Mapper.Map<RatingVm, Rating>(ratingViewModel);
                _ratingRepository.Add(rating);

                return RedirectToAction("Index");
            }

            return View(ratingViewModel);
        }

        public ActionResult Edit(int id)
        {
            var rating = _ratingRepository.GetById(id);
            var ratingVm = Mapper.Map<Rating, RatingVm>(rating);

            return View(ratingVm);
        }

        [HttpPost]
        public ActionResult Edit(RatingVm ratingViewModel)
        {
            if (ModelState.IsValid)
            {
                var rating = Mapper.Map<RatingVm, Rating>(ratingViewModel);
                _ratingRepository.Update(rating);

                return RedirectToAction("Index");
            }

            return View(ratingViewModel);
        }

        public ActionResult Details(int id)
        {
            var rating = _ratingRepository.GetById(id);
            var ratingVm = Mapper.Map<Rating, RatingVm>(rating);
            
            return View(ratingVm);
        }

        public ActionResult Delete(int id)
        {
            var rating = _ratingRepository.GetById(id);
            var ratingVm = Mapper.Map<Rating, RatingVm>(rating);

            return View(ratingVm);
        }

        [HttpPost]
        public ActionResult Delete(RatingVm carrierViewModel)
        {

            //var carrier = Mapper.Map<CarrierVm, Carrier>(carrierViewModel);
            var rating = _ratingRepository.GetById(carrierViewModel.Id);
            _ratingRepository.Remove(rating);

            return RedirectToAction("Index");

        }
    }
}