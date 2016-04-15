using AutoMapper;
using Carriers.Domain.Entities;
using Carriers.Domain.Interfaces.Repositories;
using Carriers.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carriers.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var user = (User)Session["User"];
            if (user != null)
                return RedirectToAction("Index", "Rating");


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.GetByMail(model.Mail);

            if (user != null)
            {
                Session["User"] = user;

                if (user.Password.Equals(model.Password))
                    return RedirectToAction("Index", "Rating");

                ModelState.AddModelError("incorreto", "Email ou senha incorretos.");
                return View(model);
            }
            ModelState.AddModelError("Mail", "Usuario não cadastrado.");
            return View(model);
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = Mapper.Map<UserVm, User>(model);

            _userRepository.Add(user);
            Session["User"] = user;

            return RedirectToAction("Index", "Rating");
        }

        public ActionResult Logout()
        {
            Session["User"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}