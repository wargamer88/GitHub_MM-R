using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbBreuken1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Breuken";
                objResultaat.Categorie = "Breuk-Komma";
                objResultaat.SubCategorie = "0-1";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Breuken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbBreuken2_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Breuken";
                objResultaat.Categorie = "Breuk-Komma";
                objResultaat.SubCategorie = "0-10";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Breuken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbKomma1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Breuken";
                objResultaat.Categorie = "Komma-Breuk";
                objResultaat.SubCategorie = "0-1";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Breuken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbKomma2_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Breuken";
                objResultaat.Categorie = "Komma-Breuk";
                objResultaat.SubCategorie = "0-10";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Breuken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbKomma3_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Breuken";
                objResultaat.Categorie = "Komma-Breuk";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Breuken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }
    }
}