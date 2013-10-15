using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Statistieken
    {
        public SqlDataReader OphalenResultaat()
        {
            List<Resultaat> ResultatenList = new List<Resultaat>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT R.Oefening 'Oefening', R.Categorie 'Categorie', R.SubCategorie 'SubCategorie', sum(R.AantalGoed) 'Aantal Goed', sum(R.AantalFout) 'Aantal Fout' FROM Resultaat R GROUP BY R.Oefening, R.Categorie, R.SubCategorie");
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public SqlDataReader OphalenViews()
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(s.SessieID) 'Views', s.Datum FROM Sessie s GROUP BY s.Datum");
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}