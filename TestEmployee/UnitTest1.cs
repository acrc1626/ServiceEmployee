namespace TestEmployee
{
    using Moq;
    using ServiceEmployee.DataAcces.Entities;
    using ServiceEmployee.DataAcces.Interface;
    using ServiceEmployee.Domain;
    using ServiceEmployee.Model.Entities;
    using Xunit;
    public class UnitTest1
    {
        [Fact]
        public void GetEmployeesTest()
        {
            // Arrange
            string urlService = "https://dummy.restapiexample.com/api/v1/employee/1";
            List<EmployeeService> mockedEmployees = new List<EmployeeService>
            {
            new EmployeeService  { Id= "1" ,EmployeeAge = "23", EmployeeName = "Astrid", ProfileImage = "", EmployeeSalary = "44444"},
            };

            var mockServiceEmployees = new Mock<IServiceEmployees>();
            mockServiceEmployees.Setup(se => se.GetEmployees(urlService)).Returns(mockedEmployees);


            var employeeBusiness = new EmployeeBusiness();

            List<Employee> employees = new List<Employee>
            {
            new Employee  {Id = 1, AgeEmployee = 23, NameEmployee = "Tiger Nixon", ProfileImage = "", Salary = 320800, MonthlySalary = 2333333}            
            };

            // Act
            List<Employee> result = employeeBusiness.GetEmployees(urlService);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mockedEmployees.Count, result.Count);
            Assert.All(result, employee =>
            {
                Assert.Equal(typeof(int), employee.Id.GetType());
                Assert.Equal(typeof(string), employee.NameEmployee.GetType());
                Assert.Equal(typeof(decimal), employee.Salary.GetType());
                Assert.Equal(typeof(decimal), employee.MonthlySalary.GetType());
                Assert.Equal(typeof(string), employee.ProfileImage.GetType());
                Assert.Equal(typeof(int), employee.AgeEmployee.GetType());
            });

        }

    }

}