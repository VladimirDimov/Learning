namespace Employees.Models
{
    using ODataConfiguration;
    using System.Collections.Generic;
    using System.Linq;

    [ODataEntitySet("Positions")]
    public class Position
    {
        private List<Person> employees = new List<Person>();

        public int PositionId { get; set; }

        public string Title { get; set; }

        public ICollection<Person> Employees
        {
            get { return this.employees; }
            set { this.employees = value.ToList(); }
        }
    }
}