using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
    }
    public class PatientRepository : IPatientRepository
    {
        public List<Patient> GetAllPatients()
        {
            List<Patient> lstPat = new List<Patient>();
            var dbConnect = new DataAccess();
            SqlCommand cmd = new SqlCommand("GetAllPatients", dbConnect.con)
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
                        Patient patientObj = new Patient()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"] + "",
                            LastName = reader["LastName"] + "",
                            Address = reader["Address"] + "",
                            Age = Convert.ToInt32(reader["Age"]),
                            BloodGroup = reader["Blood_Group"] + "",
                            DateOfReporting = Convert.ToDateTime(reader["DateOfReporting"]),
                            Email = reader["Email"] + "",
                            MaritalStatus = reader["Marital Status"] + "",
                            Parent_Spouse_Name = reader["Parent / Spouse Name"] + "",
                            Relation = reader["Relation"] + "",
                            Sex = reader["Sex"] + "",
                            PhoneNumber = reader["Phone_Number"] + ""
                        };
                        lstPat.Add(patientObj);
                    }
                }
                else
                {
                    throw new Exception("No patients found!!");
                }
                reader.Close();
            }
            return lstPat;
        }
    }
}
