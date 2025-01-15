<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="tp_web_equipo_C.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Seleccione el premio por el cual desea participar:</h2>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">

                        <%-- Carousel inicio --%>
                        <div id="carouselExample<%# Container.ItemIndex %>" class="carousel slide">
                            <div class="carousel-inner">
                                <%-- Repeater para las imagenes del carousel --%>
                                <asp:Repeater ID="repCarousel" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" alt="ImagenProducto" style="width:100px;height:auto;">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%-- Fin del repeater --%>

                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample<%# Container.ItemIndex %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample<%# Container.ItemIndex %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                        <%-- CarouselFin --%>

                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="btnSeleccionar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="PremioId" />
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
