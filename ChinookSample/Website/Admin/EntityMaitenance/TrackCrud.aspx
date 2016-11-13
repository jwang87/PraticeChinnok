<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrackCrud.aspx.cs" Inherits="Admin_EntityMaitenance_TrackCrud" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="My" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron">
        <h1>Wired ListView Crud</h1>
    </div>
    <My:MessageUserControl runat="server" ID="MessageUserControl" />
    <asp:ListView ID="TrackList" runat="server" DataSourceID="TrackListODS" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFF8DC;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                <td>
                    <asp:DropDownList ID="AlbumList"
                        runat="server"
                        DataSourceID="AlumListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Eval("AlbumId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="MediaTypeList"
                        runat="server"
                        DataSourceID="MediaTypeODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelctedValue='<%# Eval("MediaTypeId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="GenreList"
                        runat="server"
                        DataSourceID="GenreListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Eval("GenreId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Text='<%# Eval("composer") %>' runat="server" ID="composerLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #008A8C; color: #FFFFFF;">
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("TrackId") %>' runat="server" ID="TrackIdTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" /></td>
                <td>
                    <asp:DropDownList ID="AlbumList"
                        runat="server"
                        DataSourceID="AlumListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Bind("AlbumId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="MediaTypeList"
                        runat="server"
                        DataSourceID="MediaTypeODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Bind("MediaTypeId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="GenreList"
                        runat="server"
                        DataSourceID="GenreListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Bind("GenreId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("composer") %>' runat="server" ID="composerTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Milliseconds") %>' runat="server" ID="MillisecondsTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Bytes") %>' runat="server" ID="BytesTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" /></td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("TrackId") %>' runat="server" ID="TrackIdTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" /></td>
                <td>
                    <asp:DropDownList ID="AlbumList"
                        runat="server"
                        DataSourceID="AlumListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Bind("AlbumId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="MediaTypeList"
                        runat="server"
                        DataSourceID="MediaTypeODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Bind("MediaTypeId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="GenreList"
                        runat="server"
                        DataSourceID="GenreListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Bind("GenreId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("composer") %>' runat="server" ID="composerTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Milliseconds") %>' runat="server" ID="MillisecondsTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Bytes") %>' runat="server" ID="BytesTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" /></td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                <td>
                    <asp:DropDownList ID="AlbumList"
                        runat="server"
                        DataSourceID="AlumListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Eval("AlbumId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="MediaTypeList"
                        runat="server"
                        DataSourceID="MediaTypeODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelctedValue='<%# Eval("MediaTypeId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="GenreList"
                        runat="server"
                        DataSourceID="GenreListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Eval("GenreId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Text='<%# Eval("composer") %>' runat="server" ID="composerLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">TrackId</th>
                                <th runat="server">Name</th>
                                <th runat="server">AlbumId</th>
                                <th runat="server">MediaTypeId</th>
                                <th runat="server">GenreId</th>
                                <th runat="server">composer</th>
                                <th runat="server">Milliseconds</th>
                                <th runat="server">Bytes</th>
                                <th runat="server">UnitPrice</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                        <asp:DataPager runat="server" ID="DataPager1">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                <td>
                    <asp:DropDownList ID="AlbumList"
                        runat="server"
                        DataSourceID="AlumListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Eval("AlbumId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="MediaTypeList"
                        runat="server"
                        DataSourceID="MediaTypeODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelctedValue='<%# Eval("MediaTypeId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="GenreList"
                        runat="server"
                        DataSourceID="GenreListODS"
                        DataTextField="DisplayText"
                        DataValueField="PFKeyIdentifier"
                        SelectedValue='<%# Eval("GenreId") %>'>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Text='<%# Eval("composer") %>' runat="server" ID="composerLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="TrackListODS" runat="server"
        DataObjectTypeName="ChinookSystem.Data.Entities.Track"
        DeleteMethod="Delete_Track"
        InsertMethod="Insert_Track"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="List_Tracks_Get"
        TypeName="ChinookSystem.BLL.TrackController"
        UpdateMethod="Update_Track" OnDeleted="CheckForException" OnInserted="CheckForException" OnUpdated="CheckForException"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AlumListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="AlbumList"
        TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MediaTypeODS"
        runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="MediaTypeList"
        TypeName="ChinookSystem.BLL.MediaTypeController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GenreListODS"
        runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GenreList"
        TypeName="ChinookSystem.BLL.GenreController"></asp:ObjectDataSource>
</asp:Content>

