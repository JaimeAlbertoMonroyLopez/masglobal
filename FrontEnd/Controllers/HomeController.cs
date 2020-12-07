using BusinessAccess;
using Entities.Employee;
using MVCApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private BusinessAccessClass businessAccessClass = new BusinessAccessClass();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEmployee(Employee emp)
        {
            try
            {
                if (emp.id == 0)
                {
                    List<Employee> employeeList = ConsumeEmployeeTestAPI();
                    ViewBag.employeeList = employeeList;
                }
                else
                {
                    Employee employee = ConsumeEmployeebyIDTestAPI(emp.id);

                    if (employee.id == 0)
                    {
                        ViewBag.EmployeeIDNotFound = BusinessRulesMessages.EmployeeIDNotFound;
                        ViewBag.employeeList = null;
                    }
                    else
                        ViewBag.employeeList = new List<Employee>() { employee };
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> ConsumeEmployeeTestAPI()
        {
            return businessAccessClass.ConsumeEmployeeTestAPI().Select(x =>
            {
                return TranslateObject(x);
            }).ToList();
        }

        public Employee ConsumeEmployeebyIDTestAPI(double id)
        {
            return TranslateObject(businessAccessClass.ConsumeEmployeebyIDTestAPI(id));
        }

        public Employee TranslateObject(EmployeeDTO obj)
        {
            return JsonConvert.DeserializeObject<Employee>(JsonConvert.SerializeObject(obj));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}