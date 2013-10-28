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

            try
            {
                Sessie objSessie = new Sessie();
                objSessie.SessieID = Session.SessionID;
                objSessie.Datum = DateTime.Now;
                Session["Sessie"] = objSessie;
                Session["Inlog"] = null;
                bool SessieAlreadyExists = objSessie.CheckSessie();

                if (SessieAlreadyExists == false)
                {
                    objSessie.NewSessie();
                }
            }
            catch (Exception ex)
            {
                
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(" + ex + ")</SCRIPT>");
            }
        }

        protected void btnStatistiek_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InlogStatistieken.aspx");
        }
    }
}