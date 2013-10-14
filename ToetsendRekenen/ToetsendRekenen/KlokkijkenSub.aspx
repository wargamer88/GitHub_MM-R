<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="KlokkijkenSub.aspx.cs" Inherits="ToetsendRekenen.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Klokkijken.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="subs">
        <span style="font-weight: bold">Analoog</span>
        <br />
        <br />
        <asp:LinkButton ID="lblAnaloog15" runat="server" OnClick="lblAnaloog15_Click">15 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblAnaloog10" runat="server" OnClick="lblAnaloog10_Click">10 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblAnaloog5" runat="server" OnClick="lblAnaloog5_Click">5 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblAnaloog1" runat="server" OnClick="lblAnaloog1_Click">1 minuten</asp:LinkButton><br />

    </div>
    <div class="subs subsFloat">
        <span style="font-weight: bold">Digitaal</span>
        <br />
        <br />
        <asp:LinkButton ID="lblDigitaal15" runat="server" OnClick="lblDigitaal15_Click">15 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblDigitaal10" runat="server" OnClick="lblDigitaal10_Click">10 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblDigitaal5" runat="server" OnClick="lblDigitaal5_Click">5 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblDigitaal1" runat="server" OnClick="lblDigitaal1_Click">1 minuten</asp:LinkButton><br />

    </div>
    <div class="subsBreed">
        <span style="font-weight: bold">Analoog naar digitaal</span>
        <br />
        <br />
        <asp:LinkButton ID="lblAnaarD15" runat="server" OnClick="lblAnaarD15_Click">15 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblAnaarD10" runat="server" OnClick="lblAnaarD10_Click">10 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblAnaarD5" runat="server" OnClick="lblAnaarD5_Click">5 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblAnaarD1" runat="server" OnClick="lblAnaarD1_Click">1 minuten</asp:LinkButton><br />

    </div>
    <div class="subsBreed">
        <span style="font-weight: bold">Digitaal naar analoog</span>
        <br />
        <br />
        <asp:LinkButton ID="lblDnaarA15" runat="server" OnClick="lblDnaarA15_Click">15 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblDnaarA10" runat="server" OnClick="lblDnaarA10_Click">10 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblDnaarA5" runat="server" OnClick="lblDnaarA5_Click">5 minuten</asp:LinkButton><br />
        <asp:LinkButton ID="lblDnaarA1" runat="server" OnClick="lblDnaarA1_Click">1 minuten</asp:LinkButton><br />

    </div>
    <div id="animatedClockDIV">
        <img id="animatedClockGIF" src="Images/Clock.gif" /></div>

    <div id="Spacer"></div>
    <div id="Errorlbl">
        <asp:Label ID="lbError" runat="server" Text="Error" ForeColor="Red" Visible="False"></asp:Label>
    </div>
</asp:Content>
