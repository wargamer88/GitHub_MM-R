<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Supermarkt.aspx.cs" Inherits="ToetsendRekenen.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Supermarkt.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="voortgang">
            <div class="voortgangster">
                            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="imgSter1" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" />
             </div>
                <div class="voortgang"><span id="Span1" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/50 vragen</span></div>
            </div>
    <div id="left-content">
        <div id="plaatjesdiv" runat="server">


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
        Wat is het totale bedrag van het boodschappenlijstje? <asp:Label ID="lblafronden" runat="server" Text=" LET OP AFRONDING! "></asp:Label><asp:TextBox ID="antwoord" runat="server"></asp:TextBox>
        <asp:Button ID="verzend" runat="server" Text="Controleer" OnClick="verzend_Click" />
    </div>
    <div id="uitleg">
        Uitleg
        <asp:TextBox ID="reaction" runat="server" OnTextChanged="reaction_TextChanged"></asp:TextBox>
    </div>
</asp:Content>
