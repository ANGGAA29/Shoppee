using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> _context, IRepository<ProductCategory> _productCategories)
        {
            context = _context;
            productCategories = _productCategories;
        }

        public ActionResult Index(string category=null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;
            return View(model);
        }
        
        public ActionResult Details(string id)
        {
            Product product = context.Find(id);
            if(product == null)
            {
                return HttpNotFound();               
            }
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}