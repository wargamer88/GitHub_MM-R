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
            
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">Analoge klokken</span><br />
            <br />
            Hoelaat is het?<br />
            <br />
            <div id="questionClock">
                <img class="wijzerPlaat" src="Images/WijzerPlaat.png" />
                <img class="korteWijzer" src="Images/KorteWijzer.png" />
                <img class="langeWijzer" src="Images/LangeWijzer.png" />
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
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" />
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang 24/50 vragen</span></div>

            </div>
            <br />
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Uitleg</span><br />
            <br />

            
            
        </div>
    </div>

    
</asp:Content>
