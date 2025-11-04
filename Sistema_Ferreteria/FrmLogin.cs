using Dominio;
using Negocio;
using Sistema_Ferreteria.PopUps;
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

        private Timer temp;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtUser.Text.ToUpper(), TxtPass.Text.ToUpper());
            UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

            if((string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(TxtPass.Text)))
            {
                //MessageBox.Show("Por favor complete todos los campos.");
                //return; // Salir del método si los campos están vacíos

                MostrarMsj(new PopUpError1());

                temp = new Timer();
                temp.Interval = 3000;
                temp.Tick += (s, ev) =>
                {
                    temp.Stop();

                    if (pnlMsj.Controls.Count > 0)
                    {
                        pnlMsj.Controls.RemoveAt(0);
                    }
                };

                temp.Start();
            }
            else
            {
                if (UsuarioNegocio.Login(usuario))
                {
                    if (pnlMsj.Controls.Count > 0)
                    {
                        pnlMsj.Controls.RemoveAt(0);
                    }

                    SessionActual.Usuario = usuario;
                    SessionActual.Sucursal  = usuario.Empleado.Sucursal;

                    MostrarMsj(new PopUpExito());

                    temp = new Timer();
                    temp.Interval = 500;
                    temp.Tick += (s, ev) =>
                    {
                        temp.Stop();

                        FrmMenu frmMenu = new FrmMenu();
                        frmMenu.Show();
                        this.Hide();
                    };

                    temp.Start();

                    

                }
                else
                {
                    txtUser.BackColor = Color.Red;
                    TxtPass.BackColor = Color.Red;
                    //MessageBox.Show("Usuario Invalido");
                    MostrarMsj(new PopUpError2());

                    temp = new Timer();
                    temp.Interval = 3000;
                    temp.Tick += (s, ev) =>
                    {
                        temp.Stop();

                        if (pnlMsj.Controls.Count > 0)
                        {
                            pnlMsj.Controls.RemoveAt(0);
                        }
                    };

                    temp.Start();
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

        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPass.Checked)
            {
                TxtPass.PasswordChar = '\0';
            }
            else
            {
                TxtPass.PasswordChar = '*';
            }
        }

        private void MostrarMsj(Form frm)
        {
            if (pnlMsj.Controls.Count > 0)
            {
                pnlMsj.Controls.RemoveAt(0);
            }

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlMsj.Controls.Add(frm);
            pnlMsj.Tag = frm;
            frm.Show();
        }

    }
}
