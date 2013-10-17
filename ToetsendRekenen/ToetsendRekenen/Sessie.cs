using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Sessie
    {
        public string SessieID { get; set; }
        public DateTime Datum { get; set; }

        public void NewSessie()
        {
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            SqlCommand cmd = new SqlCommand("INSERT INTO Sessie (SessieID, Datum) VALUES (@SessieID, @Datum)");

            SqlParameter pm = new SqlParameter();
            pm.ParameterName = "@SessieID";
            pm.Value = SessieID;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@Datum";
            pm.Value = Datum;
            cmd.Parameters.Add(pm);

            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public bool CheckSessie()
        {
            bool SessieAlreadyExists = false;
            string dbSessieID = "l";
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            SqlCommand cmd = new SqlCommand("SELECT * from Sessie");

            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dbSessieID = (string)reader["SessieID"];
                if (dbSessieID == SessieID)
                {
                    SessieAlreadyExists = true;
                    break;
                }
            }
            conn.Close();

            return SessieAlreadyExists;
        }
    }
}