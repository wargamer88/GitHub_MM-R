<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Statistieken.aspx.cs" Inherits="ToetsendRekenen.WebForm5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <p>
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Hoofdmenu</span></p>
    <p>
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Account</span><br />
        Wachtwoord wijzigen</p>
    <p>
        Oud wachtwoord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" Height="16px" Width="124px"></asp:TextBox>
        <br />
        Nieuw wachtwoord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="TextBox7" runat="server" Height="16px" Width="124px"></asp:TextBox>
        <br />
        Opnieuw nieuw wachtwoord&nbsp;&nbsp;
        <asp:TextBox ID="TextBox8" runat="server" Height="16px" Width="124px"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnWijzigWW" runat="server" Text="Wijzig wachtwoord" Height="25px" Width="132px" />
        <br />
    </p>
    <p>
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Statistieken</span></p>
    <p>
        Week&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="121px">
            <asp:ListItem>Week 35</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensWeek" runat="server" Text="Toon gegevens" />
        <br />
        Maand&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="121px">
            <asp:ListItem>Februari</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensMaand" runat="server" Text="Toon gegevens" />
        <br />
        Jaar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="121px">
            <asp:ListItem>2010</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensJaar" runat="server" Text="Toon gegevens" />
        <br />
        Tussen specifieke data: van
        <asp:TextBox ID="ToonGegevensVariabelVan" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="ToonGegevensVariabelVan_CalendarExtender" runat="server" Enabled="True" TargetControlID="ToonGegevensVariabelVan">
        </asp:CalendarExtender>
&nbsp;t/m
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox5">
        </asp:CalendarExtender>
        <asp:Button ID="ToonGegevensVariabelTot" runat="server" Text="Toon gegevens" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Categorie" HeaderText="Categorie" SortExpression="Categorie" />
                <asp:BoundField DataField="SubCategorie" HeaderText="SubCategorie" SortExpression="SubCategorie" />
                <asp:BoundField DataField="AantalGoed" HeaderText="AantalGoed" SortExpression="AantalGoed" />
                <asp:BoundField DataField="AantalFout" HeaderText="AantalFout" SortExpression="AantalFout" />
            </Columns>

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PVB1314-003ConnectionString %>" SelectCommand="SELECT [Categorie], [SubCategorie], [AantalGoed], [AantalFout] FROM [Resultaat]"></asp:SqlDataSource>
    </p>
    <p>
        <br />
    </p>
</asp:Content>
