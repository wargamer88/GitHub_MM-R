<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Statistieken.aspx.cs" Inherits="ToetsendRekenen.WebForm5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:Button ID="btnWijzigWW" runat="server" Text="Wijzig wachtwoord" Height="26px" BackColor="#3333FF" ForeColor="White" Width="132px" OnClick="btnWijzigWW_Click1" />
    <p>
        <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Statistieken</span></p>
    <p style="border-bottom: solid 2px #3333FF; border-top: solid 2px #3333FF; ">
        <br />
        Week:
        <asp:DropDownList ID="ddlWeek" runat="server" Height="21px" Width="121px" style="margin-left: 165px">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
            <asp:ListItem>33</asp:ListItem>
            <asp:ListItem>34</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>37</asp:ListItem>
            <asp:ListItem>38</asp:ListItem>
            <asp:ListItem>39</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>41</asp:ListItem>
            <asp:ListItem>42</asp:ListItem>
            <asp:ListItem>43</asp:ListItem>
            <asp:ListItem>44</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>46</asp:ListItem>
            <asp:ListItem>47</asp:ListItem>
            <asp:ListItem>48</asp:ListItem>
            <asp:ListItem>49</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>51</asp:ListItem>
            <asp:ListItem>52</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensWeek" runat="server" Text="Toon gegevens" OnClick="ToonGegevensWeek_Click" />
        <br />
        Maand:<asp:DropDownList ID="ddlMaand" runat="server" Height="21px" Width="121px" style="margin-left: 161px">
            <asp:ListItem Value="01">Januari</asp:ListItem>
            <asp:ListItem Value="02">Februari</asp:ListItem>
            <asp:ListItem Value="03">Maart</asp:ListItem>
            <asp:ListItem Value="04">April</asp:ListItem>
            <asp:ListItem Value="05">Mei</asp:ListItem>
            <asp:ListItem Value="06">Juni</asp:ListItem>
            <asp:ListItem Value="07">Juli</asp:ListItem>
            <asp:ListItem Value="08">Augustus</asp:ListItem>
            <asp:ListItem Value="09">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensMaand" runat="server" Text="Toon gegevens" OnClick="ToonGegevensMaand_Click" />
        <br />
        Jaar:
        <asp:DropDownList ID="ddlJaar" runat="server" Height="21px" Width="121px" style="margin-left: 179px">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ToonGegevensJaar" runat="server" Text="Toon gegevens" OnClick="ToonGegevensJaar_Click" />
        <br />
        Tussen specifieke data: van
        <asp:TextBox ID="tbDatumVan" runat="server" style="margin-right:5px;"></asp:TextBox>
        <asp:CalendarExtender ID="tbDatumVan_CalendarExtender" runat="server" Enabled="True" TargetControlID="tbDatumVan">
        </asp:CalendarExtender>
        t/m
        <asp:TextBox ID="tbDatumTot" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="tbDatumTot_CalendarExtender" runat="server" Enabled="True" TargetControlID="tbDatumTot">
        </asp:CalendarExtender>
        <asp:Button ID="ToonGegevensVariabelTot" runat="server" Text="Toon gegevens" OnClick="ToonGegevensVariabelTot_Click" />
        <br />
        <br />
    </p>
    <div id="Tables" style="height : 340px; overflow :scroll;">
    <div style="float:left">
        <asp:GridView ID="gvResultaat" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Oefening" HeaderText="Oefening" SortExpression="Oefening" />
                <asp:BoundField DataField="Categorie" HeaderText="Categorie" SortExpression="Categorie" />
                <asp:BoundField DataField="SubCategorie" HeaderText="SubCategorie" SortExpression="SubCategorie" />
                <asp:BoundField DataField="Aantal Goed" HeaderText="Aantal Goed" ReadOnly="True" SortExpression="Aantal Goed" />
                <asp:BoundField DataField="Aantal Fout" HeaderText="Aantal Fout" ReadOnly="True" SortExpression="Aantal Fout" />
            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView>
    </div>
        <div id="gvViewsp" style="float:left; margin-left:5px; width: 181px;">
            <asp:GridView ID="gvViews" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-left: 0px" Width="181px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Views" HeaderText="Views" ReadOnly="True" SortExpression="Views" />
                    <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
    <p>
        <asp:Label ID="lbErrorStats" runat="server" Font-Bold="True" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>
