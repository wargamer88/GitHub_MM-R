<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="InlogStatistieken.aspx.cs" Inherits="ToetsendRekenen.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="inloggen">


        <br />
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">Inloggen</span><br />
        <br />
        Gebruikersnaam:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbGebruikersnaam" runat="server" style="margin-left: 0px"></asp:TextBox>
        <br />
        <br />
        Wachtwoord:&nbsp;&nbsp;
        <asp:TextBox ID="tbWachtwoord" runat="server" TextMode="Password" style="margin-left: 39px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnInloggen" runat="server" Text="Inoggen" Width="124px" OnClick="btnInloggen_Click" />


    </div>
</asp:Content>
