<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3RamirezDiego.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sectionStyle">
        <asp:Button ID="btnVerTodos" runat="server" OnClick="btnVerTodos_Click" CssClass="btnStyle" Text="Ver todos" />
        <asp:Button ID="btnVerFavoritos" runat="server" OnClick="btnVerFavoritos_Click" CssClass="btnStyle" Text="Ver Favoritos" />
    </div>
    <div class="articulosStyle">
        <%foreach (Dominio.Articulo art in list)
            {
        %>
        <div class="contArticuloStyle">
            <div class="articuloStyle">
                <div>
                    <img src="<%= art.Imagen %>" class="imagenArticulo" alt="<%= art.Nombre %>">
                </div>
                <div>
                    <h5><%= art.Nombre %> </h5>
                    <p><%= art.Descripcion %> </p>
                    <p>Precio: <%= art.Precio.ToString() %> </p>
                    <p>Codigo: <%= art.Codigo %> </p>
                </div>
            </div>
            <div>
                <a href="Detalles.aspx?id=<%= art.Id %>">Ver Detalles</a>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
