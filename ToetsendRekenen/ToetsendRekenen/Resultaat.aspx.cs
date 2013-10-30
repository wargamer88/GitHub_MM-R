using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Resultaat objResultaat = new Resultaat();
            Sessie objSessie = new Sessie();
            objResultaat = (Resultaat)Session["Resultaat"];
            objSessie = (Sessie)Session["Sessie"];
            lbAantalGoed.Text = Convert.ToString(objResultaat.AantalGoed);
            lbAantalFout.Text = Convert.ToString(objResultaat.AantalFout);

            objResultaat.NewResultaat(objSessie);

            int aantalsterren = (int)Session["AantalSterren"];
            
            if (aantalsterren == 1)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/sad.png";
                lbAanmoediging.Text = "Ga zo door.";
            }
            else if (aantalsterren == 2)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/sad.png";
                lbAanmoediging.Text = "Ga zo door, ga voor nog een ster.";
            }
            else if (aantalsterren == 3)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                imgSter3.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/sad.png";
                lbAanmoediging.Text = "Ga zo door, dan krijg je een leuke smiley te zien";
            }
            else if (aantalsterren == 4)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                imgSter3.ImageUrl = "Images/Ster.png";
                imgSter4.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/happy.png";
                lbAanmoediging.Text = "Goedzo, nu niet opgeven. Nog 1 ster en dan heb je alle sterren verdient.";
            }
            else if (aantalsterren == 5)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                imgSter3.ImageUrl = "Images/Ster.png";
                imgSter4.ImageUrl = "Images/Ster.png";
                imgSter5.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/happy.png";
                lbAanmoediging.Text = "Goedzo, je hebt alle vragen goed beantwoord.";
            }

            
        } 
    }
}