using EmpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBusiness.EmpBusinessContracts
{
    public interface IEmployeeManager
    {
        List<Employee> GetEmployeeList();

        List<Employee> FilterEmployeeBy(string condition, string sortOrder);

        List<Employee> GetEmployeeFemaleList();

        List<Employee> GetEmployeeMaleList();

        List<Employee> GetEmployeeBestRatedList();

        List<Employee> GetEmployeeWorstRatedList();

        List<Employee> GetEmployeeTopPaidList();

        List<Employee> GetEmployeeLeastPaidList();

        int GetEmployeeCount();

        void AddEmployee(string name, string gender, float salary, int rating, string department);
    }
}
