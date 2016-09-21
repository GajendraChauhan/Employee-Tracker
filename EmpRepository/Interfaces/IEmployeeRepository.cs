using EmpModels;
using System.Collections.Generic;

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
