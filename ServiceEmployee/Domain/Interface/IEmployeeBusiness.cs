namespace ServiceEmployee.Domain.Interface
{
    using ServiceEmployee.Model.Entities;
    public interface IEmployeeBusiness
    {
        List<Employee> GetEmployees(string Urlservice);

    }

}
