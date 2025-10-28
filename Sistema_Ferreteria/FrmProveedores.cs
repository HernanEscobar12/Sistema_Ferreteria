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
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkFiltroAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroAvanzada.Checked)
            {
                gboAvz.Visible = true;
            }
            else
            {
                gboAvz.Visible = false;
            }
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void Carga()
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            Proveedores = proveedorNegocio.ListarProveedores();
            dgvProveedores.DataSource = Proveedores;

            Utilidad utilidad = new Utilidad();
            cboLocalidad.DataSource = utilidad.ListadoLocalidad();
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "Nombre";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetallesProveedor frmDetallesProveedor = new FrmDetallesProveedor();
            frmDetallesProveedor.ShowDialog();
        }
    }
}
