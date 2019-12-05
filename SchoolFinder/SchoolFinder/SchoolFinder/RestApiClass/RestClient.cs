using SharpFont.PostScript;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolFinder.RestApiClass
{
    class RestClient
    {
        classRestClient<T> {  
    Private
    const string MainWebServiceUrl = "https://jammovies.azurewebsites.net/";
        Private
    const string LoginWebServiceUrl = "https://jammovies.azurewebsites.net/api/UserCredentials/";
        Public async Task<bool> checkLogin(string email, string password)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "email=" + email + "/" + "password=" + password);
            return response.IsSuccessStatusCode;
        }
    }
}

