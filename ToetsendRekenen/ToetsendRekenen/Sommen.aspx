<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Sommen.aspx.cs" Inherits="ToetsendRekenen.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 50px;
            height: 50px;
        }
        .SterImages {
            margin-left: 80px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="sommenContent">
        <div class="som">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">
                <asp:Label ID="lbCategorieTitel" runat="server" Text="Erbij sommen"></asp:Label></span><br />
            <br />
            <asp:Label ID="lbCategorieVraag" runat="server" Text="Tel de volgende getallen bij elkaar op."></asp:Label><br />
            <br />
            <asp:Label ID="lbVraagGetal1" runat="server" Text="40"></asp:Label>&nbsp;<asp:Label ID="lbCategorie" runat="server" Text="+"></asp:Label>&nbsp;<asp:Label ID="lbVraagGetal2" runat="server" Text="50"></asp:Label> &nbsp;=
            <asp:TextBox ID="tbAntwoord" runat="server" Height="16px" Width="54px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbAntwoord" runat="server" ErrorMessage="Alleen cijfers gebruiken" ValidationExpression="\d+" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
                    <asp:Label ID="lbResultaat" runat="server" Text="Resultaat"></asp:Label>
            <br />
                    <asp:Button ID="btnControlleer" runat="server" BackColor="#3333FF" ForeColor="White" Text="Controleer Antwoord" style="margin-top: 0px; margin-left: 55px;" Height="25px" OnClick="btnControleer_Click" Width="150px" /><asp:Button ID="btnVolgendeVraag" runat="server" BackColor="#3333FF" ForeColor="White" Text="Naar de volgende vraag" Visible="False" style="margin-top: 0px" Height="25px" OnClick="btnVolgendeVraag_Click" Width="192px" />
            <br />
            <br />
            <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lbError" runat="server" Text="Error" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="uitkomstSterren">
            <div class="sterrengetallenlijn">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:15px; left: 642px; width: 85px; margin-bottom: 0px;">Score</span>
                <span class="SterImages">
                <asp:Image ID="imgSter1" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" ImageUrl="Images/legeSter.png" runat="server" />
                </span>
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/<asp:Label ID="lbTotaalAantalVragen" runat="server" Text="50"></asp:Label> vragen</span></div>

            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
            <div id="uitleg" runat="server" style="visibility: hidden; width:100%; height:auto; border-top:solid 1px black; float: right; margin-left: 11px;">
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">
                    Uitleg:
                </span>
                <br />
                <asp:Label ID="lbUitleg" runat="server" Text="lbUitleg"></asp:Label>

                <br />
                <asp:Label ID="lbAntwoord" runat="server" Text="Juiste Antwoord" Visible="False"></asp:Label>
            </div>
                     </ContentTemplate>
            </asp:UpdatePanel>
    </div>
        </div>
</asp:Content>
