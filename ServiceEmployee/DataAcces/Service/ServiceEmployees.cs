namespace ServiceEmployee.DataAcces.Service
{
    public abstract class ServiceEmployees
    {
        protected readonly HttpClient _client;
        protected readonly IConfiguration _configuration;

        protected ServiceEmployees(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
        }

        protected virtual string GetApiUrl(string key, params object[] args)
        {
            string apiUrl = _configuration["UrlApis:" + key];
            return string.Format(apiUrl, args);

        }

        protected virtual string GetApiResponse(string url)
        {
            string responseData="";

            try
            {
                HttpResponseMessage respose = _client.GetAsync(url).Result;
                respose.EnsureSuccessStatusCode();
                responseData = respose.Content.ReadAsStringAsync().Result;

            }
            catch (HttpRequestException ex)
            {
                // Manejar la excepción de solicitud HTTP no exitosa
                Console.WriteLine("Error en la solicitud HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return responseData;

        }

    }

}
