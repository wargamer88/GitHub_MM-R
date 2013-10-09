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
        protected int Minuten;
        protected string[] rndAntwoorden = new string[4];
        protected int tijd;

        Klokkijken klokkijken = new Klokkijken();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tijd = 5;
                Uren = klokkijken.randomHour();
                minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", tijd, 0, Uren);
                Minuten = Convert.ToInt16(minutenVanLangewijzer);
                minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", tijd, minutenVanLangewijzer, Uren);

                antwoorden[0] = Uren.ToString() + ':' + Minuten.ToString();

                Uren = klokkijken.randomHour();
                antwoorden[1] = Uren.ToString() + ':' + klokkijken.randomtijd("langeWijzer", tijd, 0, 0).ToString();

                Uren = klokkijken.randomHour();
                antwoorden[2] = Uren.ToString() + ':' + klokkijken.randomtijd("langeWijzer", tijd, 0, 0).ToString();

                Uren = klokkijken.randomHour();
                antwoorden[3] = Uren.ToString() + ':' + klokkijken.randomtijd("langeWijzer", tijd, 0, 0).ToString();

                Random rnd = new Random();
                rndAntwoorden = antwoorden.OrderBy(x => rnd.Next()).ToArray();

                RblAntwoorden.Items[0].Text = rndAntwoorden[0];
                RblAntwoorden.Items[1].Text = rndAntwoorden[1];
                RblAntwoorden.Items[2].Text = rndAntwoorden[2];
                RblAntwoorden.Items[3].Text = rndAntwoorden[3];


                LblGoedFout.Visible = false;
                btnVolgendeVraag.Visible = false;

                Session["uur"] = Uren;
                Session["minuut"] = Minuten;

            }
        }

        protected void RblAntwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            Uren = (int)Session["uur"];
            Minuten = (int)Session["minuut"];
            string check;
            check = klokkijken.answerCheck(RblAntwoorden.SelectedItem.Text, Uren.ToString() + ':' + Minuten.ToString());
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