using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PortalUniversitario.Data
{
    public abstract class Data : IDisposable
    {
        protected SqlConnection connection;

        public Data()
        {
            string strConn = @"Data Source=localhost;
                                Initial Catalog=PortalUniversidades2;
                                Integrated Security=true";

            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
