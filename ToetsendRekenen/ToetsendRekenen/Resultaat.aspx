<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Resultaat.aspx.cs" Inherits="ToetsendRekenen.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 50px;
        }
        .auto-style3 {
            width: 100px;
            height: 100px;
            float: right;
        }
        .auto-style4 {
            width: 100px;
            height: 100px;
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sterren">
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" />
    </div>
    <div id="resultaat">
        De score die je hebt behaalt staat hieronder en de sterren die hierbij horen zie je bovenin.<br />
        <img alt="" class="auto-style4" src="Images/Happy.png" /><img alt="" class="auto-style3" src="Images/Sad.png" /><br />
        Aantal goed: <asp:Label ID="lbAantalGoed" runat="server" Text="0"></asp:Label><br />
        Aantal fout: <asp:Label ID="lbAantalFout" runat="server" Text="0"></asp:Label><br />
        <br />
        Je hebt nog niet alles goed beantwoord.<br />
        Als je alles goed hebt krijg je een leuk plaatje te zien.<br />
        <br />

    </div>

</asp:Content>
