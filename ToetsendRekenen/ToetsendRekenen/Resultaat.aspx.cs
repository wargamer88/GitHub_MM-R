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
            try
            {
                if (!IsPostBack)
                {
                    #region GegevensInladen/GoedenFout
                    //Gegevens uit de sessie halen
                    Resultaat objResultaat = new Resultaat();
                    Sessie objSessie = new Sessie();
                    objResultaat = (Resultaat)Session["Resultaat"];
                    objSessie = (Sessie)Session["Sessie"];
                    int aantalsterren = (int)Session["AantalSterren"];
                    //AantalGoed en AantalFout laten zien
                    lbAantalGoed.Text = Convert.ToString(objResultaat.AantalGoed);
                    lbAantalFout.Text = Convert.ToString(objResultaat.AantalFout); 
                    #endregion

                    #region OpslaanopDB
                    //Resultaat opslaan op Database
                    objResultaat.NewResultaat(objSessie); 
                    #endregion

                    #region Sterren/Aandmoediging
                    //Aantal sterren laten zien, een plaatje en een aanmoedigende tekst laten zien
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
                    #endregion
                }

            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(" + ex + ")</SCRIPT>");
            }
        } 
    }
}