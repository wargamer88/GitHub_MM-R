using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.SessionState;
using System.Windows.Controls;

namespace ToetsendRekenen
{
    public partial class WebForm6 : System.Web.UI.Page, IHttpHandler
    {
        Supermarkt SM = new Supermarkt();
        List<Supermarkt> SuperList = new List<Supermarkt>();
        DataToDatabase DD = new DataToDatabase();
        decimal sum =0;
        int goed = 0;
        int fout = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Subpagina word opgehaald.
            string IpassAstringfrompage1 = Convert.ToString(Session["test"]);
            reaction.Text = IpassAstringfrompage1;

            //Pad naar lokale PC voor de plaatjes.
            //string path = "C:/Users/Michael/Documents/GitHub/GitHub_MM-R/ToetsendRekenen/ToetsendRekenen/Images/Supermarkt";
            //SM.GetImagesPath(path);
            //SM.NaarDB();

            //Producten worden ingeladen in een array en prijs word opgehaald.

            SuperList = SM.VanDB();
            //Maakt een random lijst voor de producten.
            Productenlijst.Text = SM.Randomlijst();
            decimal Totaal = SM.GetPrice();

            //Plaatjes met prijs na de pagina.
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Image[] imglist = new Image[SuperList.Count];

            imglist = SM.PlaatjesNaarScherm();

            int teller = 1;
            foreach (var img in SuperList)
            {
                
                //string path = img.TagFromDBD;
                //Image1.ImageUrl = "~/Afbeelding/"+path;
                //ImageLis
            }
      
        }

        protected void reaction_TextChanged(object sender, EventArgs e)
        {

        }

        protected void verzend_Click(object sender, EventArgs e)
        {
            //Kijken of antword in antwoordenbox gelijk is aan de totale prijs van het boodschappenlijst.
            decimal antwoordvar = Convert.ToDecimal(antwoord.Text);
            if (antwoordvar == sum)
            {
                goed++;
            }
            else
            {
                fout++;
            }
        }
    }
}