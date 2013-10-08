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
                    do
                    {
                       GL.GetallenlijnGenereren(subcategorie);
                    }
                    while (GL.EindGetal > 100);
                    cblAntwoorden.Items[GL.RandomPositie2].Text = Convert.ToString(GL.FoutGetal1);
                    cblAntwoorden.Items[GL.RandomPositie3].Text = Convert.ToString(GL.FoutGetal2);
                    cblAntwoorden.Items[GL.RandomPositie4].Text = Convert.ToString(GL.FoutGetal3);
                    StartNummer.Text = Convert.ToString(GL.StartGetal);
                    EindNummer.Text = Convert.ToString(GL.EindGetal);
                    MiddelNummer.Text = Convert.ToString(GL.MiddelGetal);

                    //Pijl Verplaatsen
                    string plaatspijl = "Geen Antwoord";
                    do
                    {
                        antwoord = (GL.VraagGetal * GL.Tussenstapint) + GL.StartGetal;
                        plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";
                    }
                    while (antwoord == GL.FoutGetal1 || antwoord == GL.FoutGetal2 || antwoord == GL.FoutGetal3);
                    Pijltje.Style.Add("Left", plaatspijl);
                    cblAntwoorden.Items[GL.RandomPositie1].Text = Convert.ToString(antwoord);

                    //Tijdelijk
                    lbResultaat.Text = Convert.ToString(antwoord);
                    
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
                antwoord = Convert.ToInt32(lbResultaat.Text);
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