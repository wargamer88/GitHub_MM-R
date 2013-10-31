<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="BreukenSub.aspx.cs" Inherits="ToetsendRekenen.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Breuken.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="Images/BreukenDenken.png" id="SubImage" />

    <p id="SubTitel">
        Het Breuken Spel</p>
    <p>
        Selecteer één van de onderstaande categorieën.</p>
     <p class="SubCategorie">
        Breuk naar Komma
    </p>
    <asp:LinkButton ID="BnK01" runat="server" OnClick="lbBreuken1_Click">0-1</asp:LinkButton>
    <br />
    <asp:LinkButton ID="BnK010" runat="server" OnClick="lbBreuken2_Click">0-10</asp:LinkButton>
    <br />
        <br />
    <p class="SubCategorie">
        Komma naar Breuk:
    </p>
    <asp:LinkButton ID="KnB01" runat="server" OnClick="lbKomma1_Click">0-1</asp:LinkButton>
    <br />
    <asp:LinkButton ID="KnB010" runat="server" OnClick="lbKomma2_Click">0-10</asp:LinkButton>
    <br />
        <asp:LinkButton ID="KnB0100" runat="server" OnClick="lbKomma3_Click">0-100</asp:LinkButton>
    <br />
        <br />
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
</asp:Content>