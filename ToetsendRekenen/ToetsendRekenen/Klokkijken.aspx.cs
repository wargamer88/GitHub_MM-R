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
        protected double minutenVanLangewijzer;
        protected double minutenVanKortewijzer;
        protected int Uren;
        Klokkijken klokkijken = new Klokkijken();


        protected void Page_Load(object sender, EventArgs e)
        {

            minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", 5, 0, Uren);
            minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", 5, minutenVanLangewijzer, Uren);
        }

        protected void Antwoord1_CheckedChanged(object sender, EventArgs e)
        {
            minutenVanKortewijzer = Math.
            klokkijken.answerCheck(Antwoord1.Text, minutenVanKortewijzer.ToString() + ':' + minutenVanLangewijzer.ToString());
        }

        protected void Antwoord2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Antwoord3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Antwoord4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}