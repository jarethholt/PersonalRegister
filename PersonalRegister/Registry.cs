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

        public override string ToString()
        {
            // Want to format result to view all names and salaries easily
            // Can be made simpler using a string builder
            StringBuilder builder = new();
            return builder.ToString();
        }
    }
}
