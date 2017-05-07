using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;
using Newtonsoft.Json;
using MvcPaging;



namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 15;
        // GET: Product
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
  
        public ViewResult List(string query, string platform, int page = 1)
        {
            //string processedQuery = query.Trim().ToLower();
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => platform == null || p.Platform.Name == platform)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = platform == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Platform.Name == platform).Count()
                },
                CurrentCategory = platform
            };
            return View(model);      
        }

        public PartialViewResult ProductGrid(string query, string platform, int page = 1)
        {

            if (query == null)
                query = "";
            string processedQuery = query.Trim().ToLower();

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => String.IsNullOrWhiteSpace(platform) || p.Platform.Name == platform)
                    .Where(p => p.Platform.Name.ToLower().Contains(processedQuery)
                        || p.Title.ToLower().Contains(processedQuery)
                        || p.Description.ToLower().Contains(processedQuery)
                        || p.UPC.ToLower().Contains(processedQuery))
                    .OrderBy(p => p.ProductID),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,                
                    ItemsPerPage = PageSize,
                    TotalItems = platform == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Platform.Name == platform).Count()
                },
                CurrentCategory = platform
            };
            return PartialView("ProductGrid", model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault((p => p.ProductID == productId));
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
} 