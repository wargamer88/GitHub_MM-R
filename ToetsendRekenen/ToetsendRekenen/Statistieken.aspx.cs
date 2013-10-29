﻿using System;
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

        protected void btnWijzigWW_Click(object sender, EventArgs e)
        {
            try
            {
                #region WachtwoordAanpassen
                //Wachtwoord aanpassen
                lbResultaatChange.Visible = false;
                Inlog I = new Inlog();
                I = (Inlog)Session["Inlog"];
                bool WWChange = I.Changepassword(tbOudWW.Text, tbNieuwWW.Text, tbBevestigingNieuwWW.Text); 
                #endregion

                #region BevestigingWachtwoord
                //kijken of wachtwoord wijzigen gelukt is
                if (WWChange == true)
                {
                    lbResultaatChange.Visible = true;
                    lbResultaatChange.ForeColor = System.Drawing.Color.Green;
                    lbResultaatChange.Text = "Wachtwoord wijzigen gelukt.";
                    tbOudWW.Text = "";
                    tbNieuwWW.Text = "";
                    tbBevestigingNieuwWW.Text = "";
                }
                else
                {
                    lbResultaatChange.Visible = true;
                    lbResultaatChange.ForeColor = System.Drawing.Color.Red;
                    lbResultaatChange.Text = "Wachtwoord wijzigen mislukt";
                } 
                #endregion

            }
            catch (Exception ex)
            {
                lbResultaatChange.Visible = true;
                lbResultaatChange.ForeColor = System.Drawing.Color.Red;
                lbResultaatChange.Text = ex.ToString();
            }
        }

        protected void ToonGegevensWeek_Click(object sender, EventArgs e)
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

        protected void ToonGegevensMaand_Click(object sender, EventArgs e)
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

        protected void ToonGegevensJaar_Click(object sender, EventArgs e)
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

        protected void ToonGegevensVariabelTot_Click(object sender, EventArgs e)
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
    }
}