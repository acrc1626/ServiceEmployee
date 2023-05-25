namespace ServiceEmployee.Domain
{
    using ServiceEmployee.DataAcces.Entities;
    using ServiceEmployee.DataAcces.Service;
    using ServiceEmployee.Domain.Validation;
    using ServiceEmployee.Model.Entities;
    public class EmployeeBusiness
    {
        public List<Employee> GetEmployees(string Urlservice)
        {
            ServiceEmployees serviceEmployees = new ServiceEmployees();
            EmployeeValidation employeeValidation = new EmployeeValidation();
            try
            {
                List<EmployeeService> employees = serviceEmployees.GetEmployees(Urlservice);
                if (employees != null)
                {
                    return employeeValidation.MapeerEmployees(employees);
                }              
                
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;

        }

    }

}
