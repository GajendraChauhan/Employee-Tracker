using EmpBusiness;
using EmpBusiness.EmpBusinessContracts;
using EmpRepository;
using EmpRepository.Interfaces;
using System.Web.Mvc;

namespace Employee_Tracker.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeManager _empMan;
        private IEmployeeRepository _empRepo;
        
        public HomeController()
        {
            this._empRepo = new EmployeeRepository();
            this._empMan = new EmployeeManager(this._empRepo);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployeePage()
        {
            return View("AddEmployee");
        }

        public ActionResult ViewEmployeePage(string condition, string sortOrder)
        {
            var empList = this._empMan.FilterEmployeeBy(condition, sortOrder);
            return View("ViewEmployee", empList);
        }

        public void AddEmployee(string name, string gender, float salary, int rating, string department)
        {
            this._empMan.AddEmployee(name, gender, salary, rating, department);
        }
    }
}