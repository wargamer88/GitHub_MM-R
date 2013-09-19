<%@ Page Title="" Language="C#" MasterPageFile="~/Master_AmazingBooks.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AmazingBooksASP.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="AmazingBooksSource">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="Item ID" HeaderText="Item ID" SortExpression="Item ID" />
        <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
        <asp:BoundField DataField="Inkoop Prijs" HeaderText="Inkoop Prijs" SortExpression="Inkoop Prijs" />
        <asp:BoundField DataField="Verkoop Prijs" HeaderText="Verkoop Prijs" SortExpression="Verkoop Prijs" />
        <asp:BoundField DataField="Uitgever" HeaderText="Uitgever" SortExpression="Uitgever" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
        <asp:BoundField DataField="Artikel Type" HeaderText="Artikel Type" SortExpression="Artikel Type" />
        <asp:BoundField DataField="Schrijver" HeaderText="Schrijver" ReadOnly="True" SortExpression="Schrijver" />
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
<asp:SqlDataSource ID="AmazingBooksSource" runat="server" ConnectionString="<%$ ConnectionStrings:Amazing_BooksConnectionString %>" SelectCommand="Select i.item_id &quot;Item ID&quot;, i.isbn &quot;ISBN&quot; , i.wholesale_cost &quot;Inkoop Prijs&quot; , i.retail_price &quot;Verkoop Prijs&quot; , p.publisher &quot;Uitgever&quot; , s.subject &quot;Subject&quot;,  t.item_type &quot;Artikel Type&quot;, a.first_name + ' ' + a.last_name &quot;Schrijver&quot;
from item i
right join publisher p
on i.publisher_id=p.publisher_id
right join subject s
on i.subject_id=s.subject_id
right join item_type t
on i.item_type_id=t.item_type_id
right join author a
on i.author_id=a.author_id"></asp:SqlDataSource>
</asp:Content>
