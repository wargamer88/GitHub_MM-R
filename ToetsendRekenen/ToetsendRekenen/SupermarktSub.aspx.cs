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
            if (makenmetbutton.Visible == false && makenzonderbutton.Visible == false)
            {
                makenmetbutton.Visible = true;
                makenzonderbutton.Visible = true;
                string page1 = "makenlijst";
                Session["test"] = page1;

                var supermarkt1 = new WebForm6();
                //Response.Redirect("/Supermarkt.aspx");
            }
        }

        protected void afrekenenLijst_Click(object sender, EventArgs e)
        {
            
            if (afrekenenmetbutton.Visible == false && afrekenenzonderbutton.Visible == false)
            {
                afrekenenmetbutton.Visible = true;
                afrekenenzonderbutton.Visible = true;
                string page1 = "Hidden";
                Session["test"] = page1;

                var supermarkt1 = new WebForm6();
                //Response.Redirect("/Supermarkt.aspx");
            }
            else
            {
                string page = "afrekenen";
                Session["test"] = page;

                var supermarkt = new WebForm6();
                Response.Redirect("/Supermarkt.aspx");
            }
        }

        protected void afrekenenmet_Click(object sender, EventArgs e)
        {
            string page = "statiegeld";
            Session["test"] = page;

            var supermarkt = new WebForm6();
            Response.Redirect("/Supermarkt.aspx");
        }
    }
}