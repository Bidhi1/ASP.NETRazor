using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ADO_Example.Models;

namespace ADO_Example.DAL
{
    public class Patient_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        //Get All Patients
        public List<Patient> GetAllPatients()
        {
            List<Patient> patientList= new List<Patient>();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllPatients";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtPatients = new DataTable();

                conn.Open();
                sqlDA.Fill(dtPatients);
                conn.Close();

                foreach (DataRow dr in dtPatients.Rows)
                {
                    patientList.Add(new Patient
                    {
                        PatientId = Convert.ToInt32(dr["PatientId"]),
                        PatientName = Convert.ToString(dr["PatientName"]),
                        PatientAge = Convert.ToInt32(dr["PatientAge"]),
                        Price =Convert.ToDecimal(dr["Price"]),
                        Remarks =dr["Remarks"].ToString(),
                    });
                }
            }
            return patientList;
        }

        //Insert Patients
        public bool InsertPatient(Patient patient)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertPatients", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientName",patient.PatientName);
                command.Parameters.AddWithValue("@Price", patient.Price);
                command.Parameters.AddWithValue("@PatientAge", patient.PatientAge);
                command.Parameters.AddWithValue("@Remarks", patient.Remarks);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();

            }
            if(id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get Patients by patients Id
        public List<Patient> GetPatientById(int PatientId)
        {
            List<Patient> patientList = new List<Patient>();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetPatientById";
                command.Parameters.AddWithValue("@PatientId", PatientId);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtPatients = new DataTable();

                conn.Open();
                sqlDA.Fill(dtPatients);
                conn.Close();

                foreach (DataRow dr in dtPatients.Rows)
                {
                    patientList.Add(new Patient
                    {
                        PatientId = Convert.ToInt32(dr["PatientId"]),
                        PatientName = Convert.ToString(dr["PatientName"]),
                        PatientAge = Convert.ToInt32(dr["PatientAge"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Remarks = dr["Remarks"].ToString(),
                    });
                }
            }
            return patientList;
        }

        //Update Patients
        public bool UpdatePatient(Patient patient)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("[sp_UpdatePatients]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientId", patient.PatientId);
                command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                command.Parameters.AddWithValue("@Price", patient.Price);
                command.Parameters.AddWithValue("@PatientAge", patient.PatientAge);
                command.Parameters.AddWithValue("@Remarks", patient.Remarks);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete Patient details
        public string DeletePatient(int Patientid)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("SP_DELETEPATIENT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientId", Patientid);
                command.Parameters.Add("@Outputmessage", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@Outputmessage"].Value.ToString();
                connection.Close();
            }

            return result;
        }
    }
}