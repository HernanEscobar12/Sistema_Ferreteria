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
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            //CargarInventario();
            CargarInventarioConUbicacion();
        }

        private void CargarSucursales()
        {
            Utilidad utilidad = new Utilidad();  
            cbSucursal.DataSource = utilidad.ListadoSucursales();
            cbSucursal.ValueMember = "SucursalId";
            cbSucursal.DisplayMember = "Nombre";
        }

        private void CargarInventario(int? sucursalId = null)
        {
            InventarioNegocio negocio = new InventarioNegocio();
            dgvInventario.DataSource = negocio.ListarInventario(sucursalId);

            // 🔹 Mantener tu formato de color, headers, etc.
            if (dgvInventario.Columns.Contains("Cantidad"))
                dgvInventario.Columns["Cantidad"].Visible = false;

            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                int stock = Convert.ToInt32(row.Cells["StockActual"].Value);
                int minimo = Convert.ToInt32(row.Cells["StockMinimo"].Value);
                if (stock <= minimo)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void cbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSucursal.SelectedValue is int sucursalId)
            {
                CargarInventarioConUbicacion(sucursalId);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cbSucursal.SelectedValue is int sucursalId)
                CargarInventario(sucursalId);
        }

        private void CargarInventarioConUbicacion(int? sucursalId = null)
        {
            InventarioNegocio negocio = new InventarioNegocio();
            dgvInventario.DataSource = negocio.ListarInventarioConUbicacion(sucursalId);

            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvInventario.Columns.Contains("Sucursal"))
                dgvInventario.Columns["Sucursal"].Visible = false;

            dgvInventario.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
            dgvInventario.Columns["StockActual"].HeaderText = "Stock Actual";
            dgvInventario.Columns["Ubicacion"].HeaderText = "Ubicación (Depósito)";

            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                int stock = Convert.ToInt32(row.Cells["StockActual"].Value);
                int minimo = Convert.ToInt32(row.Cells["StockMinimo"].Value);
                if (stock <= minimo)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
