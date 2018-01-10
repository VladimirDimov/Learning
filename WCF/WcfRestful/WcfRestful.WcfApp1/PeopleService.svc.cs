namespace WcfRestful.WcfApp
{
    using System.Collections.Generic;

    public class PeopleService : IPeopleService
    {
        private static IEnumerable<PersonModel> people = new List<PersonModel>
        {
            new PersonModel { Name = "Pesho", Age = 100 },
            new PersonModel { Name = "Misho", Age = 80 },
        };

        public IEnumerable<PersonModel> Get(int id)
        {
            return people;
        }
    }
}