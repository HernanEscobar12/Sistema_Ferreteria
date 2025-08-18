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
<<<<<<< HEAD
            Carga();
=======
            ProductoNegocio productoNegocio = new ProductoNegocio();
            //dgvProductos.DataSource = productoNegocio.ListarProductos();
            dgvProductos.DataSource = productoNegocio.Listado(); // Listado con StoredProcedure

>>>>>>> fix/acceso-datos-metodo
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            FrmDetalleProducto frmDetalleProducto = new FrmDetalleProducto(Producto);
            if(frmDetalleProducto.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleProducto frmDetalleProducto = new FrmDetalleProducto();

            if (frmDetalleProducto.ShowDialog() == DialogResult.OK)
            {
                Carga();
            }

        }

        private void Carga()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvProductos.DataSource = productoNegocio.Listado();
            btnActivos.Visible = false;
            btnInactivos.Enabled = true;
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productoNegocio.ListarProductosInactivos();
            btnInactivos.Enabled = false;
            btnActivos.Visible = true;
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            Carga();
        }
    }
}
