using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace StorytellerServer.Database
{
    public class DbConnector
    {
        private String _query;
        public String Query
        {
            get { return _query; }
            set
            {
                _query = value;
                Command = new MySqlCommand(Query, Connection);
            }
        }
        public MySqlConnection Connection { get; set; }
        public MySqlCommand Command { get; set; }
        public MySqlDataReader Reader { get; set; }

        public MySqlException Error { get; set; }

        public int SQLError { get; set; }

        public DbConnector()
        {
            MySqlConnectionStringBuilder ConnectionString = new MySqlConnectionStringBuilder();
            ConnectionString.Server = System.Configuration.ConfigurationManager.AppSettings["DbAddress"];
            ConnectionString.Port = UInt32.Parse(System.Configuration.ConfigurationManager.AppSettings["DbPort"]);
            ConnectionString.UserID = System.Configuration.ConfigurationManager.AppSettings["DbUser"];
            ConnectionString.Password = System.Configuration.ConfigurationManager.AppSettings["DbPassword"];

            System.Diagnostics.Debug.WriteLine(ConnectionString);

            Connection = new MySqlConnection(ConnectionString.ToString());
        }

        public void addParameters(Dictionary<String,String> parameters)
        {
            foreach(var param in parameters)
                Command.Parameters.AddWithValue(param.Key,param.Value);
        }

        public bool select()
        {
            try
            {
                Connection.Open();

                Reader = Command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Error = ex;
                return false;
            }
            finally
            {
                Reader?.Close();
                Connection?.Close();
            }

            return true;
        }

        public bool execute()
        {
            try
            {
                Connection.Open();

                Command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Error = ex;
                return false;
            }
            finally
            {
                Connection?.Close();
            }

            return true;
        }

        ~DbConnector()
        {
            Reader?.Close();
            Connection?.Close();
        }


    }
}