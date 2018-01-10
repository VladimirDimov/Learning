namespace WcfApp
{
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleService : IPeopleService
    {
        private static IEnumerable<PersonModel> people = new List<PersonModel>
        {
            new PersonModel { Id = 1, Name = "Pesho", Age = 100 },
            new PersonModel { Id = 2, Name = "Misho", Age = 80 },
        };

        public PersonModel GetById(int id)
        {
            return people.FirstOrDefault(x => x.Id == id);
        }
    }
}