namespace ServiceEmployee.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceEmployee.DataAcces.Service;
    using ServiceEmployee.Model;

    public class EmployeeController : Controller
    {
        private readonly EmployeesData _employeesData;
        private readonly EmployeeBusiness _employeeBusiness;
        public EmployeeController(EmployeesData employeesData, EmployeeBusiness employeeBusiness)
        {
            _employeesData = employeesData;
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        [Route("GetEmployees")]

        public dynamic GetEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = _employeeBusiness.GetEmployees();
            if (lstEmployee.Any())
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
            lstEmployee = _employeeBusiness.GetEmployeeId(id);
            if (lstEmployee.Any())
            {
                return Ok(lstEmployee);

            }
            return BadRequest();
        }
    }
}
