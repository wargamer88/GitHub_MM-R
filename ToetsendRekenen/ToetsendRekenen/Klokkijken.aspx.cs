using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected int minutenVanLangewijzer;
        protected int minutenVanKortewijzer;
        Klokkijken klokkijken = new Klokkijken();

        protected void Page_Load(object sender, EventArgs e)
        {
            minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", 5, 0);
            minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", 5, minutenVanLangewijzer);
        }
    }
}