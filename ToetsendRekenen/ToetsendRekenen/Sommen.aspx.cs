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
            if (!IsPostBack)
            {
                    tbAntwoord.Attributes.Add("autocomplete", "off");
                    //Getallenlijn/Antwoorden genereren en Invullen.
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
                    
                    
            }
        }

        protected void btnControleer_Click(object sender, EventArgs e)
        {
            try
            {
                int antwoord = 0;
                lbError.Visible = false;
                btnVolgendeVraag.Visible = true;
                Resultaat objResultaat = new Resultaat();
                objResultaat = (Resultaat)Session["Resultaat"];
                antwoord = (int)Session["Antwoord"];

                    if (Convert.ToInt32(tbAntwoord.Text) == antwoord)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        objResultaat.AantalGoed = objResultaat.AantalGoed + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        tbAntwoord.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                        Session["Resultaat"] = objResultaat;

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
                    }
                    else if (Convert.ToDouble(tbAntwoord.Text) != antwoord)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbAntwoord.Visible = true;
                        lbAntwoord.Text = "Het juiste antwoord = " + Convert.ToString(antwoord);
                        objResultaat.AantalFout = objResultaat.AantalFout + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        lbAntwoord.ForeColor = System.Drawing.Color.Green;
                        tbAntwoord.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                        Session["Resultaat"] = objResultaat;
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