﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Supermarkt.aspx.cs" Inherits="ToetsendRekenen.WebForm6" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Supermarkt.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="voortgang">
            <div class="voortgangster">
                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px; left: 204px;">Score</span>
                            <span class="SterImages">
                            <asp:Image ID="imgSter1" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" ImageUrl="Images/legeSter.png" runat="server" />
                            </span>
             </div>
                <div class="voortgang"><span id="Span1" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/25 vragen</span></div>
            </div>
    <div id="left-content">
        <div id="plaatjesdiv" runat="server" style="height : 310px; overflow :scroll; overflow-x:hidden">


        </div>
        
    </div>
    <div id="right-content">
        <div id="boodschappenlijsttop">
        </div>
        <div id="divtekst" >
            
            <asp:Label ID="Productenlijst" runat="server"></asp:Label>
            
        </div>
        <div id="boodschappenlijstonder">
        </div>
    </div>
    <div id="som">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
        Wat is het totale bedrag van het boodschappenlijstje? <asp:Label ID="lblafronden" runat="server" Text=" LET OP AFRONDING! "></asp:Label>
        <br />
        <asp:TextBox ID="antwoord" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="antwoord" ValidChars="1234567890.," />
        <asp:Button ID="verzend" runat="server" Text="Controleer" OnClick="verzend_Click" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="antwoord" runat="server" ErrorMessage="Getal daarna komma of een punt dan 2 getallen die de centen uitdrukt" ValidationExpression="^\d+([\.\,]\d{1,3})?$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblantwoord" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="goedeantwoord" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnVolgendeVraag" runat="server" Text="Volgende vraag" OnClick="btnVolgendeVraag_Click" />
                     </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
