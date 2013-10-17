using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        GetallenLijn GL = new GetallenLijn();
        int antwoord;
        double antword;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Getallenlijn/Antwoorden genereren en Invullen.
                    Resultaat objResultaat = new Resultaat();
                    objResultaat = (Resultaat)Session["Resultaat"];
                    int voortgang = (int)Session["Voortgang"];         
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

                    string subcategorie = objResultaat.SubCategorie;
                    string categorie = objResultaat.Categorie;
                    do
                    {
                        GL.GetallenlijnGenereren(categorie, subcategorie);
                    }
                    while (GL.EindGetal > 100  || GL.EindKommaGetal > 100);
                    if (objResultaat.Categorie == "Getallen")
                    {
                        cblAntwoorden.Items[GL.RandomPositie2].Text = Convert.ToString(GL.FoutGetal1);
                        cblAntwoorden.Items[GL.RandomPositie3].Text = Convert.ToString(GL.FoutGetal2);
                        cblAntwoorden.Items[GL.RandomPositie4].Text = Convert.ToString(GL.FoutGetal3);
                        StartNummer.Text = Convert.ToString(GL.StartGetal);
                        EindNummer.Text = Convert.ToString(GL.EindGetal);
                        MiddelNummer.Text = Convert.ToString(GL.MiddelGetal);
                    }
                    else if (objResultaat.Categorie == "KommaGetallen")
                    {
                        cblAntwoorden.Items[GL.RandomPositie2].Text = Convert.ToString(GL.FoutKommaGetal1);
                        cblAntwoorden.Items[GL.RandomPositie3].Text = Convert.ToString(GL.FoutKommaGetal2);
                        cblAntwoorden.Items[GL.RandomPositie4].Text = Convert.ToString(GL.FoutKommaGetal3);
                        StartNummer.Text = Convert.ToString(GL.StartKommaGetal);
                        EindNummer.Text = Convert.ToString(GL.EindKommaGetal);
                        MiddelNummer.Text = Convert.ToString(GL.MiddelKommaGetal);
                    }
                    else if (objResultaat.Categorie == "Breuken")
                    {
                        //Alles naar fractions
                        cblAntwoorden.Items[GL.RandomPositie2].Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.FoutKommaGetal1)).ToString(); 
                        cblAntwoorden.Items[GL.RandomPositie3].Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.FoutKommaGetal2)).ToString();
                        cblAntwoorden.Items[GL.RandomPositie4].Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.FoutKommaGetal3)).ToString();
                        StartNummer.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.StartKommaGetal)).ToString();
                        EindNummer.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.EindKommaGetal)).ToString();
                        MiddelNummer.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.MiddelKommaGetal)).ToString();
                    }

                    //Pijl Verplaatsen
                    string plaatspijl = "Geen Antwoord";
                    if (objResultaat.Categorie == "Getallen")
                    {
                        antwoord = (GL.VraagGetal * GL.Tussenstapint) + GL.StartGetal;
                        plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";
                        
                        Pijltje.Style.Add("Left", plaatspijl);
                        cblAntwoorden.Items[GL.RandomPositie1].Text = Convert.ToString(antwoord);

                        lbUitlegBeginGetal.Text = Convert.ToString(GL.StartGetal);
                        lbUitlegMiddenGetal.Text = Convert.ToString(GL.MiddelGetal);
                        lbUitlegTussenstap.Text = Convert.ToString(GL.Tussenstapint);
                        lbUitlegTussenstapGrootte.Text = Convert.ToString(GL.Tussenstapint);
                        lbUitlegLijnnummer.Text = Convert.ToString(GL.VraagGetal);
                    }
                    else if (objResultaat.Categorie == "KommaGetallen")
                    {
                        antword = (GL.VraagGetal * GL.Tussenstapdouble) + GL.StartKommaGetal;
                        antword = Math.Round(antword, 1);
                        plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";
                        
                        Pijltje.Style.Add("Left", plaatspijl);
                        cblAntwoorden.Items[GL.RandomPositie1].Text = Convert.ToString(antword);

                        lbUitlegBeginGetal.Text = Convert.ToString(GL.StartKommaGetal);
                        lbUitlegMiddenGetal.Text = Convert.ToString(GL.MiddelKommaGetal);
                        lbUitlegTussenstap.Text = Convert.ToString(GL.Tussenstapdouble);
                        lbUitlegTussenstapGrootte.Text = Convert.ToString(GL.Tussenstapdouble);
                        lbUitlegLijnnummer.Text = Convert.ToString(GL.VraagGetal);
                    }
                    else if (objResultaat.Categorie == "Breuken")
                    {
                        antword = (GL.VraagGetal * GL.Tussenstapdouble) + GL.StartKommaGetal;
                        antword = Math.Round(antword, 1);
                        plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";

                        Pijltje.Style.Add("Left", plaatspijl);
                        cblAntwoorden.Items[GL.RandomPositie1].Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(antword)).ToString();

                        lbUitlegBeginGetal.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.StartKommaGetal)).ToString();
                        lbUitlegMiddenGetal.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.MiddelKommaGetal)).ToString();
                        lbUitlegTussenstap.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.Tussenstapdouble)).ToString();
                        lbUitlegTussenstapGrootte.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.Tussenstapdouble)).ToString();
                        lbUitlegLijnnummer.Text = GetallenLijn.ConvertToFracture(Convert.ToDecimal(GL.VraagGetal)).ToString();
                    }

                    if (objResultaat.Categorie == "Getallen")
                    {
                        Session["Antwoord"] = antwoord;
                    }
                    else if (objResultaat.Categorie == "KommaGetallen" || objResultaat.Categorie == "Breuken")
                    {
                        Session["Antwoord"] = antword;
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
               lbError.Visible = true;
               lbError.Text = ex.ToString();
            }

            
        }

        protected void Antwoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;
                btnNext.Visible = true;
                Resultaat objResultaat = new Resultaat();
                objResultaat = (Resultaat)Session["Resultaat"];

                if (objResultaat.Categorie == "Getallen")
                {
                    antwoord = (int)Session["Antwoord"];
                }
                else if (objResultaat.Categorie == "KommaGetallen" || objResultaat.Categorie == "Breuken")
                {
                    antword = (double)Session["Antwoord"];
                }

                if (objResultaat.Categorie == "Getallen")
                {
                    if (Convert.ToInt32(cblAntwoorden.SelectedItem.Text) == antwoord)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        objResultaat.AantalGoed = objResultaat.AantalGoed + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        cblAntwoorden.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);

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
                    else if (Convert.ToDouble(cblAntwoorden.SelectedItem.Text) != antwoord)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbAntwoord.Visible = true;
                        lbAntwoord.Text = "Het juiste antwoord = " + Convert.ToString(antwoord);
                        objResultaat.AantalFout = objResultaat.AantalFout + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        lbAntwoord.ForeColor = System.Drawing.Color.Green;
                        cblAntwoorden.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                    }
                }
                else if (objResultaat.Categorie == "KommaGetallen")
                {
                    if (Convert.ToDouble(cblAntwoorden.SelectedItem.Text) == antword)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        objResultaat.AantalGoed = objResultaat.AantalGoed + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        cblAntwoorden.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);

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
                    else if(Convert.ToDouble(cblAntwoorden.SelectedItem.Text) != antword)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbAntwoord.Visible = true;
                        lbAntwoord.Text = "Het juiste antwoord = " + Convert.ToString(antword);
                        objResultaat.AantalFout = objResultaat.AantalFout + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        lbAntwoord.ForeColor = System.Drawing.Color.Red;
                        cblAntwoorden.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                    }
                }
                else if (objResultaat.Categorie == "Breuken")
                {
                    double selectedantwoord = GL.FractionalNumber(cblAntwoorden.SelectedItem.Text);
                    if (selectedantwoord == antword)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is juist!";
                        objResultaat.AantalGoed = objResultaat.AantalGoed + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Green;
                        cblAntwoorden.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);

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
                    else if (selectedantwoord != antword)
                    {
                        lbResultaat.Visible = true;
                        lbResultaat.Text = "Jou antwoord is fout!";
                        lbAntwoord.Visible = true;
                        lbAntwoord.Text = "Het juiste antwoord = " + GetallenLijn.ConvertToFracture(Convert.ToDecimal(antword)).ToString(); ;
                        objResultaat.AantalFout = objResultaat.AantalFout + 1;
                        lbResultaat.ForeColor = System.Drawing.Color.Red;
                        lbAntwoord.ForeColor = System.Drawing.Color.Red;
                        cblAntwoorden.Enabled = false;
                        string visibility = "visible";
                        uitleg.Style.Add("visibility", visibility);
                    }
                }
                
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Getallenlijn.aspx");

        }
    }
}