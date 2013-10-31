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
                            if (voortgang != 25)
                            {
                                voortgang = voortgang + 1;
                            }
                            else if (voortgang >= 25)
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
                    }
                }
            catch (Exception ex)
            {
                 System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(" + ex + ")</SCRIPT>");
            }
            }

        protected void btncontroleer_Click(object sender, EventArgs e)
        {
            try
            {
                objResultaat = (Resultaat)Session["Resultaat"];
                subCategorie = Convert.ToString(objResultaat.SubCategorie);
                Antwoord = (decimal)Session["Totaal"];

                decimal tbxantwoord = Convert.ToDecimal(tbantwoord.Text);
                decimal.TryParse(tbantwoord.Text.Replace(".", ","), out tbxantwoord);
                if (!(B.LessThan3DecimalPlaces(Antwoord)))
                {
                    Antwoord = Math.Round(Antwoord,2, MidpointRounding.AwayFromZero);
                    tbxantwoord = Math.Round(tbxantwoord, 2, MidpointRounding.AwayFromZero);
                }
                if (Antwoord == tbxantwoord)
                {
                    lblcorrectie.Text = "antwoord is goed";
                    lblUitlegAntwoord.Text = "Het antwoord is correct. Het is makkelijk te berekenen door het getal 100 te gebruiken. Deel 100 door het 2de getal. Het 1ste antwoord doe je maal het 2de antwoord en verplaats je komma 2 plaatsen naar links.";
                }
                else
                {
                    lblcorrectie.Text = "antwoord is fout";
                    lblUitlegAntwoord.Text = "Het antwoord is niet correct. Het is makkelijk te berekenen door het getal 100 te gebruiken. Deel 100 door het 2de getal. Het 1ste antwoord doe je maal het 2de antwoord en verplaats je komma 2 plaatsen naar links.";
                }

                #region sterren verwerken
                {
                    //sterren verwerken
                    aantalsterren = (int)Session["AantalSterren"];
                    if (objResultaat.AantalGoed == 5)
                    {
                        imgSter1.ImageUrl = "Images/Ster.png";
                        if (aantalsterren == 0)
                        {
                            aantalsterren = aantalsterren + 1;
                        }
                        Session["AantalSterren"] = aantalsterren;
                    }
                    else if (objResultaat.AantalGoed == 10)
                    {
                        if (aantalsterren == 1)
                        {
                            aantalsterren = aantalsterren + 1;
                        }
                        Session["AantalSterren"] = aantalsterren;
                    }
                    else if (objResultaat.AantalGoed == 15)
                    {
                        if (aantalsterren == 2)
                        {
                            aantalsterren = aantalsterren + 1;
                        }
                        Session["AantalSterren"] = aantalsterren;
                    }
                    else if (objResultaat.AantalGoed == 20)
                    {
                        if (aantalsterren == 3)
                        {
                            aantalsterren = aantalsterren + 1;
                        }
                        Session["AantalSterren"] = aantalsterren;
                    }
                    else if (objResultaat.AantalGoed == 25)
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
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(" + ex + ")</SCRIPT>");
            }
        }

        protected void btnvolgende_Click(object sender, EventArgs e)
        {
            Response.Redirect("Breuken.aspx");
        }
    }
}