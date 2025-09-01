using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Sistema_Ferreteria
{
    public partial class FrmDetalleProducto : Form
    {
        private Producto Producto { get; set; }
        public FrmDetalleProducto()
        {
            InitializeComponent();
            Text = "Nuevo Producto";
        }

        public FrmDetalleProducto(Producto producto)
        {
            Producto = producto;
            InitializeComponent();
            Text = "Detalle " + Producto.Nombre + " " + Producto.Codigo;

            if (Producto.Estado)
                btnEstado.Text = "Inactivar";
            else
                btnEstado.Text = "Activar";
  
            
           btnEstado.BackColor = Producto.Estado ? Color.Red : Color.Green;
           btnEstado.Visible = true;

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        // metodo para validad imagen de producto

        private void CargaDeImagen(string imagen)
        {
            try
            {
                pcbImage.Load(imagen);
            }
            catch (Exception)
            {
                pcbImage.Load("https://imgs.search.brave.com/LeS4HHKZ1oz1T15VY5MwiUjWDjLiYKj0vgRABB3D2BY/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly90My5m/dGNkbi5uZXQvanBn/LzA2Lzg2LzE5LzM0/LzM2MF9GXzY4NjE5/MzQwN19ESFp3amV5/ZEJPUjF0RURrTEF6/d00zdzVrWXN0Unp6/Qi5qcGc");
            }



        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                if (Validar())
                {

                    if (Producto == null)
                        Producto = new Producto();

                    Producto.Codigo = txtCodigo.Text;
                    Producto.Nombre = txtNombre.Text;
                    Producto.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                    Producto.Descripcion = txtDescripcion.Text;
                    Producto.Categoria = (Categoria)cboCategoria.SelectedItem;
                    Producto.UrlImagen = txtImgen.Text;


                    if (Producto.ProductoId == 0)
                    {
                        productoNegocio.AgregarProducto(Producto);
                    }
                    else
                    {
                        productoNegocio.Modificar(Producto);
                    }

                    // Indicás que se cerró con éxito
                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            Close();
        }

        private void txtImgen_Leave(object sender, EventArgs e)
        {
            CargaDeImagen(txtImgen.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Cargar()
        {
            FrmDetalleProducto frmProducto = new FrmDetalleProducto();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";

            try
            {
                if (Producto != null)
                {
                    txtNombre.Text = Producto.Nombre.ToString();
                    txtCodigo.Text = Producto.Codigo.ToString();
                    txtPrecio.Text = Producto.PrecioUnitario.ToString();
                    txtDescripcion.Text = Producto.Descripcion.ToString();
                    txtImgen.Text = Producto.UrlImagen.ToString();
                    cboCategoria.SelectedValue = Producto.Categoria.IdCategoria;
                    CargaDeImagen(Producto.UrlImagen);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtImgen.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;

        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            if (Producto.Estado)
            {
                productoNegocio.Inactivar(Producto.ProductoId);
                // Indicás que se cerró con éxito
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                productoNegocio.Activar(Producto.ProductoId);
                // Indicás que se cerró con éxito
                this.DialogResult = DialogResult.OK;

            }


        }
    }
}