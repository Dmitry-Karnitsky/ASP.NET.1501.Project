using BLL.Interface.Entities;
using MvcPL.Models;
using MvcPL.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            @ViewBag.Users = Membership.GetAllUsers();
            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }        

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return RedirectToAction("Index", "Home", model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["files"] = null;
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserEntity()
                {
                    Login = model.UserName,
                    E_mail = model.UserEmail,
                    Password = model.Password,
                    Role_Id = 2
                };

                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(user);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error.");
                }
            }
            return View(model);
        }

    }
}
