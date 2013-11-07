using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                #region SessieControle
                //Als sessie Inloggen nog niet klopt dan terug sturen naar inlog pagina
                lbErrorStats.Visible = false;
                if (Session["Inlog"] == null)
                {
                    Response.Redirect("InlogStatistieken.aspx");
                } 
                #endregion

                if (!IsPostBack)
                {
                    #region GridviewsVullen
                    //GridviewsVullen
                    Statistieken st = new Statistieken();
                    gvResultaat.DataSource = st.OphalenResultaat();
                    gvResultaat.DataBind();
                    gvViews.DataSource = st.OphalenViews();
                    gvViews.DataBind(); 
                    #endregion

                    #region JaarVullen
                    //de filter Jaar vullen
                    int jaar = Convert.ToInt16(DateTime.Now.Year);
                    int indexjaar = 0;
                    int maximaaljaar = Convert.ToInt16(DateTime.Now.Year - 4);
                    do
                    {
                        ddlJaar.Items[indexjaar].Text = Convert.ToString(jaar);
                        jaar = jaar - 1;
                        indexjaar++;
                    }
                    while (jaar != maximaaljaar); 
                    #endregion
                    
                }
            }
            catch (Exception ex)
            {
                lbErrorStats.Visible = true;
                lbErrorStats.Text = ex.ToString();
            }

        }

        protected void ToonGegevensWeek_Click(object sender, EventArgs e)
        {
            try
            {
                #region WeekFilteren
                //Filteren dmv week
                Statistieken st = new Statistieken();
                string week = ddlWeek.SelectedItem.Text;
                gvResultaat.DataSource = st.FilterenMetWeekResultaat(week);
                gvResultaat.DataBind();
                gvViews.DataSource = st.FilterenMetWeekViews(week);
                gvViews.DataBind();
                #endregion
            }
            catch (Exception ex)
            {
                lbErrorStats.Visible = true;
                lbErrorStats.Text = ex.ToString();
            }
        }

        protected void ToonGegevensMaand_Click(object sender, EventArgs e)
        {
            try
            {
            #region MaandFilteren
            //dmv Maand Filteren
            Statistieken st = new Statistieken();
            string maand = ddlMaand.SelectedItem.Value;
            gvResultaat.DataSource = st.FilterenMetMaandResultaat(maand);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetMaandViews(maand);
            gvViews.DataBind(); 
            #endregion
            }
            catch (Exception ex)
            {
                lbErrorStats.Visible = true;
                lbErrorStats.Text = ex.ToString();
            }
        }

        protected void ToonGegevensJaar_Click(object sender, EventArgs e)
        {
            try
            {
            #region JaarFilteren
            //dmv jaar filteren
            Statistieken st = new Statistieken();
            string jaar = ddlJaar.SelectedItem.Text;
            gvResultaat.DataSource = st.FilterenMetJaarResultaat(jaar);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetJaarViews(jaar);
            gvViews.DataBind(); 
            #endregion
            }
            catch (Exception ex)
            {
                lbErrorStats.Visible = true;
                lbErrorStats.Text = ex.ToString();
            }
        }

        protected void ToonGegevensVariabelTot_Click(object sender, EventArgs e)
        {
            try
            {
            #region DatumFilteren
            //dmv van Datum Filteren
            Statistieken st = new Statistieken();
            DateTime van = Convert.ToDateTime(tbDatumVan.Text);
            DateTime tot = Convert.ToDateTime(tbDatumTot.Text);
            gvResultaat.DataSource = st.FilterenMetDatumResultaat(van, tot);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetDatumViews(van, tot);
            gvViews.DataBind(); 
            #endregion
            }
            catch (Exception ex)
            {
                lbErrorStats.Visible = true;
                lbErrorStats.Text = ex.ToString();
            }
        }

        protected void btnWijzigWW_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Wachtwoord.aspx");
        }
    }
}