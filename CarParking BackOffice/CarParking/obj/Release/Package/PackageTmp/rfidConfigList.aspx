<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rfidConfigList.aspx.cs" Inherits="CarParking.rfidConfigList" %>

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
            <div class="text-right">
                <asp:LinkButton ID="LinkButton1" runat="server"
                    ClientIDMode="Static"
                    CssClass="btn btn-info" OnClick="AddBtn_Click">Add</asp:LinkButton>
            </div>
            <br />
            <div class="table-responsive">
                <asp:GridView CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" AllowPaging="true" ID="RfidConfigGridView" runat="server" OnRowCommand="RfidConfigGridView_RowCommand" OnRowDataBound="RfidConfigGridView_RowDataBound">
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#">
                            <ItemStyle ForeColor="Transparent" Width="0%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="RfidUid" HeaderText="RFID No.">
                            <ItemStyle Width="45%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CarNo" HeaderText="Car register no.">
                            <ItemStyle Width="45%"></ItemStyle>
                        </asp:BoundField>
                        <asp:ButtonField HeaderText="Remove" Text=" Remove " ControlStyle-CssClass="btn btn-danger" CommandName="RemoveRow">
                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                            <ItemStyle Width="5%"></ItemStyle>
                        </asp:ButtonField>
                        <asp:ButtonField HeaderText="Edit" Text="Edit" ControlStyle-CssClass="btn btn-success" CommandName="EditRow">
                            <ControlStyle CssClass="btn btn-success"></ControlStyle>
                            <ItemStyle Width="5%"></ItemStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
