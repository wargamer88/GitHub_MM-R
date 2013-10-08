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
        protected string[] antwoorden = new string[4];
        protected int Uren;
        protected string[] rndAntwoorden = new string[4];
        protected int tijd;

        Klokkijken klokkijken = new Klokkijken();


        protected void Page_Load(object sender, EventArgs e)
        {
            tijd = 1;
            Uren = klokkijken.randomHour();
            minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", tijd, 0, Uren);
            minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", tijd, minutenVanLangewijzer, Uren);

            antwoorden[0] = minutenVanKortewijzer.ToString() + ':' + minutenVanLangewijzer.ToString();

            antwoorden[1] = klokkijken.randomtijd("langeWijzer", tijd, 0, 0).ToString() + ":" +
                            klokkijken.randomtijd("korteWijzer", tijd, minutenVanLangewijzer, 0).ToString();

            antwoorden[2] = klokkijken.randomtijd("langeWijzer", tijd, 0, 0).ToString() + ":" +
                            klokkijken.randomtijd("korteWijzer", tijd, minutenVanLangewijzer, 0).ToString();

            antwoorden[3] = klokkijken.randomtijd("langeWijzer", tijd, 0, 0).ToString() + ":" +
                            klokkijken.randomtijd("korteWijzer", tijd, minutenVanLangewijzer, 0).ToString();

            //Random rnd = new Random();
            //rndAntwoorden = rndAntwoorden.OrderBy(x => rnd.Next()).ToArray();

            Antwoord1.Text = antwoorden[0];
            Antwoord2.Text = antwoorden[1];
            Antwoord3.Text = antwoorden[2];
            Antwoord4.Text = antwoorden[3];


            LblGoedFout.Visible = false;
            btnVolgendeVraag.Visible = false;
        }

        protected void Antwoord1_CheckedChanged(object sender, EventArgs e)
        {
            string check;
            check =  klokkijken.answerCheck(Antwoord1.Text, minutenVanKortewijzer.ToString() + ':' + minutenVanLangewijzer.ToString());
            LblGoedFout.Text = check;
            LblGoedFout.Visible = true;
            btnVolgendeVraag.Visible = true;
        }

        protected void Antwoord2_CheckedChanged(object sender, EventArgs e)
        {
            string check;
            check = klokkijken.answerCheck(Antwoord1.Text, minutenVanKortewijzer.ToString() + ':' + minutenVanLangewijzer.ToString());
            LblGoedFout.Text = check;
            LblGoedFout.Visible = true;
            btnVolgendeVraag.Visible = true;
        }

        protected void Antwoord3_CheckedChanged(object sender, EventArgs e)
        {
            string check;
            check = klokkijken.answerCheck(Antwoord1.Text, minutenVanKortewijzer.ToString() + ':' + minutenVanLangewijzer.ToString());
            LblGoedFout.Text = check;
            LblGoedFout.Visible = true;
            btnVolgendeVraag.Visible = true;
        }

        protected void Antwoord4_CheckedChanged(object sender, EventArgs e)
        {
            string check;
            check = klokkijken.answerCheck(Antwoord1.Text, minutenVanKortewijzer.ToString() + ':' + minutenVanLangewijzer.ToString());
            LblGoedFout.Text = check;
            LblGoedFout.Visible = true;
            btnVolgendeVraag.Visible = true;
        }
    }
}