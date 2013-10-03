<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Getallenlijn.aspx.cs" Inherits="ToetsendRekenen.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="sommenContent">
        <div class="som">
            <div>
                 <div><asp:Image ID="Getallenlijn" runat="server" ImageUrl="Images/Getallenlijn.png"/></div>
                 <div id="Pijltje" runat="server" style="position:absolute; left:291px; right:708px; top: 37px;"><asp:Image ID="Pijl" runat="server" ImageUrl="Images/pijltje.png" /></div>
                 <div style="margin-left:20px; margin-top:-10px; width: 12px;"><asp:Label ID="StartNummer" runat="server" Text="0" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
                 <div style="margin-left:200px; margin-top:-30px; width: 12px;"><asp:Label ID="MiddelNummer" runat="server" Text="5" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
                 <div style="margin-left:373px; margin-top:-30px; width: 12px;"><asp:Label ID="EindNummer" runat="server" Text="10" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
            </div>
            <br />
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">Getallenlijn</span><br />
            <br />
            Welk nummer wijst de pijl aan<br />
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="False" Font-Size="Medium" Height="131px" Width="49px">
                <asp:ListItem Value="1">3</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem Value="3">5</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
        <div class="uitkomstSterren">
            <div class="sterren">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px;">Score</span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" />
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang 24/50 vragen</span></div>

            </div>
            <div class="uitleg"><span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Uitleg</span></div>
            
            
            
        </div>
    </div>
</asp:Content>
