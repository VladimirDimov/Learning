using System.IO;

namespace MenuCalculator.Database.DbModels
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public object Picture { get; set; }
    }
}