<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3RamirezDiego.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="sectionStyle">
        <div class="loginStyle">
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="tbStyle"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="tbContraseña" TextMode="Password" runat="server" CssClass="tbStyle"></asp:TextBox>
            <asp:Button ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" CssClass="btnStyle" Text="Ingresar" />
            <asp:Label ID="lblInfo" runat="server" CssClass="lblerrorStyle" Text="Usuario o contraseña incorrectos"></asp:Label>
        </div>
    </section>
</asp:Content>
