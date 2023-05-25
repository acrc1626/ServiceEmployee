namespace ServiceEmployee.Domain.Validation
{
    using ServiceEmployee.DataAcces.Entities;
    using ServiceEmployee.Model.Entities;
    using System.Collections.Generic;

    public class EmployeeValidation
    {
        public List<Employee> MapeerEmployees(List<EmployeeService> employeeServices)
        {

            return employeeServices.Select(x => new Employee{
                Id = int.Parse(x.Id),
                NameEmployee = x.EmployeeName,
                AgeEmployee = int.Parse(x.EmployeeAge),
                MonthlySalary = decimal.Parse(x.EmployeeSalary) * 12,
                ProfileImage = x.ProfileImage,
                Salary = decimal.Parse(x.EmployeeSalary)
            }).ToList();

        }
     
    }


}
