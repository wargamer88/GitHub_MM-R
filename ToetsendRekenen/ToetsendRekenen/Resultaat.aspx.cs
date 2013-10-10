using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Resultaat objResultaat = new Resultaat();
            objResultaat = (Resultaat)Session["Resultaat"];
            lbAantalGoed.Text = Convert.ToString(objResultaat.AantalGoed);
            lbAantalFout.Text = Convert.ToString(objResultaat.AantalFout);
        } 
    }
}