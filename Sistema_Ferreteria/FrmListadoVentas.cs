using Dominio;
using Negocio;
using Negocio.Utilidades;
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
    public partial class FrmListadoVentas : Form
    {
        private List<Venta> ListaVentas;

        public FrmListadoVentas()
        {
            InitializeComponent();
        }

        private void FrmListadoVentas_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarVentas();

            // Mostrar checkboxes en DateTimePicker
            dtpDesde.ShowCheckBox = true;
            dtpHasta.ShowCheckBox = true;
        }

        private void CargarCombos()
        {
            // Estados
            Utilidad utilidad = new Utilidad();
            var listaEstados = utilidad.ListarEstadoVentas();
            listaEstados.Insert(0, new EstadoVenta { IdEstadoVenta = 0, Descripcion = "Todos" });
            cboEstado.DataSource = listaEstados;
            cboEstado.ValueMember = "IdEstadoVenta";
            cboEstado.DisplayMember = "Descripcion";
            cboEstado.SelectedIndex = 0;

            // Clientes
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            var listaClientes = clienteNegocio.ListarClientes();
            listaClientes.Insert(0, new Cliente { IdCliente = 0, Nombre = "Todos" });
            cboCliente.DataSource = listaClientes;
            cboCliente.ValueMember = "IdCliente";
            cboCliente.DisplayMember = "Nombre";
            cboCliente.SelectedIndex = 0;
        }

        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            ListaVentas = negocio.ListarVentas();

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = ListaVentas;

            // Configuración visual
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvVentas.Columns["IdVenta"].HeaderText = "N° Venta";
            dgvVentas.Columns["FechaVenta"].HeaderText = "Fecha";
            dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();

            int? idVenta = null;
            if (int.TryParse(txtNroVenta.Text.Trim(), out int nro))
                idVenta = nro;

            int? idCliente = (cboCliente.SelectedIndex > 0) ? (int?)cboCliente.SelectedValue : null;
            int? idEstado = (cboEstado.SelectedIndex > 0) ? (int?)cboEstado.SelectedValue : null;
            DateTime? desde = dtpDesde.Checked ? (DateTime?)dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? (DateTime?)dtpHasta.Value.Date : null;

            var lista = negocio.FiltrarVentas(idVenta, idCliente, idEstado, desde, hasta);

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = lista;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroVenta.Clear();
            cboCliente.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;

            CargarVentas();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();
            if (frmVentas.ShowDialog() == DialogResult.OK)
                CargarVentas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Venta ventaSeleccionada = (Venta)dgvVentas.Rows[e.RowIndex].DataBoundItem;

                VentaNegocio negocio = new VentaNegocio();
                ventaSeleccionada = negocio.ObtenerVentaConDetalles(ventaSeleccionada.IdVenta);

                FrmVentas frmVentas = new FrmVentas(ventaSeleccionada);
                if (frmVentas.ShowDialog() == DialogResult.OK)
                    CargarVentas();
            }
        }

        private void txtNroVenta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNroVenta.Text))
            {
                cboCliente.SelectedIndex = 0;
                cboEstado.SelectedIndex = 0;
                dtpDesde.Checked = false;
                dtpHasta.Checked = false;
            }
        }




    }
}

