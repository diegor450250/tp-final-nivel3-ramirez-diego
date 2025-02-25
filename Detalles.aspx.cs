using BaseDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace TPFinalNivel3RamirezDiego
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = int.Parse(Request.QueryString["id"]);
                ArticuloDB articuloDB = new ArticuloDB();
                articulo = articuloDB.traerArticulo(id);
                cargarDdl();
                cargarArticulo();
                mostrarOpciones();
            }
            else
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                Usuario User = (Usuario)Session["Usuario"];
                if (!User.Admin)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }
                articulo = new Articulo();
                articulo.Nombre = "Nuevo";
                articulo.Imagen = "https://www.tropicalserver.com/wp-content/uploads/2020/06/error-403.jpg";
                cargarDdl();
                cargarAgregarArt();
            }
        }

        protected void mostrarOpciones()
        {
            Usuario User = (Usuario)Session["Usuario"];
            if (User == null || !User.Admin)
            {
                return;
            }
            btnEliminar.Visible = true;    
            btnEditar.Visible = true;
        }

        protected void cargarArticulo()
        {
            tbNombre.Text = articulo.Nombre;
            tbCodigo.Text = articulo.Codigo;
            tbDescripcion.Text = articulo.Descripcion;
            ddlCategoria.Enabled = false;
            ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
            ddlMarca.Enabled = false;
            ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
            tbPrecio.Text = articulo.Precio.ToString();
            tbImagen.Text = articulo.Imagen;
            verificarFav();
        }

        protected void cargarAgregarArt()
        {
            tbNombre.Enabled = true;
            tbCodigo.Enabled = true;
            tbDescripcion.Enabled = true;
            ddlMarca.Enabled = true;
            ddlCategoria.Enabled = true;
            tbPrecio.Enabled = true;
            tbImagen.Enabled = true;
            btnAgregarArt.Visible = true;
            btnAgregarFav.Visible = false;
            btnCancelar.Visible = true;
        }

        public void cargarDdl()
        {
            if (IsPostBack)
            {
                return;
            }
            MarcaDB md = new MarcaDB();
            CategoriaDB c = new CategoriaDB();
            ddlMarca.DataSource = md.listarMarcas();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();
            ddlCategoria.DataSource = c.listarCategorias();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }

        public void verificarFav()
        {
            if (Session["Usuario"] == null)
            {
                return;
            }
            Usuario user = (Usuario)Session["Usuario"];
            int fav = 0;
            fav = user.Favoritos.Find(e => e == articulo.Id);
            if (fav == 0)
            {
                btnAgregarFav.Visible=true;
                btnEliminarFav.Visible=false;
                return;
            }
            btnAgregarFav.Visible=false;
            btnEliminarFav.Visible=true;
        }

        protected void btnAgregarFav_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            Usuario user = (Usuario)Session["Usuario"];
            user.Favoritos.Add(articulo.Id);
            UsuarioDB userDb = new UsuarioDB();
            userDb.agregarFav(user.Id, articulo.Id);
            verificarFav();
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            UsuarioDB userDb = new UsuarioDB();
            Usuario user = (Usuario)Session["Usuario"];
            user.Favoritos.Remove(articulo.Id);
            userDb.eliminarFav(user.Id, articulo.Id);
            verificarFav();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelControl.aspx");
        }

        protected bool validarCampos()
        {
            lblInfo.Visible = false;
            btnVer.Visible = false;
            int contador = 0;
            if (tbNombre.Text == string.Empty)
            {
                lblNombre.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblNombre.ForeColor = System.Drawing.Color.Black;
                contador++;
            }
            if (tbCodigo.Text == string.Empty)
            {
                lblCodigo.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblCodigo.ForeColor= System.Drawing.Color.Black;
                contador++;
            }
            if (tbDescripcion.Text == string.Empty)
            {
                lblDescripcion.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblDescripcion.ForeColor= System.Drawing.Color.Black;
                contador++;
            }
            if (tbPrecio.Text == string.Empty)
            {
                lblPrecio.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblPrecio.ForeColor= System.Drawing.Color.Black;
                contador++;
            }
            if (tbImagen.Text == string.Empty)
            {
                lblImagen.ForeColor= System.Drawing.Color.Red;
            }
            else
            {
                lblImagen.ForeColor= System.Drawing.Color.Black;
                contador++;
            }
            if (contador == 5)
            {
                return true;
            }else
            {
                return false;
            }            
        }

        protected void limpiarCampos()
        {
            tbNombre.Text = string.Empty;
            tbDescripcion.Text = string.Empty;
            tbCodigo.Text = string.Empty;
            tbPrecio.Text = string.Empty;
            tbImagen.Text = string.Empty;
        }

        protected void btnAgregarArt_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Articulo art = new Articulo()
                {
                    Nombre = tbNombre.Text,
                    Codigo = tbCodigo.Text,
                    Descripcion = tbDescripcion.Text,
                    Imagen = tbImagen.Text,
                    Precio = decimal.Parse(tbPrecio.Text),

                };
                Marca marca = new Marca();
                marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
                art.Marca = marca;
                art.Categoria = categoria;
                ArticuloDB articuloDB = new ArticuloDB();
                articuloDB.crearArticulo(art);
                lblInfo.Visible = true;
                btnVer.Visible = true;
                limpiarCampos();
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            ArticuloDB artDB = new ArticuloDB();
            Response.Redirect("Detalles.aspx?id=" + artDB.idAgregado());
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloDB artDB = new ArticuloDB();
            artDB.eliminar(Request.QueryString["id"]);
            artDB.eliminarRegistrosFav(Request.QueryString["id"]);
            Response.Redirect("Default.aspx");
        }
    }
}