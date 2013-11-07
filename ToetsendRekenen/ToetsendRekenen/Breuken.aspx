<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Breuken.aspx.cs" Inherits="ToetsendRekenen.WebForm11" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Breuken.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="left-content">
        <asp:Label ID="lblspel" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblTekst" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblBreuk" runat="server" Text=""></asp:Label>  = 
        <asp:TextBox ID="tbantwoordD" runat="server"></asp:TextBox>

        <asp:TextBox ID="tbantwoordB" runat="server"></asp:TextBox>

        <asp:Button ID="btncontroleer" runat="server" Text="Controleer" OnClick="btncontroleer_Click" />
        <br />
        <asp:Label ID="lblFormatBreuk" runat="server" Text=""></asp:Label>
        <br />
        <asp:FilteredTextBoxExtender ID="FTBE" runat="server" ValidChars="1234567890.,/" TargetControlID="tbantwoordD"></asp:FilteredTextBoxExtender>
        <asp:RegularExpressionValidator ID="REV" ControlToValidate="tbantwoordD" runat="server" ErrorMessage="Begin altijd met een getal ookal is die 0!" ValidationExpression="^\d{1,3}(\.\d{1,3})?$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="1234567890/" TargetControlID="tbantwoordB"></asp:FilteredTextBoxExtender>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbantwoordB" runat="server" ErrorMessage="Volledig breuk. Geen hele uit de breuk halen." ValidationExpression="^\d+\/\d+$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblcorrectie" runat="server" Text=""></asp:Label>
        

        <br />
        <asp:Button ID="btnvolgende" runat="server" Text="Volgende vraag" OnClick="btnvolgende_Click" />
        

    </div>

<div class="uitkomstSterren">
            <div class="sterren">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px; left: 622px;">Score</span>
                <span class="SterImages">
                <asp:Image ID="imgSter1" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" ImageUrl="Images/legeSter.png" runat="server" />
                </span>
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/50 vragen</span></div>

            </div>
            <br />
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Uitleg</span><br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div runat="server" id="divUitleg">
                        
                    </div>
                    <asp:Label ID="lblUitlegAntwoord" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            </div>
    </asp:Content>