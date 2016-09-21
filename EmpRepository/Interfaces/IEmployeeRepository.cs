using EmpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeList();

        List<Employee> FilterEmployeeBy(string condition, string sortOrder);

        int GetEmployeeCount();

        void AddEmployee(Employee emp);
    }
}
