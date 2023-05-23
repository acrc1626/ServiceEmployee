using ServiceEmployee.DataAcces.Service;

namespace ServiceEmployee.Model
{
    public class EmployeeBusiness
    {
        private readonly EmployeesData _employeesData;

        public EmployeeBusiness(EmployeesData employeesData)
        {
            _employeesData = employeesData;
        }
        public List<Employee> GetEmployees()
        {
            EmployeeValidation employeeValidation = new EmployeeValidation();
            List<Employee> lstEmployees = new List<Employee>();
            var Json = _employeesData.GetEmployees();
            if (Json.Any())
            {
                lstEmployees = employeeValidation.MapeerEmployees(Json);
            }

            return lstEmployees;
        }

        public List<Employee> GetEmployeeId(int id)
        {
            EmployeeValidation employeeValidation = new EmployeeValidation();
            List<Employee> lstEmployees = new List<Employee>();
            var Json = _employeesData.GetEmployeeID(id);
            if (Json.Any())
            {
                lstEmployees = employeeValidation.MapeerEmployee(Json);
            }

            return lstEmployees;
        }

    }

}
