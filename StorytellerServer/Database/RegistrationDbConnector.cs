using StorytellerServer.ModelsAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StorytellerServer.Database
{
    public class RegistrationDbConnector : DbConnector
    {

        public RegistrationDbConnector() : base() { }

        public bool registration(RegistrationData data)
        {
            if (!data.Password.Equals(data.RepeatedPassword))
                return false;

            if (!createUser(data))
                return false;

            if (!createUserScheme(data.Login))
            {
                deleteUser(data.Login);
                return false;
            }

            return true;
        }

        public bool createUser(RegistrationData data)
        {
            System.Diagnostics.Debug.WriteLine("CREATE USER");

            Query = "INSERT INTO meta.user (idUser,password,email,status) VALUES (@idUser,@password, @email, @status)";

            var parameters = new Dictionary<String, String>();
            parameters.Add("@idUser", data.Login);
            parameters.Add("@password", data.Password);
            parameters.Add("@email", data.Email);
            parameters.Add("@status", "active");
            addParameters(parameters);

            if (execute())
                return true;

            System.Diagnostics.Debug.WriteLine(Error);
            return false;
        }

        public bool deleteUser(String userName)
        {
            System.Diagnostics.Debug.WriteLine("DELETE USER");

            Query = "DELETE FROM meta.user WHERE idUser=@idUser";

            var parameters = new Dictionary<String, String>();
            parameters.Add("@idUser", userName);
            addParameters(parameters);

            if (execute())
                return true;

            System.Diagnostics.Debug.WriteLine(Error);
            return false;
        }

        public bool createUserScheme(String userName)
        {
            System.Diagnostics.Debug.WriteLine("CREATE SCHEME");

            Query = String.Format("CREATE SCHEMA _usr_{0}", userName);

            if (execute())
                return true;

            System.Diagnostics.Debug.WriteLine(Error);
            return false;
        }


    }
}