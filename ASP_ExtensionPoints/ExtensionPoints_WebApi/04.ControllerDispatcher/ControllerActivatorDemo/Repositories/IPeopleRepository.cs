namespace WebApiTest.Repositories
{
    using System.Collections.Generic;

    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAll { get; }
    }
}