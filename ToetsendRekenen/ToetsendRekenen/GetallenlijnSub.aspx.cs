using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbGetallen2_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Getallenlijn";
                objResultaat.Categorie = "Getallen";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Getallenlijn.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbGetallen1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Getallenlijn";
                objResultaat.Categorie = "Getallen";
                objResultaat.SubCategorie = "0-10";
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Getallenlijn.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbKommaGetal1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Getallenlijn";
                objResultaat.Categorie = "KommaGetallen";
                objResultaat.SubCategorie = "0-10";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Getallenlijn.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbKommatGetal2_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Getallenlijn";
                objResultaat.Categorie = "KommaGetallen";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Getallenlijn.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }
    }
}