using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository repository;
        public TestController(ITestRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string HelloWorld()
        {
            return "Hello World";
        }

        public IActionResult RediectToGoogle()
        {
            return Redirect("https://www.google.com");
        }

        public IActionResult TestModel() {

            var model = new List<TestModel>
            {
                new TestModel { Name = "Product 1", Desc = "Descrition 1", Price = 1 },
                new TestModel { Name = "Product 2", Desc = "Descrition 2", Price = 2 },
                new TestModel { Name = "Product 3", Desc = "Descrition 3", Price = 3 },
                new TestModel { Name = "Product 4", Desc = "Descrition 4", Price = 4 }


            };

            return View(model);
        }
    }
}
