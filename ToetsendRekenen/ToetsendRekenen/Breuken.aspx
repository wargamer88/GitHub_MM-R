<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Breuken.aspx.cs" Inherits="ToetsendRekenen.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Breuken.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="left-content">
        Breuken 0-1
        <br />
        <br />
        <br />
        Reken de breuk om naar een komma getal:
        <br />
        Meer dan 4 cijfers achter de komma afronden na 2 cijfers!<br />
        <asp:Label ID="lblBreuk" runat="server" Text=""></asp:Label>  = 
        <asp:TextBox ID="tbantwoord" runat="server"></asp:TextBox>
        <asp:Button ID="btncontroleer" runat="server" Text="Controleer" OnClick="btncontroleer_Click" />
        <br />
        <asp:Label ID="lblcorrectie" runat="server" Text=""></asp:Label>
        

        <br />
        <asp:Button ID="btnvolgende" runat="server" Text="Volgende vraag" OnClick="btnvolgende_Click" />
        

    </div>

<div class="uitkomstSterren">
            <div class="sterren">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px; left: 622px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="imgSter1" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" CssClass="auto-style2" ImageUrl="Images/legeSter.png" runat="server" />
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