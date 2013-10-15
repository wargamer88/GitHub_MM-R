using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Inlog"] == null)
            {
                Response.Redirect("InlogStatistieken.aspx");
            }
        }

        protected void btnWijzigWW_Click(object sender, EventArgs e)
        {
            try
            {
                lbResultaatChange.Visible = false;
                Inlog I = new Inlog();
                I = (Inlog)Session["Inlog"];
                bool WWChange = I.Changepassword(tbOudWW.Text, tbNieuwWW.Text, tbBevestigingNieuwWW.Text);

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

            }
            catch (Exception ex)
            {
                lbResultaatChange.Visible = true;
                lbResultaatChange.ForeColor = System.Drawing.Color.Red;
                lbResultaatChange.Text = ex.ToString();
            }
        }
    }
}