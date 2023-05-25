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
            string urlService = "https://dummy.restapiexample.com/api/v1/employees";
            List<EmployeeService> mockedEmployees = new List<EmployeeService>
            {
            new EmployeeService  { Id= "1" ,EmployeeAge = "23", EmployeeName = "Astrid", ProfileImage = "", EmployeeSalary = "44444"},
            new EmployeeService  { Id= "2" ,EmployeeAge = "45", EmployeeName = "Carolina", ProfileImage = "", EmployeeSalary = "44444"}
            };

            // Mock the ServiceEmployees dependency
            var mockServiceEmployees = new Mock<IServiceEmployees>();
            mockServiceEmployees.Setup(se => se.GetEmployees(urlService)).Returns(mockedEmployees);


            // Create an instance of EmployeeBusiness and inject the mocked dependency
            var employeeBusiness = new EmployeeBusiness();

            // Act
            List<Employee> result = employeeBusiness.GetEmployees(urlService);

            // Assert
            Assert.NotNull(result);

        }



    }
}