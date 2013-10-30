using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    #region Autocomplete
                    //Auto complete uitzetten
                    tbAntwoord.Attributes.Add("autocomplete", "off");
                    lbError.Visible = false;  
                    #endregion

                    #region Voortgang
                    //Voortgang controlleren
                    Resultaat objResultaat = new Resultaat();
                    objResultaat = (Resultaat)Session["Resultaat"];
                    int voortgang = (int)Session["Voortgang"];
                    if (objResultaat.SubCategorie == "0-10")
                    {
                        lbTotaalAantalVragen.Text = "25";
                        if (voortgang != 25)
                        {
                            voortgang = voortgang + 1;
                        }
                        else if (voortgang >= 25)
                        {
                            Response.Redirect("Resultaat.aspx");
                        }
                    }
                    else if (objResultaat.Categorie == "-" && objResultaat.SubCategorie == "0-1000")
                    {
                        lbTotaalAantalVragen.Text = "25";
                        if (voortgang != 25)
                        {
                            voortgang = voortgang + 1;
                        }
                        else if (voortgang >= 25)
                        {
                            Response.Redirect("Resultaat.aspx");
                        }
                    }
                    else if (objResultaat.Categorie == "x" || objResultaat.Categorie == ":")
                    {
                        lbTotaalAantalVragen.Text = "25";
                        if (voortgang != 25)
                        {
                            voortgang = voortgang + 1;
                        }
                        else if (voortgang >= 25)
                        {
                            Response.Redirect("Resultaat.aspx");
                        }
                    }
                    else
                    {
                        if (voortgang != 50)
                        {
                            voortgang = voortgang + 1;
                        }
                        else if (voortgang >= 50)
                        {
                            Response.Redirect("Resultaat.aspx");
                        }
                    }
                    lbVoortgang.Text = Convert.ToString(voortgang);
                    Session["Voortgang"] = voortgang;

                    lbError.Visible = false;
                    lbResultaat.Visible = false;
                    #endregion

                    #region Sterren
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
                    #endregion

                    #region Sommen/Antwoorden
                    //Sommen/Antwoorden genereren en Invullen.
                    Sommen S = new Sommen();
                    S.Vragen = (List<string>)Session["Vragen"];
                    if (S.Vragen == null)
                    {
                        S.Vragen = new List<string>();
                    }
                    string subcategorie = objResultaat.SubCategorie;
                    string categorie = objResultaat.Categorie;
                    S.GenerateSommen(categorie, subcategorie);
                    Session["Vragen"] = S.Vragen;
                    int antwoord = S.Antwoord;
                    Session["Antwoord"] = antwoord;

                    if (objResultaat.Categorie == "+")
                    {
                        lbVraagGetal1.Text = Convert.ToString(S.VraagGetal1);
                        lbVraagGetal2.Text = Convert.ToString(S.VraagGetal2);
                        lbCategorie.Text = S.CategorieTeken;
                        lbCategorieTitel.Text = "Erbij sommen";
                        lbCategorieVraag.Text = "Tel de volgende getallen bij elkaar op.";
                    }
                    else if (objResultaat.Categorie == "-")
                    {
                        lbVraagGetal1.Text = Convert.ToString(S.VraagGetal1);
                        lbVraagGetal2.Text = Convert.ToString(S.VraagGetal2);
                        lbCategorie.Text = S.CategorieTeken;
                        lbCategorieTitel.Text = "Eraf Sommen";
                        lbCategorieVraag.Text = "Haal de volgende getallen van elkaar af.";
                    }
                    else if (objResultaat.Categorie == "x")
                    {
                        lbVraagGetal1.Text = Convert.ToString(S.VraagGetal1);
                        lbVraagGetal2.Text = Convert.ToString(S.VraagGetal2);
                        lbCategorie.Text = S.CategorieTeken;
                        lbCategorieTitel.Text = "Keer Sommen";
                        lbCategorieVraag.Text = "Vermenigvuldig de volgende getallen.";
                    }
                    else if (objResultaat.Categorie == ":")
                    {
                        lbVraagGetal1.Text = Convert.ToString(S.VraagGetal1);
                        lbVraagGetal2.Text = Convert.ToString(S.VraagGetal2);
                        lbCategorie.Text = S.CategorieTeken;
                        lbCategorieTitel.Text = "Deel Sommen";
                        lbCategorieVraag.Text = "Deel de volgende getallen.";
                    }
                    #endregion

                    #region Uitleg
                    //Uitleg laden
                    if (objResultaat.Categorie == "+")
                    {
                        lbUitleg.Text = "Je telt de eerste getal bij de tweede getal op door het boven elkaar te zetten, en dan eerst de meeste rechtse getal bij elkaar optellen, cijfer onder de 10 opschrijven, en die boven de 10 onthouden, bijvoorbeeld 15, 5 opschrijven 1 onthouden, daarna ga je naar de volgende en daar doe je hetzelfde alleen die 1 die je moest onthouden tel je ook bij de 2de op. Zo ga je door totdat je alles gehad hebt.";
                    }
                    else if (objResultaat.Categorie == "-")
                    {
                        lbUitleg.Text = "Je haalt de eerste getal van de tweede getal af door het boven elkaar te zetten, en dan de eerst de meest rechter getal van elkaar afhalen, mocht het onder de 0 komen, dan haal je er 1 af van de volgende getal links, en zet je een tiental voor de huidige som, daar het antwoord van schrijf je op, en zo ga je verder totdat je alles gehad hebt.";
                    }
                    else if (objResultaat.Categorie == "x")
                    {

                        lbUitleg.Text = "Bij hoofdrekenen moet je de oplossing vaak in een paar stappen berekenen." + Environment.NewLine +  "Bijvoorbeeld: 12 x 36 = ?" + Environment.NewLine + "Stap 1: 10 x 36 = 360" + Environment.NewLine +  "Stap 2: 2 x 36 = 72" + Environment.NewLine + "Stap 3: 360 + 72 = 432";
                    }
                    else if (objResultaat.Categorie == ":")
                    {
                        lbUitleg.Text = "Bereken de vraag door middel van Staartdelingen.";
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }
        }

        protected void btnControleer_Click(object sender, EventArgs e)
        {
            try
            {
                #region InladenGegevens
                //Alle gegevens inladen
                int antwoord = 0;
                lbError.Visible = false;
                btnVolgendeVraag.Visible = true;
                Resultaat objResultaat = new Resultaat();
                objResultaat = (Resultaat)Session["Resultaat"];
                antwoord = (int)Session["Antwoord"]; 
                #endregion

                    if (Convert.ToInt32(tbAntwoord.Text) == antwoord)
                    {
                        #region GoedAntwoord
                        //Antwoord Goed, dan Antwoord is juist laten zien
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        //Voortgang aantal goed updaten
                        objResultaat.AantalGoed = objResultaat.AantalGoed + 1;
                        tbAntwoord.Enabled = false;
                        //Uitleg laten zien
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                        Session["Resultaat"] = objResultaat; 
                        #endregion

                        #region SterrenBijvullen
                        //Aantal Sterren bijvullen bij aantal goed
                        if (objResultaat.SubCategorie == "0-10")
                        {
                            int aantalsterren = (int)Session["AantalSterren"];
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
                        else if (objResultaat.Categorie == "-" && objResultaat.SubCategorie == "0-1000")
                        {
                            int aantalsterren = (int)Session["AantalSterren"];
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
                        else if (objResultaat.Categorie == "x" || objResultaat.Categorie == ":")
                        {
                            int aantalsterren = (int)Session["AantalSterren"];
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
                        else
                        {
                            int aantalsterren = (int)Session["AantalSterren"];
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
                    }
                    else if (Convert.ToInt32(tbAntwoord.Text) != antwoord)
                    {
                        #region FoutAntwoord
                        //Resultaat weergeven fout + antwoord
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbAntwoord.Visible = true;
                        lbAntwoord.Text = "Het juiste antwoord = " + Convert.ToString(antwoord);
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        lbAntwoord.ForeColor = System.Drawing.Color.Green;
                        //Voortgang aantal fout updaten
                        objResultaat.AantalFout = objResultaat.AantalFout + 1;
                        tbAntwoord.Enabled = false;
                        //Uitleg laten zien
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                        Session["Resultaat"] = objResultaat; 
                        #endregion
                    }
                    btnControlleer.Visible = false;

            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }

        }

        protected void btnVolgendeVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sommen.aspx");
        }
    }
}