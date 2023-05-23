namespace ServiceEmployee.Model
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    public class EmployeeValidation
    {
        public List<Employee> MapeerEmployees(string json)
        {
            List<Employee> lstEmployees = new List<Employee>();


            JObject jObject = JObject.Parse(json);
            JArray jArray = (JArray)jObject["data"];
            foreach (JObject item in jArray)
            {
                string id = item["id"].ToString().Replace("23,dou", "23");
                string employeeName = item["employee_name"].ToString();
                decimal employeeSalary = (int)item["employee_salary"];
                int employeeAge = (int)item["employee_age"];
                string profileImage = item["profile_image"].ToString();

                Employee employee = new Employee
                {
                    Id = int.Parse(id),
                    NameEmployee = employeeName,
                    Salary = employeeSalary,
                    AgeEmployee = employeeAge,
                    ProfileImage = profileImage,
                    MonthlySalary = employeeSalary * 12
                };

                lstEmployees.Add(employee);
            }

            return lstEmployees;

        }


        public List<Employee> MapeerEmployee(string json)
        {
            List<Employee> lstEmployees = new List<Employee>();
            JObject jObject = JObject.Parse(json);
            var item = jObject["data"];
            string id = item["id"].ToString().Replace("23,dou", "23");
            string employeeName = item["employee_name"].ToString();
            decimal employeeSalary = (int)item["employee_salary"];
            int employeeAge = (int)item["employee_age"];
            string profileImage = item["profile_image"].ToString();

            Employee employee = new Employee
            {
                Id = int.Parse(id),
                NameEmployee = employeeName,
                Salary = employeeSalary,
                AgeEmployee = employeeAge,
                ProfileImage = profileImage,
                MonthlySalary = employeeSalary * 12
            };


            lstEmployees.Add(employee);
            return lstEmployees;
        }
    }


}
