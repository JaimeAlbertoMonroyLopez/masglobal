using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess.FactoryContract
{
    abstract class AbstractContractType
    {
        public virtual double CalculateAnnualMonthlySalary(double salary)
        {
            return 0;
        }
        public virtual double CalculateAnnualHourlySalary(double salary)
        {
            return 0;
        }
    } 
}
