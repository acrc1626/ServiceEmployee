namespace ServiceEmployee.Domain
{
    using ServiceEmployee.DataAcces.Entities;
    using ServiceEmployee.DataAcces.Service;
    using ServiceEmployee.Domain.Interface;
    using ServiceEmployee.Domain.Validation;
    using ServiceEmployee.Model.Entities;
    public class EmployeeBusiness : EmployeeValidation, IEmployeeBusiness
    {
        public List<Employee> GetEmployees(string Urlservice)
        {
            ServiceEmployees serviceEmployees = new ServiceEmployees();
            try
            {
                List<EmployeeService> employees = serviceEmployees.GetEmployees(Urlservice);
                if (employees != null)
                {
                    return this.MapeerEmployees(employees);
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
