using ServiceEmployee.Model.Entities;

namespace ServiceEmployee.Domain.Interface
{
    public interface IEmployeeBusiness
    {
        List<Employee> GetEmployees();
        List<Employee> GetEmployeeId(int id);
    }
}
