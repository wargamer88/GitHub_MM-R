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
                //string path = "C:/Users/Michael/Documents/GitHub/GitHub_MM-R/ToetsendRekenen/ToetsendRekenen/Images/Supermarkt";
                //SM.GetImagesPath(path);
                //SM.NaarDB();

                //Producten worden ingeladen in een array en prijs word opgehaald.

                SuperList = SM.VanDB();
                //Maakt een random lijst voor de producten.
                Productenlijst.Text = SM.Randomlijst();
                Totaal = SM.GetPrice();

                //Plaatjes met prijs na de pagina.
                int teller = 1;
                foreach (var pic in SuperList)
                {
                    plaatjesdiv.InnerHtml += plaatjesdiv.InnerHtml = "<img src=" + "ShowImage.ashx?id=" + teller + " style='width:75px;'/>" + "<span class='price'>" + pic.PriceFromDBD + "</span>";
                    teller++;
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