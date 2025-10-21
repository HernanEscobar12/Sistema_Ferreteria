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
    public partial class FrmListadoSinUsuarios : Form
    {
        private Empleado Empleado = null;
        public FrmListadoSinUsuarios()
        {
            InitializeComponent();
            Carga();
        }

        public void Carga()
        {
            pnlDatos.Visible = false;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            dgvEmpleados.DataSource = usuarioNegocio.ListarEmpleadosSinUsuarios();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlDatos.Visible = true;

            Empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            //lblIdEmpleado.Text = Empleado.EmpleadoId.ToString();
            lblCuil.Text = Empleado.Cuil;
            lblEmail.Text = Empleado.Email;
            lblNombre.Text = Empleado.Nombre;
            lblSucursal.Text = Empleado.Sucursal.Nombre;
            lblTel.Text = Empleado.Telefono;
        }




        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            Empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            FrmDetalleUsuarios detallesUsuario = new FrmDetalleUsuarios(Empleado);

            if (detallesUsuario.ShowDialog() == DialogResult.OK)
                detallesUsuario.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
