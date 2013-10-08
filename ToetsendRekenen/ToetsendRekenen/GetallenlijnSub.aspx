<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="GetallenlijnSub.aspx.cs" Inherits="ToetsendRekenen.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 385px;
            height: 471px;
            float:right;
        }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img alt="Denken aan sommen" class="auto-style2" src="Images/GetallenlijnDenken.png" />
    <p style="font-size: 19px; font-weight: bolder; font-family: Georgia, 'Times New Roman', Times, serif">
        Ken jij de getallenlijn?</p>
    <p>
        Selecteer één van de onderstaande categorieën.</p>
    <p style="font-weight:bold;">
        Getallen:
    </p>
    <asp:LinkButton ID="lbGetallen1" runat="server" OnClick="lbGetallen1_Click">0 t/m 10</asp:LinkButton>
    <br />
    <asp:LinkButton ID="lbGetallen2" runat="server" OnClick="lbGetallen2_Click">0 t/m 100</asp:LinkButton>

    <p style="font-weight:bold;">
        Komma Getallen:
    </p>
    <div>0 t/m 10</div>    
    <div>0 t/m 100</div>

    <p style="font-weight:bold;">
        Breuken:
    </p>
    <div>0 t/m 10</div>    
    <div>0 t/m 100</div>      
    <p>
        &nbsp;</p>
    <asp:Label ID="lbError" runat="server" Text="Error" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>
