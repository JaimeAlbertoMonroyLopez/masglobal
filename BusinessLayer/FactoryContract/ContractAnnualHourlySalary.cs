using Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess.FactoryContract
{

    class ContractAnnualHourlySalary : AbstractContractType
    {
        public override double CalculateAnnualHourlySalary(double salary)
        {
            return 120 * salary * 12;
        }
    }
}
