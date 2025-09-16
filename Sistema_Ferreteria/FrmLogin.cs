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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtUser.Text.ToUpper(), TxtPass.Text.ToUpper());
            UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

            if((string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(TxtPass.Text)))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return; // Salir del método si los campos están vacíos
            }
            else
            {
                if (UsuarioNegocio.Login(usuario))
                {
                    MessageBox.Show("Login extioso");

                    FrmMenu FrmMenu = new FrmMenu();
                    FrmMenu.ShowDialog();
                    this.Hide();
                }
                else
                {
                    txtUser.BackColor = Color.Red;
                    TxtPass.BackColor = Color.Red;
                    MessageBox.Show("Usuario Invalido");
                }
            }

            // Limpiar los campos de texto después del intento de inicio de sesión
            LimpiarCampos();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Limpiar los campos de texto después del intento de inicio de sesión
        private void LimpiarCampos()
        {
            txtUser.Clear();
            TxtPass.Clear();
            txtUser.BackColor = SystemColors.Window;
            TxtPass.BackColor = SystemColors.Window;
        }
    }
}
