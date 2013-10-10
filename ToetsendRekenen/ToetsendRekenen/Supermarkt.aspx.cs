using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace ToetsendRekenen
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Supermarkt SM = new Supermarkt();
        List<Supermarkt> SuperList = new List<Supermarkt>();
        decimal sum;
        int goed = 0;
        int fout = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Subpagina word opgehaald.
            string IpassAstringfrompage1 = Convert.ToString(Session["test"]);
            reaction.Text = IpassAstringfrompage1;

            //Producten worden ingeladen in een array en prijs word opgehaald.
            string path = "C:/Users/Michael/Documents/GitHub/GitHub_MM-R/ToetsendRekenen/ToetsendRekenen/Images/Supermarkt";
            SM.GetImagesPath(path);
            SM.VanDB();
            //Maakt een random lijst voor de producten.
            Productenlijst.Text = SM.Randomlijst();
            decimal Totaal = SM.GetPrice();

            //Hieronder word de lijst met producten gemaakt. Dit word later in een methode gezet van deze pagina.        
            //Productenlijst.Text = SM.GetProductsList(producten);
            
            //SM.PlaatjeNaarDatabase();
            //SM.NaarDB();

            
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