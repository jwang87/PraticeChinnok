<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

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
                <li class="active">
                    <a href="#roles" data-toggle="tab">Roles</a>
                </li>
                <li class="active">
                    <a href="#unregistered" data-toggle="tab">Unregistered Users</a>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>

