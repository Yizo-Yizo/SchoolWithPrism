using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder.RestApiClass
{
    class RestClient<T>
    {
           
    private const string MainWebServiceUrl = "http://localhost:44349/";
    private const string LoginWebServiceUrl = "http://10.0.2.2:5000/api/Users";

        public async Task<bool> CheckLogin(string email, string password)
        {
            var httpClient = new HttpClient();

            var credentials = new { email = email, password = password };

            var stringContent = JsonConvert.SerializeObject(credentials);

            var content = new StringContent(stringContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(LoginWebServiceUrl, content);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return false;

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        } 
    }

    internal class T
    {
    }
}

