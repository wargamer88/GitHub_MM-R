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
            objResultaat = (Resultaat)Session["Resultaat"];
            //lbAantalGoed.Text = Convert.ToString(objResultaat.AantalGoed);
            //lbAantalFout.Text = Convert.ToString(objResultaat.AantalFout);


            int aantalsterren ;//(int)Session["AantalSterren"];
            aantalsterren = 1;
            if (aantalsterren == 1)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/sad.png";
            }
            else if (aantalsterren == 2)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/sad.png";
            }
            else if (aantalsterren == 3)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                imgSter3.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/sad.png";
            }
            else if (aantalsterren == 4)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                imgSter3.ImageUrl = "Images/Ster.png";
                imgSter4.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/happy.png";
            }
            else if (aantalsterren == 5)
            {
                imgSter1.ImageUrl = "Images/Ster.png";
                imgSter2.ImageUrl = "Images/Ster.png";
                imgSter3.ImageUrl = "Images/Ster.png";
                imgSter4.ImageUrl = "Images/Ster.png";
                imgSter5.ImageUrl = "Images/Ster.png";
                face.ImageUrl = "Images/happy.png";
            }

            
        } 
    }
}