<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstQuery.aspx.cs" Inherits="Query_FirstQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Entity vs Linq to Entity Query</h1>
    <asp:DropDownList ID="ReleaseYearList" runat="server" DataSourceID="ReleaseYearODS"
        DataTextField="ReleaseYear" DataValueField="ReleaseYear" AutoPostBack="true">
    </asp:DropDownList>
    <asp:GridView ID="EntityFrameworkList" runat="server" DataSourceID="EntityFrameWorkODS" 
        AllowPaging="True" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ArtistId" HeaderText="ArtistId" SortExpression="ArtistId"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="LinqToEntityList" runat="server" DataSourceID="LinqToEntityODS" AllowPaging="True" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="EntityFrameWorkODS" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Artist_ListAll" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LinqToEntityODS" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Artist_Album_Get" TypeName="ChinookSystem.BLL.ArtistController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ReleaseYearList" PropertyName="SelectedValue" Name="releaseYear" 
                Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ReleaseYearODS" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="AlbumReleaseYear_Get" TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
</asp:Content>

