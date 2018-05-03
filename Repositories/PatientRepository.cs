using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        bool AddPatient(Patient patient);
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

        public bool AddPatient(Patient patient)
        {
            var dbConnect = new DataAccess();
            int status;
            SqlCommand cmd = new SqlCommand("AddPatientDetails", dbConnect.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@Age", patient.Age);
            cmd.Parameters.AddWithValue("@Sex", patient.Sex);
            cmd.Parameters.AddWithValue("@Address", patient.Address);
            cmd.Parameters.AddWithValue("@BloodGrp", patient.BloodGroup);
            cmd.Parameters.AddWithValue("@SpName", patient.Parent_Spouse_Name);
            cmd.Parameters.AddWithValue("@Relation", patient.Relation);
            cmd.Parameters.AddWithValue("@Email", patient.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
            cmd.Parameters.AddWithValue("@MaritalStatus", patient.MaritalStatus);
            
            using (dbConnect.con)
            {
                dbConnect.con.Open();
                status= cmd.ExecuteNonQuery();
            }

            return (status == 1) ? true : false;
        }
    }
}
