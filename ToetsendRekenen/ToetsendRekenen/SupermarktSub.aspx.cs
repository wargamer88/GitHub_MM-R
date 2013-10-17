using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace ToetsendRekenen
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void lbGetallen1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Supermarkt";
                objResultaat.Categorie = "Lijst afrekenen";
                objResultaat.SubCategorie = "Met afronden";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Supermarkt.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lbGetallen2_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Supermarkt";
                objResultaat.Categorie = "Lijst afrekenen";
                objResultaat.SubCategorie = "Zonder afronden";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Supermarkt.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }

        }
    }
}