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
    public partial class FrmDetalleProducto : Form
    {
        public FrmDetalleProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            FrmDetalleProducto frmProducto = new FrmDetalleProducto();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cboCategoria.DataSource=  categoriaNegocio.ListarCategorias();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";
        }
    }
}
