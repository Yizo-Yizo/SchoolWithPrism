using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder.RestApiClass
{
    class RestClient<T>
    {
           
    private const string MainWebServiceUrl = "http: //localhost:44349/";
    private const string LoginWebServiceUrl = "http: //localhost:44349/api/UserCredentials";

        public async Task<bool> checkLogin(string email, string password)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "email=" + email + "/" + "password=" + password);
            return response.IsSuccessStatusCode;
        } 
    }

    internal class T
    {
    }
}

