using Negocio;
using System;
using Dominio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Utilidades;

namespace Sistema_Ferreteria
{
    public partial class FrmListadoCompras : Form
    {
        private List<Compra> ListaCompras;

        public FrmListadoCompras()
        {
            InitializeComponent();
        }

        private void FrmListadoCompras_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarCompras();

            // Mostrar checkbox en los DateTimePicker
            dtpDesde.ShowCheckBox = true;
            dtpHasta.ShowCheckBox = true;
        }

        private void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            ListaCompras = negocio.ListarCompras();

            dgvCompras.DataSource = null;
            dgvCompras.DataSource = ListaCompras;

            // Formato visual del DataGridView
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCompras.Columns["IdCompra"].HeaderText = "N° Compra";
            dgvCompras.Columns["FechaCompra"].HeaderText = "Fecha";
            dgvCompras.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        private void CargarCombos()
        {
            // Estados
            Utilidad utilidad = new Utilidad();
            var listaEstados = utilidad.ListarEstadoCompras();
            listaEstados.Insert(0, new EstadoCompra { IdEstadoCompra = 0, Descripcion = "Todos" });
            cboEstado.DataSource = listaEstados;
            cboEstado.ValueMember = "IdEstadoCompra";
            cboEstado.DisplayMember = "Descripcion";
            cboEstado.SelectedIndex = 0;

            // Proveedores
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            var listaProveedores = proveedorNegocio.ListarProveedores();
            listaProveedores.Insert(0, new Proveedor { ProveedorId = 0, RazonSocial = "Todos" });
            cboProveedor.DataSource = listaProveedores;
            cboProveedor.ValueMember = "ProveedorId";
            cboProveedor.DisplayMember = "RazonSocial";
            cboProveedor.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CompraNegocio negocio = new CompraNegocio();

            // 🔹 Si el usuario escribe N° de compra, priorizarlo
            int? idCompra = null;
            if (int.TryParse(txtNroCompra.Text.Trim(), out int nro))
                idCompra = nro;

            int? idProveedor = (cboProveedor.SelectedIndex > 0) ? (int?)cboProveedor.SelectedValue : null;
            int? idEstado = (cboEstado.SelectedIndex > 0) ? (int?)cboEstado.SelectedValue : null;
            DateTime? desde = dtpDesde.Checked ? (DateTime?)dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? (DateTime?)dtpHasta.Value.Date : null;

            var lista = negocio.FiltrarCompras(idCompra, idProveedor, idEstado, desde, hasta);

            dgvCompras.DataSource = null;
            dgvCompras.DataSource = lista;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroCompra.Clear();
            cboProveedor.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;

            CargarCompras();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Opcional: si se escribe un número, limpiar combos automáticamente
        private void txtNroCompra_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNroCompra.Text))
            {
                cboProveedor.SelectedIndex = 0;
                cboEstado.SelectedIndex = 0;
                dtpDesde.Checked = false;
                dtpHasta.Checked = false;
            }
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            if(frmCompras.ShowDialog() == DialogResult.OK)
                CargarCompras();    
        }

        private void dgvCompras_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Compra compraSeleccionada = (Compra)dgvCompras.Rows[e.RowIndex].DataBoundItem;

                CompraNegocio negocio = new CompraNegocio();
                compraSeleccionada = negocio.ObtenerCompraConDetalles(compraSeleccionada.IdCompra);

                FrmCompras frmCompras = new FrmCompras(compraSeleccionada);
                if (frmCompras.ShowDialog() == DialogResult.OK)
                    CargarCompras();

                CargarCompras();
            }
        }
    }

}

