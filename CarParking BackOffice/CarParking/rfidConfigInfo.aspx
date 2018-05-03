<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rfidConfigInfo.aspx.cs" Inherits="CarParking.rfidConfigInfo" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper">

        <asp:HiddenField ID="hidImage" runat="server" />
        <div class="content-wrapper">
            <div class="col-lg-8"></div>
            <div class="col-lg-4" id="AlertMsg" runat="server">
                <div class="bs-component">
                    <div class="alert alert-dismissible alert-info">
                        <button class="close" type="button" data-dismiss="alert">×</button><strong>Save success!</strong>
                    </div>
                </div>
            </div>
            <div class="row user text">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-2">
                        <asp:Label ID="Label2" runat="server" Text="RFID No."></asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtRfidUid" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="txtRfidUid"
                            runat="server" ErrorMessage="*กรุณาใส่ข้อมูล" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Car register no."></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCarNo" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="txtCarNo"
                            runat="server" ErrorMessage="*กรุณาใส่ข้อมูล" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-1">
                        <asp:LinkButton ID="LinkButton2" runat="server"
                            ClientIDMode="Static"
                            CssClass="btn btn-primary" OnClick="SaveBtn_Click">บันทึก</asp:LinkButton>
                    </div>
                    <div class="col-md-11 text-right">
                        <asp:LinkButton ID="LinkButton1" runat="server"
                            ClientIDMode="Static"
                            CssClass="btn btn-warning" OnClick="SaveBackClick">Back </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
