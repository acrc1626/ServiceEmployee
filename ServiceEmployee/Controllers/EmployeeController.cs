namespace ServiceEmployee.Controllers
{
    using Microsoft.AspNetCore.DataProtection.KeyManagement;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using ServiceEmployee.Domain;
    using ServiceEmployee.Model.Entities;

    public class EmployeeController : Controller
    {
        private readonly EmployeeBusiness _employeeBusiness;
        private readonly IConfiguration _configuration;
        private string operation;

        public EmployeeController( EmployeeBusiness employeeBusiness, IConfiguration configuration)
        {
            _employeeBusiness = employeeBusiness;
            _configuration = configuration;
            operation = "Employees";
        }

        [HttpGet]
        [Route("GetEmployees")]

        public dynamic GetEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();
            string urlService = _configuration["UrlApis:" + operation];
            lstEmployee = _employeeBusiness.GetEmployees(urlService + "employees");
            if (lstEmployee != null)
            {
                return Ok(lstEmployee);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("GetEmployeeId")]

        public dynamic GetEmployee(int id)
        {
            List<Employee> lstEmployee = new List<Employee>();
            string urlService = _configuration["UrlApis:" + operation];
            lstEmployee = _employeeBusiness.GetEmployees(urlService + "employee/" + id);
            if (lstEmployee != null)
            {
                return Ok(lstEmployee);
            }

            return BadRequest();
        }
    }
}
