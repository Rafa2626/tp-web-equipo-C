<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="tp_web_equipo_C.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>

            <h2 id="title"><%:MiTitulo %>.</h2>
            <h3>Usted ya esta participando por el siguiente premio:</h3>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <div class="col">
                    <div class="card h-100">

                        <img src="<%:filtrada[0].Imagenes[0].ImagenUrl%>" class="card-img-top" alt="" style="width: 200px;">
                        <div class="card-body">
                            <h5 class="card-title"><%:filtrada[0].Nombre %></h5>
                            <p class="card-text"><%:filtrada[0].Descripcion %></p>
                            <asp:Button ID="btnInicio" runat="server" Text="Inicio" CssClass="btn btn-primary" OnClick="btnInicio_Click"/>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </main>
</asp:Content>
