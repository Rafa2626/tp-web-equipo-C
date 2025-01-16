<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="tp_web_equipo_C.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="container vh-100 d-flex justify-content-center align-items-center">
        <div class="row w-75">
            <h2 class="text-center mb-4">Formulario de registro</h2>
             <asp:Panel ID="FormPanel" runat="server" CssClass="row">
                    <div class="col-md-6">
                        <div class="mb-3">
                             <asp:Label ID="lblDni" runat="server" Text="DNI" CssClass="form-label"></asp:Label>
                             <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" Required="true" OnTextChanged="txtDni_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:Label ID="lblValidarDni" runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                        <%--<div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="textNombre" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarNombre" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="textNombre" ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="textApellido" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarApellido" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="textApellido" ErrorMessage="El apellido es obligatorio." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="textEmail" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarEmail" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="textEmail" ErrorMessage="El email es obligatorio." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="textEmail" ErrorMessage="Formato de email inválido." CssClass="text-danger" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>

                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label ID="lblDireccion" runat="server" Text="Dirección" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Required="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="La dirección es obligatoria." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                                <asp:Label ID="lblValidarCiudad" runat="server" CssClass="text-danger"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ControlToValidate="txtCiudad" ErrorMessage="La ciudad es obligatoria." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>--%>

                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="textNombre" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarNombre" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="textApellido" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarApellido" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="textEmail" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarEmail" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarDireccion" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" Required="true" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblValidarCiudad" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblCp" runat="server" Text="Codigo postal" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCp" runat="server" CssClass="form-control" Required="true" OnTextChanged="txtCp_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:Label ID="lblValidarCP" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                        <div class="form-check mb-3">
                            <asp:CheckBox ID="chkCondiciones" runat="server" CssClass="form-check-input" />
                            <asp:Label ID="lblCondiciones" runat="server" Text="Acepto las condiciones" CssClass="form-check-label"></asp:Label>
                        </div>
                        <div class="mb-3">
                        <asp:Label ID="lblNoAcepto" runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                    </div>
                 </asp:Panel>
                <div class="text-center">
                    <asp:Label ID="lblNoContinuar" runat="server" CssClass="text-danger"></asp:Label>
                    <asp:Button ID="btnParticipar" runat="server" Text="Participar" CssClass="btn btn-primary w-50" OnClick="btnParticipar_Click" />
                </div>
        </div>
    </div>
    </main>
</asp:Content>
