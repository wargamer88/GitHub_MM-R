<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Hoofdscherm.aspx.cs" Inherits="ToetsendRekenen.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Welkom op de site van ToetsendRekenen</p>
    <p>
        Links in het hoofdmenu kan je uit de verschilende categorieën kiezen. </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;<asp:Button ID="btnStatistiek" runat="server" Text="Ga naar statistieken" />
    </p>
</asp:Content>
