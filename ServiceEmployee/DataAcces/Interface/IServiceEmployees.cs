using ServiceEmployee.DataAcces.Entities;

namespace ServiceEmployee.DataAcces.Interface
{
    public interface IServiceEmployees
    {
        List<EmployeeService> GetEmployees(string service);

    }
}
