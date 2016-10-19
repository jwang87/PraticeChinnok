﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row Jumbotron">
        <h1>User and Role Administratoion</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <%-- Nav tabs --%>
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#users" data-toggle="tab">Users</a>
                </li>
                <li>
                    <a href="#roles" data-toggle="tab">Roles</a>
                </li>
                <li>
                    <a href="#unregistered" data-toggle="tab">Unregistered Users</a>
                </li>
            </ul>
            <%-- tab content area --%>
            <div class="tab-content">
                <div class="tab-pane fade in active" id="users">
                    <<h1>Users</h1>
                </div>
                <%--eof--%>
                <div class="tab-pane fade" id="roles">
                    <asp:ListView ID="RoleListView" runat="server" DataSourceID="RoleListViewODS"
                        ItemType="=RoleProfile" InsertItemPosition="LastItem">
                        <EmptyDataTemplate>
                            <span>No security role have been set up</span>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <div class="col-sm-3 h4">Action</div>
                            <div class="col-sm-3 h4">RoleName</div>
                            <div class="col-sm-6 h4">Users</div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="col-sm-3 h4">
                                <asp:LinkButton ID="RemoveRole" runat="server">Remove</asp:LinkButton>
                            </div>
                            <div class="col-sm-3 h4">
                                <%# Item.RoleName %>
                            </div>
                            <div class="col-sm-6 h4">
                                <asp:Repeater ID="RoleUsers" runat="server" DataSource="<%#Item.UserNames %>"
                                     ItemType="System.String">
                                    <ItemTemplate>
                                        <%#Item %>
                                    </ItemTemplate
                                    <SeparatorTemplate>,</SeparatorTemplate>
                                </asp:Repeater>
                            </div>

                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="col-sm-3 h4">
                                <asp:LinkButton ID="InsertRole" runat="server">Insert</asp:LinkButton>
                                                                <asp:LinkButton ID="Cancel" runat="server">Cancel</asp:LinkButton>

                            </div>
                            <div class="col-sm-3 h4">
                                <asp:TextBox ID="RoleName" runat="server"
                                     Text='<%# BindItem.RoleName %>' placeholder="Role Name"></asp:TextBox>
                            </div>

                        </InsertItemTemplate>
                    </asp:ListView>
                    <asp:ObjectDataSource ID="RoleListViewODS" runat="server"></asp:ObjectDataSource>
                </div>
                <%--eof--%>
                <div class="tab-pane fade" id="unregistered">
                </div>
                <%--eof--%>
            </div>
        </div>
    </div>
</asp:Content>

