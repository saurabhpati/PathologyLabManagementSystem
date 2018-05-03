using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Repositories
{
    public interface ITestAttributeRepository
    {
        bool AddAttributes(IEnumerable<TestAttribute> Obj);
        bool EditTestAttribute(List<TestAttribute> lstAttr);
    }

    public class TestAttributeRepository : ITestAttributeRepository
    {
        public bool AddAttributes(IEnumerable<TestAttribute> Obj)
        {
            bool response;
            int j = 0;
            foreach (var attribute in Obj)
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

        private bool IsAttributeExist(int id)
        {
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("Select count(*) from TestAttribute where Id = @Id ", dbConnect.con);
            cmd.Parameters.AddWithValue("@Id", id);
            int count;
            using (dbConnect.con)
            {
                dbConnect.con.Open();
                count = (int)cmd.ExecuteScalar();
            }
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditTestAttribute(List<TestAttribute> lstAttr)
        {
            bool response = false;
            int i;
            int count=0;
            foreach (var attr in lstAttr)
            {
                var dbConnect = new DataAccess();
                if (attr.Id!=0)
                {
                    SqlCommand cmd = new SqlCommand("EditAttribute", dbConnect.con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Name", attr.Name);
                    cmd.Parameters.AddWithValue("@Unit", attr.Unit);
                    cmd.Parameters.AddWithValue("@ReferenceValue", attr.ReferenceValue);
                    cmd.Parameters.AddWithValue("@Id", attr.Id);
                    using (dbConnect.con)
                    {
                        dbConnect.con.Open();
                        i = cmd.ExecuteNonQuery();
                        count++;
                    }

                    if (i == 1)
                    {
                        response = true;
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("AddTestAttribute", dbConnect.con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Name", attr.Name);
                    cmd.Parameters.AddWithValue("@Unit", attr.Unit);
                    cmd.Parameters.AddWithValue("@ReferenceValue", attr.ReferenceValue);
                    cmd.Parameters.AddWithValue("@TestId", attr.TestId);
                    using (dbConnect.con)
                    {
                        dbConnect.con.Open();
                        i=cmd.ExecuteNonQuery();
                        count++;
                    }
                    if (i == 1)
                    {
                        response = true;
                    }
                }
                if (count != lstAttr.Count())
                {
                    response = false;
                }
            }
            return response;
        }
    }
}
