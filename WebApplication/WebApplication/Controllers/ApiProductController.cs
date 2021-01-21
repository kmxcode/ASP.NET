using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ApiProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Returns a list of products
        /// </summary>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.Products;
        }

        /// <summary>
        /// Find product by ID
        /// </summary>
        [HttpGet("{id}")]
        public Product Get(int productID)
        {
            return productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            product.ProductID = 0;
            productRepository.SaveProduct(product);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        [HttpPut("{id}")]
        public void Put(int productID, [FromBody] Product product)
        {
            product.ProductID = productID;
            productRepository.SaveProduct(product);
        }

        /// <summary>
        /// Deletes product
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int productID)
        {
            Product deletedProduct = productRepository.DeleteProduct(productID);
        }
    }
}
