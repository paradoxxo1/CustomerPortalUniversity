using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DataContext
{
    public class DapperOrmHelper : IDapperOrmHelper
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public string ProviderName { get; }
        public DapperOrmHelper(IConfiguration configuration)
        {
            _configuration = configuration;


            //--Dapper Setting 
            ConnectionString = _configuration.GetConnectionString("DBconnection");
            ProviderName = "System.Data.SqlClient";
        }

        //-- Dapper Connection String
        public IDbConnection GetDapperContextHelper()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}