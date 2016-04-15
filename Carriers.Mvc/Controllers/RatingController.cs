using AutoMapper;
using Carriers.Domain.Entities;
using Carriers.Domain.Interfaces;
using Carriers.Domain.Interfaces.Repositories;
using Carriers.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Carriers.Mvc.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICarrierRepository _carrierRepository;
        private readonly IUserRepository _userRepository;

        public RatingController(IRatingRepository ratingRepository, ICarrierRepository carrierRepository, IUserRepository userRepository)
        {
            _ratingRepository = ratingRepository;
            _carrierRepository = carrierRepository;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var carriers = _carrierRepository.GetAll();
            var user = (User)Session["User"];

            if (user == null)
                return RedirectToAction("Login", "Account");

            foreach (var item in carriers)
            {
                var rating = _ratingRepository.GetRatingBy(user.Id, item.Id);
                if (rating != null)
                    item.AvaliadaPeloUsuario = true;
            }

            var carriersVm = Mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierVm>>(carriers);
            return View(carriersVm);
        }

        public ActionResult Create(int id)
        {
            var user = (User)Session["User"];
            var carrier = _carrierRepository.GetById(id);
            var ratingVm = new RatingVm { IdCarrier = carrier.Id, IdUser = user.Id };

            return View("~/Views/Rating/Create.cshtml", ratingVm);
        }

        [HttpPost]
        public ActionResult Create(RatingVm ratingViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rating = Mapper.Map<RatingVm, Rating>(ratingViewModel);


                    rating.Carrier =_carrierRepository.GetById(ratingViewModel.IdCarrier);
                   
                    rating.User = (User)Session["User"]; 

                    _ratingRepository.Add(rating);

                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
                }

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