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
        <div id="afrekenenmet">
            <asp:Button ID="afrekenenmetbutton" runat="server" Text="Met statiegeld" OnClick="afrekenenmet_Click" Visible="False" />
        </div>
        <div id="afrekenenzonder">
            <asp:Button ID="afrekenenzonderbutton" runat="server" Text="Zonder statiegeld" Visible="False" Width="120px" />
        </div>
    </div>
    <div id="lijstmakenstatiegeld">
        <div id="makenmet">
            <asp:Button ID="makenmetbutton" runat="server" Text="Met statiegeld" Visible="False" Width="100px" />
        </div>
        <div id="makenzonder">
            <asp:Button ID="makenzonderbutton" runat="server" Text="Zonder statiegeld" Visible="False" Width="120px" />
        </div>
    </div>
</asp:Content>
