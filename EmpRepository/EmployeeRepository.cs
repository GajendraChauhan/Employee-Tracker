using DataAccess;
using EmpModels;
using EmpRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public List<Employee> GetEmployeeList()
        {
            using (var conMan = new ConnectionManager())
            {
                var da = new DataAccessHelper(conMan);
                var empList = da.GetDataList<Employee>("GetEmployees");
                return empList;
            }
        }

        public List<Employee> FilterEmployeeBy(string condition, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public int GetEmployeeCount()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee emp)
        {
            using (var conMan = new ConnectionManager())
            {
                var da = new DataAccessHelper(conMan);
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", emp.Name),
                    new SqlParameter("@Gender", emp.Gender),
                    new SqlParameter("@Salary", emp.Salary),
                    new SqlParameter("@Rating", emp.Rating),
                    new SqlParameter("@Department", emp.Department)
                };
                da.PutData("AddEmployee", parameters);
            }
        }
    }
}
