<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Getallenlijn.aspx.cs" Inherits="ToetsendRekenen.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div><asp:Image ID="Image1" runat="server" ImageUrl="Images/Getallenlijn.png" /></div>
        <div style="margin-left:22px; margin-top:-10px; width: 12px;"><asp:Label ID="StartNummer" runat="server" Text="0" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
        <div style="margin-left:215px; margin-top:-30px; width: 12px;"><asp:Label ID="MiddelNummer" runat="server" Text="5" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
        <div style="margin-left:401px; margin-top:-30px; width: 12px;"><asp:Label ID="EindNummer" runat="server" Text="10" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
    </div>
    <div>

    </div>
</asp:Content>
