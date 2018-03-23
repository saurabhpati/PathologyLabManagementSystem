using Models;
using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public interface ITestRepository
    {
        int AddTest(Test tstObj);
    }
    public class TestRepository: ITestRepository
    {
        public int AddTest(Test tstObj)
        {
            int testIdRecent;
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("AddTest", dbConnect.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", tstObj.Name);
            cmd.Parameters.AddWithValue("@Type", tstObj.Type);
            cmd.Parameters.Add("@TestId", SqlDbType.Int);
            cmd.Parameters["@TestId"].Direction = ParameterDirection.Output;

            using (dbConnect.con)
            {
                dbConnect.con.Open();
                //var returnParameter = cmd.Parameters.Add("@TestId", SqlDbType.Int);
                //returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                testIdRecent = (int)cmd.Parameters["@TestId"].Value;
            }
            return testIdRecent;
        }
    }
}
