using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        GetallenLijn GL = new GetallenLijn();
        int antwoord;
        double antword;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lbError.Visible = false;
                    lbResultaat.Visible = false;

                    //Getallenlijn/Antwoorden genereren en Invullen.
                    Resultaat objResultaat = new Resultaat();
                    objResultaat = (Resultaat)Session["Resultaat"];
                    string subcategorie = objResultaat.SubCategorie;
                    string categorie = objResultaat.Categorie;
                    do
                    {
                        GL.GetallenlijnGenereren(categorie, subcategorie);
                    }
                    while (GL.EindGetal > 100  || GL.EindKommaGetal > 100);
                    if (objResultaat.Categorie == "Getallen")
                    {
                        cblAntwoorden.Items[GL.RandomPositie2].Text = Convert.ToString(GL.FoutGetal1);
                        cblAntwoorden.Items[GL.RandomPositie3].Text = Convert.ToString(GL.FoutGetal2);
                        cblAntwoorden.Items[GL.RandomPositie4].Text = Convert.ToString(GL.FoutGetal3);
                        StartNummer.Text = Convert.ToString(GL.StartGetal);
                        EindNummer.Text = Convert.ToString(GL.EindGetal);
                        MiddelNummer.Text = Convert.ToString(GL.MiddelGetal);
                    }
                    else if (objResultaat.Categorie == "KommaGetallen")
                    {
                        cblAntwoorden.Items[GL.RandomPositie2].Text = Convert.ToString(GL.FoutKommaGetal1);
                        cblAntwoorden.Items[GL.RandomPositie3].Text = Convert.ToString(GL.FoutKommaGetal2);
                        cblAntwoorden.Items[GL.RandomPositie4].Text = Convert.ToString(GL.FoutKommaGetal3);
                        StartNummer.Text = Convert.ToString(GL.StartKommaGetal);
                        EindNummer.Text = Convert.ToString(GL.EindKommaGetal);
                        MiddelNummer.Text = Convert.ToString(GL.MiddelKommaGetal);
                    }

                    //Pijl Verplaatsen
                    string plaatspijl = "Geen Antwoord";
                    if (objResultaat.Categorie == "Getallen")
                    {
                        antwoord = (GL.VraagGetal * GL.Tussenstapint) + GL.StartGetal;
                        plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";
                        
                        Pijltje.Style.Add("Left", plaatspijl);
                        cblAntwoorden.Items[GL.RandomPositie1].Text = Convert.ToString(antwoord);
                    }
                    else if (objResultaat.Categorie == "KommaGetallen")
                    {
                        antword = (GL.VraagGetal * GL.Tussenstapdouble) + GL.StartKommaGetal;
                        plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";
                        
                        Pijltje.Style.Add("Left", plaatspijl);
                        cblAntwoorden.Items[GL.RandomPositie1].Text = Convert.ToString(antword);
                    }

                    if (objResultaat.Categorie == "Getallen")
                    {
                        Session["Antwoord"] = antwoord;
                    }
                    else if (objResultaat.Categorie == "KommaGetallen")
                    {
                        Session["Antwoord"] = antword;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }

            
        }

        protected void Antwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                btnNext.Visible = true;
                Resultaat objResultaat = new Resultaat();
                objResultaat = (Resultaat)Session["Resultaat"];

                if (objResultaat.Categorie == "Getallen")
                {
                    antwoord = (int)Session["Antwoord"];
                }
                else if (objResultaat.Categorie == "KommaGetallen")
                {
                    antword = (double)Session["Antwoord"];
                }

                if (objResultaat.Categorie == "Getallen")
                {
                    if (Convert.ToInt32(cblAntwoorden.SelectedItem.Text) == antwoord)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        cblAntwoorden.Enabled = false;
                    }
                    else
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        cblAntwoorden.Enabled = false;
                    }
                }
                else if (objResultaat.Categorie == "KommaGetallen")
                {
                    if (Convert.ToDouble(cblAntwoorden.SelectedItem.Text) == antword)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        cblAntwoorden.Enabled = false;
                    }
                    else
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        cblAntwoorden.Enabled = false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Getallenlijn.aspx");

        }
    }
}