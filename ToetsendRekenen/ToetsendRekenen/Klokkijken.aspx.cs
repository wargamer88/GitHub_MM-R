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
        //klok variabelen
        protected double minutenVanLangewijzer;
        protected double minutenVanKortewijzer;
        
        //goede antwoord variabelen
        protected int goedUren;
        protected int goedMinuten;
        protected string goedsUren;
        protected string goedsMinuten;

        //foute antwoord variabelen
        protected int Uren;
        protected int Minuten;
        protected string sUren;
        protected string sMinuten;

        //antwoorden arrays
        protected string[] antwoorden = new string[4];
        protected string[] rndAntwoorden = new string[4];

        //Session variabelen
        protected int subCategorie;
        protected int voortgang;
        protected int aantalsterren;

        //class instanties
        Resultaat objResultaat = new Resultaat();
        Klokkijken klokkijken = new Klokkijken();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //object en subcategorie vullen
                objResultaat = (Resultaat)Session["Resultaat"];
                subCategorie = Convert.ToInt16(objResultaat.SubCategorie);

                //Sterren laden
                int aantalsterren = (int)Session["AantalSterren"];
                if (aantalsterren == 1)
                {
                    imgSter1.ImageUrl = "Images/Ster.png";
                }
                else if (aantalsterren == 2)
                {
                    imgSter1.ImageUrl = "Images/Ster.png";
                    imgSter2.ImageUrl = "Images/Ster.png";
                }
                else if (aantalsterren == 3)
                {
                    imgSter1.ImageUrl = "Images/Ster.png";
                    imgSter2.ImageUrl = "Images/Ster.png";
                    imgSter3.ImageUrl = "Images/Ster.png";
                }
                else if (aantalsterren == 4)
                {
                    imgSter1.ImageUrl = "Images/Ster.png";
                    imgSter2.ImageUrl = "Images/Ster.png";
                    imgSter3.ImageUrl = "Images/Ster.png";
                    imgSter4.ImageUrl = "Images/Ster.png";
                }
                else if (aantalsterren == 5)
                {
                    imgSter1.ImageUrl = "Images/Ster.png";
                    imgSter2.ImageUrl = "Images/Ster.png";
                    imgSter3.ImageUrl = "Images/Ster.png";
                    imgSter4.ImageUrl = "Images/Ster.png";
                    imgSter5.ImageUrl = "Images/Ster.png";
                }

                //voortgang verwerken
                voortgang = (int)Session["Voortgang"];
                if (voortgang != 50)
                {
                    voortgang = voortgang + 1;
                }
                else if (voortgang >= 50)
                {
                    Response.Redirect("Resultaat.aspx");
                }
                lbVoortgang.Text = Convert.ToString(voortgang);
                Session["Voortgang"] = voortgang;

                //kloktijden aanmaken en goede antwoord opslaan
                goedUren = klokkijken.randomHour();
                goedsUren = klokkijken.timeLengthCheck(goedUren);
                minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", subCategorie, 0, goedUren);
                goedMinuten = Convert.ToInt16(minutenVanLangewijzer);
                goedsMinuten = klokkijken.timeLengthCheck(goedMinuten);
                minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", subCategorie, minutenVanLangewijzer, goedUren);
                antwoorden[0] = goedsUren + ':' + goedsMinuten;

                //Fout antwoord genereren en opslaan
                Uren = klokkijken.randomHour();
                sUren = klokkijken.timeLengthCheck(Uren);
                Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                sMinuten = klokkijken.timeLengthCheck(Minuten);
                antwoorden[1] = sUren + ':' + sMinuten;

                //Fout antwoord genereren en opslaan
                Uren = klokkijken.randomHour();
                sUren = klokkijken.timeLengthCheck(Uren);
                Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                sMinuten = klokkijken.timeLengthCheck(Minuten);
                antwoorden[2] = sUren + ':' + sMinuten;

                //Fout antwoord genereren en opslaan
                Uren = klokkijken.randomHour();
                sUren = klokkijken.timeLengthCheck(Uren);
                Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                sMinuten = klokkijken.timeLengthCheck(Minuten);
                antwoorden[3] = sUren + ':' + sMinuten;

                //Aatwoorden[] ranomizen naar rndAntwoorden[]
                Random rnd = new Random();
                rndAntwoorden = antwoorden.OrderBy(x => rnd.Next()).ToArray();

                //RadioButtonList vullen
                RblAntwoorden.Items[0].Text = rndAntwoorden[0];
                RblAntwoorden.Items[1].Text = rndAntwoorden[1];
                RblAntwoorden.Items[2].Text = rndAntwoorden[2];
                RblAntwoorden.Items[3].Text = rndAntwoorden[3];

                //labels verbergen
                LblGoedFout.Visible = false;
                btnVolgendeVraag.Visible = false;

                //goede antwoord en objResultaat in de sessie zetten 
                Session["uur"] = goedsUren;
                Session["minuut"] = goedsMinuten;
                Session["Resultaat"] = objResultaat;
            }
        }

        protected void RblAntwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            //object resultaat ophalen
            objResultaat = (Resultaat)Session["Resultaat"];

            //goede antwoord ophalen
            goedsUren = (string)Session["uur"];
            goedsMinuten = (string)Session["minuut"];

            //antwoord checken
            string check;
            check = klokkijken.answerCheck(RblAntwoorden.SelectedItem.Text, goedsUren + ':' + goedsMinuten);

            if (check == "Dit andwoord is goed")
            {
                objResultaat.AantalGoed += 1;
            }
            else if (check == "Dit antwoord is fout")
            {
                objResultaat.AantalFout += 1;
            }

            //sterren verwerken
            aantalsterren = (int)Session["AantalSterren"];
            if (objResultaat.AantalGoed == 10)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                aantalsterren = aantalsterren + 1;
                Session["AantalSterren"] = aantalsterren;
            }
            else if (objResultaat.AantalGoed == 20)
            {
                aantalsterren = aantalsterren + 1;
                Session["AantalSterren"] = aantalsterren;
            }
            else if (objResultaat.AantalGoed == 30)
            {
                aantalsterren = aantalsterren + 1;
                Session["AantalSterren"] = aantalsterren;
            }
            else if (objResultaat.AantalGoed == 40)
            {
                aantalsterren = aantalsterren + 1;
                Session["AantalSterren"] = aantalsterren;
            }
            else if (objResultaat.AantalGoed == 50)
            {
                aantalsterren = aantalsterren + 1;
                Session["AantalSterren"] = aantalsterren;
            }

            //alle controls laten verschijnen/verdwijnen en enablen/disablen
            LblGoedFout.Text = check;
            LblGoedFout.Visible = true;
            btnVolgendeVraag.Visible = true;
            RblAntwoorden.Enabled = false;

            //objResultaat weer wegschrijven
            Session["Resultaat"] = objResultaat;
        }

        protected void btnVolgendeVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Klokkijken.aspx");
        }

        
    }
}