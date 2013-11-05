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
                #region NieuweSessie
                //Nieuwe Sessie aanmaken
                Sessie objSessie = new Sessie();
                objSessie.SessieID = Session.SessionID;
                objSessie.Datum = DateTime.Now;
                Session["Sessie"] = objSessie;
                Session["Inlog"] = null; 
                #endregion

                #region SessieOpslaanDB
                //Sessie Opslaan op de database
                bool SessieAlreadyExists = objSessie.CheckSessie();
                if (SessieAlreadyExists == false)
                {
                    objSessie.NewSessie();
                } 
                #endregion
            }
            catch (Exception)
            {

                string textForMessage = @"<script language='javascript'> alert('Er is wat mis gegaan.');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
        }

        protected void btnStatistiek_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InlogStatistieken.aspx");
        }

        protected void btnEasteregg_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProcentenSub.aspx");
        }
    }
}