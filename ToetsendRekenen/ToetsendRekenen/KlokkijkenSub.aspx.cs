using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lblAnaloog15_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog";
                objResultaat.SubCategorie = "15";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaloog10_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog";
                objResultaat.SubCategorie = "10";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaloog5_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog";
                objResultaat.SubCategorie = "5";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaloog1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog";
                objResultaat.SubCategorie = "1";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDigitaal15_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal";
                objResultaat.SubCategorie = "15";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDigitaal10_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal";
                objResultaat.SubCategorie = "10";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDigitaal5_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal";
                objResultaat.SubCategorie = "5";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDigitaal1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal";
                objResultaat.SubCategorie = "1";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaarD15_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog naar digitaal";
                objResultaat.SubCategorie = "15";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaarD10_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog naar digitaal";
                objResultaat.SubCategorie = "10";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaarD5_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog naar digitaal";
                objResultaat.SubCategorie = "5";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblAnaarD1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Analoog naar digitaal";
                objResultaat.SubCategorie = "1";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDnaarA15_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal naar analoog";
                objResultaat.SubCategorie = "15";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDnaarA10_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal naar analoog";
                objResultaat.SubCategorie = "10";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDnaarA5_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal naar analoog";
                objResultaat.SubCategorie = "5";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void lblDnaarA1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Klokkijken";
                objResultaat.Categorie = "Digitaal naar analoog";
                objResultaat.SubCategorie = "1";
                objResultaat.SessieID = Session.SessionID;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Klokkijken.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }
    }
}