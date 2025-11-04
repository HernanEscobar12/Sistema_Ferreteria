using Dominio;
using Presentacion;
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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            AbrirFormularioEnPanel(new MenuLogo(), null);
        }

        public FrmMenu(Usuario usuarioLogueado)
        {
            InitializeComponent();

            SessionActual.Usuario = usuarioLogueado;
            SessionActual.Sucursal = usuarioLogueado.Empleado.Sucursal;

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //FrmDetalleProducto frmProductos = new FrmDetalleProducto();
            //frmProductos.ShowDialog();
            AbrirFormularioEnPanel(new FrmDetalleProducto(), btnProductos);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrmListadoProductos frmListadoProductos = new FrmListadoProductos();
            //frmListadoProductos.ShowDialog();
            AbrirFormularioEnPanel(new FrmListadoProductos(), btnProductos);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //FrmListadoClientes frmListadoClientes = new FrmListadoClientes();
            //frmListadoClientes.ShowDialog();
            AbrirFormularioEnPanel(new FrmListadoClientes(), btnClientes);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //FrmListadoEmpleados frmListadoEmpleados = new FrmListadoEmpleados();
            //frmListadoEmpleados.ShowDialog();
            AbrirFormularioEnPanel(new FrmListadoEmpleados(), button1);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //FrmUsuarios frmUsuarios = new FrmUsuarios();
            //frmUsuarios.ShowDialog();
            AbrirFormularioEnPanel(new FrmListadoUsuarios(), btnUsuarios);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            //FrmProveedores frmProveedores = new FrmProveedores();
            //frmProveedores.ShowDialog();
            AbrirFormularioEnPanel(new FrmProveedores(), btnProveedores);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            //FrmListadoCompras frmListadoCompras = new FrmListadoCompras();
            //frmListadoCompras.ShowDialog();
            AbrirFormularioEnPanel(new FrmListadoCompras(), btnCompras);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //FrmListadoVentas frmListadoVentas = new FrmListadoVentas();
            //frmListadoVentas.ShowDialog();

            AbrirFormularioEnPanel(new FrmListadoVentas(), btnVentas);

        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            //FrmCaja frmCaja = new FrmCaja();
            //frmCaja.ShowDialog();
            AbrirFormularioEnPanel(new FrmCaja(), btnCaja);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            //FrmInventario frmInventario = new FrmInventario();
            //frmInventario.ShowDialog();
            AbrirFormularioEnPanel(new FrmInventario(), btnInventario);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        private void pbBanner_Click(object sender, EventArgs e)
        {
            if (pnlForms.Controls.Count > 0)
            {
                pnlForms.Controls.RemoveAt(0);
            }

            AbrirFormularioEnPanel(new MenuLogo(), null);

        }

        private void AbrirFormularioEnPanel(Form frm, Button botonSeleccionado)
        {
            if (pnlForms.Controls.Count > 0)
            {
                pnlForms.Controls.RemoveAt(0);
            }

            frm.TopLevel = false;                     
            frm.FormBorderStyle = FormBorderStyle.None; 
            frm.Dock = DockStyle.Fill;                
            pnlForms.Controls.Add(frm);
            pnlForms.Tag = frm;

            lblTitulo.Text = frm.Text;

            frm.Show();
        }

        private void pbBanner_Click_1(object sender, EventArgs e)
        {
            if (pnlForms.Controls.Count > 0)
            {
                pnlForms.Controls.RemoveAt(0);
            }

            AbrirFormularioEnPanel(new MenuLogo(), null);
        }
    }
}
