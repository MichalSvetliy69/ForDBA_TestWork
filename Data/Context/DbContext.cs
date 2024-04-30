using ForDBA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Data.Context
{
    
    class DbContext
    {
        private static IRepository _userRepository;
        public static string connectionString = "Server=localhost;Database=YourDatabaseName5560; User Id=root;Password=jZRDEr87P8Ya#$x; SslMode=none;";
        public static void ConfigureServices()
        {
            //_userRepository = new UserRepository(connectionString);
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
