using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesReportUI.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SalesReportUI.Service
{
    public class ApiService : IApiService
    {
        private static string _user;
        private static string _password;
        private static string _baseUrl;
        private static string _token;

        public ApiService() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _user = builder.GetSection("ApiSettings:user").Value;
            _password = builder.GetSection("ApiSettings:password").Value;
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task Auth()
        {

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var auth = new User() { Email = _user, Password = _password };

            var content = new StringContent(JsonConvert.SerializeObject(auth), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Auth/Validar", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<UserToken>(json_response);
            _token = result.Token;
        }

        public async Task<List<CustomerName>> GetAllCustomerName()
        {
            List<CustomerName> list = new List<CustomerName>();

            //await Auth();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("CustomerName/GetAll/customerName");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<List<CustomerName>>(json_respons);
                list = resultApi;
            }

            return list;
        }

        public async Task<List<ProductCategory>> GetAllProductName()
        {
            List<ProductCategory> list = new List<ProductCategory>();

            //await Auth();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("ProductCategory/GetAll/ProductName");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<List<ProductCategory>>(json_respons);
                list = resultApi;
            }

            return list;
        }

        public async Task<List<SalesPersonName>> GetAllSalesPersonName()
        {
            List<SalesPersonName> list = new List<SalesPersonName>();

            //await Auth();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("SalesPersonName/GetAll/salesPersonName");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<List<SalesPersonName>>(json_respons);
                list = resultApi;
            }

            return list;
        }

        public async Task<List<SalesOHeader>> GetAllYears()
        {
            List<SalesOHeader> list = new List<SalesOHeader>();

            //await Auth();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("SalesOHeader/GetAll/Years");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<List<SalesOHeader>> (json_respons);
                list = resultApi  ;
            }

            return list;
        }

        public async Task<List<SalesOrderDetails>> GetSalesOrderDetailsAsync()
        {
            List<SalesOrderDetails> list = new List<SalesOrderDetails>();

            //await Auth();


            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("SalesODetail/GetAll");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<List<SalesOrderDetails>>(json_respons);
                list = resultApi;
            }

            return list;

        }

        public async Task<List<SalesOrderDetails>> GetSalesOrderDetailsByFilters([FromQuery] SalesFilter filter)
        {
            List<SalesOrderDetails> list = new List<SalesOrderDetails>();

            //await Auth();


            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("salesODetail/details/filters");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<ResultSales>(json_respons);
                list = resultApi.list;
            }

            return list;
        }

        public async Task<List<SalesPerson>> GetSalesPerson()
        {
            List<SalesPerson> list = new List<SalesPerson>();

            //await Auth();


            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("salesOHeader/vendor");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<List<SalesPerson>>(json_respons);
                list = resultApi;
            }

            return list;
        }

        public async Task<List<SalesPerson>> GetSalesPersonDetails([FromQuery] SalesFilter filter)
        {
            List<SalesPerson> list = new List<SalesPerson>();

            //await Auth();


            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("salesOHeader/vendor/filter");

            if (response.IsSuccessStatusCode)
            {

                var json_respons = await response.Content.ReadAsStringAsync();
                var resultApi = JsonConvert.DeserializeObject<ResultVendor>(json_respons);
                list = resultApi.listVendor;
            }

            return list;
        }
    }
}
