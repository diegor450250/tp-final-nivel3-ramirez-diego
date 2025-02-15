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
                return;
            }
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario user = usuarioDB.ObtenerUser(tbEmail.Text, tbContraseña.Text);
            if (user.Id == 0)
            {
                lblInfo.Visible = true;
                return;
            }
            Session.Add("Usuario", user);
            Response.Redirect("Perfil.aspx");
        }
    }
}