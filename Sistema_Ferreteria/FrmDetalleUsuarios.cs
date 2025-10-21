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
    public partial class FrmDetalleUsuarios : Form
    {
        private Usuario Usuario = null;

        private Empleado Empleado = null;

        public FrmDetalleUsuarios()
        {
            InitializeComponent();
            Carga();
        }

        public FrmDetalleUsuarios(Usuario U)
        {
            this.Usuario = U;
            InitializeComponent();
            Carga();
        }

        public FrmDetalleUsuarios(Empleado E)
        {
            this.Empleado = E;
            InitializeComponent();
            Carga();
        }

        public void Carga()
        {
            Utilidad utilidad = new Utilidad();

            //-- Carga Roles 
            cboRol.DataSource = utilidad.ListadoDeRol();
            cboRol.ValueMember = "IdRol";
            cboRol.DisplayMember = "Nombre";


            //-- Carga Cargo 
            cboCargo.DataSource = utilidad.ListadoDeCargo();
            cboCargo.ValueMember = "IdCargo";
            cboCargo.DisplayMember = "Descripcion";

            if (Usuario != null)
            {
                if(Usuario.Estado == 1)
                {
                    btnEstado.Visible = true;
                    btnEstado.Text = "Inactivar";
                }
                else
                {
                    btnEstado.Visible = true;
                    btnEstado.Text = "Activar";
                }

                lblIdEmpleado.Text = Usuario.IdUsuario.ToString();
                lblIdUsuario.Text = Usuario.IdUsuario.ToString();
                txtUser.Text = Usuario.User;
                txtClave.Text = Usuario.Clave;
                cboCargo.SelectedValue = Usuario.Cargo.IdCargo;
                cboRol.SelectedValue = Usuario.Rol.IdRol;

            }

            if (Empleado != null)
            {
                lblIdEmpleado.Text = Empleado.EmpleadoId.ToString();
                txtUser.Text = Empleado.Nombre;
            }

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtClave.Text) || string.IsNullOrEmpty(txtClave2.Text))
            {
                MessageBox.Show("Debes completar los campos");
            }
            else
            {

                if (txtClave.Text == txtClave2.Text)
                {
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
                    usuario.User = txtUser.Text;
                    usuario.Clave = txtClave.Text;
                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = (int)cboRol.SelectedValue;
                    usuario.Cargo = new Cargo();
                    usuario.Cargo.IdCargo = (int)cboCargo.SelectedValue;
                    usuario.Empleado = new Empleado();
                    usuario.Empleado.EmpleadoId = Convert.ToInt32(lblIdEmpleado.Text);

                    if(usuario.IdUsuario != 0)
                    {
                        usuarioNegocio.ModificarUsuario(usuario);
                        MessageBox.Show("Usuario modificado");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        usuarioNegocio.CrearUsuario(usuario);
                        MessageBox.Show("Usuario Creando");
                        this.DialogResult = DialogResult.OK;
                    }

                }
            }

            this.Close();
        }

        private void chbReset_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReset.Checked)
            {
                btnReset.Visible = true;
            }
            else
            {
                btnReset.Visible = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (chbReset.Checked)
            {
                DialogResult resultado = MessageBox.Show(
                     "¿Estás seguro que querés reiniciar la contraseña del empleado?",
                      "Confirmar reinicio",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                 );

                if (resultado == DialogResult.Yes)
                {

                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    usuarioNegocio.ReiniciarClave(Usuario.IdUsuario);

                    MessageBox.Show("Contraseña Reiniciada");
                }

                this.Close();
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("¿ Estas seguro que queres cambiar de estado a " + Usuario.User + " ? ", "Inactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            if(Resultado == DialogResult.Yes)
            {
                usuarioNegocio.CambiarEstadoUsuario(Usuario.IdUsuario, Usuario.Estado);
                MessageBox.Show("Cambiado de estado");
            }

            this.Close();
        }   


    }
}

