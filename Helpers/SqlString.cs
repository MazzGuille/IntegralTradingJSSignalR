using System.Data.Common;

namespace IntegralTradingJS.Helpers
{
    public class SqlString
    {
        private readonly string _connection = string.Empty;

        public SqlString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _connection = builder.GetSection("ConnectionStrings:sqlString").Value;
        }

        public string GetSqlString()
        {
            return _connection;
        }

    }

}

