﻿using Dominio;
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
    public partial class FrmListadoProductos : Form
    {
        private Producto Producto = null;
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvProductos.DataSource = productoNegocio.ListarProductos();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            FrmDetalleProducto frmDetalleProducto = new FrmDetalleProducto(Producto);
            frmDetalleProducto.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleProducto frmDetalleProducto = new FrmDetalleProducto();
            frmDetalleProducto.ShowDialog();
        }
    }
}
