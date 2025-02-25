<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3RamirezDiego.Perfil1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="sectionStyle">
        <div class="perfilStyle">
            <asp:Image ID="imgPerfil" CssClass="imgPerfilStyle" runat="server"></asp:Image>
            <asp:Label ID="lblImagen" runat="server" Text="Url de imagen:"></asp:Label>
            <asp:TextBox ID="tbImagen" CssClass="tbStyle" runat="server"></asp:TextBox>
            <asp:Label ID="lblEmail" runat="server"  Text="Email:"></asp:Label>
            <asp:TextBox ID="tbEmail" cssclass="tbStyle" runat="server"></asp:TextBox>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="tbNombre" cssclass="tbStyle" runat="server"></asp:TextBox>
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="tbApellido" cssclass="tbStyle" runat="server"></asp:TextBox>
            <asp:Button ID="btnEditar" OnClick="btnEditar_Click" runat="server" cssclass="btnStyle" Text="Editar" />
            <div id="divBotones" runat="server">
                <asp:Button ID="btnAceptar" CssClass="btnStyle" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" visible="false"/>
                <asp:Button ID="btnCancelar" cssclass="btnStyle btnCerrarSesion" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" Visible="false" />
            </div>
        </div>
    </section>
    <div class="cerrar-sesion">
        <asp:Button ID="btnAdmin" Visible="false" CssClass="btnBusqueda" OnClick="btnAdmin_Click" runat="server" Text="Panel de control" />
        <asp:Button ID="btnCerrarSesion" CssClass="btnCerrarSesion" Onclick="btnCerrarSesion_Click" runat="server" Text="Cerrar Sesion" />
    </div>
</asp:Content>
