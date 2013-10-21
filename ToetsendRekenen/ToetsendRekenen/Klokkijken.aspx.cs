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

        //uitleg variabelen
        protected string uitleg;
        protected string tijdzone; // dag/nacht

        //arrays
        protected string[] antwoorden = new string[4];
        protected string[] rndAntwoorden = new string[4];
        protected List<string> vragen;

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
                //object, subcategorie en vragen list vullen
                objResultaat = (Resultaat)Session["Resultaat"];
                subCategorie = Convert.ToInt16(objResultaat.SubCategorie);
                vragen = (List<string>)Session["vragenlijst"];
                if (vragen == null)
                {
                    vragen = new List<string>();
                }

                if (objResultaat.Categorie == "Analoog")
                {
                    #region Analoog klokkijken
                    { 
                        
                    }
                    #endregion
                }
                else if (objResultaat.Categorie == "Digitaal")
                {
                    #region Digitaal klokkijken
                    { }
                    #endregion
                }
                else if (objResultaat.Categorie == "Analoog naar digitaal")
                {
                    #region Analoog naar digitaal
                    {
                        #region sterren laden
                        {
                            aantalsterren = (int)Session["AantalSterren"];
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
                        }
                        #endregion

                        #region voortgang verwerken
                        {
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
                        }
                        #endregion

                        #region goede/foute tijden genereren
                        {
                            //kloktijden aanmaken en goede antwoord opslaan en dag/nacht plaatje toevoegen
                            do
                            {
                                goedUren = klokkijken.randomHour();
                                goedsUren = klokkijken.timeLengthCheck(goedUren);
                                minutenVanLangewijzer = klokkijken.randomtijd("langeWijzer", subCategorie, 0, goedUren);
                                goedMinuten = Convert.ToInt16(minutenVanLangewijzer);
                                goedsMinuten = klokkijken.timeLengthCheck(goedMinuten);
                                minutenVanKortewijzer = klokkijken.randomtijd("korteWijzer", subCategorie, minutenVanLangewijzer, goedUren);
                                antwoorden[0] = goedsUren + " : " + goedsMinuten;
                                if (goedUren >= 6 && goedUren <= 17)
                                {
                                    imgSunAndMoon.ImageUrl = "Images/Sun.png";
                                }
                                else
                                {
                                    imgSunAndMoon.ImageUrl = "Images/Moon.png";
                                }

                            } while (klokkijken.PreventRepeatingQuestions(antwoorden[0], vragen));
                            vragen.Add(antwoorden[0]);

                            //1e Fout antwoord genereren en opslaan
                            do
                            {
                                Uren = klokkijken.randomHour();
                                sUren = klokkijken.timeLengthCheck(Uren);
                                Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                sMinuten = klokkijken.timeLengthCheck(Minuten);
                                antwoorden[1] = sUren + " : " + sMinuten;
                            } while (antwoorden[1] == antwoorden[0]);

                            //2e Fout antwoord genereren en opslaan
                            do
                            {
                                Uren = klokkijken.randomHour();
                                sUren = klokkijken.timeLengthCheck(Uren);
                                Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                sMinuten = klokkijken.timeLengthCheck(Minuten);
                                antwoorden[2] = sUren + " : " + sMinuten;
                            } while (antwoorden[2] == antwoorden[0] | antwoorden[2] == antwoorden[1]);

                            //3e Fout antwoord genereren en opslaan
                            do
                            {
                                Uren = klokkijken.randomHour();
                                sUren = klokkijken.timeLengthCheck(Uren);
                                Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                sMinuten = klokkijken.timeLengthCheck(Minuten);
                                antwoorden[3] = sUren + " : " + sMinuten;
                            } while (antwoorden[3] == antwoorden[0] | antwoorden[3] == antwoorden[1] | antwoorden[3] == antwoorden[2]);
                        }
                        #endregion

                        //Antwoorden[] randomizen naar rndAntwoorden[]
                        Random rnd = new Random();
                        rndAntwoorden = antwoorden.OrderBy(x => rnd.Next()).ToArray();

                        //RadioButtonList vullen
                        RblAntwoorden.Items[0].Text = rndAntwoorden[0] + " uur";
                        RblAntwoorden.Items[1].Text = rndAntwoorden[1] + " uur";
                        RblAntwoorden.Items[2].Text = rndAntwoorden[2] + " uur";
                        RblAntwoorden.Items[3].Text = rndAntwoorden[3] + " uur";

                        RblAntwoorden.Items[0].Value = rndAntwoorden[0];
                        RblAntwoorden.Items[1].Value = rndAntwoorden[1];
                        RblAntwoorden.Items[2].Value = rndAntwoorden[2];
                        RblAntwoorden.Items[3].Value = rndAntwoorden[3];

                        //labels verbergen
                        LblGoedFout.Visible = false;
                        btnVolgendeVraag.Visible = false;
                        lblUitlegAntwoord.Visible = false;

                        //alle nodige variabelen in de sessie zetten
                        Session["uur"] = goedsUren;
                        Session["minuut"] = goedsMinuten;
                        Session["Resultaat"] = objResultaat;
                        Session["vragenlijst"] = vragen;
                    }
                    #endregion
                }
                else if (objResultaat.Categorie == "Digitaal naar analoog")
                {
                    #region Digitaal naar analoog
                    {

                    }
                    #endregion
                }
            }
        }

        protected void RblAntwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            //object resultaat ophalen
            objResultaat = (Resultaat)Session["Resultaat"];
            subCategorie = Convert.ToInt16(objResultaat.SubCategorie);

            if (objResultaat.Categorie == "Analoog")
            {
                #region Analoog klokkijken
                { }
                #endregion
            }
            else if (objResultaat.Categorie == "Digitaal")
            {
                #region Digitaal klokkijken
                { }
                #endregion
            }
            else if (objResultaat.Categorie == "Analoog naar digitaal")
            {
                #region Analoog naar digitaal
                {
                    //object resultaat ophalen
                    objResultaat = (Resultaat)Session["Resultaat"];
                    subCategorie = Convert.ToInt16(objResultaat.SubCategorie);

                    //goede antwoord ophalen
                    goedsUren = (string)Session["uur"];
                    goedsMinuten = (string)Session["minuut"];
                    goedUren = Convert.ToInt16(goedsUren);
                    goedMinuten = Convert.ToInt16(goedsMinuten);

                    //antwoord checken
                    string check;
                    check = klokkijken.answerCheck(RblAntwoorden.SelectedItem.Value, goedsUren + " : " + goedsMinuten);

                    if (check == "Dit andwoord is goed")
                    {
                        objResultaat.AantalGoed += 1;
                    }
                    else if (check == "Dit antwoord is fout")
                    {
                        objResultaat.AantalFout += 1;
                    }

                    #region sterren verwerken
                    {
                        //sterren verwerken
                        aantalsterren = (int)Session["AantalSterren"];
                        if (objResultaat.AantalGoed == 10)
                        {
                            imgSter1.ImageUrl = "Images/Ster.png";
                            if (aantalsterren == 0)
                            {
                                aantalsterren = aantalsterren + 1;
                            }
                            Session["AantalSterren"] = aantalsterren;
                        }
                        else if (objResultaat.AantalGoed == 20)
                        {
                            if (aantalsterren == 1)
                            {
                                aantalsterren = aantalsterren + 1;
                            }
                            Session["AantalSterren"] = aantalsterren;
                        }
                        else if (objResultaat.AantalGoed == 30)
                        {
                            if (aantalsterren == 2)
                            {
                                aantalsterren = aantalsterren + 1;
                            }
                            Session["AantalSterren"] = aantalsterren;
                        }
                        else if (objResultaat.AantalGoed == 40)
                        {
                            if (aantalsterren == 3)
                            {
                                aantalsterren = aantalsterren + 1;
                            }
                            Session["AantalSterren"] = aantalsterren;
                        }
                        else if (objResultaat.AantalGoed == 50)
                        {
                            if (aantalsterren == 4)
                            {
                                aantalsterren = aantalsterren + 1;
                            }
                            Session["AantalSterren"] = aantalsterren;
                        }
                    }
                    #endregion

                    //alle controls laten verschijnen/verdwijnen en enablen/disablen
                    LblGoedFout.Text = check;
                    LblGoedFout.Visible = true;
                    if (check == "Dit andwoord is goed")
                    {
                        LblGoedFout.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        LblGoedFout.ForeColor = System.Drawing.Color.Red;
                    }
                    btnVolgendeVraag.Visible = true;
                    RblAntwoorden.Enabled = false;

                    #region uitleg maken
                    {
                        //uitleg weergeven
                        switch (subCategorie)
                        {
                            case 15: //15 minuten
                                uitleg = "Het is nu ";
                                if (goedUren >= 6 && goedUren <= 17)
                                {
                                    //dag
                                    tijdzone = "dag";
                                    uitleg += "dag. Dit is te zien aan de zon.<br />";
                                }
                                else
                                {
                                    //nacht
                                    tijdzone = "nacht";
                                    uitleg += "nacht. Dit is te zien aan de maan.<br />";
                                }
                                uitleg += "De korte wijzer staat op of na de ";
                                if (goedUren >= 13)
                                {
                                    goedUren = goedUren - 12;
                                }
                                uitleg += goedUren + ".<br /> Dus zijn de uren " + goedsUren + ", omdat het " + tijdzone + " is.<br /> De lange wijzer staat op of tussen de ";

                                switch (goedMinuten)
                                {
                                    case 0:
                                        uitleg += "12. Dus zijn de minuten 00.<br />";
                                        break;
                                    case 15:
                                        uitleg += "3. Dus zijn de minuten 15.<br />";
                                        break;
                                    case 30:
                                        uitleg += "6. Dus zijn de minuten 30.<br />";
                                        break;
                                    case 45:
                                        uitleg += "9. Dus zijn de minuten 45.<br />";
                                        break;
                                }
                                lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";

                                break;
                            case 10: //10 minuten
                                uitleg = "Het is nu ";
                                if (goedUren >= 6 && goedUren <= 17)
                                {
                                    //dag
                                    tijdzone = "dag";
                                    uitleg += "dag. Dit is te zien aan de zon.<br />";
                                }
                                else
                                {
                                    //nacht
                                    tijdzone = "nacht";
                                    uitleg += "nacht. Dit is te zien aan de maan.<br />";
                                }
                                uitleg += "De korte wijzer staat op of na de ";
                                if (goedUren >= 13)
                                {
                                    goedUren = goedUren - 12;
                                }
                                uitleg += goedUren + ".<br /> Dus zijn de uren " + goedsUren + ", omdat het " + tijdzone + " is.<br /> De lange wijzer staat op of tussen de ";

                                switch (goedMinuten)
                                {
                                    case 0:
                                        uitleg += "12. Dus zijn de minuten 00.<br />";
                                        break;
                                    case 10:
                                        uitleg += "2. Dus zijn de minuten 10.<br />";
                                        break;
                                    case 20:
                                        uitleg += "4. Dus zijn de minuten 20.<br />";
                                        break;
                                    case 30:
                                        uitleg += "6. Dus zijn de minuten 30.<br />";
                                        break;
                                    case 40:
                                        uitleg += "8. Dus zijn de minuten 40.<br />";
                                        break;
                                    case 50:
                                        uitleg += "10. Dus zijn de minuten 50.<br />";
                                        break;
                                }
                                lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";

                                break;
                            case 5: //5 minuten
                                uitleg = "Het is nu ";
                                if (goedUren >= 6 && goedUren <= 17)
                                {
                                    //dag
                                    tijdzone = "dag";
                                    uitleg += "dag. Dit is te zien aan de zon.<br />";
                                }
                                else
                                {
                                    //nacht
                                    tijdzone = "nacht";
                                    uitleg += "nacht. Dit is te zien aan de maan.<br />";
                                }
                                uitleg += "De korte wijzer staat op of na de ";
                                if (goedUren >= 13)
                                {
                                    goedUren = goedUren - 12;
                                }
                                uitleg += goedUren + ".<br /> Dus zijn de uren " + goedsUren + ", omdat het " + tijdzone + " is.<br /> De lange wijzer staat op of tussen de ";


                                switch (goedMinuten)
                                {
                                    case 0:
                                        uitleg += "12. Dus zijn de minuten 00.<br />";
                                        break;
                                    case 5:
                                        uitleg += "1. Dus zijn de minuten 05.<br />";
                                        break;
                                    case 10:
                                        uitleg += "2. Dus zijn de minuten 10.<br />";
                                        break;
                                    case 15:
                                        uitleg += "3. Dus zijn de minuten 15.<br />";
                                        break;
                                    case 20:
                                        uitleg += "4. Dus zijn de minuten 20.<br />";
                                        break;
                                    case 25:
                                        uitleg += "5. Dus zijn de minuten 25.<br />";
                                        break;
                                    case 30:
                                        uitleg += "6. Dus zijn de minuten 30.<br />";
                                        break;
                                    case 35:
                                        uitleg += "7. Dus zijn de minuten 35.<br />";
                                        break;
                                    case 40:
                                        uitleg += "8. Dus zijn de minuten 40.<br />";
                                        break;
                                    case 45:
                                        uitleg += "9. Dus zijn de minuten 45.<br />";
                                        break;
                                    case 50:
                                        uitleg += "10. Dus zijn de minuten 50.<br />";
                                        break;
                                    case 55:
                                        uitleg += "11. Dus zijn de minuten 55.<br />";
                                        break;
                                }



                                lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";

                                break;
                            case 1: //1 minuut
                                uitleg = "Het is nu ";
                                if (goedUren >= 6 && goedUren <= 17)
                                {
                                    //dag
                                    tijdzone = "dag";
                                    uitleg += "dag. Dit is te zien aan de zon.<br />";
                                }
                                else
                                {
                                    //nacht
                                    tijdzone = "nacht";
                                    uitleg += "nacht. Dit is te zien aan de maan.<br />";
                                }
                                uitleg += "De korte wijzer staat op of na de ";
                                if (goedUren >= 13)
                                {
                                    goedUren = goedUren - 12;
                                }
                                uitleg += goedUren + ".<br /> Dus zijn de uren " + goedsUren + ", omdat het " + tijdzone + " is.<br /> De lange wijzer staat op of tussen de ";

                                if (goedMinuten >= 0 && goedMinuten <= 4)
                                {
                                    uitleg += "12. <br />Als je lange wijzer op de 12 staat is het 0 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 12 zit.<br />" +
                                        "Dit tel je dan bij de 0 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 5 && goedMinuten <= 9)
                                {
                                    uitleg += "1. <br />Als je lange wijzer op de 1 staat is het 5 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 1 zit.<br />" +
                                        "Dit tel je dan bij de 5 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 10 && goedMinuten <= 14)
                                {
                                    uitleg += "2. <br />Als je lange wijzer op de 2 staat is het 10 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 2 zit.<br />" +
                                        "Dit tel je dan bij de 10 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 15 && goedMinuten <= 19)
                                {
                                    uitleg += "3. <br />Als je lange wijzer op de 3 staat is het 15 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 3 zit.<br />" +
                                        "Dit tel je dan bij de 15 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 20 && goedMinuten <= 24)
                                {
                                    uitleg += "4. <br />Als je lange wijzer op de 4 staat is het 20 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 4 zit.<br />" +
                                        "Dit tel je dan bij de 20 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 25 && goedMinuten <= 29)
                                {
                                    uitleg += "5. <br />Als je lange wijzer op de 5 staat is het 25 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 5 zit.<br />" +
                                        "Dit tel je dan bij de 25 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 30 && goedMinuten <= 34)
                                {
                                    uitleg += "6. <br />Als je lange wijzer op de 6 staat is het 30 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 6 zit.<br />" +
                                        "Dit tel je dan bij de 30 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 35 && goedMinuten <= 39)
                                {
                                    uitleg += "7. <br />Als je lange wijzer op de 7 staat is het 35 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 7 zit.<br />" +
                                        "Dit tel je dan bij de 35 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 40 && goedMinuten <= 44)
                                {
                                    uitleg += "8. <br />Als je lange wijzer op de 8 staat is het 40 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 8 zit.<br />" +
                                        "Dit tel je dan bij de 40 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 45 && goedMinuten <= 49)
                                {
                                    uitleg += "9. <br />Als je lange wijzer op de 9 staat is het 45 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 9 zit.<br />" +
                                        "Dit tel je dan bij de 45 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 50 && goedMinuten <= 54)
                                {
                                    uitleg += "10. <br />Als je lange wijzer op de 10 staat is het 50 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 10 zit.<br />" +
                                        "Dit tel je dan bij de 50 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                else if (goedMinuten >= 55 && goedMinuten <= 59)
                                {
                                    uitleg += "11. <br />Als je lange wijzer op de 11 staat is het 55 minuten. <br />Dan tel je hoeveel minuten er tussen de lange wijzer en de 11 zit.<br />" +
                                        "Dit tel je dan bij de 55 minuten die al hebt op. <br />Bij deze vraag kom je dan op " + goedMinuten + ".";
                                }
                                lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";
                                break;
                        }
                        divUitleg.InnerHtml = uitleg;
                        lblUitlegAntwoord.ForeColor = System.Drawing.Color.Green;
                        lblUitlegAntwoord.Visible = true;
                    }
                    #endregion

                    //objResultaat weer wegschrijven
                    Session["Resultaat"] = objResultaat;
                }
                #endregion
            }
            else if (objResultaat.Categorie == "Digitaal naar analoog")
            {
                #region Digitaal naar analoog
                {

                }
                #endregion
            }
        }

        protected void btnVolgendeVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Klokkijken.aspx");
        }

        
    }
}