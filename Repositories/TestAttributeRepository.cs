using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITestAttributeRepository
    {
       bool AddAttributes(IEnumerable<TestAttribute> Obj);
    }
    public class TestAttributeRepository : ITestAttributeRepository
    {
        public bool AddAttributes(IEnumerable<TestAttribute> Obj)
        {
            bool response;
            int j=0;
            foreach(var attribute in Obj)
            {
                var dbConnect = new DataAccess();
                SqlCommand cmd = new SqlCommand("AddTestAttribute", dbConnect.con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", attribute.Name);
                cmd.Parameters.AddWithValue("@Unit", attribute.Unit);
                cmd.Parameters.AddWithValue("@ReferenceValue", attribute.ReferenceValue);
                cmd.Parameters.AddWithValue("@TestId", attribute.TestId);
                using (dbConnect.con)
                {
                    dbConnect.con.Open();
                    cmd.ExecuteNonQuery();
                    j++;
                }
            }
            if (j == Obj.Count())
            {
                response = true;
            }
            else
            {
                response = false;
            }

            return response;
        }
    }
}
