<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="tp_web_equipo_C.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Seleccione el premio por el cual desea participar:</h2>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">

                        <img src="<%#Eval("Imagenes[0].ImagenUrl")%>" class="card-img-top" alt="" style=" width: 200px;">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-primary" onclick="btnSeleccionar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="PremioId" />
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
