<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Klokkijken.aspx.cs" Inherits="ToetsendRekenen.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Klokkijken.css" />
    <script type="text/javascript" src="http://jqueryrotate.googlecode.com/svn/trunk/jQueryRotate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $gradesLangewijzer = 360 / 60 * parseInt("<%= minutenVanLangewijzer%>");
            $gradesKortewijzer = 360 / 60 * parseInt("<%= minutenVanKortewijzer%>");
            $('.langeWijzer').rotate($gradesLangewijzer);
            $('.korteWijzer').rotate($gradesKortewijzer);
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="sommenContent">
        
        <div class="som">
            
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;"><asp:Label ID="lblCategorie" runat="server" Text=""></asp:Label></span><br />
            <br />
            Wat is de tijd van de klok?<br />
            <br />
            06 : 00 uur t/m 17 : 59 uur is dag.<br />
            18 : 00 uur t/m 05 : 59 uur is nacht.<br />
            <br />
            <div id="questionClock">
                <img class="wijzerPlaat" src="Images/WijzerPlaat.png" />
                <img class="korteWijzer" src="Images/KorteWijzer.png" />
                <img class="langeWijzer" src="Images/LangeWijzer.png" />
                <asp:Image ID="imgSunAndMoon" CssClass="SunAndMoon" ImageUrl="Images/Sun.png" runat="server" />
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <asp:RadioButtonList ID="RblAntwoorden" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RblAntwoorden_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="LblGoedFout" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnVolgendeVraag" runat="server" Text="Volgende vraag" OnClick="btnVolgendeVraag_Click" BackColor="#3333FF" ForeColor="White" />
                 </ContentTemplate>
            </asp:UpdatePanel>

            

            <br />
        </div>
        <div class="uitkomstSterren">
            <div class="sterren">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px; left: 623px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="imgSter1" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" />
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/50 vragen</span></div>

            </div>
            <br />
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Uitleg</span><br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div runat="server" id="divUitleg">
                        
                    </div>
                    <asp:Label ID="lblUitlegAntwoord" runat="server" Text="Label"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />

            
            
        </div>
    </div>

    
</asp:Content>
