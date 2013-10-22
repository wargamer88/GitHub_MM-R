<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Sommen.aspx.cs" Inherits="ToetsendRekenen.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 50px;
        height: 50px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="sommenContent">
        <div class="som">
            
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">Erbij sommen</span><br />
            <br />
            Tel de volgende getallen bij elkaar op.<br />
            <br />
            <asp:Label ID="lbVraagGetal1" runat="server" Text="40"></asp:Label>&nbsp;<asp:Label ID="lbCategorie" runat="server" Text="+"></asp:Label>&nbsp;<asp:Label ID="lbVraagGetal2" runat="server" Text="50"></asp:Label> &nbsp;=
            <asp:TextBox ID="tbAntwoord" runat="server" Height="16px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnControleer" runat="server" Height="23px" Text="Controleer antwoord" Width="127px" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
        <div class="uitkomstSterren">
            <div class="sterren">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" />
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang 24/50 vragen</span></div>

            </div>
            <br />
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Uitleg</span>
            <br />
            <br />
            40 + 50 kan je makkelijk uitrekenen.<br />
            Je zet ze onder elkaar.<br />
            Dan tel je de getallen bij elkaar op, van rechts naar links.<br />
            Dan tel je eerst de nullen bij elkaar op, dat blijft 0.<br />
            En dan de 4 en 5 en dat word 9. Dan staat er 90 en dat is het antwoord.<br />
            
            
        </div>
    </div>
</asp:Content>
