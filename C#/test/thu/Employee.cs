using System;
using System.Collections.Generic;
using System.Text;

namespace thu
{
    class Employee
    {
        private string name = "FirstName, LastName";
        private double salary = 100.0;

        public string GetName()
        {
            return name;
        }

        private double Salary
        {
            get { return salary; }
        }

    }
}
