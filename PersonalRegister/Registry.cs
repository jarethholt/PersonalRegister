using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalRegister
{
    public class Registry
    {
        /* A registry of employees.
         * 
         * This class holds a collection of Employee objects representing
         * the company's employees.
         * The only attribute it really needs is a list of Employees.
         * For methods, I think it makes sense for the class to expose:
         * - Ways to Add and Remove employees; and
         * - A way to print out a formatted version of the whole registry.
         */

        private List<Employee> _Employees = [];

        public Registry() { }  // Nothing needs to be initialized on creation

        public void AddEmployee(string name, decimal salary)
        {
            _Employees.Add(new Employee(name, salary));
        }

        private int MaxNameLength()
        {
            // Determine the maximum length needed to display a name
            if (_Employees.Count == 0) return 0;
            else return _Employees.Max(employee => employee.Name.Length);
        }

        private int MaxSalaryLength()
        {
            // Determine the maximum length needed to display a salary
            if (_Employees.Count == 0) return 0;
            else return _Employees.Max(employee => $"{employee.Salary:C}".Length);
        }

        public void DisplayRegistry()
        {
            // Display the registry in a well-formatted way.
            int nameLength = MaxNameLength();
            int salaryLength = MaxSalaryLength();
            salaryLength = Math.Min(salaryLength, "Salary".Length);

            // Use nameLength and salaryLength to determine alignment
            // Complicated format string here to be able to embed braces
            string format = string.Format(
                "{0}0,-{2}{1}    {0}1,{3}{1}",
                "{", "}", nameLength, salaryLength);
            string header = string.Format(format, "Name", "Salary");
            Console.WriteLine(header);
            Console.WriteLine(new string('-', header.Length));

            format = string.Format(
                "{0}0,-{2}{1}    {0}1,{3}:C{1}",
                "{", "}", nameLength, salaryLength);
            foreach (Employee employee in _Employees)
            {
                Console.WriteLine(string.Format(format, employee.Name, employee.Salary));
            }
            return;
        }
    }
}
