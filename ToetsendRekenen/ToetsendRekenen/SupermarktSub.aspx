<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="SupermarktSub.aspx.cs" Inherits="ToetsendRekenen.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Supermarkt.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="SubTitel">
        Het Supermarkt Spel</p>
    <p>
        Selecteer één van de onderstaande categorieën.</p>
     <p class="SubCategorie">
        Boodschappenlijst:
    </p>
    <asp:LinkButton ID="MetAfronden" runat="server" OnClick="lbGetallen1_Click">Met afronden</asp:LinkButton>
    <br />
    <asp:LinkButton ID="ZonderAfronden" runat="server" OnClick="lbGetallen2_Click">Zonder afronden</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
    </asp:Content>
