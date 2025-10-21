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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmListadoUsuarios frmListadoUsuarios = new FrmListadoUsuarios();

            if (frmListadoUsuarios.ShowDialog() == DialogResult.OK)
                Close();
        }

        private void BtnUserNuevo_Click(object sender, EventArgs e)
        {
            FrmListadoSinUsuarios frmListadoSinUsuarios = new FrmListadoSinUsuarios();

            if (frmListadoSinUsuarios.ShowDialog() == DialogResult.OK)
                Close();
        }
    }
}
