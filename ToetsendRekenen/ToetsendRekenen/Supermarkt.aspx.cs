using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace ToetsendRekenen
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IpassAstringfrompage1 = Convert.ToString(Session["test"]);
            reaction.Text = IpassAstringfrompage1;
        }

        protected void reaction_TextChanged(object sender, EventArgs e)
        {

        }
    }
}