<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="PanelControl.aspx.cs" Inherits="TPFinalNivel3RamirezDiego.PanelControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sectionStyle">
        <div class="perfilStyle">
            <h3>Articulos</h3>
            <asp:Button ID="btnAgregarArt" OnClick="btnAgregarArt_Click" CssClass="btnStyle btnBusqueda" runat="server" Text="Agregar" />
        </div>
        <div class="perfilStyle">
            <h3>Categorias</h3>
            <asp:Button ID="btnAgregarCategoria" CssClass="btnStyle btnBusqueda" OnClick="btnAgregarCategoria_Click" runat="server" Text="Agregar" />
            <asp:Button ID="btnEditarCategoria" CssClass="btnStyle btnBusqueda" OnClick="btnEditarCategoria_Click" runat="server" Text="Editar" />
        </div>
        <div class="perfilStyle">
            <h3>Marcas</h3>
            <asp:Button ID="btnAgregarMarca" CssClass="btnStyle btnBusqueda" OnClick="btnAgregarMarca_Click" runat="server" Text="Agregar" />
            <asp:Button ID="btnEditarMarca" CssClass="btnStyle btnBusqueda" OnClick="btnEditarMarca_Click" runat="server" Text="Editar" />
        </div>
    </div>
    <div class="sectionStyle">
        <h3 id="Index" runat="server" visible="false">Index</h3>
    </div>
    <div class="sectionStyle">
        <div id="Agregar" class="perfilStyle" runat="server" visible="false">
            <h4>Agregar</h4>
            <asp:Label ID="lblNombreAgregar" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="tbAgregar" runat="server"></asp:TextBox>
            <asp:Button CssClass="btnStyle" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
            <asp:Button ID="btnAgregarCancelar" OnClick="btnAgregarCancelar_Click" CssClass="btnStyle btnCerrarSesion" runat="server" Text="Cancelar" />
        </div>
        <div id="Editar" class="perfilStyle" runat="server" visible="false">
            <h4>Editar</h4>
            <asp:DropDownList ID="ddlEditar" runat="server"></asp:DropDownList>
            <asp:Label ID="lblNombreEditar" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="tbEditar" runat="server"></asp:TextBox>
            <asp:Button CssClass="btnStyle" ID="btnEditar" OnClick="btnEditar_Click" runat="server" Text="Editar" />
            <asp:Button ID="btnEditarCancelar" OnClick="btnEditarCancelar_Click" CssClass="btnStyle btnCerrarSesion" runat="server" Text="Cancelar" />
        </div>
    </div>
    <div class="sectionStyle">
        <div class="alert alert-danger" role="alert" runat="server" id="error" visible="false">
            Nombre ya ocupado...
        </div>
        <div class="alert alert-success" role="alert" runat="server" id="exito" visible="false">
            Agregado con exito...
        </div>
    </div>
    <!-- Se agrego debido a que al dar enter sobre el text box redidirigia a otra pagina
     Elimina el evento al presionar la tecla enter-->
    <script type="text/javascript">
        function disableEnterKey(e) {
            var key;
            if (window.event) {
                key = window.event.keyCode; //IE
            } else {
                key = e.which; //Firefox
            }
            if (key == 13) {
                return false; //Desactivar Enter
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
