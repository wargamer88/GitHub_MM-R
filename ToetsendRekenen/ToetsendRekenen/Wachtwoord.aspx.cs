using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWijzigWW_Click(object sender, EventArgs e)
        {
            try
            {
                #region WachtwoordAanpassen
                //Wachtwoord aanpassen
                lbResultaatChange.Visible = false;
                Inlog I = new Inlog();
                I = (Inlog)Session["Inlog"];
                bool WWChange = I.Changepassword(tbOudWW.Text, tbNieuwWW.Text, tbBevestigingNieuwWW.Text);
                #endregion

                #region BevestigingWachtwoord
                //kijken of wachtwoord wijzigen gelukt is
                if (WWChange == true)
                {
                    lbResultaatChange.Visible = true;
                    lbResultaatChange.ForeColor = System.Drawing.Color.Green;
                    lbResultaatChange.Text = "Wachtwoord wijzigen gelukt.";
                    tbOudWW.Text = "";
                    tbNieuwWW.Text = "";
                    tbBevestigingNieuwWW.Text = "";
                }
                else
                {
                    lbResultaatChange.Visible = true;
                    lbResultaatChange.ForeColor = System.Drawing.Color.Red;
                    lbResultaatChange.Text = "Wachtwoord wijzigen mislukt";
                }
                #endregion

            }
            catch (Exception ex)
            {
                lbResultaatChange.Visible = true;
                lbResultaatChange.ForeColor = System.Drawing.Color.Red;
                lbResultaatChange.Text = ex.ToString();
            }
        }

        protected void btnStatistiek_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statistieken.aspx");
        }
    }
}