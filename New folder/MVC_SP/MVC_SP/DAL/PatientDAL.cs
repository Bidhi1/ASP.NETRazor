using MVC_SP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace MVC_SP.DAL
{
    public class PatientDAL

    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        public List<Patients> GetData(string iD)
        {
            List<Patients> lst = new List<Patients>();
            SqlCommand cmd = new SqlCommand("SelectPatientDetails_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            DataTable dt = new DataTable();
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    lst.Add(new Patients
                    {
                        Id = Convert.ToInt32(row["PatientId"]),
                        Name = Convert.ToString(row["NAME"]),
                        Age = Convert.ToInt32(row["AGE"]),
                        DOB = Convert.ToDateTime(row["DOB"]),
                        EntryDate = Convert.ToDateTime(row["ENTRY"])
                    });
                }
                return lst;
            }
            return null;

        }
        public bool Insert(Patients obj)
        {
            
            SqlCommand cmd = new SqlCommand("InsertPatientsDetails_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NAME", obj.Name);
            cmd.Parameters.AddWithValue("@AGE", obj.Age);
            cmd.Parameters.AddWithValue("@GENDER", obj.Gender);
            cmd.Parameters.AddWithValue("@DOB", obj.DOB);
            cmd.Parameters.AddWithValue("@ENTRY", obj.EntryDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Edit(Patients obj)
        {
            SqlCommand cmd = new SqlCommand("EditPatientsDetails_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NAME", obj.Name);
            cmd.Parameters.AddWithValue("@AGE", obj.Age);
            cmd.Parameters.AddWithValue("@GENDER", obj.Gender);
            cmd.Parameters.AddWithValue("@DOB", obj.DOB);
            cmd.Parameters.AddWithValue("@ENTRY", obj.EntryDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update(Patients obj)
        {
            SqlCommand cmd = new SqlCommand("UpdatePatientsDetails_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NAME", obj.Name);
            cmd.Parameters.AddWithValue("@AGE", obj.Age);
            cmd.Parameters.AddWithValue("@GENDER", obj.Gender);
            cmd.Parameters.AddWithValue("@DOB", obj.DOB);
            cmd.Parameters.AddWithValue("@ENTRY", obj.EntryDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete(Patients obj)
        {
            SqlCommand cmd = new SqlCommand("PatientsDetails_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NAME", obj.Name);
            cmd.Parameters.AddWithValue("@AGE", obj.Age);
            cmd.Parameters.AddWithValue("@GENDER", obj.Gender);
            cmd.Parameters.AddWithValue("@DOB", obj.DOB);
            cmd.Parameters.AddWithValue("@ENTRY", obj.EntryDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
                return false;
        }

        internal object GetData(object ID)
        {
            throw new NotImplementedException();
        }

        internal bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

  
