namespace MenuCalculator.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using MenuCalculator.Database.DbModels;

    public class UsersRepository
    {
        private IDapperRequester dapperRequester;

        public UsersRepository(IDapperRequester dapperRequester)
        {
            this.dapperRequester = dapperRequester;
        }

        public User GetByIdOrDefault(int id)
        {
            return
                this.dapperRequester
                    .QueryFirst<User>("Categories_GetById", new { id = id });
        }

        public User GetByUsername(string username)
        {
            return
                this.dapperRequester
                    .QueryFirst<User>("AppUser_GetByUsername", new { username = username });
        }

        public IEnumerable<User> All()
        {
            return
                this.dapperRequester
                .Query<User>("Categories_All");
        }

        public string Insert(
            string email,
            string userName,
            string passwordHash,
            string phoneNumber,
            bool emailConfirmed = false,
            bool phoneNumberConfirmed = false)
        {
            return this.dapperRequester.QueryFirst<string>(
                "User_Insert",
                new
                {
                    id = Guid.NewGuid().ToString(),
                    email = email,
                    userName = userName,
                    passwordHash = passwordHash,
                    phoneNumber = phoneNumber,
                    emailConfirmed = emailConfirmed,
                    phoneNumberConfirmed = phoneNumber
                });
        }
    }
}