using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace Repositories
{
    public interface ITestRepository
    {
        int AddTest(Test tstObj);
        List<Test> GetAllTest();
        Test GetTest(int id);
        List<TestAttribute> GetTestAttributes(int testId);
        bool EditTest(Test tst);
    }

    public class TestRepository : ITestRepository
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
                cmd.ExecuteNonQuery();
                testIdRecent = (int)cmd.Parameters["@TestId"].Value;
            }
            return testIdRecent;
        }

        public List<Test> GetAllTest()
        {
            List<Test> lstTest = new List<Test>();
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("ReadAllTest", dbConnect.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            using (dbConnect.con)
            {
                dbConnect.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Test Object = new Test();
                        Object.Name = reader["Name"] + "";
                        Object.Id = Convert.ToInt32(reader["Id"]);
                        Object.Type = reader["Type"] + "";
                        lstTest.Add(Object);
                    }
                }
                else
                {
                    throw new Exception("No Tests found!!");
                }
                reader.Close();
            }
            return lstTest;
        }

        public Test GetTest(int id)
        {
            Test tst = new Test();
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("GetTestById", dbConnect.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@TestId", id);
            using (dbConnect.con)
            {
                dbConnect.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tst.Name = reader["Name"] + "";
                    tst.Id = Convert.ToInt32(reader["Id"]);
                    tst.Type = reader["Type"] + "";
                }
                else
                {
                    throw new Exception("No Tests found!!");
                }
                reader.Close();
            }

            return tst;
        }

        public List<TestAttribute> GetTestAttributes(int testId)
        {
            List<TestAttribute> lstTestAttribute = new List<TestAttribute>();
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("GetTestAttributes", dbConnect.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@TestId", testId);
            using (dbConnect.con)
            {
                dbConnect.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TestAttribute Object = new TestAttribute()
                        {
                            Name = reader["Name"] + "",
                            Id = Convert.ToInt32(reader["Id"]),
                            Unit = reader["Unit"] + "",
                            ReferenceValue = reader["ReferenceValue"] + ""
                        };
                        lstTestAttribute.Add(Object);
                    }
                }                
                reader.Close();
            }
            
            return lstTestAttribute;
        }

        public bool EditTest(Test tst)
        {
            bool response = false;
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("EditTest", dbConnect.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Name", tst.Name);
            cmd.Parameters.AddWithValue("@Type", tst.Type);
            cmd.Parameters.AddWithValue("@TestId", tst.Id);
            int i;
            using (dbConnect.con)
            {
                dbConnect.con.Open();
                i = cmd.ExecuteNonQuery();
            }

            if (i == 1)
            {
                response = true;
            }

            return response;
        }
    }
}
