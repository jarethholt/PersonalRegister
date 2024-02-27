using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalRegister
{
    public class Employee
    {
        /* Representation of an employee.
         * 
         * To represent an employee, we need two pieces of information:
         * - Their name, either as a whole name or as first and last name;
         * - Their salary.
         * These are encapsulated in the attributes Name and Salary.
         * The relevant methods to expose are:
         * - The constructor for creating employees (Employee);
         * - Ways to get/set the name and salary of existing employees;
         * - A string representation of the employee.
         * The get/set methods are part of the attribute definitions.
         * The string representation is defined by ToString (inherited from Object).
         */

        private const string _SalarySuffix = "SEK/månad";
        private static int _NextID = 1;
        private readonly int ID;
        private string _Name = "";
        private decimal _Salary;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public decimal Salary
        {
            get { return _Salary; }
            set
            {
                // Should check that salary is positive.
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: "The salary value must be positive");
                }
                _Salary = value;
            }
        }

        public Employee(string name, decimal salary)
        {
            ID = _NextID;
            _NextID++;
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Salary:C} {_SalarySuffix}";
        }
    }
}
