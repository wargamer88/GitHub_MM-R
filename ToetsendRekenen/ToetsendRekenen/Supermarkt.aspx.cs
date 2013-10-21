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
        DataToDatabase DD = new DataToDatabase();
        decimal Totaal =0;
        int goed = 0;
        int fout = 0;
        public FileUpload imgUpload { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Zonder afronden
                //Subpagina word opgehaald.


                //Pad naar lokale PC voor de plaatjes.
                //SM.GetImagesPath(path);

                //Producten, prijs en plaatje worden ingeladen in een list.
                SuperList = SM.VanDB();

                //Maakt een random lijst voor de producten.
                Productenlijst.Text = SM.Randomlijst();

                //Haalt het totale prijs op van de lijst die gegenereerd is.
                Totaal = SM.GetPrice();

                //Plaatjes met prijs na de pagina.

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
                tellerpr = 0;
                int count = SuperList.Count - enkelproduct.Count;
                for (int i = 0; i < count; i++)
                {
                    var List = SuperList.RemoveAll(x => x.TagFromDBD == enkelproduct[tellerpr]);
                }
                Random R = new Random();
                for (int i = 0; i < R.Next(3, SuperList.Count); i++)
                {
                    Supermarkt super = SuperList[R.Next(SuperList.Count)];
                    RSuperList.Add(super);
                }

                foreach (var Rprogtag in RSuperList)
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
                for (int i = 0; i < enkelproduct.Count; i++)
                {
                    var result = from p in SuperList
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
                #region Met afronden
                #endregion

                Session["Totaal"] = Totaal;
            }
        }

        protected void reaction_TextChanged(object sender, EventArgs e)
        {

        }

        protected void verzend_Click(object sender, EventArgs e)
        {
            //Kijken of antword in antwoordenbox gelijk is aan de totale prijs van het boodschappenlijst.
            Totaal = (decimal)Session["Totaal"];
            decimal antwoordvar = Convert.ToDecimal(antwoord.Text);
            if (antwoordvar == Totaal)
            {
                goed++;
                reaction.Text = "antwoord is goed";
            }
            else
            {
                fout++;
                reaction.Text = "antwoord is fout";
            }
        }
    }
}