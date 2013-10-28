using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Web.SessionState;
using System.Windows.Controls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

namespace ToetsendRekenen
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        #region Properties
        Supermarkt SM = new Supermarkt();
        List<Supermarkt> SuperList = new List<Supermarkt>();
        List<Supermarkt> SuperListprice = new List<Supermarkt>();
        DataToDatabase DD = new DataToDatabase();
        decimal Totaal =0;
        public FileUpload imgUpload { get; set; }

        Resultaat objResultaat = new Resultaat();

        //Sessie variabelen
        protected string subCategorie;
        protected int voortgang;
        protected int aantalsterren;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                antwoord.Attributes.Add("autocomplete", "off");
                objResultaat = (Resultaat)Session["Resultaat"];
                subCategorie = Convert.ToString(objResultaat.SubCategorie);
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
                if (subCategorie == "Zonder afronden")
                {
                    #region Zonder afronden
                lblafronden.Visible = false;
                btnVolgendeVraag.Visible = false;

                //Pad naar lokale PC voor de plaatjes.
                //SM.GetImagesPath(path);

                //Producten, prijs en plaatje worden ingeladen in een list.
                SuperList = SM.VanDB();

                //Maakt een random lijst voor de producten.
                Productenlijst.Text = SM.Randomlijst();

                //Haalt het totale prijs op van de lijst die gegenereerd is.
                Totaal = SM.GetPrice();

                //Plaatjes met prijs na de pagina.
                #region MethodePlaatjeNaarSchem
                int tellerpr = 0;
                string[] disttostring = new string[SM.dist.Count];               
                List<string> enkelproduct = new List<string>();
                List<Supermarkt> RSuperList = new List<Supermarkt>();
                List<string> OverigProduct = new List<string>();

                int tellerDist = 0;
                foreach (var aantal in SM.dist)
                {
                    string distincttostring = aantal.aantal + "x " + aantal.TagFromDBD + "<br />";
                    disttostring[tellerDist] = distincttostring;
                    tellerDist = tellerDist + 1;
                }

                IEnumerable<string> productendistinct = disttostring.Distinct();

                foreach (var p in productendistinct)
                {
                    string pr = p.Substring(3);
                    string[] explode = pr.Split("<".ToCharArray());
                    enkelproduct.Add(explode[0]);
                }
                
                tellerpr = 0;
                //int count = SuperList.Count - enkelproduct.Count;
                for (int i = 0; i < enkelproduct.Count; i++)
                {
                    SuperList.RemoveAll(x => x.TagFromDBD == enkelproduct[tellerpr]);
                    tellerpr++;
                }
                Random R = new Random();
                for (int i = 0; i < R.Next(3, SuperList.Count); i++)
                {
                    Supermarkt super = SuperList[R.Next(SuperList.Count)];
                    RSuperList.Add(super);
                }
                IEnumerable<Supermarkt> RSuperList1 = RSuperList.Distinct();
                foreach (var Rprogtag in RSuperList1)
                {
                    enkelproduct.Add(Rprogtag.TagFromDBD);
                }
                tellerpr = 0;
                string[] RSuperPro = new string[enkelproduct.Count];
                foreach (string stringarr in enkelproduct)
                {
                    RSuperPro[tellerpr] = stringarr;
                    tellerpr++;
                }

                tellerpr = 0;
                decimal[] price = new decimal[enkelproduct.Count];
                enkelproduct = enkelproduct.OrderBy(x => R.Next()).ToList();
                SuperListprice = SM.VanDB();
                for (int i = 0; i < enkelproduct.Count; i++)
                {
                    var result = from p in SuperListprice
                                 where p.TagFromDBD == enkelproduct[tellerpr]
                                 select p.PriceFromDBD;
                    IEnumerable<decimal> resultprice = result;
                    foreach (decimal Rprice in resultprice)
                    {
                        price[tellerpr] = Rprice;

                    }
                    tellerpr = tellerpr + 1;
                }
                tellerpr = 0;
                foreach (string pic in enkelproduct)
                {                    
                    var test = Server.UrlEncode(pic);
                    plaatjesdiv.InnerHtml += plaatjesdiv.InnerHtml = "<img src=" + "ShowImage.ashx?tag=" + test + " style='width:75px;'/>";
                    for (int i = 0; i < 1; i++)
                    {
                        plaatjesdiv.InnerHtml += "<span class='price'>" + price[tellerpr] + "</span>";
                        tellerpr++;
                    }
                }
                #endregion


                #endregion
                }
                else if (subCategorie == "Met afronden")
                {
                    #region Met afronden
                    lblafronden.Visible = true;
                    btnVolgendeVraag.Visible = false;

                    //Pad naar lokale PC voor de plaatjes.
                    //SM.GetImagesPath(path);

                    //Producten, prijs en plaatje worden ingeladen in een list.
                    SuperList = SM.VanDB();

                    //Maakt een random lijst voor de producten.
                    Productenlijst.Text = SM.Randomlijst();

                    //Haalt het totale prijs op van de lijst die gegenereerd is.
                    Totaal = SM.GetPrice();

                    

                    //Plaatjes met prijs na de pagina.
                    #region MethodePlaatjeNaarSchem
                    int tellerpr = 0;
                    string[] disttostring = new string[SM.dist.Count];
                    List<string> enkelproduct = new List<string>();
                    List<Supermarkt> RSuperList = new List<Supermarkt>();
                    List<string> OverigProduct = new List<string>();

                    int tellerDist = 0;
                    foreach (var aantal in SM.dist)
                    {
                        string distincttostring = aantal.aantal + "x " + aantal.TagFromDBD + "<br />";
                        disttostring[tellerDist] = distincttostring;
                        tellerDist = tellerDist + 1;
                    }

                    IEnumerable<string> productendistinct = disttostring.Distinct();

                    foreach (var p in productendistinct)
                    {
                        string pr = p.Substring(3);
                        string[] explode = pr.Split("<".ToCharArray());
                        enkelproduct.Add(explode[0]);
                    }

                    tellerpr = 0;
                    //int count = SuperList.Count - enkelproduct.Count;
                    for (int i = 0; i < enkelproduct.Count; i++)
                    {
                        SuperList.RemoveAll(x => x.TagFromDBD == enkelproduct[tellerpr]);
                        tellerpr++;
                    }
                    Random R = new Random();
                    for (int i = 0; i < R.Next(3, SuperList.Count); i++)
                    {
                        Supermarkt super = SuperList[R.Next(SuperList.Count)];
                        RSuperList.Add(super);
                    }
                    IEnumerable<Supermarkt> RSuperList1 = RSuperList.Distinct();
                    foreach (var Rprogtag in RSuperList1)
                    {
                        enkelproduct.Add(Rprogtag.TagFromDBD);
                    }
                    tellerpr = 0;
                    string[] RSuperPro = new string[enkelproduct.Count];
                    foreach (string stringarr in enkelproduct)
                    {
                        RSuperPro[tellerpr] = stringarr;
                        tellerpr++;
                    }

                    tellerpr = 0;
                    decimal[] price = new decimal[enkelproduct.Count];
                    enkelproduct = enkelproduct.OrderBy(x => R.Next()).ToList();
                    SuperListprice = SM.VanDB();
                    for (int i = 0; i < enkelproduct.Count; i++)
                    {
                        var result = from p in SuperListprice
                                     where p.TagFromDBD == enkelproduct[tellerpr]
                                     select p.PriceFromDBD;
                        IEnumerable<decimal> resultprice = result;
                        foreach (decimal Rprice in resultprice)
                        {
                            price[tellerpr] = Rprice;

                        }
                        tellerpr = tellerpr + 1;
                    }
                    tellerpr = 0;
                    foreach (string pic in enkelproduct)
                    {
                        var test = Server.UrlEncode(pic);
                        plaatjesdiv.InnerHtml += plaatjesdiv.InnerHtml = "<img src=" + "ShowImage.ashx?tag=" + test + " style='width:75px;'/>";
                        for (int i = 0; i < 1; i++)
                        {
                            plaatjesdiv.InnerHtml += "<span class='price'>" + price[tellerpr] + "</span>";
                            tellerpr++;
                        }
                    }
                    #endregion
                #endregion
                }

                Session["Resultaat"] = objResultaat;
                Session["Totaal"] = Totaal;
            }
        }

        protected void verzend_Click(object sender, EventArgs e)
        {
            objResultaat = (Resultaat)Session["Resultaat"];
            subCategorie = Convert.ToString(objResultaat.SubCategorie);

            //Kijken of antword in antwoordenbox gelijk is aan de totale prijs van het boodschappenlijst.
            Totaal = (decimal)Session["Totaal"];
            if (antwoord.Text == "")
            {
                antwoord.Text = "0";
            }
            decimal antwoordvar = Convert.ToDecimal(antwoord.Text);
            decimal.TryParse(antwoord.Text.Replace(".", ","), out antwoordvar);
            decimal.TryParse(antwoord.Text.Replace("-", "00"), out antwoordvar);
            #region verzendknop
            if (subCategorie == "Zonder afronden")
            {
                if (antwoordvar == Totaal)
                {
                    objResultaat.AantalGoed += 1;
                    lblantwoord.Text = "<span style= color:green>Antwoord is goed</span>";
                }
                else
                {
                    objResultaat.AantalFout += 1;
                    lblantwoord.Text = "<span style= color:red> Antwoord is fout</span>";
                    goedeantwoord.Text = "Het goede antwoord was: <span style= color:green>" + Totaal + "</span> kijk nog even na wat je fout gedaan kon hebben.";
                }
            }
            else if (subCategorie == "Met afronden")
            {
                decimal Totaalantwoord = Math.Round(Totaal / 0.05M) * 5 / 100;
                Totaalantwoord = Math.Round(Totaalantwoord, 2, MidpointRounding.AwayFromZero);
                if (antwoordvar == Totaalantwoord)
                {
                    objResultaat.AantalGoed += 1;
                    lblantwoord.Text = "<span style= color:green>Antwoord is goed</span>";
                }
                else
                {
                    objResultaat.AantalFout += 1;
                    lblantwoord.Text = "<span style= color:red> Antwoord is fout</span>";
                    goedeantwoord.Text = "Het goede antwoord was: <span style= color:green>" + String.Format("{0:0.00}", Totaalantwoord) +"</span>. Als de bereking kwam op: " + Totaal + " was je vergeten af te ronden naar 0 of 5. <br />" +
                    "Kijk nog even na wat je fout gedaan kon hebben.";
                }
            }
            #endregion

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
            btnVolgendeVraag.Visible = true;
            verzend.Enabled = false;
            antwoord.Enabled = false;
            Session["Resultaat"] = objResultaat;
        }

        protected void btnVolgendeVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supermarkt.aspx");
        }
    }
}