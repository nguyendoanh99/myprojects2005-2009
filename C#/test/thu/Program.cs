using System;
using System.Collections.Generic;
using System.Text;

namespace thu
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            
            // The data members are inaccessible (private), so
            // then can't be accessed like this:
            //    string n = e.name;
            //    double s = e.salary;

            // 'name' is indirectly accessed via method:
            string n = e.GetName();

            // 'salary' is indirectly accessed via property
            double s = e.Salary;
        }
    }
}
