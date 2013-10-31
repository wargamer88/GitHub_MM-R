<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="InlogStatistieken.aspx.cs" Inherits="ToetsendRekenen.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="inloggen">


        <br />
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">Inloggen</span><br />
        <br />
        Gebruikersnaam:
        <asp:TextBox ID="tbGebruikersnaam" runat="server" style="margin-left: 36px"></asp:TextBox>
        <br />
        <br />
        Wachtwoord:
        <asp:TextBox ID="tbWachtwoord" runat="server" TextMode="Password" style="margin-left: 60px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error" Visible="False" style="margin-left: 165px"></asp:Label>
        <br />
        <asp:Button ID="btnInloggen" runat="server" Text="Inloggen" Width="124px" OnClick="btnInloggen_Click" style="margin-left: 165px" Height="26px" BackColor="#3333FF" ForeColor="White" />


    </div>
</asp:Content>
