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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> list { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listar();
            }
        }

        protected void listar()
        {
            ArticuloDB articuloDB = new ArticuloDB();
            list = articuloDB.ListarArticulos();
        } 

        protected void btnVerFavoritos_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            Usuario user = (Usuario)Session["Usuario"];
            ArticuloDB articuloDB = new ArticuloDB();
            list = articuloDB.ListarFavoritos(user.Id);
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}