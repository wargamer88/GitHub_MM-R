<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Statistieken.aspx.cs" Inherits="ToetsendRekenen.WebForm5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Hoofdmenu</span>
    <br />  
    <br />
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Wachtwoord Wijzigen</span><br />
    <p>
        Oud wachtwoord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbOudWW" runat="server" Height="16px" Width="124px" TextMode="Password"></asp:TextBox>
        <br />
        Nieuw wachtwoord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="tbNieuwWW" runat="server" Height="16px" Width="124px" style="margin-left: 3px" TextMode="Password"></asp:TextBox>
        <br />
        Opnieuw nieuw wachtwoord&nbsp;&nbsp;
        <asp:TextBox ID="tbBevestigingNieuwWW" runat="server" Height="16px" Width="124px" TextMode="Password" style="margin-left: 1px"></asp:TextBox>
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
        <asp:DropDownList ID="ddlWeek" runat="server" Height="21px" Width="121px" style="margin-left: 2px">
            <asp:ListItem>Week 35</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensWeek" runat="server" Text="Toon gegevens" />
        <br />
        Maand&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ddlMaand" runat="server" Height="21px" Width="121px" style="margin-left: 3px">
            <asp:ListItem>Februari</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensMaand" runat="server" Text="Toon gegevens" />
        <br />
        Jaar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="ddlJaar" runat="server" Height="21px" Width="121px">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensJaar" runat="server" Text="Toon gegevens" />
        <br />
        Tussen specifieke data: van
        <asp:TextBox ID="tbDatumVan" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="tbDatumVan_CalendarExtender" runat="server" Enabled="True" TargetControlID="tbDatumVan">
        </asp:CalendarExtender>
&nbsp;t/m
        <asp:TextBox ID="tbDatumTot" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="tbDatumTot_CalendarExtender" runat="server" Enabled="True" TargetControlID="tbDatumTot">
        </asp:CalendarExtender>
        <asp:Button ID="ToonGegevensVariabelTot" runat="server" Text="Toon gegevens" />
    </p>
    <div id="Tables" style="height : 160px; overflow :scroll;">
    <div style="float:left">
        <asp:GridView ID="gvResultaat" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Oefening" HeaderText="Oefening" SortExpression="Oefening" />
                <asp:BoundField DataField="Categorie" HeaderText="Categorie" SortExpression="Categorie" />
                <asp:BoundField DataField="SubCategorie" HeaderText="SubCategorie" SortExpression="SubCategorie" />
                <asp:BoundField DataField="Aantal Goed" HeaderText="Aantal Goed" ReadOnly="True" SortExpression="Aantal Goed" />
                <asp:BoundField DataField="Aantal Fout" HeaderText="Aantal Fout" ReadOnly="True" SortExpression="Aantal Fout" />
            </Columns>

        </asp:GridView>
    </div>
        <div id="gvViewsp" style="float:left; margin-left:50px;">
            <asp:GridView ID="gvViews" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Views" HeaderText="Views" ReadOnly="True" SortExpression="Views" />
                    <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" DataFormatString="{0:MM/dd/yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <p>
        <asp:Label ID="lbErrorStats" runat="server" Font-Bold="True" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>
