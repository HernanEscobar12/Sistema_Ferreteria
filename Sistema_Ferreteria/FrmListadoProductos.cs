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
    public partial class FrmListadoProductos : Form
    {
        private bool ModoSeleccion;
        public Producto ProductoSeleccionado { get; private set; }

        public FrmListadoProductos(bool modoSeleccion = false)
        {
            InitializeComponent();
            ModoSeleccion = modoSeleccion;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void Carga()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvProductos.DataSource = productoNegocio.Listado();
            btnActivos.Visible = false;
            btnInactivos.Enabled = true;
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ProductoSeleccionado = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

                if (ModoSeleccion)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    FrmDetalleProducto frmDetalleProducto = new FrmDetalleProducto(ProductoSeleccionado);
                    if (frmDetalleProducto.ShowDialog() == DialogResult.OK)
                    {
                        Carga();
                    }
                }
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleProducto frmDetalleProducto = new FrmDetalleProducto();
            if (frmDetalleProducto.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }
        }
    }
}