using Entities.Employee;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataLayerHelperClass
    {
        public static List<EmployeeDTO> DeserializeObjectEmployee(string jsonInput)
        {
            return JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsonInput);
        }
    }
}
