using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class TestRepository : ITestRepository
    {
        public IEnumerable<TestModel> GetItems()
        {
            return new List<TestModel>
            {
                new TestModel { Name = "Product 1", Desc = "Descrition 1", Price = 1 },
                new TestModel { Name = "Product 2", Desc = "Descrition 2", Price = 2 },
                new TestModel { Name = "Product 3", Desc = "Descrition 3", Price = 3 },
                new TestModel { Name = "Product 4", Desc = "Descrition 4", Price = 4 }


            };
        }
    }
}
