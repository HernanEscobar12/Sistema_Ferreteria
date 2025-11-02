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
    public partial class FrmVentas : Form
    {
        private Venta VentaActual = new Venta();
        private bool EsModificacion = false;

        public FrmVentas()
        {
            InitializeComponent();
        }

        public FrmVentas(Venta ventaSeleccionada)
        {
            InitializeComponent();
            this.VentaActual = ventaSeleccionada;
            this.txtIdCliente.Tag = ventaSeleccionada.Cliente;
            EsModificacion = true;
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaDetalle();

            if (EsModificacion && VentaActual != null)
            {
                // Cargar cabecera
                //[Cliente]
                txtCuit.Text = VentaActual.Cliente.Cuit;
                txtNombre.Text = VentaActual.Cliente.Nombre;
                txtApellidoCliente.Text = VentaActual.Cliente.Apellido;
                txtIdCliente.Text = VentaActual.Cliente.IdCliente.ToString();
                txtNombreCliente.Text = VentaActual.Cliente.Nombre + " " ;

                //[Fecha]
                dtpFecha.Value = VentaActual.FechaVenta;
                txtTotal.Text = VentaActual.Total.ToString("0.00");
                txtCuit.Tag = VentaActual.Cliente;

                // Cargar detalle
                foreach (var det in VentaActual.Detalles)
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

        private void btnListadoClientes_Click(object sender, EventArgs e)
        {
            FrmListadoClientes frm = new FrmListadoClientes(true); // modo selección
            if (frm.ShowDialog() == DialogResult.OK && frm != null)
            {
                Cliente cliente = frm.ClienteSeleccionado;
                txtCuit .Text = cliente.Cuit;
                txtNombreCliente.Text = cliente.Nombre;
                txtApellidoCliente.Text = cliente.Apellido;
                txtIdCliente.Text = cliente.IdCliente.ToString();
                txtIdCliente.Tag = cliente; // guardamos el objeto
            }
        }

        private void btnListadoProductos_Click(object sender, EventArgs e)
        {
            FrmListadoProductos frm = new FrmListadoProductos(true); // modo selección
            if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
            {
                Producto producto = frm.ProductoSeleccionado;

                // Mostramos los datos
                txtCodigo.Text = producto.Codigo.ToString();
                txtNombre.Text = producto.Nombre ?? "";
                txtDescripcion.Text = producto.Descripcion ?? "";
                txtPrecioCosto.Text = producto.PrecioCosto.ToString("0.00");
                IdProducto.Tag = producto;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IdProducto.Tag == null)
            {
                MessageBox.Show("Seleccione un producto antes de agregar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto producto = (Producto)IdProducto.Tag;
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
            LimpiarCamposProducto();
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

            dgvDetalleCompra.Columns.Add("IdProducto", "ID Producto");
            dgvDetalleCompra.Columns.Add("Descripcion", "Descripción");
            dgvDetalleCompra.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleCompra.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalleCompra.Columns.Add("Subtotal", "Subtotal");

            dgvDetalleCompra.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleCompra.Columns["IdProducto"].ReadOnly = true;
            dgvDetalleCompra.Columns["Subtotal"].ReadOnly = true;
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

        private void LimpiarCamposProducto()
        {
            IdProducto.Tag = null;
            txtDescripcion.Clear();
            txtCodigo.Clear();
            txtPrecioCosto.Clear();
            txtCantidad.Clear();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdCliente.Tag == null)
                {
                    MessageBox.Show("Seleccione un cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvDetalleCompra.Rows.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto a la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Venta venta = new Venta
                {
                    Cliente = (Cliente)txtIdCliente.Tag,
                    FechaVenta = dtpFecha.Value,
                    Total = Convert.ToDecimal(txtTotal.Text),
                    EstadoVenta = new EstadoVenta { IdEstadoVenta = 3 },
                    Detalles = new List<DetalleVenta>()
                };

                foreach (DataGridViewRow fila in dgvDetalleCompra.Rows)
                {
                    if (fila.IsNewRow) continue;

                    DetalleVenta det = new DetalleVenta
                    {
                        Producto = new Producto
                        {
                            ProductoId = Convert.ToInt32(fila.Cells["IdProducto"].Value),
                            Descripcion = fila.Cells["Descripcion"].Value.ToString()
                        },
                        Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value)
                    };

                    venta.Detalles.Add(det);
                }

                VentaNegocio negocio = new VentaNegocio();

                if (EsModificacion && VentaActual != null)
                {
                    venta.IdVenta = VentaActual.IdVenta;
                    negocio.ModificarVenta(venta);
                    MessageBox.Show("Venta modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocio.RegistrarVenta(venta);
                    MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                (e.ColumnIndex == dgvDetalleCompra.Columns["Cantidad"].Index ||
                 e.ColumnIndex == dgvDetalleCompra.Columns["PrecioUnitario"].Index))
            {
                try
                {
                    DataGridViewRow fila = dgvDetalleCompra.Rows[e.RowIndex];
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    decimal precio = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                    decimal subtotal = cantidad * precio;

                    fila.Cells["Subtotal"].Value = subtotal.ToString("0.00");

                    CalcularTotal();
                }
                catch
                {
                    MessageBox.Show("Verifique los valores ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            VentaNegocio ventaNegocio = new VentaNegocio();

            try
            {
                if (EsModificacion && VentaActual != null)
                {
                    ventaNegocio.AnularVenta(VentaActual.IdVenta);
                    MessageBox.Show("Venta anulada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se puede anular una venta que no ha sido guardada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al anular la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
