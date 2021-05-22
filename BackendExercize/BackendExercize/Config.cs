using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize
{
    public class Config
    {
        public string server = "";
        public string port = "";
        public string userId = "";
        public string password = "";
        public string database = "";

        public string Connection => "Server=" + server + "; Port=" + port + "; User Id=" + userId + "; Password=" + password + "; Database=" + database + ";";

        public Config()
        {
            server = Environment.GetEnvironmentVariable("server");
            port = Environment.GetEnvironmentVariable("port");
            userId = Environment.GetEnvironmentVariable("userId");
            password = Environment.GetEnvironmentVariable("password");
            database = Environment.GetEnvironmentVariable("database");
        }
    }
}
