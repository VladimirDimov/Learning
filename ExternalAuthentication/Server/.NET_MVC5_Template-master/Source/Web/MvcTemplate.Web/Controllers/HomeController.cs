namespace MvcTemplate.Web.Controllers
{
    using Filters;
    using Infrastructure.Mapping;
    using Services.Data;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly ICategoriesService jokeCategories;
        private IUsersService usersService;

        public HomeController(
            IJokesService jokes,
            ICategoriesService jokeCategories,
            IUsersService usersService)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
            this.usersService = usersService;
        }

        public ActionResult Index()
        {
            var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories
            };

            return this.View(viewModel);
        }

        [CustomAuthorizeAtribute]
        public ActionResult Test()
        {
            var token = this.Request.Headers["Token"];
            var user = this.usersService.GetByToken(token);

            if (user == null)
            {
                return new HttpStatusCodeResult(401);
            }

            return this.Json(new { data = "test", id = user.Id }, JsonRequestBehavior.AllowGet);
        }
    }
}
