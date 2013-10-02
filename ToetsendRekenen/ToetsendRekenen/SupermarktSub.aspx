<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="SupermarktSub.aspx.cs" Inherits="ToetsendRekenen.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Supermarkt.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="lijstafrekenen">
        <asp:Button ID="afrekenenLijst" runat="server" Text="Boodschappen afrekenen" OnClick="afrekenenLijst_Click" />
    </div>
    <div id="lijstmaken">
        <asp:Button ID="makenLijst" runat="server" Text="Boodschappenlijst maken" OnClick="makenLijst_Click" />
    </div>
    <div id="lijstafrekenenstatiegeld">

        <asp:Button ID="afrekenenmet" runat="server" Text="Met statiegeld" />
        <asp:Button ID="afrekenenzonder" runat="server" Text="Zonder statiegeld" />

    </div>
    <div id="lijstmakenstatiegeld">

        <asp:Button ID="makenmet" runat="server" Text="Met statiegeld" />
        <asp:Button ID="makenzonder" runat="server" Text="Zonder statiegeld" />

    </div>
</asp:Content>
