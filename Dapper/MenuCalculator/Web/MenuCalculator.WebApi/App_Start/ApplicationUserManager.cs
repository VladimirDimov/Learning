using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MenuCalculator.WebApi.Models;
using MenuCalculator.Database.DbModels;
using MenuCalculator.Database.Repositories;
using MenuCalculator.Database;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MenuCalculator.WebApi
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<User>
    {
        private UsersRepository usersRepository;

        public ApplicationUserManager(IUserStore<User> store, UsersRepository usersRepository)
            : base(store)
        {
            this.usersRepository = usersRepository;
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<ApplicationDbContext>()), new UsersRepository(new DapperRequester()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var rowsaffected = this.usersRepository.Insert(user.Email, user.UserName, password, user.PhoneNumber, false, false);
                    if (rowsaffected != null)
                    {
                        return IdentityResult.Success;
                    }

                    return new IdentityResult("Unknown error occured");
                }
                catch (Exception ex)
                {
                    return new IdentityResult(ex.Message);
                }
            });
        }

        /// <summary>
        /// Return a user with the specified username and password or null if there is no match.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>User or null</returns>
        public override Task<User> FindAsync(string userName, string password)
        {
            return Task.Factory.StartNew<User>(() =>
            {
                var user = this.usersRepository.GetByUsername(userName);
                if (user == null || user.PasswordHash != password)
                {
                    return null;
                }

                return user;
            });
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType)
        {
            return Task.Factory.StartNew<ClaimsIdentity>(() =>
            {
                var identity = new ClaimsIdentity(authenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                return identity;
            });
        }
    }
}
