using SchoolFinder.Models;
using SchoolFinder.RestApiClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder.ServiceHandler
{
    class LoginService
    {
        RestClient<User> _restClient = new RestClient<User>();
        public async Task<bool> CheckLoginIfExists(string email, string password)
        {
            var check = await _restClient.checkLogin(email, password);
            return check;
        }
    }
}
