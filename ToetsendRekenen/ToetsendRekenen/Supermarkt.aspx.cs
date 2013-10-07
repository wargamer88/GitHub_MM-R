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
        decimal sum;
        int goed = 0;
        int fout = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Subpagina word opgehaald.
            string IpassAstringfrompage1 = Convert.ToString(Session["test"]);
            reaction.Text = IpassAstringfrompage1;

            //Producten worden ingeladen in een array en prijs word opgehaald en uitgerekend.
            string[,] producten = new string[,] { { "Appels", "2,69" }, { "Bananen", "2,19" }, { "Melk", "0,83" }, { "Pruimen", "1,41" }, { "Manderijnen", "1,55" }, { "Appelsap", "1,06" }, { "Chocola", "1,87" }, { "Eieren", "1,29" }, { "Peren", "1,69" }, { "Koekjes", "0,81" }, { "Rode Bieten", "1,13" }, { "Blik groente", "1,39" }, { "Thee", "0,93" }, { "Ananas", "1,99" }, { "Frisdrank", "0,39" } }; 
            decimal Totaal = SM.GetPrice();

            //Hieronder word de lijst met producten gemaakt. Dit word later in een methode gezet van deze pagina.        
            //Productenlijst.Text = SM.GetProductsList(producten);
            //Productenlijst.Text = SM.Randomlijst(producten);
            string path = System.IO.Directory.GetCurrentDirectory() + "/Images/Supermarkt/";
            SM.GetImagesPath(path);
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