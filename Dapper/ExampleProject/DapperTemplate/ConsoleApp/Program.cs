namespace ConsoleApp
{
    using DapperTemplate.Data;
    using DapperTemplate.Data.Repositories;

    internal class Program
    {
        private static void Main()
        {
            var categoriesRepository = new CategoriesRepository(new DapperRequester());
            var category = categoriesRepository.FirstOrDefault(1);
        }
    }
}