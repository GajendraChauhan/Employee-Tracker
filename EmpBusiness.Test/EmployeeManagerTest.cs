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
            var mockRepo = MockRepository.GenerateStub<IEmployeeRepository>();
            var eList = new List<Employee>{new Employee
                    {
                        EmployeeId = 1,
                        Gender = "M"
                    }
                };
            mockRepo.Stub(x => x.GetEmployeeList()).Return(eList);

            var empManager = new EmployeeManager(mockRepo);
            var empList = empManager.GetEmployeeList();
            Assert.AreEqual(empList, eList);
        }

        [TestMethod]
        public void TestEmployeeFetchByFilter()
        {
            var mockRepo = MockRepository.GenerateStub<IEmployeeRepository>();
            var eList = new List<Employee>{
                    new Employee
                    {
                        EmployeeId = 1,
                        Gender = "M"
                    },
                    new Employee
                    {
                        EmployeeId = 2,
                        Gender = "F"
                    }
                };
            mockRepo.Stub(x => x.GetEmployeeList()).Return(eList);
            var empManager = new EmployeeManager(mockRepo);
            var fList = empManager.FilterEmployeeBy("fem", "");
            Assert.AreEqual(fList[0].Gender, "F");
        }

        [TestMethod]
        public void TestFemaleEmployees()
        {
            var s = MockRepository.GenerateStub<IEmployeeRepository>();
            var eList = new List<Employee>{
                    new Employee
                    {
                        EmployeeId = 1,
                        Gender = "M"
                    },
                    new Employee
                    {
                        EmployeeId = 2,
                        Gender = "F"
                    }
                };
            s.Stub(x => x.GetEmployeeList()).Return(eList);

            var empManager = new EmployeeManager(s);
            var empList = empManager.GetEmployeeFemaleList();
            Assert.AreEqual(empList[0].Gender, "F");
        }

        //[TestMethod]
        //public void TestMaleEmployees()
        //{
        //    var s = MockRepository.GenerateStub<IEmployeeRepository>();
        //    var eList = new List<Employee>{
        //            new Employee
        //            {
        //                EmployeeId = 1,
        //                Gender = "M"
        //            },
        //            new Employee
        //            {
        //                EmployeeId = 2,
        //                Gender = "F"
        //            }
        //        };
        //    s.Stub(x => x.GetEmployeeList()).Return(eList);

        //    var empManager = new EmployeeManager(s);
        //    var empList = empManager.GetEmployeeMaleList();
        //    Assert.AreEqual(empList[0].Gender, "M");
        //}
    }
}
