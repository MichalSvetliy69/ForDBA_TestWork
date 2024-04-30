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
        public static string connectionString = "Server=31.31.196.77;Database=u2501067_DBTestTwo; User Id=u2501067_JustUse;Password=jZRDEr87P8Ya#$x; SslMode=none;";
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
