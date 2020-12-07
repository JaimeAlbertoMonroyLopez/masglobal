using Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess.FactoryContract
{
    class ContractAnnualMonthlySalary : AbstractContractType
    {
        public override double CalculateAnnualMonthlySalary(double salary)
        {
            return salary * 12;
        }
    }
}
