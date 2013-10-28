<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Getallenlijn.aspx.cs" Inherits="ToetsendRekenen.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Getallenlijn.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="sommenContent">
        <div class="som">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <div><asp:Image ID="Getallenlijn" runat="server" ImageUrl="Images/Getallenlijn.png"/></div>
                        <div id="Pijltje" style="position:absolute; left:255px; right: 708px; top:37px; z-index:2" runat="server" ><asp:Image ID="Pijl" runat="server" ImageUrl="Images/pijltje.png" /></div>
                        <div id="StartNummerCss"><asp:Label ID="StartNummer" runat="server" Text="012341123" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" style="font-family:Calibri"></asp:Label></div>
                        <div id="MiddelNummerCss"><asp:Label ID="MiddelNummer" runat="server" Text="5124123" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" style="font-family:Calibri"></asp:Label></div>
                        <div id="EindNummerCss"><asp:Label ID="EindNummer" runat="server" Text="10241123" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" style="font-family:Calibri"></asp:Label></div>
                    </div>
                    <br />
                    <span id="OefeningTitel">Getallenlijn</span><br />
                    <br />
                    Welk nummer wijst de pijl aan<br />
                    <br />
                    <asp:RadioButtonList ID="cblAntwoorden" runat="server" Font-Bold="False" Font-Size="Medium" Height="125px" Width="104px" AutoPostBack="True" OnSelectedIndexChanged="Antwoorden_SelectedIndexChanged">
                    <asp:ListItem Value="1">3000000</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">5</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lbResultaat" runat="server" Text="Resultaat"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnNext" runat="server" BackColor="#3333FF" ForeColor="White" Text="Naar de volgende vraag" Visible="False" Width="176px" OnClick="btnNext_Click" />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lbError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
        <div class="uitkomstSterren">
            <div class="sterrengetallenlijn">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:15px; left: 675px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="imgSter1" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" />
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/50 vragen</span></div>

            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
            <div id="uitleg" runat="server" style="visibility: hidden; width:100%; height:auto; border-top:solid 1px black; float: right; margin-left: 11px;">
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">
                    Uitleg:
                </span>
                <br />
                Je begint door <asp:Label ID="lbUitlegMiddenGetal" runat="server" Text="MiddelGetal"></asp:Label> - <asp:Label ID="lbUitlegBeginGetal" runat="server" Text="BeginGetal"></asp:Label>
                daarna deel je dat door 5, en het antwoord daarvan is <asp:Label ID="lbUitlegTussenstap" runat="server" Text="Tussenstapgroote"></asp:Label>, dat is de tussenstapgrootte.
                Wat je dus dan doet is <asp:Label ID="lbUitlegTussenstapGrootte" runat="server" Text="tussenstapgrootte"></asp:Label> * <asp:Label ID="lbUitlegLijnnummer" runat="server" Text="VraagGetal"></asp:Label>.

                <br />
                <asp:Label ID="lbAntwoord" runat="server" Text="Juiste Antwoord" Visible="False"></asp:Label>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            
            
        </div>
    </div>
</asp:Content>
