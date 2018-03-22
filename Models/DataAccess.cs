using System.Data.SqlClient;
using System.Configuration;

namespace Models
{

    public class DataAccess
    {
        private DataAccess dbConnect;
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
