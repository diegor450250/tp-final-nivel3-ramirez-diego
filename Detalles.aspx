<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="TPFinalNivel3RamirezDiego.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function errorImage(image) {
        image.onerror = null;
        image.src = "https://www.tropicalserver.com/wp-content/uploads/2020/06/error-403.jpg";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sectionStyle">
        <asp:Label ID="lblInfo" Visible="false" runat="server" Text="Agregado exitosamente..."></asp:Label>
        <asp:Button ID="btnVer" OnClick="btnVer_Click" runat="server" Visible="false" CssClass="btnBusqueda" Text="Ver articulo..." />
    </div>
    <div class="sectionStyle">
        <asp:Button ID="btnAgregarFav" runat="server" cssclass="btnStyle" OnClick="btnAgregarFav_Click" Text="Agregar a favoritos" />
        <asp:Button ID="btnEliminarFav" Visible="false" runat="server" cssclass="btnStyle btnCerrarSesion" onclick="btnEliminarFav_Click" Text="Eliminar de favoritos" />
    </div>
    <div class="sectionStyle">
        <div class="perfilStyle">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="tbNombre" CssClass="tbStyle" Enabled="false" runat="server"></asp:TextBox>
            <asp:Label ID="lblCodigo" runat="server" Text="Codigo:"></asp:Label>
            <asp:TextBox ID="tbCodigo" CssClass="tbStyle" Enabled="false" runat="server"></asp:TextBox>
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label>
            <asp:TextBox ID="tbDescripcion" CssClass="tbStyle" Enabled="false" runat="server"></asp:TextBox>
            <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
            <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
            <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
            <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="tbPrecio" CssClass="tbStyle" TextMode="Number" Enabled="false" runat="server"></asp:TextBox>
            <asp:Label ID="lblImagen" runat="server" Text="Imagen:"></asp:Label>
            <asp:TextBox ID="tbImagen" TextMode="MultiLine" CssClass="tbStyle" Enabled="false" runat="server"></asp:TextBox>
            <img src="<%: articulo.Imagen %>" alt="<%: articulo.Nombre %>" onerror="errorImage(this)" class="imagenArticulo margen" />
            <div class="sectionStyle">
                <asp:Button ID="btnEditar" Visible="false" CssClass="btnStyle" runat="server" Text="Editar" />
                <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" Visible="false" CssClass="btnStyle btnCerrarSesion" runat="server" Text="Elminar" />
            </div>
        </div>
    </div>
    <div class="sectionStyle">
        <asp:Button ID="btnAgregarArt" Visible="false" runat="server" cssclass="btnStyle" Text="Agregar articulo" onclick="btnAgregarArt_Click"/>
        <asp:Button ID="btnCancelar" Visible="false" CssClass="btnStyle btnCerrarSesion" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
