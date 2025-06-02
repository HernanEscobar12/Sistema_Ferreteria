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

            

            if (UsuarioNegocio.Login(usuario))
            {
                MessageBox.Show("Login extioso");
            }
            else
            {
                MessageBox.Show("Usuario Invalido");
            }

            // Limpiar los campos de texto después del intento de inicio de sesión
            txtUser.Clear();
            TxtPass.Clear();
            this.Hide();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
