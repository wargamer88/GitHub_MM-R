<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Wachtwoord.aspx.cs" Inherits="ToetsendRekenen.WebForm7" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:Button ID="btnStatistiek" runat="server" Text="Terug naar statistieken" Height="26px" BackColor="#3333FF" ForeColor="White" Width="156px" OnClick="btnStatistiek_Click" />
    <br />
    <br />
    <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Wachtwoord Wijzigen</span><br />
    <p>
        Oud wachtwoord:
        <asp:TextBox ID="tbOudWW" runat="server" Height="16px" Width="124px" TextMode="Password" style="margin-left: 92px"></asp:TextBox>
        <br />
        Nieuw wachtwoord:
        <asp:TextBox ID="tbNieuwWW" runat="server" Height="16px" Width="124px" style="margin-left: 75px" TextMode="Password"></asp:TextBox>
        <br />
        Opnieuw nieuw wachtwoord:
        <asp:TextBox ID="tbBevestigingNieuwWW" runat="server" Height="16px" Width="124px" TextMode="Password" style="margin-left: 7px"></asp:TextBox>
        <br /> 
        <asp:Label ID="lbResultaatChange" runat="server" Text="Resultaat" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="btnWijzigWW" runat="server" Text="Wijzig wachtwoord" Height="26px" BackColor="#3333FF" ForeColor="White" Width="132px" OnClick="btnWijzigWW_Click" style="margin-left: 232px" />
        <br />
    </p>
</asp:Content>
