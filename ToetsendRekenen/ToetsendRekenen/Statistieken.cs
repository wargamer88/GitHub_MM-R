using System;
using System.Collections.Generic;
using System.Data;
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

        public SqlDataReader FilterenMetMaandResultaat(String Maand)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT R.Oefening 'Oefening', R.Categorie 'Categorie', R.SubCategorie 'SubCategorie', sum(R.AantalGoed) 'Aantal Goed', sum(R.AantalFout) 'Aantal Fout' FROM Resultaat R Right Join Sessie S on S.SessieID = R.SessieID where DATEPART(mm, S.Datum) = " + Maand + " GROUP BY R.Oefening, R.Categorie, R.SubCategorie", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }
        public SqlDataReader FilterenMetDatumResultaat(DateTime Van, DateTime Tot)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT R.Oefening 'Oefening', R.Categorie 'Categorie', R.SubCategorie 'SubCategorie', sum(R.AantalGoed) 'Aantal Goed', sum(R.AantalFout) 'Aantal Fout' FROM Resultaat R Right Join Sessie S on S.SessieID = R.SessieID WHERE S.Datum between '" + Van + "' and '" + Tot + "' GROUP BY R.Oefening, R.Categorie, R.SubCategorie", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }
        public SqlDataReader FilterenMetJaarResultaat(string Jaar)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT R.Oefening 'Oefening', R.Categorie 'Categorie', R.SubCategorie 'SubCategorie', sum(R.AantalGoed) 'Aantal Goed', sum(R.AantalFout) 'Aantal Fout' FROM Resultaat R Right Join Sessie S on S.SessieID = R.SessieID where DATEPART(yy, S.Datum) = " + Jaar + " GROUP BY R.Oefening, R.Categorie, R.SubCategorie", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }
        public SqlDataReader FilterenMetWeekResultaat(string Week)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT R.Oefening 'Oefening', R.Categorie 'Categorie', R.SubCategorie 'SubCategorie', sum(R.AantalGoed) 'Aantal Goed', sum(R.AantalFout) 'Aantal Fout' FROM Resultaat R Right Join Sessie S on S.SessieID = R.SessieID where DATEPART(ww, S.Datum) = " + Week + " GROUP BY R.Oefening, R.Categorie, R.SubCategorie", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }

        public SqlDataReader FilterenMetMaandViews(String Maand)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(s.SessieID) 'Views', s.Datum FROM Sessie s where DATEPART(mm, S.Datum) = " + Maand + " GROUP BY s.Datum", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }
        public SqlDataReader FilterenMetDatumViews(DateTime Van, DateTime Tot)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(s.SessieID) 'Views', s.Datum FROM Sessie s WHERE S.Datum between '" + Van + "' and '" + Tot + "'", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }
        public SqlDataReader FilterenMetJaarViews(string Jaar)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(s.SessieID) 'Views', s.Datum FROM Sessie s where DATEPART(yy, s.Datum) = " + Jaar + "", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }
        public SqlDataReader FilterenMetWeekViews(string Week)
        {
            List<Sessie> SessieList = new List<Sessie>();
            SqlConnection conn = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;Password=romimi;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(s.SessieID) 'Views', s.Datum FROM Sessie s where DATEPART(ww, s.Datum) = " + Week + "", conn);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            return reader;
        }


    }
}