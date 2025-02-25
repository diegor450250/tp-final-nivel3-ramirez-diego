<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3RamirezDiego.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function errorImage(image) {
            image.onerror = null;
            image.src = "https://www.tropicalserver.com/wp-content/uploads/2020/06/error-403.jpg";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="articulosStyle">
        <asp:TextBox ID="tbBusqueda" runat="server" placeholder="Busqueda por nombre..." CssClass="busquedaStyle"></asp:TextBox>
        <div>
            <asp:TextBox ID="tbBusquedaPrecio" TextMode="Number" placeholder="Busqueda por precio..." CssClass="busquedaStyle" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlBusquedaPrecio" CssClass="busquedaStyle" runat="server"></asp:DropDownList>
            <div class="sectionStyle">
                <asp:Label ID="lblMarcaBusqueda" runat="server" Text="Marca: "></asp:Label>
                <asp:DropDownList ID="ddlMarcas" CssClass="busquedaStyle" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="cbMarcasFiltro" CssClass="busquedaStyle" runat="server" />
            </div>
            <div class="sectionStyle">
                <asp:Label ID="lblCategoriasBusqueda" runat="server" Text="Categoria: "></asp:Label>
                <asp:DropDownList ID="ddlCategorias" CssClass="busquedaStyle" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="cbCtegoriasFiltro" CssClass="busquedaStyle" runat="server" />
            </div>
        </div>
        <div class="sectionStyle">
            <asp:Button ID="btnBusqueda" OnClick="btnBusqueda_Click" CssClass="btnStyle btnBusqueda" runat="server" Text="Buscar" />
            <asp:Button ID="btnLimpiarFiltro" OnClick="btnLimpiarFiltro_Click" CssClass="btnStyle btnBusqueda" runat="server" Text="Limpiar filtros" />
        </div>
    </div>
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
                    <img src="<%= art.Imagen %>" class="imagenArticulo" onerror="errorImage(this)" alt="<%= art.Nombre %>">
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
    <div id="info" class="sectionStyle" visible="false" role="alert" runat="server">
        Sin resultados...
    </div>
</asp:Content>
