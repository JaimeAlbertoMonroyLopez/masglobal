using BusinessAccess.FactoryContract;
using DataAccess;
using Entities.Employee;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{

    public class BusinessAccessClass
    {
        private DataAccessClass dataAccessClass = new DataAccessClass();
        ContractSalaryFactory contractSalaryFactory = null;
        public List<EmployeeDTO> ConsumeEmployeeTestAPI()
        {
            try
            {
                List<EmployeeDTO> employeeData = dataAccessClass.ConsumeEmployeesTestAPI();

                employeeData.Where(x => x.contractTypeName.Equals(Constants.HourlySalaryEmployee)).Select(y =>
                 {
                     contractSalaryFactory = new ContractSalaryFactory();
                     AbstractContractType contractSalary = contractSalaryFactory.GetContractSalary(y);
                     y.AnualHourlySalary = contractSalary.CalculateAnnualHourlySalary(y.hourlySalary);
                     return y;
                 }).ToList();

                employeeData.Where(x => x.contractTypeName.Equals(Constants.MonthlySalaryEmployee)).Select(y =>
                 {
                     contractSalaryFactory = new ContractSalaryFactory();
                     AbstractContractType contractSalary = contractSalaryFactory.GetContractSalary(y);
                     y.AnualMonthlySalary = contractSalary.CalculateAnnualMonthlySalary(y.monthlySalary);
                     return y;
                 }).ToList();

                return employeeData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeDTO ConsumeEmployeebyIDTestAPI(double empID)
        {
            try
            {
                EmployeeDTO employeeData = dataAccessClass.ConsumeEmployeesTestAPI(empID);
                if (employeeData != null)
                {
                    if (employeeData.contractTypeName.Equals(Constants.HourlySalaryEmployee))
                    {
                        contractSalaryFactory = new ContractSalaryFactory();
                        AbstractContractType contractSalary = contractSalaryFactory.GetContractSalary(employeeData);
                        employeeData.AnualHourlySalary = contractSalary.CalculateAnnualHourlySalary(employeeData.hourlySalary);
                    }

                    if (employeeData.contractTypeName.Equals(Constants.MonthlySalaryEmployee))
                    {
                        contractSalaryFactory = new ContractSalaryFactory();
                        AbstractContractType contractSalary = contractSalaryFactory.GetContractSalary(employeeData);
                        employeeData.AnualMonthlySalary = contractSalary.CalculateAnnualMonthlySalary(employeeData.monthlySalary);
                    }
                }
                else
                    employeeData = new EmployeeDTO();
                return employeeData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        
    }
}
