using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine("Sum of numbers: " + numbers.Sum());
            Console.WriteLine("");
            Console.WriteLine("Average of numbers: " + numbers.Average());
            Console.WriteLine("");

            //Order numbers in ascending order and decsending order. Print each to console.

            Console.WriteLine("Descending Order:");
            var numberSpace = from num in numbers
                              orderby num descending
                              select num;

            foreach (var n in numberSpace)
            {
                Console.Write(n);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Ascending Order:");
            var numSpace = from num in numbers
                           orderby num ascending
                           select num;
            foreach (var n in numSpace)
            {
                Console.Write(n);
            }
            Console.WriteLine("");
            Console.WriteLine("");



            //Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers greater than 6:");
            var greaterThanSix =
                numbers.OrderByDescending(num => num).Take(3);
            foreach (var a in greaterThanSix)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("");
            Console.WriteLine("");


            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print Four Numbers Using foreach loop:");
            var onlyFour =
                numbers.Take(4);
            foreach (var b in onlyFour)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Change value to my age:");
            var nums = from num in numbers
                      orderby num descending
                      select num;

            numbers[4] = 33;
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            Console.WriteLine("Employees names who start with C or S:");
            var firstName = employees.OrderBy(x => x.FirstName).Where(name =>
            employees.Any(names => name.FirstName.StartsWith("C") || name.FirstName.StartsWith("S")));
            foreach (var item in firstName)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Order By Age and First Name:");
            var employeeAge = employees.OrderBy(x => x.Age).OrderBy(x => x.FirstName).Where(name =>
            employees.Any(age => name.Age > 26));
            foreach (var item in employeeAge)
            {
                Console.WriteLine(item.FullName + " " + item.Age);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("Sum and Average of Years of Experience:");

            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience));
            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience));
            
            Console.WriteLine("");


            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Added employee to the end of the list:");

            Employee newEmp = new Employee("Katie", "McGlawn", 33, 10);
            var newEmployees = employees.Append(newEmp);
            foreach (var emp in newEmployees)
            {
                Console.WriteLine(emp.FirstName+ " " + emp.LastName +" "+ emp.Age +" "+ emp.YearsOfExperience);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
