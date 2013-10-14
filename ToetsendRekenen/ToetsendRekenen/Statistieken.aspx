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
        <asp:TextBox ID="tbOudWW" runat="server" Height="16px" Width="124px" TextMode="Password"></asp:TextBox>
        <br />
        Nieuw wachtwoord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="tbNieuwWW" runat="server" Height="16px" Width="124px" style="margin-left: 3px" TextMode="Password"></asp:TextBox>
        <br />
        Opnieuw nieuw wachtwoord&nbsp;&nbsp;
        <asp:TextBox ID="tbBevestigingNieuwWW" runat="server" Height="16px" Width="124px" TextMode="Password"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br /> 
        <asp:Label ID="lbResultaatChange" runat="server" Text="Resultaat" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>&nbsp;<br />
        <asp:Button ID="btnWijzigWW" runat="server" Text="Wijzig wachtwoord" Height="25px" Width="132px" OnClick="btnWijzigWW_Click" />
        <br />
    </p>
    <p>
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Statistieken</span></p>
    <p>
        Week&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="121px" style="margin-left: 2px">
            <asp:ListItem>Week 35</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensWeek" runat="server" Text="Toon gegevens" />
        <br />
        Maand&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="121px" style="margin-left: 3px">
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
                <asp:BoundField DataField="Oefening" HeaderText="Oefening" SortExpression="Oefening" />
                <asp:BoundField DataField="Categorie" HeaderText="Categorie" SortExpression="Categorie" />
                <asp:BoundField DataField="SubCategorie" HeaderText="SubCategorie" SortExpression="SubCategorie" />
                <asp:BoundField DataField="Aantal Goed" HeaderText="Aantal Goed" ReadOnly="True" SortExpression="Aantal Goed" />
                <asp:BoundField DataField="Aantal Fout" HeaderText="Aantal Fout" ReadOnly="True" SortExpression="Aantal Fout" />
            </Columns>

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PVB1314-003ConnectionString %>" SelectCommand="SELECT DISTINCT R.Oefening &quot;Oefening&quot;, R.Categorie &quot;Categorie&quot;, R.SubCategorie &quot;SubCategorie&quot;, sum(R.AantalGoed) &quot;Aantal Goed&quot; , sum(R.AantalFout) &quot;Aantal Fout&quot; FROM Resultaat R
Group by R.Oefening, R.Categorie, R.SubCategorie"></asp:SqlDataSource>
    </p>
<p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="Views" HeaderText="Views" ReadOnly="True" SortExpression="Views" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" DataFormatString="{0:MM/dd/yyyy}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PVB1314-003ConnectionString2 %>" SelectCommand="Select count(s.SessieID) &quot;Views&quot;, s.Datum
from Sessie s 
group by s.Datum"></asp:SqlDataSource>
    </p>
</asp:Content>
