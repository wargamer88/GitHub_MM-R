<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="SommenSub.aspx.cs" Inherits="ToetsendRekenen.WebForm1" %>
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

    <img alt="Denken aan sommen" class="auto-style2" src="Images/RekenenDenken.png" />

    <p style="font-size: 19px; font-weight: bolder; font-family: Georgia, 'Times New Roman', Times, serif">
        Kan je met sommen werken?</p>
    <p>
        Selecteer één van de onderstaande categorieën.</p>
    <p style="font-weight:bold;">
        Erbij sommen:
    </p>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">0 t/m 10</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">0 t/m 100</asp:LinkButton>    
        <br />
    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">0 t/m 1000</asp:LinkButton>    
    <p style="font-weight:bold;">
        Eraf sommen:
    </p>
    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">0 t/m 10</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">0 t/m 100</asp:LinkButton>    
        <br />
    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">0 t/m 1000</asp:LinkButton> 
    <p style="font-weight:bold;">
        Keer sommen:
    </p>
    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">0 t/m 10</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">0 t/m 100</asp:LinkButton>    
        <br />
    <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">0 t/m 1000</asp:LinkButton> 
    <p style="font-weight:bold;">
        Deel sommen:
    </p>
    <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">0 t/m 10</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click">0 t/m 100</asp:LinkButton>    
        <br />
    <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click">0 t/m 1000</asp:LinkButton> 
    <p>
        <asp:Label ID="lbError" runat="server" Text="Error" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
    </p>
</asp:Content>
