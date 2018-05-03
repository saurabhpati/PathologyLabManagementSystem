using System.Configuration;
using System.Data.SqlClient;

namespace Models
{
    public class DataAccess
    {
        public SqlConnection con = null;
       
        public DataAccess()
        {
            Initialize();
        }

        private void Initialize()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        }

        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
