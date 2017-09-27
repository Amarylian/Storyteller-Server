using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorytellerServer.ModelsDB
{
    public class User
    {
        public string idUser { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }
}