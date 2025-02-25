using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using BaseDatos;

namespace TPFinalNivel3RamirezDiego
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "" || tbContraseña.Text == "")
            {
                lblInfo.Visible = true;
                lblInfo.Text = "Usuario o contraseña incorrectos";
                return;
            }
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario user = usuarioDB.ObtenerUser(tbEmail.Text, tbContraseña.Text);
            if (user.Id == 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "Usuario o contraseña incorrectos";
                return;
            }
            user.Favoritos = usuarioDB.listarIdsFavs(user.Id);
            Session.Add("Usuario", user);
            Response.Redirect("Perfil.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //Validacion de campos y de que el correo no este ya registrado
            if (tbEmail.Text == string.Empty)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "No se ha ingresado un correo";
                return;
            }
            UsuarioDB usuarioDB = new UsuarioDB();
            if (usuarioDB.emailRegistrado(tbEmail.Text) == 1)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "Correo ya registrado";
                return;
            }
            if (tbContraseña.Text == string.Empty)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "No se ha ingresado una contraseña";
                return;
            }
            if (tbContraseña.Text.Length < 8)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "La contraseña es demasiado corta";
                return;
            }
            //creacion de usuario
            usuarioDB.crearUsuario(tbEmail.Text, tbContraseña.Text);
            Usuario user = usuarioDB.ObtenerUser(tbEmail.Text, tbContraseña.Text);
            user.Favoritos = usuarioDB.listarIdsFavs(user.Id);
            Session.Add("Usuario", user);
            Response.Redirect("Perfil.aspx");
        }
    }
}