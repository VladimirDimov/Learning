using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Data
{
    public class Data
    {
        private static List<Person> employees = new List<Person>();
        private static List<Position> positions = new List<Position>();

        static Data()
        {
            for (int i = 0; i < 10; i++)
            {
                positions.Add(new Position { PositionId = i + 1, Title = $"Position {i + 1}" });
            }

            var rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                var employeePosition = positions[rnd.Next(0, positions.Count - 1)];
                var employeeToAdd = new Person
                {
                    Age = rnd.Next(20, 60),
                    FirstName = $"Firstname {i + 1}",
                    LastName = $"Lastname {i + 1}",
                    PersonId = i + 1,
                    Position = employeePosition,
                    PositionId = employeePosition.PositionId,
                    Salary = rnd.Next(1000, 3000),
                    PeopertyToIgnore = "This property will be ignored!"
                };

                employees.Add(employeeToAdd);

                employeePosition.Employees.Add(employeeToAdd);
            }
        }

        public static IQueryable<Person> Employees
        {
            get
            {
                return employees.AsQueryable();
            }

            private set
            {
                employees = value.ToList();
            }
        }


        public static IQueryable<Position> Positions
        {
            get
            {
                return positions.AsQueryable();
            }

            set
            {
                positions = value.ToList();
            }
        }

        public static void AddEmployee(Person employee)
        {
            employees.Add(employee);
        }

        public static Person Remove(Person entity)
        {
            employees.Remove(entity);

            return entity;
        }
    }
}