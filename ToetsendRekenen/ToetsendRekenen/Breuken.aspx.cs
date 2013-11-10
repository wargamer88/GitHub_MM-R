using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        Breuken B = new Breuken();
        decimal Antwoord = 0;
        List<string> vragen;
        string breuk = "";
        Random R = new Random();

        //Sessie
        Resultaat objResultaat = new Resultaat();

        //Sessie variabelen
        protected string subCategorie;
        protected string Categorie;
        protected int voortgang;
        protected int aantalsterren;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    objResultaat = (Resultaat)Session["Resultaat"];
                        subCategorie = Convert.ToString(objResultaat.SubCategorie);
                        Categorie = Convert.ToString(objResultaat.Categorie);
                        vragen = (List<string>)Session["vragenlijst"];
                        tbantwoordD.Attributes.Add("autocomplete", "off");
                        tbantwoordB.Attributes.Add("autocomplete", "off");
                        if (vragen == null)
                        {
                            vragen = new List<string>();
                        }
                        btnvolgende.Visible = false;
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
                        #region BnD0-1
                        if (Categorie == "Breuk-Komma")
                        {
                            tbantwoordD.Visible = true;
                            tbantwoordB.Visible = false;
                            lblspel.Text = "Breuken spel" + Categorie + " " + subCategorie;
                            lblTekst.Text = "Reken de breuk om naar komma getal.";
                            if (subCategorie == "0-1")
                            {
                                do
                                {

                                    string[,] BrArray = B.BreukArray();
                                    B.GangbareBreuken(BrArray);
                                    breuk = B.RandomBreuk();
                                    Antwoord = B.RandomAntwoord(breuk);
                                    lblBreuk.Text = breuk;

                                }
                                while (B.PreventRepeatingQuestions(breuk, vragen));
                                vragen.Add(breuk);
                            }
                        #endregion
                            #region BnD0-10
                            else if (subCategorie == "0-10")
                            {
                                do
                                {
                                    string[,] BrArray = B.BreukArray();
                                    B.GangbareBreuken(BrArray);

                                    breuk = B.RandomBreuk();

                                    string[] split = breuk.Split("/".ToArray());
                                    int getal1 = Convert.ToInt16(split[0]);
                                    int getal2 = Convert.ToInt16(split[1]);

                                    int helegetal = R.Next(0, 10);

                                    int breukgetal1 = helegetal * getal2;
                                    breukgetal1 = breukgetal1 + getal1;

                                    breuk = breukgetal1 + "/" + getal2;

                                    Antwoord = B.RandomAntwoord(breuk);
                                    lblBreuk.Text = breuk;
                                }
                                while (B.PreventRepeatingQuestions(breuk, vragen));
                                vragen.Add(breuk);
                            }
                            #region BnD0-100
                            else if (subCategorie == "0-100")
                            {
                                do
                                {
                                    string[,] BrArray = B.BreukArray();
                                    B.GangbareBreuken(BrArray);

                                    breuk = B.RandomBreuk();

                                    string[] split = breuk.Split("/".ToArray());
                                    int getal1 = Convert.ToInt16(split[0]);
                                    int getal2 = Convert.ToInt16(split[1]);

                                    int helegetal = R.Next(0, 100);

                                    int breukgetal1 = helegetal * getal2;
                                    breukgetal1 = breukgetal1 + getal1;

                                    breuk = breukgetal1 + "/" + getal2;

                                    Antwoord = B.RandomAntwoord(breuk);
                                    lblBreuk.Text = breuk;
                                }
                                while (B.PreventRepeatingQuestions(breuk, vragen));
                                vragen.Add(breuk);
                            }
                            #endregion
                        }
                            #endregion
                        
                        if (Categorie == "Komma-Breuk")
                        {
                            #region DnB0-1
                            tbantwoordD.Visible = false;
                            tbantwoordB.Visible = true;
                            bool GF = false;
                            lblspel.Text = "Breuken spel" + Categorie + " " + subCategorie;
                            lblTekst.Text = "Vul de breuk in vanuit een decimaal getal.";
                            lblFormatBreuk.Text = "Schrijf het antwoord op als bijvoorbeeld: 1/3. Zover mogelijk vereenvoudigen!";
                            if (subCategorie == "0-1")
                            {
                                do
                                {
                                    string[,] BrArray = B.BreukArray();
                                    B.GangbareBreuken(BrArray);

                                    breuk = B.RandomBreuk();

                                    breuk = B.Deelbarebreuken(breuk);

                                    Antwoord = B.RandomAntwoord(breuk);
                                    
                                    lblBreuk.Text = Antwoord.ToString();
                                    #region controleer op 1 0-1
                                    do
                                    {
                                        if (subCategorie == "0-1")
                                        {
                                            if (Antwoord == 1)
                                            {
                                                BrArray = B.BreukArray();
                                                B.GangbareBreuken(BrArray);

                                                breuk = B.RandomBreuk();

                                                breuk = B.Deelbarebreuken(breuk);

                                                Antwoord = B.RandomAntwoord(breuk);
                                    
                                                lblBreuk.Text = Antwoord.ToString();
                                                GF = true;
                                                if (Antwoord != 1)
                                                {
                                                    GF = false;
                                                }
                                            }
                                        }
                                    } while (GF);
                                    #endregion
                                }
                                while (B.PreventRepeatingQuestions(Antwoord.ToString(), vragen));
                                vragen.Add(Antwoord.ToString());
                                #endregion
                            #region DnB0-10
                            }                           
                            if (subCategorie == "0-10")
                            {
                                lblFormatBreuk.Text = lblFormatBreuk.Text + " <br />Een gehele breuk. 4/3 is dus ook mogelijk!";
                                do
                                {
                                    string[,] BrArray = B.BreukArray();
                                    B.GangbareBreuken(BrArray);

                                    breuk = B.RandomBreuk();

                                    string[] split = breuk.Split("/".ToArray());
                                    int getal1 = Convert.ToInt16(split[0]);
                                    int getal2 = Convert.ToInt16(split[1]);

                                    int helegetal = R.Next(0, 10);

                                    helegetal = helegetal * getal2;

                                    getal1 = getal1 + helegetal;
                                    breuk = getal1 + "/" + getal2;

                                    breuk = B.Deelbarebreuken(breuk);

                                    Antwoord = B.RandomAntwoord(breuk);

                                    lblBreuk.Text = Antwoord.ToString();
                                    #region controleer op heel 0-1
                                    do
                                    {
                                        if (subCategorie == "0-10")
                                        {
                                            bool isint = true;
                                            if (Antwoord % 1 == 0)
                                            {
                                                isint = true;
                                            }
                                            else
                                            {
                                                isint = false;
                                            }
                                            if (isint )
                                            {
                                                BrArray = B.BreukArray();
                                                B.GangbareBreuken(BrArray);

                                                breuk = B.RandomBreuk();

                                                breuk = B.Deelbarebreuken(breuk);

                                                Antwoord = B.RandomAntwoord(breuk);

                                                lblBreuk.Text = Antwoord.ToString();
                                                GF = true;
                                                if (Antwoord % 1 != 0)
                                                {
                                                    GF = false;
                                                }
                                            }
                                        }
                                    } while (GF);
                                    #endregion
                                }
                                while (B.PreventRepeatingQuestions(Antwoord.ToString(), vragen));
                                vragen.Add(Antwoord.ToString());
                            }
                            #endregion
                            #region DnB0-10
                            if (subCategorie == "0-100")
                            {
                                lblFormatBreuk.Text = lblFormatBreuk.Text + " <br />Een gehele breuk. 4/3 is dus ook mogelijk!";
                                do
                                {
                                    string[,] BrArray = B.BreukArray();
                                    B.GangbareBreuken(BrArray);

                                    breuk = B.RandomBreuk();

                                    breuk = B.Deelbarebreuken(breuk);

                                    string[] split = breuk.Split("/".ToArray());
                                    int getal1 = Convert.ToInt16(split[0]);
                                    int getal2 = Convert.ToInt16(split[1]);

                                    int helegetal = R.Next(0, 100);
                                    helegetal = helegetal * getal2;
                                    getal1 = getal1 + helegetal;
                                    breuk = getal1 + "/" + getal2;

                                    Antwoord = B.RandomAntwoord(breuk);

                                    lblBreuk.Text = Antwoord.ToString();
                                    #region controleer op heel 0-100
                                    do
                                    {
                                        if (subCategorie == "0-10")
                                        {
                                            bool isint = true;
                                            if (Antwoord % 1 == 0)
                                            {
                                                isint = true;
                                            }
                                            else
                                            {
                                                isint = false;
                                            }
                                            if (isint)
                                            {
                                                BrArray = B.BreukArray();
                                                B.GangbareBreuken(BrArray);

                                                breuk = B.RandomBreuk();

                                                breuk = B.Deelbarebreuken(breuk);

                                                Antwoord = B.RandomAntwoord(breuk);

                                                lblBreuk.Text = Antwoord.ToString();
                                                GF = true;
                                                if (Antwoord % 1 != 0)
                                                {
                                                    GF = false;
                                                }
                                            }
                                        }
                                    } while (GF);
                                    #endregion
                                }
                                while (B.PreventRepeatingQuestions(Antwoord.ToString(), vragen));
                                vragen.Add(Antwoord.ToString());
                            }
                            #endregion 
                        }
                       
                        Session["Resultaat"] = objResultaat;
                        Session["Totaal"] = Antwoord;
                        Session["vragenlijst"] = vragen;
                        Session["breuken"] = breuk;
                    }
                }
            catch (Exception)
            {
                string textForMessage = @"<script language='javascript'> alert('Er is wat mis gegaan. U gaat terug naar het hoofdscherm. Probeer later opnieuw.');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                Response.Redirect("Hoofdscherm.aspx");
            }
        }

        protected void btncontroleer_Click(object sender, EventArgs e)
        {
            try
            {
                objResultaat = (Resultaat)Session["Resultaat"];
                subCategorie = Convert.ToString(objResultaat.SubCategorie);
                Categorie = Convert.ToString(objResultaat.Categorie);
                Antwoord = (decimal)Session["Totaal"];
                breuk = (string)Session["breuken"];

                string[] split = breuk.Split("/".ToArray());
                int getal1 = Convert.ToInt16(split[0]);
                int getal2 = Convert.ToInt16(split[1]);
                decimal getal = 100 / getal2;
                decimal aangepastebreuk = Antwoord * 100;
                aangepastebreuk = Math.Round(aangepastebreuk, 0);

                if (tbantwoordD.Text == "")
                {
                    tbantwoordD.Text = "0";
                }
                else if (tbantwoordB.Text == "")
                {
                    tbantwoordB.Text = "0/0";
                }
                if (Categorie == "Breuk-Komma")
                {
                    #region Breuk-Komma
                    decimal tbxantwoord = Convert.ToDecimal(tbantwoordD.Text);
                    decimal.TryParse(tbantwoordD.Text.Replace(",", "."), out tbxantwoord);

                    split = breuk.Split("/".ToArray());
                    getal1 = Convert.ToInt16(split[0]);
                    getal2 = Convert.ToInt16(split[1]);
                    getal = 100 / getal2;

                    if (!(B.LessThan3DecimalPlaces(Antwoord)))
                    {
                        Antwoord = Math.Round(Antwoord, 2, MidpointRounding.AwayFromZero);
                        tbxantwoord = Math.Round(tbxantwoord, 2, MidpointRounding.AwayFromZero);
                    }
                    if (Antwoord == tbxantwoord)
                    {
                        objResultaat.AantalGoed += 1;
                        lblcorrectie.Text = "<span style= color:green>Het antwoord is goed</span>.";
                        lblUitlegAntwoord.Text = "Het is makkelijk te berekenen door het getal 100 te gebruiken. <br />Deel 100 door het 2de getal dat is " + (decimal)getal2 + " de uitkomst is " + (decimal)getal + ". <br />Het getal dat je krijgt van 100 : " + (decimal)getal2 + " doe je keer het eerste getal van de breuk. <br />" + (decimal)getal1 + " x " + (decimal)getal + " = " + (getal = (decimal)getal1 * getal) + ". <br />Verplaats de komma 2 plaatjes naar links om terug te rekenen van 100. <br />Want dat heb je gebruikt dus moet er door gedeeld worden. <br />" + (decimal)getal + " : 100 = " + (decimal)getal1 / getal2 + ".";
                    }
                    else
                    {
                        objResultaat.AantalFout += 1;
                        lblcorrectie.Text = "<span style= color:red>Het antwoord is fout</span> en had <span style= color:green>" + (decimal)Antwoord + "</span> moeten zijn.";
                        lblUitlegAntwoord.Text = "Het is makkelijk te berekenen door het getal 100 te gebruiken. <br />Deel 100 door het 2de getal dat is " + (decimal)getal2 + " de uitkomst is " + (decimal)getal + ". <br />Het getal dat je krijgt van 100 : " + (decimal)getal2 + " doe je keer het eerste getal van de breuk. <br />" + (decimal)getal1 + " x " + (decimal)getal + " = " + (getal = (decimal)getal1 * getal) + ". <br />Verplaats de komma 2 plaatjes naar links om terug te rekenen van 100. <br />Want dat heb je gebruikt dus moet er door gedeeld worden. <br />" + (decimal)getal + " : 100 = " + (decimal)getal1 / getal2 + ".";
                    }
                #endregion
                }
                else if (Categorie == "Komma-Breuk")
                {
                    #region Komma-Breuk
                    string tbxantwoordB = tbantwoordB.Text;

                    if (breuk == tbxantwoordB)
                    {
                        objResultaat.AantalGoed += 1;
                        lblcorrectie.Text = "<span style= color:green>Het antwoord is goed</span>.";
                        lblUitlegAntwoord.Text = "Voor een breuk is makkelijk het getal 100 te gebruiken. <br /> Zo kun je dus elke getal/100 doen. <br /> Als " + Antwoord + " 1 nul heeft is het dus gelijk aan 2 nullen. <br />Bijvoorbeeld 0,1 is hetzelfde als 0,10 en 0,100. <br /> Daarmee kun je de breuk altijd /100 maken. <br />De breuk bij deze is dus eigenlijk " + aangepastebreuk + "/100. <br />Vanuit hier is dan mogelijk om te vereenvoudigen. <br />Het moet te delen zijn door beide getallen.<br /> Vaak is door 2 soms ook 4 en 5 mogelijk. <br />Zo niet kijk dan verder na mogelijkheden.<br />Ook de antwoorden daarvan zouden mogelijk te zijn om te delen.<br />Doe doe je tot je niet meer kan en kom je op het antwoord:<span style= color:green> " + breuk + "<span>";
                    }
                    else
                    {
                        objResultaat.AantalFout += 1;
                        lblcorrectie.Text = "<span style= color:red>Het antwoord is fout</span> en had <span style= color:green>" + breuk + "</span> moeten zijn.";
                        lblUitlegAntwoord.Text = "Voor een breuk is makkelijk het getal 100 te gebruiken. <br /> Zo kun je dus elke getal/100 doen. <br /> Als " + Antwoord + " 1 nul heeft is het dus gelijk aan 2 nullen. <br />Bijvoorbeeld 0,1 is hetzelfde als 0,10 en 0,100. <br /> Daarmee kun je de breuk altijd /100 maken. <br />De breuk bij deze is dus eigenlijk " + aangepastebreuk + "/100. <br />Vanuit hier is dan mogelijk om te vereenvoudigen. <br />Het moet te delen zijn door beide getallen.<br /> Vaak is door 2 soms ook 4 en 5 mogelijk. <br />Zo niet kijk dan verder na mogelijkheden.<br />Ook de antwoorden daarvan zouden mogelijk te zijn om te delen.<br />Doe doe je tot je niet meer kan en kom je op het antwoord:<span style= color:green> " + breuk + "<span>";
                    }
                    #endregion
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
                tbantwoordB.Enabled = false;
                btnvolgende.Visible = true;
                tbantwoordD.Enabled = false;
                btncontroleer.Enabled = false;
                Session["Resultaat"] = objResultaat;
            }
            catch (Exception)
            {
                string textForMessage = @"<script language='javascript'> alert('Er is wat mis gegaan. U gaat terug naar het hoofdscherm. Probeer later opnieuw.');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                Response.Redirect("Hoofdscherm.aspx");
            }
        }

        protected void btnvolgende_Click(object sender, EventArgs e)
        {
            Response.Redirect("Breuken.aspx");
        }
    }
}