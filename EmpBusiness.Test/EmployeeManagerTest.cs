using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using EmpRepository.Interfaces;
using EmpModels;
using System.Collections.Generic;

namespace EmpBusiness.Test
{
    [TestClass]
    public class EmployeeManagerTest
    {
        [TestMethod]
        public void TestAllEmployees()
        {
            var s = MockRepository.GenerateStub<IEmployeeRepository>();
            var eList = new List<Employee>{new Employee
                    {
                        EmployeeId = 1,
                        Gender = "Male"
                    }
                };
            s.Stub(x => x.GetEmployeeList()).Return(eList);

            var empManager = new EmployeeManager(s);
            var empList = empManager.GetEmployeeList();
            Assert.AreEqual(empList, eList);
        }

        [TestMethod]
        public void TestEmployeeFetchByFilter()
        {
            var s = MockRepository.GenerateStub<IEmployeeRepository>();
            var eList = new List<Employee>{
                    new Employee
                    {
                        EmployeeId = 1,
                        Gender = "Male"
                    },
                    new Employee
                    {
                        EmployeeId = 2,
                        Gender = "Female"
                    }
                };
            s.Stub(x => x.GetEmployeeList()).Return(eList);
            var empManager = new EmployeeManager(s);
            var fList = empManager.FilterEmployeeBy("fem", "");
            Assert.AreEqual(fList[0].Gender, "Female");
        }

        //[TestMethod]
        //public void TestFemaleEmployees()
        //{
        //    var s = MockRepository.GenerateStub<IEmployeeRepository>();
        //    var eList = new List<Employee>{
        //            new Employee
        //            {
        //                EmployeeId = 1,
        //                Gender = "Male"
        //            },
        //            new Employee
        //            {
        //                EmployeeId = 2,
        //                Gender = "Female"
        //            }
        //        };
        //    s.Stub(x => x.GetEmployeeList()).Return(eList);

        //    var empManager = new EmployeeManager(s);
        //    var empList = empManager.GetEmployeeFemaleList();
        //    Assert.AreEqual(empList[0].Gender, "Female");
        //}

        //[TestMethod]
        //public void TestMaleEmployees()
        //{
        //    var s = MockRepository.GenerateStub<IEmployeeRepository>();
        //    var eList = new List<Employee>{
        //            new Employee
        //            {
        //                EmployeeId = 1,
        //                Gender = "Male"
        //            },
        //            new Employee
        //            {
        //                EmployeeId = 2,
        //                Gender = "Female"
        //            }
        //        };
        //    s.Stub(x => x.GetEmployeeList()).Return(eList);

        //    var empManager = new EmployeeManager(s);
        //    var empList = empManager.GetEmployeeMaleList();
        //    Assert.AreEqual(empList[0].Gender, "Male");
        //}
    }
}
