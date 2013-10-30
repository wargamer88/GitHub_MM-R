using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "+";
                objResultaat.SubCategorie = "0-10";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "+";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "+";
                objResultaat.SubCategorie = "0-1000";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "-";
                objResultaat.SubCategorie = "0-10";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "-";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "-";
                objResultaat.SubCategorie = "0-1000";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "x";
                objResultaat.SubCategorie = "0-10";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "x";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = "x";
                objResultaat.SubCategorie = "0-1000";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = ":";
                objResultaat.SubCategorie = "0-100";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Resultaat objResultaat = new Resultaat();
                objResultaat.Oefening = "Sommen";
                objResultaat.Categorie = ":";
                objResultaat.SubCategorie = "0-1000";
                objResultaat.SessieID = Session.SessionID;
                objResultaat.AantalGoed = 0;
                objResultaat.AantalFout = 0;
                int aantalsterren = 0;
                Session["AantalSterren"] = aantalsterren;
                int voortgang = 0;
                Session["Voortgang"] = voortgang;

                Session["Resultaat"] = objResultaat;
                Response.Redirect("Sommen.aspx");
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }
    }
}