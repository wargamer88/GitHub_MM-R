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

        decimal[] price;
        decimal sum;
        protected void Page_Load(object sender, EventArgs e)
        {
            string IpassAstringfrompage1 = Convert.ToString(Session["test"]);
            reaction.Text = IpassAstringfrompage1;
            string[,] producten = new string[,] { { "Appels", "2,69" }, { "Bananen", "2,19" }, { "Melk", "0,83" }, { "Pruimen", "1,41" }, { "Manderijnen", "1,55" }, { "Appelsap", "1,06" }, { "Chocola", "1,87" }, { "Eieren", "1,29" }, { "Peren", "1,69" }, { "Koekjes", "0,81" }, { "Rode Bieten", "1,13" }, { "Blik groente", "1,39" }, { "Thee", "0,93" }, { "Ananas", "1,99" }, { "Frisdrank", "0,39" } }; 
            price = new decimal[producten.Length / 2];
            int teller = 0;
            for (int arr = 0; arr < producten.Length/2; arr++)
            {
                int j=1;
                var test = producten[arr,j];
                decimal test1  = Convert.ToDecimal(test);
                price[teller] = test1;
                teller++;
                sum += price[arr];
            }
        }

        protected void reaction_TextChanged(object sender, EventArgs e)
        {

        }

        protected void verzend_Click(object sender, EventArgs e)
        {
            decimal antwoordvar = Convert.ToDecimal(antwoord.Text);
            if (antwoordvar == sum)
            {
                reaction.Text = "Het werkt!";
            }
            else
            {
                reaction.Text = "Klopt niet!";
            }
        }
    }
}