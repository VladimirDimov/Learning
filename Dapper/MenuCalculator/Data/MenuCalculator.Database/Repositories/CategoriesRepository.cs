﻿namespace MenuCalculator.Database.Repositories
{
    using System.Collections.Generic;
    using MenuCalculator.Database.DbModels;

    public class CategoriesRepository
    {
        private IDapperRequester dapperRequester;

        public CategoriesRepository(IDapperRequester dapperRequester)
        {
            this.dapperRequester = dapperRequester;
        }

        public Category GetByIdOrDefault(int id)
        {
            return
                this.dapperRequester
                    .QueryFirst<Category>("Categories_GetById", new { id = id });
        }

        public IEnumerable<Category> All()
        {
            return
                this.dapperRequester
                .Query<Category>("Categories_All");
        }
    }
}