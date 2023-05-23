using ServiceEmployee.Model;

namespace ServiceEmployee.DataAcces.Service
{
    public class EmployeesData : ServiceEmployees
    {
        public EmployeesData(IConfiguration configuration) : base(configuration)
        {
        }

        public string GetEmployees()
        {
            string url = GetApiUrl("Employees");
            return GetApiResponse(url+ "employees");
        }

        public string GetEmployeeID(int id)
        {
            string url = GetApiUrl("Employees");
            return GetApiResponse(url + "employee/" + id);
        }
    }
}
