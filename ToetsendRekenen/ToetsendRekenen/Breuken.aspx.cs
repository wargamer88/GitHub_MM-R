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

        //Sessie
        Resultaat objResultaat = new Resultaat();

        //Sessie variabelen
        protected string subCategorie;
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
                        vragen = (List<string>)Session["vragenlijst"];
                        tbantwoord.Attributes.Add("autocomplete", "off");
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
                        if (subCategorie == "0-1")
                        {
                            do
                            {
                                #region 0-1
                                string[,] BrArray = B.BreukArray();
                                B.GangbareBreuken(BrArray);
                                breuk = B.RandomBreuk();
                                Antwoord = B.RandomAntwoord(breuk);
                                #endregion
                            }
                            while (B.PreventRepeatingQuestions(breuk, vragen));
                            lblBreuk.Text = breuk;
                            vragen.Add(breuk);
                        }
                        else if (subCategorie == "0-10")
                        {
                        
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
                Antwoord = (decimal)Session["Totaal"];
                breuk = (string)Session["breuken"];

                decimal tbxantwoord = Convert.ToDecimal(tbantwoord.Text);
                decimal.TryParse(tbantwoord.Text.Replace(".", ","), out tbxantwoord);

                string[] split = breuk.Split("/".ToArray());
                int getal1 = Convert.ToInt16(split[0]);
                int getal2 = Convert.ToInt16(split[1]);
                decimal getal = 100 / getal2;

                if (!(B.LessThan3DecimalPlaces(Antwoord)))
                {
                    Antwoord = Math.Round(Antwoord,2, MidpointRounding.AwayFromZero);
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
                    lblcorrectie.Text = "<span style= color:red>Het antwoord is niet fout</span> en had <span style= color:green>" + (decimal)Antwoord + "</span>.";
                    lblUitlegAntwoord.Text = "Het is makkelijk te berekenen door het getal 100 te gebruiken. <br />Deel 100 door het 2de getal dat is " + (decimal)getal2 + " de uitkomst is " + (decimal)getal + ". <br />Het getal dat je krijgt van 100 : " + (decimal)getal2 + " doe je keer het eerste getal van de breuk. <br />" + (decimal)getal1 + " x " + (decimal)getal + " = " + (getal = (decimal)getal1 * getal) + ". <br />Verplaats de komma 2 plaatjes naar links om terug te rekenen van 100. <br />Want dat heb je gebruikt dus moet er door gedeeld worden. <br />" + (decimal)getal + " : 100 = " + (decimal)getal1 / getal2 + ".";
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
                btnvolgende.Visible = true;
                tbantwoord.Enabled = false;
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