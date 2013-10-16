<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="GetallenlijnSub.aspx.cs" Inherits="ToetsendRekenen.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Getallenlijn.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <img alt="Denken aan sommen" id="SubImage" src="Images/GetallenlijnDenken.png" />
    <p id="SubTitel">
        Ken jij de getallenlijn?</p>
    <p>
        Selecteer één van de onderstaande categorieën.</p>
    <p class="SubCategorie">
        Getallen:
    </p>
    <asp:LinkButton ID="lbGetallen1" runat="server" OnClick="lbGetallen1_Click">0 t/m 20</asp:LinkButton>
    <br />
    <asp:LinkButton ID="lbGetallen2" runat="server" OnClick="lbGetallen2_Click">0 t/m 100</asp:LinkButton>

    <p class="SubCategorie">
        Komma Getallen:
    </p>
    <asp:LinkButton ID="lbKommaGetal1" runat="server" OnClick="lbKommaGetal1_Click">0 t/m 20</asp:LinkButton>
    <br />
    <asp:LinkButton ID="lbKommatGetal2" runat="server" OnClick="lbKommatGetal2_Click">0 t/m 100</asp:LinkButton>

    <p class="SubCategorie">
        Breuken:
    </p>
    <div>0 t/m 10</div>    
    <div>0 t/m 100</div>      
    <p>
        &nbsp;</p>
    <asp:Label ID="lbError" runat="server" Text="Error" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>
