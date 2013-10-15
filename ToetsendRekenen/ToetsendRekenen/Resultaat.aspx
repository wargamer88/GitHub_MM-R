<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Resultaat.aspx.cs" Inherits="ToetsendRekenen.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 50px;
        }
        .auto-style4 {
            width: 100px;
            height: 100px;
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sterren" style="border-left: none;">
        <span style="border-left: none; font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="imgSter1" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" />
    </div>
    <div id="resultaat">
        De score die je hebt behaalt staat hieronder en de sterren die hierbij horen zie je bovenin.<br />
        <asp:Image ID="face" CssClass="auto-style4" ImageUrl="Images/happy.png" runat="server" /><br />
        Aantal goed: <asp:Label ID="lbAantalGoed" runat="server" Text="0"></asp:Label><br />
        Aantal fout: <asp:Label ID="lbAantalFout" runat="server" Text="0"></asp:Label><br />
        <br />
        Je hebt nog niet alles goed beantwoord.<br />
        Als je alles goed hebt krijg je een leuk plaatje te zien.<br />
        <br />

    </div>

</asp:Content>
