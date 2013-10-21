using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToetsendRekenen
{
    /// <summary>
    /// Summary description for ShowImage
    /// </summary>
    public class ShowImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string AfbeeldingID;
            if (context.Request.QueryString["id"] != null)
            {
                AfbeeldingID = Convert.ToString(context.Request.QueryString["id"]);
                SqlConnection con = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi; Password=romimi;");
                SqlCommand cmd = new SqlCommand();
                string qry = "Select Afbeelding from Afbeelding where AfbeeldingID = '" + AfbeeldingID.ToString() + "'";
                cmd.CommandText = qry;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                con.Open();
                context.Response.BinaryWrite((byte[])cmd.ExecuteScalar());
                con.Close();
            }
            else if (context.Request.QueryString["tag"] != null)
            {
                AfbeeldingID = Convert.ToString(context.Request.QueryString["tag"]);
                SqlConnection con = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi; Password=romimi;");
                SqlCommand cmd = new SqlCommand();
                string qry = "Select Afbeelding from Afbeelding where tag = '" + AfbeeldingID.ToString() + "'";
                cmd.CommandText = qry;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                con.Open();
                context.Response.BinaryWrite((byte[])cmd.ExecuteScalar());
                con.Close();
            }
            else
            {
                context.Response.Write("Mislukt om de afbeelding te laden");
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    
}