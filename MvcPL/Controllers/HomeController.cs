using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;
        public HomeController(IUserService service )
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var l = service.GetAllEntities();
            return View(service.GetAllEntities()
                .Select(user => new UserViewModel()
                {
                    Name = user.Login
                }));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(RegisterModel user)
        {
            
            var blluser = new UserEntity()
            {
                Login = user.UserName,
                Role_Id = 2, // user
                RegistryDate = DateTime.Now,
                Password = "12345",
                E_mail = "12345"                
            };
            service.Create(blluser);
            return RedirectToAction("Index");
        }
    }
}