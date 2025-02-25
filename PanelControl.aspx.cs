using BaseDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3RamirezDiego
{
    public partial class PanelControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //evitamos que entren si no es admin
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            Usuario usuario = (Usuario)Session["Usuario"];
            if (!usuario.Admin)
            {
                Response.Redirect("Default.aspx");
                return;
            }
        }

        protected void btnAgregarArt_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detalles.aspx");
        }

        protected void cargarMarcas()
        {

            MarcaDB marcaDB = new MarcaDB();
            ddlEditar.Items.Clear();
            ddlEditar.DataSource = marcaDB.listarMarcas();
            ddlEditar.DataTextField = "Nombre";
            ddlEditar.DataValueField = "Id";
            ddlEditar.DataBind();

        }

        protected void cargarCategorias()
        {

            CategoriaDB categoriaDB = new CategoriaDB();
            ddlEditar.DataSource = categoriaDB.listarCategorias();
            ddlEditar.DataTextField = "Nombre";
            ddlEditar.DataValueField = "Id";
            ddlEditar.DataBind();

        }

        protected void mostarEditar()
        {
            tbEditar.Text = string.Empty;
            Agregar.Visible = false;
            Editar.Visible = true;
            Index.Visible = true;
            ocultarMensajes();
        }

        protected void mostrarAgregar()
        {
            tbAgregar.Text = string.Empty;
            Editar.Visible = false;
            Agregar.Visible = true;
            Index.Visible=true;
            ocultarMensajes();
        }

        protected void ocultarSeccion()
        {
            Index.Visible = false;
            Editar.Visible = false;
            Agregar.Visible = false;
            ocultarMensajes();
        }

        protected void ocultarMensajes()
        {
            error.Visible = false;
            exito.Visible = false;
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            mostrarAgregar();
            Index.InnerText = "Categoria";
        }

        protected void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            mostarEditar();
            cargarCategorias();
            Index.InnerText = "Categoria";
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            mostrarAgregar();
            Index.InnerText = "Marca";
        }

        protected void btnEditarMarca_Click(object sender, EventArgs e)
        {
            mostarEditar();
            cargarMarcas();
            Index.InnerText = "Marca";
        }

        protected void btnAgregarCancelar_Click(object sender, EventArgs e)
        {
            ocultarSeccion();
        }

        protected void btnEditarCancelar_Click(object sender, EventArgs e)
        {
            ocultarSeccion();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbAgregar.Text == string.Empty)
            {
                return;
            }
            if (Index.InnerText == "Marca")
            {
                MarcaDB marcaDB = new MarcaDB();
                if (marcaDB.validarDisponibiladad(tbAgregar.Text))
                {
                    marcaDB.crear(tbAgregar.Text);
                    exito.Visible = true;
                    error.Visible = false;
                    tbAgregar.Text = string.Empty;
                }
                else
                {
                    exito.Visible = false;
                    error.Visible = true;
                    return;
                }
            }
            else
            {
                CategoriaDB categoriaDB = new CategoriaDB();
                if (categoriaDB.validarDisponibiladad(tbAgregar.Text))
                {
                    categoriaDB.crear(tbAgregar.Text);
                    exito.Visible = true;
                    error.Visible = false;
                    tbAgregar.Text = string.Empty;
                }
                else
                {
                    exito.Visible = false;
                    error.Visible = true;
                    return;
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (tbEditar.Text == string.Empty)
            {
                return;
            }
            if (Index.InnerText == "Marca")
            {
                MarcaDB marcaDB = new MarcaDB();
                if (marcaDB.validarDisponibiladad(tbEditar.Text))
                {
                    marcaDB.editar(Convert.ToInt32(ddlEditar.SelectedValue), tbEditar.Text);
                    exito.Visible = true;
                    error.Visible = false;
                    tbEditar.Text = string.Empty;
                }
                else
                {
                    exito.Visible = false;
                    error.Visible = true;
                    return;
                }
            }
            else
            {
                CategoriaDB categoriaDB = new CategoriaDB();
                if (categoriaDB.validarDisponibiladad(tbEditar.Text))
                {
                    categoriaDB.editar(Convert.ToInt32(ddlEditar.SelectedValue), tbEditar.Text);
                    exito.Visible = true;
                    error.Visible = false;
                    tbEditar.Text = string.Empty;
                }
                else
                {
                    exito.Visible = false;
                    error.Visible = true;
                    return;
                }
            }
        }
    }
}