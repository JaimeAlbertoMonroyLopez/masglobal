using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using Entities.Employee;

namespace DataAccess
{
    public class DataAccessClass
    {
        string EmployeeAPIurl = ConfigurationManager.AppSettings["EmployeeAPIurl"];

        HttpClient testAPIclient = new HttpClient();
        public List<EmployeeDTO> ConsumeEmployeesTestAPI()
        {
            return this.GetEmployeeSync(EmployeeAPIurl);
        }

        public EmployeeDTO ConsumeEmployeesTestAPI(double empId)
        {
            return this.GetEmployeeSyncById(EmployeeAPIurl, empId);
        }

        List<EmployeeDTO> GetEmployeeSync(string path)
        {
            List<EmployeeDTO> employeeList = null;
            string employeeString = string.Empty;
            HttpResponseMessage response = testAPIclient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                employeeString = (response.Content).ReadAsStringAsync().Result;
            }
            employeeList = DataLayerHelperClass.DeserializeObjectEmployee(employeeString);
            return employeeList;
        }

        EmployeeDTO GetEmployeeSyncById(string path, double empId)
        {
            List<EmployeeDTO> employeeList = null;
            string employeeString = string.Empty;
            HttpResponseMessage response = testAPIclient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                employeeString = (response.Content).ReadAsStringAsync().Result;
            }
            employeeList = DataLayerHelperClass.DeserializeObjectEmployee(employeeString);
            return employeeList.Where(x=>x.id==empId).FirstOrDefault();
        }
    }
}
