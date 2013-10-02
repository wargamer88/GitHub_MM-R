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

        protected void makenLijst_Click(object sender, EventArgs e)
        {

        }

        protected void afrekenenLijst_Click(object sender, EventArgs e)
        {
            string page = "afrekenen";
            var supermarkt = new WebForm6();
            Response.Redirect("/Supermarkt.aspx");
            

        }
    }
}