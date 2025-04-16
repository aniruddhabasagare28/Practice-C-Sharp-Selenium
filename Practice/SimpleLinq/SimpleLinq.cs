using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Practice.SimpleLinq
{
    public class SimpleLinq
    {
        public void MyLinq()
        {
            // Example usage of LINQ queries
            var employees = Employee.Employees;

            // Get all employees with salary greater than 50000
            var highSalaryEmployees = employees.Where(e => e.Salary > 50000).ToList();

            foreach (var employee in highSalaryEmployees)
            {
                Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Salary: {employee.Salary}");
            }

            // 1. employees whose name starts with 'A'
            var NameStartWithA = employees.Where(e=>e.Name.StartsWith("A")).ToList();

            foreach (var employee in NameStartWithA) 
            {
                Console.WriteLine($"Name:: {employee.Name}"); 
            }

            // 2. Get the names of all employees in uppercase

            var upperCaseNames = employees.Select(e => e.Name.ToUpper()).ToList();

           //3.  Get employees sorted by age(ascending)

            var ascendingEmplyees = employees.OrderBy(e=>e.Age).ToList();

            //4. Check if there is any employee over 50 ( this is for checking only if employee is present or not 

            var emploeeOverFiftyAge = employees.Any(e => e.Age > 50);

            //5. Check if all employees are over 25

            var employeeOver25Age = employees.All(e => e.Age > 25);

           // 6.Get the average age of employees

            var averageAge = employees.Average(e => e.Age);

            //7. Get the first employee whose age is more than 30

            var moreThan20ageEmpl = employees.FirstOrDefault(e => e.Age > 30);

            //8. Get employee count per age
            var emplCountperAge = employees.GroupBy(e => e.Age)
                                  .Select(e => new { Age = e.Key, Count = e.Count()}).ToList();

        }
    }

    public class Employee
    {
        public int Id { get; set; }          // Unique identifier
        public string Name { get; set; }     // Employee name
        public int Age { get; set; }         // Age of the employee
        public string Department { get; set; } // Department
        public double Salary { get; set; }   // Monthly salary

        public static List<Employee> Employees
        {
            get
            {
                return new List<Employee>
                {
                    new Employee { Id = 1, Name = "Alice", Age = 28, Department = "HR", Salary = 40000 },
                    new Employee { Id = 2, Name = "Bob", Age = 34, Department = "IT", Salary = 55000 },
                    new Employee { Id = 3, Name = "Charlie", Age = 32, Department = "IT", Salary = 60000 },
                    new Employee { Id = 4, Name = "David", Age = 45, Department = "Finance", Salary = 70000 },
                    new Employee { Id = 5, Name = "Eva", Age = 30, Department = "HR", Salary = 42000 },
                    new Employee { Id = 6, Name = "Aniruddha", Age = 40, Department = "QA", Salary = 50000 },
                    new Employee { Id = 7, Name = "Richa", Age = 35, Department = "QA", Salary = 52000 },
                    new Employee { Id = 8, Name = "Karthick", Age = 38, Department = "QA", Salary = 51000 },
                };
            }
        }
    }
}
