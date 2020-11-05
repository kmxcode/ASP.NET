using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
                new Product { ProductID = 1, Name = "Name 1", Description = "Desc 1", Price = 1, Category = "Category 1" },
                new Product { ProductID = 2, Name = "Name 2", Description = "Desc 2", Price = 2, Category = "Category 2" },
                new Product { ProductID = 3, Name = "Name 3", Description = "Desc 3", Price = 3, Category = "Category 3" },
                new Product { ProductID = 4, Name = "Name 4", Description = "Desc 4", Price = 4, Category = "Category 4" }
        }.AsQueryable<Product>();
    }
}
