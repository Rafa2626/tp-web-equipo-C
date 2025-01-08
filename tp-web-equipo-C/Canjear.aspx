<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Canjear.aspx.cs" Inherits="tp_web_equipo_C.Cajear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container vh-100">
        <div class="container text-center">
            <div class="row">
                <div class="col">
                </div>
                <div class="col">
                    <h1>Canjear Voucher</h1>
                    <p>Ingrese el código de su voucher!</p>
                    <asp:TextBox ID="txtVoucher" runat="server" placeholder="XXXX-XXXX-XXXX-XXXX"></asp:TextBox>
                    <div style="margin-top: 10px;">
                        <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente" />
                    </div>
                </div>
                <div class="col">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
