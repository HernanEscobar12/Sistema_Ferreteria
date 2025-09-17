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
    public partial class FrmListadoEmpleados : Form
    {

       private Empleado Empleado = null;

        public FrmListadoEmpleados()
        {
            InitializeComponent();
        }

        private void FrmListadoEmpleados_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void Carga()
        {
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
            dgvEmpleados.DataSource = empleadoNegocio.ListarEmpleados();

            // **** [Ocultar Columnas  -- IdEmpleado - Estado ] ****
            dgvEmpleados.Columns["EmpleadoId"].Visible = false;
            dgvEmpleados.Columns["Estado"].Visible = false;
            //dgvEmpleados.Columns["Usuario"].Visible = false;

        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            FrmDetallesEmpleados frmDetallesEmpleados = new FrmDetallesEmpleados(Empleado);
           
            if(frmDetallesEmpleados.ShowDialog()  == DialogResult.OK)
            {
                Carga();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetallesEmpleados frmDetallesEmpleados = new FrmDetallesEmpleados();
            if(frmDetallesEmpleados.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            Carga();
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
            dgvEmpleados.DataSource = empleadoNegocio.ListarInactivos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
