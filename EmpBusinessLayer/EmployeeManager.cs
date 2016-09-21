using EmpBusiness.EmpBusinessContracts;
using EmpModels;
using EmpRepository.Interfaces;
using System;
using System.Collections.Generic;

namespace EmpBusiness
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepository _empRepo;

        public EmployeeManager(IEmployeeRepository empRepo)
        {
            this._empRepo = empRepo;
        }

        public List<Employee> GetEmployeeList()
        {
            return this._empRepo.GetEmployeeList();
        }

        public List<EmpModels.Employee> FilterEmployeeBy(string condition, string sortOrder)
        {
            if(condition == "All")
            {
                return this.GetEmployeeList();
            }
            else if (condition == "fem")
            {
                return this.GetEmployeeFemaleList();
            }
            else if (condition == "male")
            {
                return this.GetEmployeeMaleList();
            }
            else if (condition == "best2")
            {
                return this.GetEmployeeBestRatedList();
            }
            else if (condition == "last2")
            {
                return this.GetEmployeeWorstRatedList();
            }
            else if (condition == "topPaid")
            {
                return this.GetEmployeeTopPaidList();
            }
            else    //least paid
            {
                return this.GetEmployeeLeastPaidList();
            }
        }

        public int GetEmployeeCount()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(string name, string gender, float salary, int rating, string department)
        {
            var emp = new Employee
            {
                Name = name,
                Gender = gender,
                Salary = salary,
                Rating = rating,
                Department = department
            };
            this._empRepo.AddEmployee(emp);
        }

        public List<Employee> GetEmployeeFemaleList()
        {
            var empList = this.GetEmployeeList();
            List<Employee> empRet = new List<Employee>();
            foreach (var emp in empList)
            {
                if (emp.Gender == "F")
                    empRet.Add(emp);
            }
            return empRet;
        }

        public List<Employee> GetEmployeeMaleList()
        {
            var empList = this.GetEmployeeList();
            List<Employee> empRet = new List<Employee>();
            foreach (var emp in empList)
            {
                if (emp.Gender == "M")
                    empRet.Add(emp);
            }
            return empRet;
        }

        public List<Employee> GetEmployeeBestRatedList()
        {
            var empList = this.GetEmployeeList();
            return empList;
        }

        public List<Employee> GetEmployeeWorstRatedList()
        {
            var empList = this.GetEmployeeList();
            return empList;
        }

        public List<Employee> GetEmployeeTopPaidList()
        {
            var empList = this.GetEmployeeList();
            return empList;
        }

        public List<Employee> GetEmployeeLeastPaidList()
        {
            var empList = this.GetEmployeeList();
            return empList;
        }
    }
}
