<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Hoofdscherm.aspx.cs" Inherits="ToetsendRekenen.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Welkom op de site van ToetsendRekenen</h1>
    <p>
        Links in het hoofdmenu kan je uit de verschilende categorieën kiezen. </p>
    <p style="float:left; margin-bottom:0;">
        <asp:Button ID="btnStatistiek" runat="server" Height="26px" BackColor="#3333FF" ForeColor="White" Text="Ga naar statistieken" OnClick="btnStatistiek_Click" />
    </p>
    <div style="position:absolute; left: 978px; top:3px; width: 16px; height: 26px;">
        <asp:Button ID="btnEasteregg" runat="server" Height="26px" BackColor="#FFFFFF" BorderStyle="None" ForeColor="White" Text="" Width="16px" OnClick="btnEasteregg_Click" />
    </div>
</asp:Content>
