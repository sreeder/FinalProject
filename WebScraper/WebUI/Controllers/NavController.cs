using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        public IProductRepository repository { get; set; }

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string platform = null)
        {
            ViewBag.SelectedCategory = platform;
            IEnumerable<string> categories=repository.Products
                                                .Select(x=>x.Platform.Name)
                                                .Distinct()
                                                .OrderBy(x=>x);
            return PartialView(categories);
        }
        
    }
}