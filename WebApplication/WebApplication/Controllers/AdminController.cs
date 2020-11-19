using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;
        public AdminController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public ViewResult Index() => View(productRepository.Products);

        public ViewResult Edit(int productID) => View(productRepository.Products.FirstOrDefault(p => p.ProductID == productID));

        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.SaveProduct(product);
                TempData["message"] = $"Zapisano {product.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", product);
            }
        }

        public ViewResult Create() => View("Edit", new Product { ProductID = 0 });
        public IActionResult Delete(int productID)
        {
            Product deletedProduct = productRepository.DeleteProduct(productID);
            if(deletedProduct != null)
            {
                TempData["message"] = $"Usunieto {deletedProduct.Name}";
            }
            return RedirectToAction("Index");
        }
    }
}
