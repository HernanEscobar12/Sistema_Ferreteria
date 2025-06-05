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

        }

        private void FrmProducto_Load(object sender, EventArgs e)
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
                    CargaDeImagen(Producto.UrlImagen);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

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

        }


        // Metodo para Cargar Imagen
        //public void CargarImagen()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        pcbImage.Load(openFileDialog.FileName);
        //        Producto.UrlImagen = openFileDialog.FileName;
        //    }
        //}
    }
}
