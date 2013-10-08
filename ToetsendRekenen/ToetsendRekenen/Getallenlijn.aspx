<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Getallenlijn.aspx.cs" Inherits="ToetsendRekenen.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="sommenContent">
        <div class="som">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <div><asp:Image ID="Getallenlijn" runat="server" ImageUrl="Images/Getallenlijn.png"/></div>
                        <div id="Pijltje" runat="server" style="position:absolute; left:255px; right:708px; top: 37px;"><asp:Image ID="Pijl" runat="server" ImageUrl="Images/pijltje.png" /></div>
                        <div style="margin-left:20px; margin-top:-10px; width: 12px;"><asp:Label ID="StartNummer" runat="server" Text="0" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
                        <div style="margin-left:200px; margin-top:-30px; width: 12px;"><asp:Label ID="MiddelNummer" runat="server" Text="5" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
                        <div style="margin-left:373px; margin-top:-30px; width: 12px;"><asp:Label ID="EindNummer" runat="server" Text="10" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue" style="font-family:Calibri"></asp:Label></div>
                    </div>
                    <br />
                    <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">Getallenlijn</span><br />
                    <br />
                    Welk nummer wijst de pijl aan<br />
                    <br />
                    <asp:RadioButtonList ID="cblAntwoorden" runat="server" Font-Bold="False" Font-Size="Medium" Height="125px" Width="53px" AutoPostBack="True" OnSelectedIndexChanged="Antwoorden_SelectedIndexChanged">
                    <asp:ListItem Value="1">300</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">5</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lbResultaat" runat="server" Text="Resultaat"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnNext" runat="server" BackColor="#3333FF" ForeColor="White" Text="Naar de volgende vraag" Visible="False" Width="154px" OnClick="btnNext_Click" />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lbError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
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
