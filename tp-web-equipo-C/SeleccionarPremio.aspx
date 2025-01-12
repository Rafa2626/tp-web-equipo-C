<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="tp_web_equipo_C.SeleccionarPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Seleccione el premio por el cual desea participar.</h2>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
            foreach(Dominio.Premio prem in ListaPremios)
            {
        %>
            <div class="col">
                <div class="card h-100">
                    <img src="..." class="card-img-top" alt="...">
                    <div class="card-body">

                        <h5 class="card-title"<% prem.Nombre%></h5>
                        <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    </div>
                </div>
            </div>
        <% } %>

    </div>
</asp:Content>
