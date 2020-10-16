using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ToBrasil.Infrastructure.Data.Factory
{
    public class ToBrabilFactory
    {
        private readonly IDbConnection _dbConnection;

        public ToBrabilFactory(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }
    }
}
