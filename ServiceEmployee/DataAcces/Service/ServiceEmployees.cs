namespace ServiceEmployee.DataAcces.Service
{

    using Microsoft.AspNetCore.DataProtection.KeyManagement;
    using Newtonsoft.Json;
    using ServiceEmployee.DataAcces.Entities;
    using ServiceEmployee.DataAcces.Interface;
    using System.Collections.Generic;

    public class ServiceEmployees : IServiceEmployees
    {
        private async Task<dynamic> GetApiResponse(string service)
        {
            HttpClient httpClient = new HttpClient();
            dynamic message = null;
            try
            {
                var response = httpClient.GetAsync(service).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return message;
                }
                var responseData = response.Content.ReadAsStringAsync().Result;
                return message = JsonConvert.DeserializeObject<dynamic>(responseData);
            }

            catch (TaskCanceledException)
            {
                return message;
            }

        }


        public List<EmployeeService> GetEmployees(string service)
        {
            try
            {
                dynamic response = this.GetApiResponse(service).ConfigureAwait(false).GetAwaiter().GetResult();
                if (response != null)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<EmployeeService>>(
                                    response["data"].ToString(),
                                    new JsonSerializerSettings());
                    }

                    catch (Exception)
                    {
                        List<EmployeeService> employees = new List<EmployeeService>();
                        var objecto = JsonConvert.DeserializeObject<EmployeeService>(
                                     response["data"].ToString(),
                                     new JsonSerializerSettings());
                        employees.Add(objecto);
                        return employees;

                    }

                }

            }

            catch (Exception)
            {
                throw;
            }

            return null;
        }

    }

}
