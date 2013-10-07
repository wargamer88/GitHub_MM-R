using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbError.Visible = false;    

                //Getallenlijn/Antwoorden genereren en Invullen.
                string moeilijkheidsgraad = "0-100";
                GetallenLijn GL = new GetallenLijn();
                do
                {
                    GL.GetallenlijnGenereren(moeilijkheidsgraad);
                }
                while (GL.EindGetal > 100);
                Antwoorden.Items[0].Text = Convert.ToString(GL.FoutGetal1);
                Antwoorden.Items[2].Text = Convert.ToString(GL.FoutGetal2);
                Antwoorden.Items[3].Text = Convert.ToString(GL.FoutGetal3);
                StartNummer.Text = Convert.ToString(GL.StartGetal);
                EindNummer.Text = Convert.ToString(GL.EindGetal);
                MiddelNummer.Text = Convert.ToString(GL.MiddelGetal);

                //Pijl Verplaatsen
                int antwoord = (GL.VraagGetal * GL.Tussenstapint) + GL.StartGetal;
                string plaatspijl = Convert.ToString((GL.VraagGetal * 36) + 219) + "px;";
                Pijltje.Style.Add("Left", plaatspijl);
                Antwoorden.Items[1].Text = Convert.ToString(antwoord);


            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = ex.ToString();
            }

            
        }
    }
}