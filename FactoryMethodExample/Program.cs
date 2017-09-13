using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace FactoryMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DbProviderFactory factory = SqlClientFactory.Instance;

            using (var connection = factory.CreateConnection())
            {
                var connectionString = GetConnectionString();
            }
        }

        private static string GetConnectionString()
        {
            var server = Console.ReadLine();

            return string.Format("server={0}", server);

            return $"server={server};...";
        }
    }
}
