using
    Dominio;
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
    public partial class FrmListadoClientes : Form
    {

        private Cliente Cliente = null;
        public FrmListadoClientes()
        {
            InitializeComponent();
        }

        private void FrmListadoClientes_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = null;
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            dgvClientes.DataSource = clienteNegocio.ListadoClienteInactivos();
        }



        private void Carga()
        {
            ClienteNegocio ClienteNegocio = new ClienteNegocio();
            dgvClientes.DataSource = ClienteNegocio.ListarClientes();

        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            Carga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleClientes frmDetalleClientes = new FrmDetalleClientes();
            if (frmDetalleClientes.ShowDialog() == DialogResult.OK)
            {
                frmDetalleClientes.ShowDialog();
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            FrmDetalleClientes frmDetalleClientes = new FrmDetalleClientes(Cliente);
            if (frmDetalleClientes.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }
        }
    }
}
