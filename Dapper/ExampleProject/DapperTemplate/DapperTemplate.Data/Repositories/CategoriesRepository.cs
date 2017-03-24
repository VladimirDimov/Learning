namespace DapperTemplate.Data.Repositories
{
    using DapperTemplate.Data.DbModels;

    public class CategoriesRepository
    {
        private IDapperRequester dapperRequester;

        public CategoriesRepository(IDapperRequester dapperRequester)
        {
            this.dapperRequester = dapperRequester;
        }

        public Category FirstOrDefault(int id)
        {
            return this.dapperRequester.QueryFirst<Category>("Categories_GetById", id);
        }
    }
}