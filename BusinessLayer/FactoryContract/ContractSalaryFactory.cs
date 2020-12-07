using Entities.Employee;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess.FactoryContract
{
    class ContractSalaryFactory
    {
        public AbstractContractType GetContractSalary(EmployeeDTO employeeDTO)
        {
            AbstractContractType contractSalary = null;
            switch(employeeDTO.contractTypeName)
            {
                case Constants.HourlySalaryEmployee:
                    contractSalary = new ContractAnnualHourlySalary();
                    break;
                case Constants.MonthlySalaryEmployee:
                    contractSalary = new ContractAnnualMonthlySalary();
                    break;
            }
            return contractSalary;
        }
    }
}
