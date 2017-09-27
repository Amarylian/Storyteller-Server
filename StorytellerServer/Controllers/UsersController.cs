using StorytellerServer.Database;
using StorytellerServer.ModelsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StorytellerServer.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public AuthorizationData login(LoginData data)
        {
            return null;
        }

        [HttpPost]
        public bool registration(RegistrationData data)
        {
            var conn = new RegistrationDbConnector();
            return conn.registration(data);
        }

        [HttpPost]
        public bool logout(AuthorizationData data)
        {
            return true;
        }

        [HttpPost]
        public bool resetPassword()
        {
            return true;
        }
    }
}
