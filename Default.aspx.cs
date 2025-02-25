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
                cargarDropDownList();
            }
        }

        protected void listar()
        {
            ArticuloDB articuloDB = new ArticuloDB();
            list = articuloDB.ListarArticulos();
        }

        protected void cargarDropDownList()
        {
            ddlBusquedaPrecio.Items.Add("Menor a");
            ddlBusquedaPrecio.Items.Add("Igual a");
            ddlBusquedaPrecio.Items.Add("Mayor a");
            MarcaDB md = new MarcaDB();
            CategoriaDB c = new CategoriaDB();
            ddlMarcas.DataSource = md.listarMarcas();
            ddlMarcas.DataTextField = "Nombre";
            ddlMarcas.DataValueField = "Id";
            ddlMarcas.DataBind();
            ddlCategorias.DataSource = c.listarCategorias();
            ddlCategorias.DataTextField = "Nombre";
            ddlCategorias.DataValueField = "Id";
            ddlCategorias.DataBind();
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
            List<Articulo> listFavs = new List<Articulo>();
            listar();
            foreach (var item in user.Favoritos)
            {
                var articulo = list.Find(a => a.Id == item);
                if (articulo != null)
                {
                    listFavs.Add((Articulo)articulo);
                }
            }
            if (listFavs.Count == 0)
            {
                info.Visible = true;
            }
            list = listFavs;
            tbBusqueda.Visible = false;
            btnBusqueda.Visible = false;
            btnLimpiarFiltro.Visible = false;
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            listar();
            tbBusqueda.Visible = true;
            btnBusqueda.Visible = true;
            btnLimpiarFiltro.Visible = true;
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            tbBusqueda.Text = string.Empty;
            tbBusquedaPrecio.Text = string.Empty;
            cbMarcasFiltro.Checked = false;
            cbCtegoriasFiltro.Checked = false;
            listar();
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (
                tbBusqueda.Text == string.Empty &&
                tbBusquedaPrecio.Text == string.Empty &&
                !cbCtegoriasFiltro.Checked &&
                !cbMarcasFiltro.Checked
                )
            {
                listar();
                return;
            }
            listar();
            List<Articulo> listFiltrada = list;
            if (tbBusqueda.Text != string.Empty)
            {
                string busqueda = tbBusqueda.Text;
                listFiltrada = listFiltrada.Where(a => a.Nombre.ToLower().Contains(busqueda.ToLower())).ToList();
            }
            if (tbBusquedaPrecio.Text != string.Empty)
            {
                decimal precio = decimal.Parse(tbBusquedaPrecio.Text);
                string seleccionPrecio = ddlBusquedaPrecio.SelectedItem.Text;
                switch (seleccionPrecio)
                {
                    case "Menor a":
                        listFiltrada = listFiltrada.Where(a => a.Precio <= precio).ToList();
                        break;
                    
                    case "Mayor a":
                        listFiltrada = listFiltrada.Where(a => a.Precio >= precio).ToList();
                        break;
                    
                    case "Igual a":
                        listFiltrada = listFiltrada.Where(a => a.Precio == precio).ToList();
                        break;
                }
            }
            if (cbCtegoriasFiltro.Checked)
            {
                int idCategoria = int.Parse(ddlCategorias.SelectedValue);
                listFiltrada = listFiltrada.Where(a => a.Categoria.Id <= idCategoria).ToList();
            }if (cbMarcasFiltro.Checked)
            {
                int idMarca = int.Parse(ddlMarcas.SelectedValue);
                listFiltrada = listFiltrada.Where(a => a.Marca.Id <= idMarca).ToList();
            }
            list = listFiltrada;
            if (list.Count == 0)
            {
                info.Visible = true;
            }
            else
            {
                info.Visible = false;
            }
        }
    }
}