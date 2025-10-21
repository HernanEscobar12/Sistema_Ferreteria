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
    public partial class FrmListadoUsuarios : Form
    {
        private List<Usuario> ListaFitrada;
        private List<Usuario> Usuarios;
        public FrmListadoUsuarios()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmListadoUsuarios_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            

            FrmListadoSinUsuarios frmNuevoUsuario = new FrmListadoSinUsuarios();
            if(frmNuevoUsuario.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }
            ;
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

        public void Carga()
        {
            dgvUsuarios.DataSource = null;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuarios = usuarioNegocio.ListarUsuarios();
            dgvUsuarios.DataSource = Usuarios;
            OcultarColumnas();

            Utilidad utilidad = new Utilidad();

            //-- Carga Roles 
            cboRol.DataSource = utilidad.ListadoDeRol();
            cboRol.ValueMember = "IdRol";
            cboRol.DisplayMember = "Nombre";


            //-- Carga Cargo 
            cboCargo.DataSource = utilidad.ListadoDeCargo();
            cboCargo.ValueMember = "IdCargo";
            cboCargo.DisplayMember = "Descripcion";

            // -- Carga Sucursales

            cboSucursal.DataSource = utilidad.ListadoSucursales();
            cboSucursal.ValueMember = "SucursalId";
            cboSucursal.DisplayMember = "Nombre";

            LimpiezaCbos();
        }

        public void OcultarColumnas()
        {
            dgvUsuarios.Columns["Estado"].Visible = false;
            dgvUsuarios.Columns["Clave"].Visible = false;
        }



        private void FiltrarUsuarios()
        {
            ListaFitrada = Usuarios;

            // Filtra por Rol si hay selección
            if (cboRol.SelectedValue != null && cboRol.SelectedIndex != -1)
            {
                int idRol = (int)cboRol.SelectedIndex + 1;
                ListaFitrada = ListaFitrada.Where(u => u.Rol.IdRol == idRol).ToList();
            }

            // Filtra por Cargo si hay selección
            if (cboCargo.SelectedValue != null && cboCargo.SelectedIndex != -1)
            {
                int idCargo = (int)cboCargo.SelectedIndex + 1 ;
                ListaFitrada = ListaFitrada.Where(u => u.Cargo.IdCargo == idCargo).ToList();
            }

            // Filtra por Sucursal si hay selección
            if (cboSucursal.SelectedValue != null && cboSucursal.SelectedIndex != -1)
            {
                int idSucursal = (int)cboSucursal.SelectedIndex + 1;
                ListaFitrada = ListaFitrada.Where(u => u.Empleado.Sucursal.SucursalId == idSucursal).ToList();
            }

            dgvUsuarios.DataSource = ListaFitrada.Any() ? ListaFitrada : Usuarios;

            //if (ListaFitrada.Count > 0)
            //    dgvUsuarios.DataSource = ListaFitrada;
            //else


            OcultarColumnas();
        }

        // Asocia este método a los eventos de los tres ComboBox
        private void cboRol_SelectedValueChanged(object sender, EventArgs e) => FiltrarUsuarios();
        private void cboCargo_SelectedValueChanged(object sender, EventArgs e) => FiltrarUsuarios();
        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e) => FiltrarUsuarios();

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Restablece el DataSource a la lista original de usuarios
            dgvUsuarios.DataSource = Usuarios;
            OcultarColumnas();
            LimpiezaCbos();

        }

        private void LimpiezaCbos()
        {
            // Limpia las selecciones de los ComboBox
            cboRol.SelectedIndex = -1;
            cboCargo.SelectedIndex = -1;
            cboSucursal.SelectedIndex = -1;
        }
        private void txtFiltroSimple_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroSimple.Text;

            if (filtro.Length >= 3)
            {
                ListaFitrada = Usuarios.FindAll(x =>
                   x.User.ToUpper().Contains(filtro.ToUpper())
                || x.Empleado.Nombre.ToUpper().Contains(filtro.ToUpper())
                );
            }
            else
            {
                ListaFitrada = Usuarios;
            }

            dgvUsuarios.DataSource = ListaFitrada;
        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltroAvz.Text))
            {
                if (rbCuil.Checked) { 
                    ListaFitrada = Usuarios.FindAll(x => x.Empleado.Cuil.ToUpper().Contains(txtFiltroAvz.Text.ToUpper()));
                }

                if (rbIdEmpleado.Checked) {
                    ListaFitrada = Usuarios.FindAll(x => x.Empleado.EmpleadoId == Convert.ToInt32(txtFiltroAvz.Text));

                }

                if (rbNombre.Checked) {
                    ListaFitrada = Usuarios.FindAll(x => x.User.ToUpper().Contains(txtFiltroAvz.Text));   
                }
            }

            dgvUsuarios.DataSource = ListaFitrada;

        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

            FrmDetalleUsuarios frmDetalleUsuarios = new FrmDetalleUsuarios(usuario);
            if (frmDetalleUsuarios.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }

        }

        private void btnACtivos_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarioNegocio.ListarUsuarios();

            btnACtivos.Enabled = false;
            btnInactivos.Enabled = true;
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            dgvUsuarios.DataSource = usuarioNegocio.ListarInactivosUsuarios();

            btnInactivos.Enabled = false;
            btnACtivos.Enabled = true;
        }
    }
}
