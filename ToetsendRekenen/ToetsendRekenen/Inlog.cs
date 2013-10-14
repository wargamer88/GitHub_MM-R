using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Inlog
    {
        public int GebruikersID { get; set; }
        public string GebruikersNaam { get; set; }
        public string WachtWoord { get; set; }

        public void UpdateObject()
        {
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            SqlCommand cmd = new SqlCommand("SELECT * from Inlog where GebruikersID = 1");

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GebruikersID = (int)reader["GebruikersID"];
                GebruikersNaam = (string)reader["Gebruikersnaam"];
                WachtWoord = (string)reader["Wachtwoord"];
            }
        }
        public bool Inloggen(string Gebruikersnaam, string Wachtwoord)
        {
            bool inloggen = false;
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            SqlCommand cmd = new SqlCommand("SELECT * from Inlog where Gebruikersnaam = @Gebruikersnaam AND Wachtwoord = @Wachtwoord");

            SqlParameter pm = new SqlParameter();
            pm.ParameterName = "@Gebruikersnaam";
            pm.Value = Gebruikersnaam;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@Wachtwoord";
            pm.Value = Wachtwoord;
            cmd.Parameters.Add(pm);

            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GebruikersID = (int)reader["GebruikersID"];
                GebruikersNaam = (string)reader["Gebruikersnaam"];
                WachtWoord = (string)reader["Wachtwoord"];

                if (Gebruikersnaam == GebruikersNaam && Wachtwoord == WachtWoord)
                {
                    inloggen = true;
                }
                else
                {
                    inloggen = false;   
                }
            }
            conn.Close();
            return inloggen;

        }
        public bool Changepassword(string OudWW, string NieuwWW, string BevestigingNieuwWW)
        {
            bool Changepassword = false;
            if (OudWW == WachtWoord)
            {
                if (NieuwWW == BevestigingNieuwWW)
                {
                    SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
                    SqlCommand cmd = new SqlCommand("UPDATE Inlog SET Wachtwoord = @Wachtwoord where Gebruikersnaam = @Gebruikersnaam AND Wachtwoord = @Wachtwoord");

                    SqlParameter pm = new SqlParameter();
                    pm.ParameterName = "@Gebruikersnaam";
                    pm.Value = GebruikersNaam;
                    cmd.Parameters.Add(pm);

                    pm = new SqlParameter();
                    pm.ParameterName = "@Wachtwoord";
                    pm.Value = NieuwWW;
                    cmd.Parameters.Add(pm);

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    UpdateObject();
                    Changepassword = true;
                    
                }
                else
                {
                    Changepassword = false;
                }
            }
            return Changepassword;
        }
    }
}