using System.Collections.Generic;

namespace mvc.Models
{
    public interface ITestRepository
    {
        IEnumerable<TestModel> GetItems();
    }
}