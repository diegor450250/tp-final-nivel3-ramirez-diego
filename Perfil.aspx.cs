using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDatos;
using Dominio;

namespace TPFinalNivel3RamirezDiego
{
    public partial class Perfil1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUser();
            }
        }

        public void CargarUser()
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Usuario user = (Usuario)Session["Usuario"];
            if (user.Imagen == "")
            {
                imgPerfil.ImageUrl = "https://png.pngtree.com/png-clipart/20210829/original/pngtree-page-not-found-png-image_6674563.jpg";
            }
            else
            {
                imgPerfil.ImageUrl = user.Imagen;
            }
            tbEmail.Text = user.Email;
            tbEmail.Enabled = false;
            tbNombre.Text = user.Nombre;
            tbNombre.Enabled = false;
            tbApellido.Text = user.Apellido;
            tbApellido.Enabled = false;
            tbImagen.Text = user.Imagen;
            tbImagen.Visible = false;
            lblImagen.Visible = false;
        }

        public void Editar(bool i)
        {
            if (i)
            {
                lblImagen.Visible = true;
                tbImagen.Visible = true;
                tbNombre.Enabled = true;
                tbApellido.Enabled = true;
                divBotones.Visible = true;
                btnEditar.Visible = false;
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
            }
            else
            {
                lblImagen.Visible = false;
                tbImagen.Visible = false;
                tbNombre.Enabled = false;
                tbApellido.Enabled = false;
                divBotones.Visible = false;
                btnEditar.Visible = true;
                lblNombre.ForeColor = System.Drawing.Color.Black;
                lblApellido.ForeColor = System.Drawing.Color.Black;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar(true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Editar(false);
            CargarUser();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario user = (Usuario)Session["Usuario"];
            user.Nombre = tbNombre.Text;
            user.Apellido = tbApellido.Text;
            user.Imagen = tbImagen.Text;
            Session["Usuario"] = user;
            usuarioDB.EditarUser(user);
            CargarUser();
            Editar(false);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            CargarUser();
        }
    }
}