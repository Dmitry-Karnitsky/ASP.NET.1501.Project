using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class ProductController : Controller
    {        
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        
        //
        // GET: /Product/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {    
            // Sorting

            var products = service.GetAllEntities();
            IEnumerable<ProductsViewModel> pwml = products.Select(p => new ProductsViewModel()
            {
                Id = p.Id,
                Auction_Cost = p.Auction_Cost,
                Description = p.Description
            });

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(pwml.ToPagedList(pageNumber, pageSize));
        }

    }
}
