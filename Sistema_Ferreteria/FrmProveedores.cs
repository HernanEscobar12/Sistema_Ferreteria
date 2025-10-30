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
    public partial class FrmProveedores : Form
    {

        private List<Proveedor> Proveedores;
        private bool Cargando = false;
        private Proveedor ProveedorSeleccionado;

        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {

            Cargando = true;
            CargarCbo();
            Carga(2);
            // Después de cargar todo, recién habilitamos los eventos
            Cargando = false;
        }

        private void CargarCbo()
        {
            Utilidad utilidad = new Utilidad();
            cboLocalidad.DataSource = utilidad.ListadoLocalidad();
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "Nombre";
        }

        private void Carga(int e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            if (e == 0 || e == 1)
            {
                if (e == 1)
                    Proveedores = proveedorNegocio.ListarProveedoresActivos();
                else
                    Proveedores = proveedorNegocio.ListarProveedoresInactivos();
            }
            else
                Proveedores = proveedorNegocio.ListarProveedores();

            dgvProveedores.DataSource = Proveedores;


        }

        private void cboLocalidad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Cargando) return; // 🚫 evita ejecución durante la carga inicial

            if (cboLocalidad.SelectedValue != null && cboLocalidad.SelectedIndex != -1)
            {
                // ✅ Usamos SelectedValue, no SelectedIndex
                int localidadId = Convert.ToInt32(cboLocalidad.SelectedValue);

                List<Proveedor> proveedoresFiltrados = Proveedores
                    .Where(p => p.Direccion.Localidad.LocalidadId == localidadId)
                    .ToList();

                dgvProveedores.DataSource = proveedoresFiltrados;
            }
        }

        private void btnACtivos_Click(object sender, EventArgs e)
        {
            Carga(1);
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            Carga(0);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Carga(2);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkFiltroAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroAvanzada.Checked)
                gboAvz.Visible = true;
            else
                gboAvz.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string txtoBuscar = txtFiltroAvz.Text;

            Proveedor proveedor = new Proveedor();

            if (string.IsNullOrEmpty(txtoBuscar))
            {
                MessageBox.Show("Ingrese un texto para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rbCuil.Checked)
            {
                proveedor = Proveedores.Find(x => x.Cuit.ToUpper().Contains(txtoBuscar.ToUpper()));
            }

            if (rbIdProveedor.Checked)
            {
                proveedor = Proveedores.Find(x => x.ProveedorId.ToString().Contains(txtoBuscar));
            }

            if (rbRazonSocial.Checked)
            {
                proveedor = Proveedores.Find(x => x.RazonSocial.ToUpper().Contains(txtoBuscar.ToUpper()));
            }

            dgvProveedores.DataSource = proveedor != null ? new List<Proveedor> { proveedor } : new List<Proveedor>();
        }

        private void dgvProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProveedorSeleccionado = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            FrmDetallesProveedor detallesProveedor = new FrmDetallesProveedor(ProveedorSeleccionado);
            if (detallesProveedor.ShowDialog() == DialogResult.OK)
            {
                Carga(1);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetallesProveedor frmDetallesProveedor = new FrmDetallesProveedor();
            if (frmDetallesProveedor.ShowDialog() == DialogResult.OK)
            {
                Carga(1);
            }
        }
    }
}
