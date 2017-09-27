using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorytellerServer.ModelsAPI
{
    public class RegistrationData
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }

    }
}