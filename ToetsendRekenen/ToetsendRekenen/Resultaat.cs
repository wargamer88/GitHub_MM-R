using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Resultaat : Sessie
    {
        public int ResultaatID { get; set; }
        public string Oefening { get; set; }
        public string Categorie { get; set; }
        public string SubCategorie { get; set; }
        public int AantalGoed { get; set; }
        public int AantalFout { get; set; }

        public void NewResultaat(Sessie S)
        {
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            SqlCommand cmd = new SqlCommand("INSERT INTO Resultaat (Oefening, Categorie, SubCategorie, AantalGoed, AantalFout, SessieID) VALUES (@Oefening, @Categorie, @SubCategorie, @AantalGoed, @AantalFout, @SessieID)");

            SqlParameter pm = new SqlParameter();
            pm.ParameterName = "@Oefening";
            pm.Value = Oefening;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@Categorie";
            pm.Value = Categorie;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@SubCategorie";
            pm.Value = SubCategorie;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@AantalGoed";
            pm.Value = AantalGoed;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@AantalFout";
            pm.Value = AantalFout;
            cmd.Parameters.Add(pm);

            pm = new SqlParameter();
            pm.ParameterName = "@SessieID";
            pm.Value = S.SessieID;
            cmd.Parameters.Add(pm);

            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}