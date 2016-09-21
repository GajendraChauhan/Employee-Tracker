using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpModels
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public float Salary { get; set; }

        public int Rating { get; set; }

        public string Department { get; set; }
    }
}
