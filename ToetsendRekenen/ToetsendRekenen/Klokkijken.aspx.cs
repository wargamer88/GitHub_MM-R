﻿using System;
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

        protected double AnswerMinutenVanLangewijzer1;
        protected double AnswerMinutenVanKortewijzer1;

        protected double AnswerMinutenVanLangewijzer2;
        protected double AnswerMinutenVanKortewijzer2;

        protected double AnswerMinutenVanLangewijzer3;
        protected double AnswerMinutenVanKortewijzer3;

        protected double AnswerMinutenVanLangewijzer4;
        protected double AnswerMinutenVanKortewijzer4;

        protected bool clockVisibility;
        protected bool answerClockVisibility;
        
        //goede antwoord variabelen
        protected int goedUren;
        protected int goedMinuten;
        protected string goedsUren;
        protected string goedsMinuten;
        protected string antwoord;
        protected string check;

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
        protected string[] rndAnalogAntwoorden;
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
            try
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
                            imgSunAndMoon1.Visible = false;
                            imgSunAndMoon2.Visible = false;
                            imgSunAndMoon3.Visible = false;
                            imgSunAndMoon4.Visible = false;
                            UitlegImgSunAndMoon.Visible = false;

                            lblCategorie.Text = "Analoog klokkijken";

                            clockVisibility = true;
                            digitalClock.Visible = false;
                            imgSunAndMoon.Visible = true;
                            answerClockVisibility = false;
                            RblAntwoorden.RepeatDirection = RepeatDirection.Vertical;
                            RblAntwoorden.CssClass = "";

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
                                    antwoorden[0] = klokkijken.uitgeschrevenAntwoordMaken(goedUren, goedMinuten);
                                    antwoord = antwoorden[0];
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
                                    antwoorden[1] = klokkijken.uitgeschrevenAntwoordMaken(Uren, Minuten);
                                } while (antwoorden[1] == antwoorden[0]);

                                //2e Fout antwoord genereren en opslaan
                                do
                                {
                                    Uren = klokkijken.randomHour();
                                    sUren = klokkijken.timeLengthCheck(Uren);
                                    Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                    sMinuten = klokkijken.timeLengthCheck(Minuten);
                                    antwoorden[2] = klokkijken.uitgeschrevenAntwoordMaken(Uren, Minuten);
                                } while (antwoorden[2] == antwoorden[0] | antwoorden[2] == antwoorden[1]);

                                //3e Fout antwoord genereren en opslaan
                                do
                                {
                                    Uren = klokkijken.randomHour();
                                    sUren = klokkijken.timeLengthCheck(Uren);
                                    Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                    sMinuten = klokkijken.timeLengthCheck(Minuten);
                                    antwoorden[3] = klokkijken.uitgeschrevenAntwoordMaken(Uren, Minuten);
                                } while (antwoorden[3] == antwoorden[0] | antwoorden[3] == antwoorden[1] | antwoorden[3] == antwoorden[2]);
                            }
                            #endregion

                            //Antwoorden[] randomizen naar rndAntwoorden[]
                            Random rnd = new Random();
                            rndAntwoorden = antwoorden.OrderBy(x => rnd.Next()).ToArray();

                            //RadioButtonList vullen
                            RblAntwoorden.Items[0].Text = rndAntwoorden[0];
                            RblAntwoorden.Items[1].Text = rndAntwoorden[1];
                            RblAntwoorden.Items[2].Text = rndAntwoorden[2];
                            RblAntwoorden.Items[3].Text = rndAntwoorden[3];

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
                            Session["Antwoord"] = antwoorden[0];
                        }
                        #endregion
                    }
                    else if (objResultaat.Categorie == "Digitaal")
                    {
                        #region Digitaal klokkijken
                        {
                            imgSunAndMoon1.Visible = false;
                            imgSunAndMoon2.Visible = false;
                            imgSunAndMoon3.Visible = false;
                            imgSunAndMoon4.Visible = false;
                            UitlegImgSunAndMoon.Visible = false;

                            lblCategorie.Text = "Digitaal klokkijken";

                            imgSunAndMoon.Visible = false;
                            digitalClock.Visible = true;
                            clockVisibility = false;
                            answerClockVisibility = false;
                            RblAntwoorden.RepeatDirection = RepeatDirection.Vertical;
                            RblAntwoorden.CssClass = "";
                           

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
                                    antwoorden[0] = klokkijken.uitgeschrevenAntwoordMaken(goedUren, goedMinuten); ;
                                    antwoord = goedsUren + " : " + goedsMinuten;
                                    digitalClock.Text = "<span style='font-size:100px; border:dashed 3px black'>" + antwoord + "</span>";

                                } while (klokkijken.PreventRepeatingQuestions(antwoorden[0], vragen));
                                vragen.Add(antwoorden[0]);

                                //1e Fout antwoord genereren en opslaan
                                do
                                {
                                    Uren = klokkijken.randomHour();
                                    sUren = klokkijken.timeLengthCheck(Uren);
                                    Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                    sMinuten = klokkijken.timeLengthCheck(Minuten);
                                    antwoorden[1] = klokkijken.uitgeschrevenAntwoordMaken(Uren, Minuten);
                                } while (antwoorden[1] == antwoorden[0]);

                                //2e Fout antwoord genereren en opslaan
                                do
                                {
                                    Uren = klokkijken.randomHour();
                                    sUren = klokkijken.timeLengthCheck(Uren);
                                    Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                    sMinuten = klokkijken.timeLengthCheck(Minuten);
                                    antwoorden[2] = klokkijken.uitgeschrevenAntwoordMaken(Uren, Minuten);
                                } while (antwoorden[2] == antwoorden[0] | antwoorden[2] == antwoorden[1]);

                                //3e Fout antwoord genereren en opslaan
                                do
                                {
                                    Uren = klokkijken.randomHour();
                                    sUren = klokkijken.timeLengthCheck(Uren);
                                    Minuten = (int)klokkijken.randomtijd("langeWijzer", subCategorie, 0, 0);
                                    sMinuten = klokkijken.timeLengthCheck(Minuten);
                                    antwoorden[3] = klokkijken.uitgeschrevenAntwoordMaken(Uren, Minuten);
                                } while (antwoorden[3] == antwoorden[0] | antwoorden[3] == antwoorden[1] | antwoorden[3] == antwoorden[2]);
                            }
                            #endregion

                            //Antwoorden[] randomizen naar rndAntwoorden[]
                            Random rnd = new Random();
                            rndAntwoorden = antwoorden.OrderBy(x => rnd.Next()).ToArray();

                            //RadioButtonList vullen
                            RblAntwoorden.Items[0].Text = rndAntwoorden[0];
                            RblAntwoorden.Items[1].Text = rndAntwoorden[1];
                            RblAntwoorden.Items[2].Text = rndAntwoorden[2];
                            RblAntwoorden.Items[3].Text = rndAntwoorden[3];

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
                            Session["Antwoord"] = antwoorden[0];
                        }
                        
                        #endregion
                    }
                    else if (objResultaat.Categorie == "Analoog-Digitaal")
                    {
                        #region Analoog naar digitaal
                        {
                            imgSunAndMoon1.Visible = false;
                            imgSunAndMoon2.Visible = false;
                            imgSunAndMoon3.Visible = false;
                            imgSunAndMoon4.Visible = false;
                            UitlegImgSunAndMoon.Visible = false;

                            lblCategorie.Text = "Analoog naar Digitaal";

                            imgSunAndMoon.Visible = true;
                            clockVisibility = true;
                            digitalClock.Visible = false;
                            answerClockVisibility = false;
                            RblAntwoorden.RepeatDirection = RepeatDirection.Vertical;
                            RblAntwoorden.CssClass = "";

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
                    else if (objResultaat.Categorie == "Digitaal-Analoog")
                    {
                        #region Digitaal naar analoog
                        {
                            imgSunAndMoon1.Visible = true;
                            imgSunAndMoon2.Visible = true;
                            imgSunAndMoon3.Visible = true;
                            imgSunAndMoon4.Visible = true;
                            UitlegImgSunAndMoon.Visible = false;

                            lblCategorie.Text = "Digitaal naar analoog";

                            imgSunAndMoon.Visible = false;
                            digitalClock.Visible = true;
                            clockVisibility = false;
                            answerClockVisibility = true;
                            RblAntwoorden.RepeatDirection = RepeatDirection.Horizontal;
                            


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
                                    antwoord = goedsUren + " : " + goedsMinuten;
                                    digitalClock.Text = "<span style='font-size:100px; border:dashed 3px black'>" + antwoord + "</span>";
                                    if (goedUren >= 6 && goedUren <= 17)
                                    {
                                        UitlegImgSunAndMoon.ImageUrl = "Images/Sun.png";
                                    }
                                    else
                                    {
                                        UitlegImgSunAndMoon.ImageUrl = "Images/Moon.png";
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
                            RblAntwoorden.Items[0].Value = rndAntwoorden[0];
                            if (Convert.ToInt16(RblAntwoorden.Items[0].Value.Substring(0, 2)) >= 6 && Convert.ToInt16(RblAntwoorden.Items[0].Value.Substring(0, 2)) <= 17)
                            {
                                imgSunAndMoon1.ImageUrl = "Images/Sun.png";
                            }
                            else
                            {
                                imgSunAndMoon1.ImageUrl = "Images/Moon.png";
                            }

                            RblAntwoorden.Items[1].Value = rndAntwoorden[1];
                            if (Convert.ToInt16(RblAntwoorden.Items[1].Value.Substring(0, 2)) >= 6 && Convert.ToInt16(RblAntwoorden.Items[1].Value.Substring(0, 2)) <= 17)
                            {
                                imgSunAndMoon2.ImageUrl = "Images/Sun.png";
                            }
                            else
                            {
                                imgSunAndMoon2.ImageUrl = "Images/Moon.png";
                            }

                            RblAntwoorden.Items[2].Value = rndAntwoorden[2];
                            if (Convert.ToInt16(RblAntwoorden.Items[2].Value.Substring(0, 2)) >= 6 && Convert.ToInt16(RblAntwoorden.Items[2].Value.Substring(0, 2)) <= 17)
                            {
                                imgSunAndMoon3.ImageUrl = "Images/Sun.png";
                            }
                            else
                            {
                                imgSunAndMoon3.ImageUrl = "Images/Moon.png";
                            }

                            RblAntwoorden.Items[3].Value = rndAntwoorden[3];
                            if (Convert.ToInt16(RblAntwoorden.Items[3].Value.Substring(0, 2)) >= 6 && Convert.ToInt16(RblAntwoorden.Items[3].Value.Substring(0, 2)) <= 17)
                            {
                                imgSunAndMoon4.ImageUrl = "Images/Sun.png";
                            }
                            else
                            {
                                imgSunAndMoon4.ImageUrl = "Images/Moon.png";
                            }

                            AnswerMinutenVanLangewijzer1 = Convert.ToDouble(rndAntwoorden[0].Substring(5, 2));
                            AnswerMinutenVanKortewijzer1 = klokkijken.randomtijd("korteWijzer", subCategorie, AnswerMinutenVanLangewijzer1, Convert.ToInt16(rndAntwoorden[0].Substring(0, 2)));

                            AnswerMinutenVanLangewijzer2 = Convert.ToDouble(rndAntwoorden[1].Substring(5, 2));
                            AnswerMinutenVanKortewijzer2 = klokkijken.randomtijd("korteWijzer", subCategorie, AnswerMinutenVanLangewijzer2, Convert.ToInt16(rndAntwoorden[1].Substring(0, 2)));

                            AnswerMinutenVanLangewijzer3 = Convert.ToDouble(rndAntwoorden[2].Substring(5, 2));
                            AnswerMinutenVanKortewijzer3 = klokkijken.randomtijd("korteWijzer", subCategorie, AnswerMinutenVanLangewijzer3, Convert.ToInt16(rndAntwoorden[2].Substring(0, 2)));

                            AnswerMinutenVanLangewijzer4 = Convert.ToDouble(rndAntwoorden[3].Substring(5, 2));
                            AnswerMinutenVanKortewijzer4 = klokkijken.randomtijd("korteWijzer", subCategorie, AnswerMinutenVanLangewijzer4, Convert.ToInt16(rndAntwoorden[3].Substring(0, 2)));

                            //labels verbergen
                            LblGoedFout.Visible = false;
                            btnVolgendeVraag.Visible = false;
                            lblUitlegAntwoord.Visible = false;

                            //alle nodige variabelen in de sessie zetten
                            Session["uur"] = goedsUren;
                            Session["minuut"] = goedsMinuten;
                            Session["Resultaat"] = objResultaat;
                            Session["vragenlijst"] = vragen;
                            Session["Antwoord"] = antwoorden[0];

                            Session["AnswerLang1"] = AnswerMinutenVanLangewijzer1;
                            Session["AnswerKort1"] = AnswerMinutenVanKortewijzer1;

                            Session["AnswerLang2"] = AnswerMinutenVanLangewijzer2;
                            Session["AnswerKort2"] = AnswerMinutenVanKortewijzer2;

                            Session["AnswerLang3"] = AnswerMinutenVanLangewijzer3;
                            Session["AnswerKort3"] = AnswerMinutenVanKortewijzer3;

                            Session["AnswerLang4"] = AnswerMinutenVanLangewijzer4;
                            Session["AnswerKort4"] = AnswerMinutenVanKortewijzer4;

                            Session["UitlegLang"] = minutenVanLangewijzer;
                            Session["UitlegKort"] = minutenVanKortewijzer;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(" + ex + ")</SCRIPT>");
            }
        }

        protected void RblAntwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //object resultaat ophalen
                objResultaat = (Resultaat)Session["Resultaat"];
                subCategorie = Convert.ToInt16(objResultaat.SubCategorie);

                if (objResultaat.Categorie == "Analoog")
                {
                    #region Analoog klokkijken
                    {
                        imgSunAndMoon1.Visible = false;
                        imgSunAndMoon2.Visible = false;
                        imgSunAndMoon3.Visible = false;
                        imgSunAndMoon4.Visible = false;
                        UitlegImgSunAndMoon.Visible = false;

                        //goede antwoord ophalen
                        goedsUren = (string)Session["uur"];
                        goedsMinuten = (string)Session["minuut"];
                        goedUren = Convert.ToInt16(goedsUren);
                        goedMinuten = Convert.ToInt16(goedsMinuten);
                        antwoord = (string)Session["Antwoord"];

                        //antwoord checken
                        check = klokkijken.answerCheckAnaloog(RblAntwoorden.SelectedItem.Value, antwoord);

                        if (check == "Dit antwoord is goed")
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
                        if (check == "Dit antwoord is goed")
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
                            
                            lblUitlegAntwoord.Text = "Het juiste antwoord is: <br />" + antwoord;
                            lblUitlegAntwoord.ForeColor = System.Drawing.Color.Green;
                            lblUitlegAntwoord.Visible = true;
                        }
                        #endregion

                        //objResultaat weer wegschrijven
                        Session["Resultaat"] = objResultaat;
                    }
                    #endregion
                }
                else if (objResultaat.Categorie == "Digitaal")
                {
                    #region Digitaal klokkijken
                    {
                        imgSunAndMoon1.Visible = false;
                        imgSunAndMoon2.Visible = false;
                        imgSunAndMoon3.Visible = false;
                        imgSunAndMoon4.Visible = false;
                        UitlegImgSunAndMoon.Visible = false;

                        //goede antwoord ophalen
                        goedsUren = (string)Session["uur"];
                        goedsMinuten = (string)Session["minuut"];
                        goedUren = Convert.ToInt16(goedsUren);
                        goedMinuten = Convert.ToInt16(goedsMinuten);
                        antwoord = (string)Session["Antwoord"];

                        //antwoord checken
                        check = klokkijken.answerCheckAnaloog(RblAntwoorden.SelectedItem.Value, antwoord);

                        if (check == "Dit antwoord is goed")
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
                        if (check == "Dit antwoord is goed")
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

                            lblUitlegAntwoord.Text = "Het juiste antwoord is: <br />" + antwoord;
                            lblUitlegAntwoord.ForeColor = System.Drawing.Color.Green;
                            lblUitlegAntwoord.Visible = true;
                        }
                        #endregion

                        //objResultaat weer wegschrijven
                        Session["Resultaat"] = objResultaat;
                    }
                    #endregion
                }
                else if (objResultaat.Categorie == "Analoog-Digitaal")
                {
                    #region Analoog naar digitaal
                    {
                        imgSunAndMoon1.Visible = false;
                        imgSunAndMoon2.Visible = false;
                        imgSunAndMoon3.Visible = false;
                        imgSunAndMoon4.Visible = false;
                        UitlegImgSunAndMoon.Visible = false;

                        //goede antwoord ophalen
                        goedsUren = (string)Session["uur"];
                        goedsMinuten = (string)Session["minuut"];
                        goedUren = Convert.ToInt16(goedsUren);
                        goedMinuten = Convert.ToInt16(goedsMinuten);

                        //antwoord checken
                        check = klokkijken.answerCheckAnaloogNaarDigitaal(RblAntwoorden.SelectedItem.Value, goedsUren + " : " + goedsMinuten);

                        if (check == "Dit antwoord is goed")
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
                        if (check == "Dit antwoord is goed")
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
                else if (objResultaat.Categorie == "Digitaal-Analoog")
                {
                    #region Digitaal naar analoog
                    {
                        imgSunAndMoon1.Visible = true;
                        imgSunAndMoon2.Visible = true;
                        imgSunAndMoon3.Visible = true;
                        imgSunAndMoon4.Visible = true;
                        UitlegImgSunAndMoon.Visible = true;

                        AnswerMinutenVanLangewijzer1 = (double)Session["AnswerLang1"];
                        AnswerMinutenVanKortewijzer1 = (double)Session["AnswerKort1"];
                                                     
                        AnswerMinutenVanLangewijzer2 = (double)Session["AnswerLang2"];
                        AnswerMinutenVanKortewijzer2 = (double)Session["AnswerKort2"];
                                                     
                        AnswerMinutenVanLangewijzer3 = (double)Session["AnswerLang3"];
                        AnswerMinutenVanKortewijzer3 = (double)Session["AnswerKort3"];
                                                     
                        AnswerMinutenVanLangewijzer4 = (double)Session["AnswerLang4"];
                        AnswerMinutenVanKortewijzer4 = (double)Session["AnswerKort4"];

                        minutenVanLangewijzer = (double)Session["UitlegLang"];
                        minutenVanKortewijzer = (double)Session["UitlegKort"];

                        //goede antwoord ophalen
                        goedsUren = (string)Session["uur"];
                        goedsMinuten = (string)Session["minuut"];
                        goedUren = Convert.ToInt16(goedsUren);
                        goedMinuten = Convert.ToInt16(goedsMinuten);

                        //antwoord checken
                        check = klokkijken.answerCheckAnaloogNaarDigitaal(RblAntwoorden.SelectedItem.Value, goedsUren + " : " + goedsMinuten);

                        if (check == "Dit antwoord is goed")
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
                        spacer.InnerHtml = "<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />";
                        LblGoedFout.Text = check;
                        LblGoedFout.Visible = true;
                        if (check == "Dit antwoord is goed")
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
                                    //lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";

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
                                    //lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";

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



                                    //lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";

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
                                    //lblUitlegAntwoord.Text = "Het juiste antwoord is: " + goedsUren + " : " + goedsMinuten + " uur.";
                                    break;
                            }
                            //divUitleg.InnerHtml = uitleg;
                            lblUitlegAntwoord.ForeColor = System.Drawing.Color.Green;
                            lblUitlegAntwoord.Visible = true;
                        }
                        #endregion

                        divUitleg.InnerHtml = "Het antwoord is:";
                        lblUitlegAntwoord.Text = "";

                        

                        //objResultaat weer wegschrijven
                        Session["Resultaat"] = objResultaat;
                    }
                    #endregion
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "setAnswerclocksAfterRBLselection", "setAnswerclocksAfterRBLselection();", true);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(" + ex + ")</SCRIPT>");
            }
        }

        protected void btnVolgendeVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Klokkijken.aspx");
        }

        
    }
}