<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Supermarkt.aspx.cs" Inherits="ToetsendRekenen.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Supermarkt.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="voortgang">
                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" />
                <span id="Span1" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00;margin-top:15px; float:right;">Voortgang 24/50 vragen</span></div>
    <div id="left-content">
        Plaatjes van de producten met geldprijs.

    </div>
    <div id="right-content">
        <div id="boodschappenlijsttop">
        </div>
        <div id="boodschappenlijst1px">
        </div>
        <div id="boodschappenlijstonder">
        </div>
    </div>
    <div id="som">
        Som met antwoord balk
    </div>
    <div id="uitleg">
        Uitleg

    </div>
</asp:Content>
