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
                lbErrorStats.Visible = false;
                if (Session["Inlog"] == null)
                {
                    Response.Redirect("InlogStatistieken.aspx");
                }
                if (!IsPostBack)
                {
                    Statistieken st = new Statistieken();
                    gvResultaat.DataSource = st.OphalenResultaat();
                    gvResultaat.DataBind();
                    gvViews.DataSource = st.OphalenViews();
                    gvViews.DataBind();

                    int jaar = Convert.ToInt16(DateTime.Now.Year);
                    int indexjaar = 0;
                    int maximaaljaar = Convert.ToInt16(DateTime.Now.Year - 4);
                    do
                    {
                        ddlJaar.Items[indexjaar].Text = Convert.ToString(jaar);
                        jaar = jaar-1;
                        indexjaar++;
                    }
                    while(jaar != maximaaljaar);
                    
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
                lbResultaatChange.Visible = false;
                Inlog I = new Inlog();
                I = (Inlog)Session["Inlog"];
                bool WWChange = I.Changepassword(tbOudWW.Text, tbNieuwWW.Text, tbBevestigingNieuwWW.Text);

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
            Statistieken st = new Statistieken();
            string week = ddlWeek.SelectedItem.Text;
            gvResultaat.DataSource = st.FilterenMetWeekResultaat(week);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetWeekViews(week);
            gvViews.DataBind();
        }

        protected void ToonGegevensMaand_Click(object sender, EventArgs e)
        {
            Statistieken st = new Statistieken();
            string maand = ddlMaand.SelectedItem.Text;
            gvResultaat.DataSource = st.FilterenMetMaandResultaat(maand);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetMaandViews(maand);
            gvViews.DataBind();
        }

        protected void ToonGegevensJaar_Click(object sender, EventArgs e)
        {
            Statistieken st = new Statistieken();
            string jaar = ddlJaar.SelectedItem.Text;
            gvResultaat.DataSource = st.FilterenMetJaarResultaat(jaar);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetJaarViews(jaar);
            gvViews.DataBind();
        }

        protected void ToonGegevensVariabelTot_Click(object sender, EventArgs e)
        {
            Statistieken st = new Statistieken();
            DateTime van = Convert.ToDateTime(tbDatumVan.Text);
            DateTime tot = Convert.ToDateTime(tbDatumTot.Text);
            gvResultaat.DataSource = st.FilterenMetDatumResultaat(van, tot);
            gvResultaat.DataBind();
            gvViews.DataSource = st.FilterenMetDatumViews(van, tot);
            gvViews.DataBind();
        }
    }
}