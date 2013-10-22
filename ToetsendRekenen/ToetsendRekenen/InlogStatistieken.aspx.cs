using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbGebruikersnaam.Attributes.Add("autocomplete", "off");
        }

        protected void btnInloggen_Click(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                Inlog I = new Inlog();
                bool inlog = I.Inloggen(tbGebruikersnaam.Text, tbWachtwoord.Text);

                if (inlog == true)
                {
                    Session["Inlog"] = I;
                    Response.Redirect("Statistieken.aspx");
                }
                else
                {
                    lbError.Visible = true;
                    lbError.Text = "Inloggen Mislukt";
                }
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }
    }
}