namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> All();
        User GetByToken(string token);
    }
}