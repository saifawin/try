<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usersList.aspx.cs" Inherits="CarParking.UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="css/page.css">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
        <div class="content-wrapper">
            <div class="text-left">
                <div class="row">
                    <div class="col-md-1">
                        <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label>
                    </div>
                </div>
                <div class="row">

                    <div class="col-md-3">
                        <asp:DropDownList ID="DropDownListSearch" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtSearch" Width="100%" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:LinkButton ID="LinkButton3" runat="server"
                            ClientIDMode="Static"
                            CssClass="btn btn-info" OnClick="SearchBtn_Click">Search</asp:LinkButton>
                    </div>
                </div>
            </div>
            <br /> <br /><br />
            <div class="table-responsive">
                <asp:GridView CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" AllowPaging="true" ID="UsersGridView" runat="server" OnRowCommand="UsersGridView_RowCommand" >
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#">
                            <ItemStyle ForeColor="Transparent" Width="0%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name">
                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="LastName" HeaderText="Last Name">
                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PhoneNo" HeaderText="Phone No">
                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CarNo" HeaderText="Car No">
                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
