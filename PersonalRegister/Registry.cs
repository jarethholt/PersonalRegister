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

        public void AddEmployee(Employee employee)
        {
            _Employees.Add(employee);
        }

        public Employee RemoveEmployee(string name)
        {
            throw new NotImplementedException("Removing employees has not been implemented yet");
        }

        private int MaxNameLength()
        {
            // Determine the maximum length needed to display a name
            return _Employees.Max(employee => employee.Name.Length);
        }

        private int MaxSalaryLength()
        {
            // Determine the maximum length needed to display a salary
            return _Employees.Max(employee => "{employee.Salary:C}".Length);
        }

        public override string ToString()
        {
            // Want to format result to view all names and salaries easily
            // Can be made simpler using a string builder
            StringBuilder builder = new();
            int nameLength = MaxNameLength();
            int salaryLength = MaxSalaryLength();
            string formatString = string.Format("{0}0:{2}{1}    {0}1:{3}{1}\n", "{", "}", nameLength, salaryLength);
            string header = string.Format(formatString, "Name", "Salary");
            builder.Append(header);
            builder.AppendLine(new string('-', header.Length));
            formatString = string.Format("{0}0:{2}{1}    {0}1:{3}C{1}\n", "{", "}", nameLength, salaryLength);
            foreach(Employee employee in _Employees)
            {
                builder.Append(string.Format(formatString, employee.Name, employee.Salary));
            }
            return builder.ToString();
        }
    }
}
