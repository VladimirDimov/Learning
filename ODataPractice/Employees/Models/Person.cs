namespace Employees.Models
{
    using Controllers;
    using ODataConfiguration;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Web.OData.Builder;

    [ODataEntitySet("People")]
    public class Person : IHaveCustomODataConfiguration
    {
        public int PositionId { get; internal set; }

        public int PersonId { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [IgnoreDataMember]
        public string PeopertyToIgnore { get; set; }

        public Position Position { get; set; }

        public void CustomODataConfiguration(ODataModelBuilder builder)
        {
            builder.Namespace = "Services";

            builder
                .EntityType<Person>()
                .Action(nameof(PeopleController.ModifySalary))
                .Parameter<decimal>("Salary");

            builder
                .EntityType<Person>()
                .Collection
                .Function(nameof(PeopleController.GetMaxSalary))
                .Returns<decimal>();
        }

        public Person DeepCopy()
        {
            return new Person
            {
                Age = this.Age,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PeopertyToIgnore = this.PeopertyToIgnore,
                PersonId = this.PersonId,
                Position = this.Position,
                Salary = this.Salary
            };
        }
    }
}