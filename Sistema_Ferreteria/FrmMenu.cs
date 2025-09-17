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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmDetalleProducto frmProductos = new FrmDetalleProducto();
            frmProductos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListadoProductos frmListadoProductos = new FrmListadoProductos();
            frmListadoProductos.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmListadoClientes frmListadoClientes = new FrmListadoClientes();
            frmListadoClientes.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmListadoEmpleados frmListadoEmpleados = new FrmListadoEmpleados();
            frmListadoEmpleados.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmListadoUsuarios frmListadoUsuarios = new FrmListadoUsuarios();
            frmListadoUsuarios.ShowDialog();
        }
    }
}
