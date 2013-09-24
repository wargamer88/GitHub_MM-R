<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Sommen.aspx.cs" Inherits="ToetsendRekenen.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 50px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="sommenContent">
        <div class="som">&nbsp;
            <br />
            <br />
            <br />
            Tel de volgende getallen bij elkaar op.<br />
            <br />
            40 + 50 = <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <br />
            <br />
        </div>
        <div class="uitkomstSterren">
            <div class="sterren">
                <img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/Ster.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /><img alt="" class="auto-style2" src="Images/legeSter.png" /></div>
        </div>
    </div>
</asp:Content>
