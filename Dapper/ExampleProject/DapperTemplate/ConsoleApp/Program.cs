namespace ConsoleApp
{
    using DapperTemplate.Data;
    using DapperTemplate.Data.Repositories;

    internal class Program
    {
        static string connectionString = @"data source=.\vdimov;initial catalog=NORTHWND;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        private static void Main()
        {
            var categoriesRepository = new CategoriesRepository(new DapperRequester(connectionString));
            var category1 = categoriesRepository.GetByIdOrDefault(1);
            var allCategories = categoriesRepository.All();
        }
    }
}