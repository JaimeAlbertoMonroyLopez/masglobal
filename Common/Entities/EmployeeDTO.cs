using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Employee
{
    public class EmployeeDTO
    {
        [JsonProperty]
        public double id { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public string contractTypeName { get; set; }
        [JsonProperty]
        public int roleId { get; set; }
        [JsonProperty]
        public string roleName { get; set; }
        [JsonProperty]
        public string roleDescription { get; set; }
        [JsonProperty]
        public double hourlySalary { get; set; }
        [JsonProperty]
        public double monthlySalary { get; set; }
        public double AnualHourlySalary { get; set; }
        public double AnualMonthlySalary { get; set; }
    }
}
