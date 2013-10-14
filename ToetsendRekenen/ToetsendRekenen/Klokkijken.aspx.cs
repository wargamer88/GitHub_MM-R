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

        protected int goedUren;
        protected int goedMinuten;
        protected string goedsUren;
        protected string goedsMinuten;

        protected int Uren;
        protected int Minuten;
        protected string sUren;
        protected string sMinuten;
        protected string[] rndAntwoorden = new string[4];
        protected int tijd;

        Klokkijken klokkijken = new Klokkijken();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tijd = 5;
                goedUren = klokkijken.randomHour();
                goedsUren = klokkijken.timeLengthCheck(goedUren);
                minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", tijd, 0, goedUren);
                goedMinuten = Convert.ToInt16(minutenVanLangewijzer);
                goedsMinuten = klokkijken.timeLengthCheck(goedMinuten);
                minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", tijd, minutenVanLangewijzer, goedUren);

                antwoorden[0] = goedsUren + ':' + goedsMinuten;

                Uren = klokkijken.randomHour();
                sUren = klokkijken.timeLengthCheck(Uren);
                Minuten = (int)klokkijken.randomtijd("langeWijzer", tijd, 0, 0);
                sMinuten = klokkijken.timeLengthCheck(Minuten);
                antwoorden[1] = sUren + ':' + sMinuten;

                Uren = klokkijken.randomHour();
                sUren = klokkijken.timeLengthCheck(Uren);
                Minuten = (int)klokkijken.randomtijd("langeWijzer", tijd, 0, 0);
                sMinuten = klokkijken.timeLengthCheck(Minuten);
                antwoorden[2] = sUren + ':' + sMinuten;

                Uren = klokkijken.randomHour();
                sUren = klokkijken.timeLengthCheck(Uren);
                Minuten = (int)klokkijken.randomtijd("langeWijzer", tijd, 0, 0);
                sMinuten = klokkijken.timeLengthCheck(Minuten);
                antwoorden[3] = sUren + ':' + sMinuten;

                Random rnd = new Random();
                rndAntwoorden = antwoorden.OrderBy(x => rnd.Next()).ToArray();

                RblAntwoorden.Items[0].Text = rndAntwoorden[0];
                RblAntwoorden.Items[1].Text = rndAntwoorden[1];
                RblAntwoorden.Items[2].Text = rndAntwoorden[2];
                RblAntwoorden.Items[3].Text = rndAntwoorden[3];


                LblGoedFout.Visible = false;
                btnVolgendeVraag.Visible = false;

                Session["uur"] = goedsUren;
                Session["minuut"] = goedsMinuten;

            }
        }

        protected void RblAntwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            goedsUren = (string)Session["uur"];
            goedsMinuten = (string)Session["minuut"];
            string check;
            check = klokkijken.answerCheck(RblAntwoorden.SelectedItem.Text, goedsUren + ':' + goedsMinuten);
            LblGoedFout.Text = check;
            LblGoedFout.Visible = true;
            btnVolgendeVraag.Visible = true;
            RblAntwoorden.Enabled = false;
        }

        protected void btnVolgendeVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Klokkijken.aspx");
        }

        
    }
}