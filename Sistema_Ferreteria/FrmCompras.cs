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
    public partial class FrmCompras : Form
    {
        private Compra CompraActual = new Compra();
        private bool EsModificacion = false;

        public FrmCompras()
        {
            InitializeComponent();
        }

        public FrmCompras(Compra compraSeleccionada)
        {
            InitializeComponent();
            this.CompraActual = compraSeleccionada;
            EsModificacion = true;
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores(true); // activamos modo selección
            if (frm.ShowDialog() == DialogResult.OK && frm.ProveedorSeleccionado != null)
            {
                Proveedor proveedor = frm.ProveedorSeleccionado;
                txtCuit.Text = proveedor.Cuit;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtTelefono.Text = proveedor.Telefono;
                txtIdProveedor.Text = proveedor.ProveedorId.ToString();
                txtEmail.Text = proveedor.Email;
                txtCuit.Tag = proveedor; // guardamos el objeto para usarlo luego
            }
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaDetalle();
            if (EsModificacion && CompraActual != null)
            {
                // Cargar cabecera
                txtCuit.Text = CompraActual.Proveedor.Cuit;
                txtRazonSocial.Text = CompraActual.Proveedor.RazonSocial;
                txtIdProveedor.Text = CompraActual.Proveedor.ProveedorId.ToString();
                txtTelefono.Text = CompraActual.Proveedor.Telefono;
                txtEmail.Text = CompraActual.Proveedor.Email;
                dtpFecha.Value = CompraActual.FechaCompra;
                txtTotal.Text = CompraActual.Total.ToString("0.00");
                txtCuit.Tag = CompraActual.Proveedor;

                // Cargar detalle
                foreach (var det in CompraActual.Detalles)
                {
                    dgvDetalleCompra.Rows.Add(
                        det.Producto.ProductoId,
                        det.Producto.Descripcion,
                        det.Cantidad,
                        det.PrecioUnitario.ToString("0.00"),
                        (det.Cantidad * det.PrecioUnitario).ToString("0.00")
                    );
                }

                btnConfirmar.Text = "Guardar cambios";
            }
        }

        private void btnListadoProductos_Click(object sender, EventArgs e)
        {
            FrmListadoProductos frm = new FrmListadoProductos(true); // modo selección
            if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
            {
                Producto producto = frm.ProductoSeleccionado;

                // Mostramos los datos del producto en el formulario
                txtIdProveedor.Text = producto.ProductoId.ToString();
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion ?? "";
                txtCodigo.Text = producto.Codigo ?? "";
                // Guardamos el objeto completo para usarlo al agregar detalle
                txtIdProveedor.Tag = producto;
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvDetalleCompra.Rows)
            {
                if (fila.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value);
            }

            txtTotal.Text = total.ToString("N2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIdProveedor.Tag == null)
            {
                MessageBox.Show("Seleccione un producto antes de agregar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto producto = (Producto)txtIdProveedor.Tag;
             producto.PrecioCosto = Convert.ToDecimal(txtPrecioCosto.Text);
            decimal subtotal = producto.PrecioCosto * cantidad;

            dgvDetalleCompra.Rows.Add(
                producto.ProductoId,
                producto.Descripcion,
                cantidad,
                producto.PrecioCosto.ToString("0.00"),
                subtotal.ToString("0.00")
            );

            CalcularTotal();

            // 🔹 Limpieza de campos para el siguiente producto
            LimpiarCamposProducto();

            // 🔹 Foco al primer campo (para trabajar rápido)
            txtCodigo.Focus();

            
        }

        private void ConfigurarGrillaDetalle()
        {
            dgvDetalleCompra.Columns.Clear();
            dgvDetalleCompra.AutoGenerateColumns = false;
            dgvDetalleCompra.AllowUserToAddRows = false;
            dgvDetalleCompra.RowHeadersVisible = false;
            dgvDetalleCompra.BackgroundColor = Color.White;
            dgvDetalleCompra.BorderStyle = BorderStyle.Fixed3D;
            dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 🧱 Columnas manuales
            dgvDetalleCompra.Columns.Add("IdProducto", "ID Producto");
            dgvDetalleCompra.Columns.Add("Descripcion", "Descripción");
            dgvDetalleCompra.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleCompra.Columns.Add("PrecioCosto", "Precio Costo");
            dgvDetalleCompra.Columns.Add("Subtotal", "Subtotal");

            // Columna subtotal de solo lectura
            dgvDetalleCompra.Columns["Cantidad"].ReadOnly = false;
            dgvDetalleCompra.Columns["PrecioCosto"].ReadOnly = false;
            dgvDetalleCompra.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleCompra.Columns["IdProducto"].ReadOnly = true;
            dgvDetalleCompra.Columns["Subtotal"].ReadOnly = true;

        }

        private void LimpiarCamposProducto()
        {
            txtIdProveedor.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioCosto.Clear();
            txtCantidad.Clear();
            txtCodigo.Clear();
            txtIdProveedor.Tag = null; // quitamos referencia al producto anterior
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // 🟡 Validaciones
                if (txtCuit.Tag == null)
                {
                    MessageBox.Show("Seleccione un proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvDetalleCompra.Rows.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto a la compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🟢 Crear el objeto Compra
                Compra compra = new Compra
                {
                    Proveedor = (Proveedor)txtCuit.Tag,
                    FechaCompra = dtpFecha.Value,
                    Total = Convert.ToDecimal(txtTotal.Text),
                    EstadoCompra = new EstadoCompra { IdEstadoCompra = 1 }, // "Recibida" o el estado inicial que uses
                    Detalles = new List<DetalleCompra>()
                };

                // 🟢 Reconstruir los detalles desde el DataGridView
                foreach (DataGridViewRow fila in dgvDetalleCompra.Rows)
                {
                    // 🚫 Evitar fila vacía al final
                    if (fila.IsNewRow) continue;

                    DetalleCompra det = new DetalleCompra
                    {
                        Producto = new Producto
                        {
                            ProductoId = Convert.ToInt32(fila.Cells["IdProducto"].Value),
                            Descripcion = fila.Cells["Descripcion"].Value.ToString()
                        },
                        Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioCosto"].Value)
                    };

                    compra.Detalles.Add(det);
                }

                CompraNegocio negocio = new CompraNegocio();

                // 🟢 Decidir si es modificación o nueva
                if (EsModificacion && CompraActual != null)
                {
                    compra.IdCompra = CompraActual.IdCompra;
                    negocio.ModificarCompra(compra);
                    MessageBox.Show("Compra modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocio.RegistrarCompra(compra);
                    MessageBox.Show("Compra registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 🔁 Devolver resultado al formulario padre
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvDetalleCompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvDetalleCompra.Columns["Cantidad"].Index ||
                        e.ColumnIndex == dgvDetalleCompra.Columns["PrecioCosto"].Index))
            {
                try
                {
                    DataGridViewRow fila = dgvDetalleCompra.Rows[e.RowIndex];
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    decimal precio = Convert.ToDecimal(fila.Cells["PrecioCosto"].Value);
                    decimal subtotal = cantidad * precio;

                    fila.Cells["Subtotal"].Value = subtotal.ToString("0.00");

                    CalcularTotal(); // 🔄 recalcula el total de la compra
                }
                catch
                {
                    MessageBox.Show("Verifique los valores ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}


