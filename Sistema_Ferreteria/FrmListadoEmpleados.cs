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
    public partial class FrmListadoEmpleados : Form
    {

        private Empleado Empleado = null;
        private List<Empleado> ListadoActivo;
        private List<Empleado> ListadoInactivo;
        private List<Empleado> ListaFiltrada;
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
            ListadoActivo = empleadoNegocio.ListarEmpleados();
            dgvEmpleados.DataSource = ListadoActivo;
            // **** [Ocultar Columnas  -- IdEmpleado - Estado ] ****
            dgvEmpleados.Columns["EmpleadoId"].Visible = false;
            dgvEmpleados.Columns["Estado"].Visible = false;
            //dgvEmpleados.Columns["Usuario"].Visible = false;

            Utilidad utilidad = new Utilidad();

            //-- Carga Cargo 
            cboCargo.DataSource = utilidad.ListadoDeCargo();
            cboCargo.ValueMember = "IdCargo";
            cboCargo.DisplayMember = "Descripcion";

            // -- Carga Sucursales

            cboSucursal.DataSource = utilidad.ListadoSucursales();
            cboSucursal.ValueMember = "SucursalId";
            cboSucursal.DisplayMember = "Nombre";

            // -- Carga Localidades

            cboLocalidad.DataSource = utilidad.ListadoLocalidad();
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "Nombre";

        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            FrmDetallesEmpleados frmDetallesEmpleados = new FrmDetallesEmpleados(Empleado);

            if (frmDetallesEmpleados.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetallesEmpleados frmDetallesEmpleados = new FrmDetallesEmpleados();
            if (frmDetallesEmpleados.ShowDialog() == DialogResult.OK)
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

            ListadoInactivo = empleadoNegocio.ListarInactivos();
            dgvEmpleados.DataSource = ListadoInactivo;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFiltroAvanzado.Checked)
            {
                pnlFiltroSimple.Visible = false;
                pnFiltroAvanzado.Visible = true;
            }
            else
            if (rbFiltroSimple.Checked)
            {
                pnlFiltroSimple.Visible = true;
                pnFiltroAvanzado.Visible = false;
            }
        }


        // Filtro Simple por texto
        private void txtFiltroSimple_TextChanged(object sender, EventArgs e)
        {
            string Filtro = txtFiltroSimple.Text;

            if (Filtro.Length > 3)
            {
                ListaFiltrada = ListadoActivo.FindAll(x => x.Nombre.ToUpper().Contains(Filtro.ToUpper()));
            }
            else
            {
                ListaFiltrada = ListadoActivo;
            }

            dgvEmpleados.DataSource = ListaFiltrada;
        }

        private void FiltrarEmpleados()
        {
            ListaFiltrada = ListadoActivo;

            // filtrar por localidad si hay seleccion
            if(cboLocalidad.SelectedValue != null  &&  cboLocalidad.SelectedIndex != -1)
            {
                int id = (int)cboLocalidad.SelectedIndex + 1;
                ListaFiltrada = ListadoActivo.Where(u => u.Direccion.Localidad.LocalidadId == id).ToList();
            }

            if(cboCargo.SelectedValue != null && cboCargo.SelectedIndex != -1)
            {
                int idCargo = (int)cboCargo.SelectedIndex + 1;
                ListaFiltrada = ListadoActivo.Where(U => U.Cargo.IdCargo == idCargo).ToList();
            }

            if(cboSucursal.SelectedValue != null && cboSucursal.SelectedIndex != -1)
            {
                int IdSucursal = (int)cboSucursal.SelectedIndex + 1;
                ListaFiltrada = ListadoActivo.Where(u => u.Sucursal.SucursalId == IdSucursal).ToList();
            }

            dgvEmpleados.DataSource = ListaFiltrada.Any() ? ListaFiltrada : null;
        }

        private void cboLocalidad_SelectedValueChanged(object sender, EventArgs e) => FiltrarEmpleados();

        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e) => FiltrarEmpleados();

        private void cboCargo_SelectedValueChanged(object sender, EventArgs e) => FiltrarEmpleados();

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = null;

            dgvEmpleados.DataSource = ListadoActivo;
        }
    }
}
