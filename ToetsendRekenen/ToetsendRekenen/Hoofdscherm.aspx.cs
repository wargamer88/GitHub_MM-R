using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ToetsendRekenen
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sessie objSessie = new Sessie();
            objSessie.SessieID = Session.SessionID;
            objSessie.Datum = DateTime.Now;
            Session["Sessie"] = objSessie;
            Session["Inlog"] = null;
            objSessie.NewSessie();
        }

        protected void btnStatistiek_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InlogStatistieken.aspx");
        }
    }
}