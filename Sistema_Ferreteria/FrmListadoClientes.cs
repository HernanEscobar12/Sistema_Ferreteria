using
    Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ferreteria
{
    public partial class FrmListadoClientes : Form
    {

        private Cliente Cliente = null;
        private List<Cliente> Clientes;
        private List<Cliente> ListaFiltrada;
        public FrmListadoClientes()
        {
            InitializeComponent();
        }

        private void FrmListadoClientes_Load(object sender, EventArgs e)
        {
            Carga(1);
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            Carga(0);
        }



        private void Carga(int o = 0)
        {
            ClienteNegocio ClienteNegocio = new ClienteNegocio();

            if (o == 0 ||o == 1)
            {
                if(o == 1)
                {
                    Clientes = ClienteNegocio.ListarClientes();
                    dgvClientes.DataSource = Clientes;
                }
                else
                {
                    Clientes = ClienteNegocio.ListadoClienteInactivos();
                    dgvClientes.DataSource = Clientes;

                }
            }
            else
            {
                Clientes = ClienteNegocio.ListadoCompletoCliente();
                dgvClientes.DataSource = Clientes;
            }

        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            Carga(1);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleClientes frmDetalleClientes = new FrmDetalleClientes();
            if (frmDetalleClientes.ShowDialog() == DialogResult.OK)
            {
                Carga(1);
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            FrmDetalleClientes frmDetalleClientes = new FrmDetalleClientes(Cliente);

            if (frmDetalleClientes.ShowDialog() == DialogResult.OK)
            {
                Carga(1);
            }
        }

        private void chkfiltroAvz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfiltroAvz.Checked)
            {
                pnFiltroAvanzado.Enabled = true;
            }
            else
            {
                pnFiltroAvanzado.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCuil.Text) || (!string.IsNullOrEmpty(txtDni.Text)))
            {

                if (!string.IsNullOrEmpty(txtCuil.Text))
                {
                    string Cuil = txtCuil.Text;
                    ListaFiltrada = Clientes.FindAll(x => x.Cuit == Cuil).ToList();
                }
                else
                {
                    string Dni = txtDni.Text;
                    ListaFiltrada = Clientes.FindAll(x => x.Dni == Dni).ToList();
                }

                dgvClientes.DataSource = ListaFiltrada.Any() ? ListaFiltrada : null;

            }
        }

        private void txtFiltroSimple_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroSimple.Text;

            if (filtro.Length >= 3)
            {
                ListaFiltrada = Clientes.FindAll(x =>
                   x.Nombre.ToUpper().Contains(filtro.ToUpper())
                || x.Apellido.ToUpper().Contains(filtro.ToUpper())
                );
            }
            else
            {
                ListaFiltrada = Clientes;
            }

            dgvClientes.DataSource = ListaFiltrada;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Carga(2);
        }
    }
}
