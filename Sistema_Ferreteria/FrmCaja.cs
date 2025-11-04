using Dominio;
using Negocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmCaja : Form
    {
        private readonly CajaNegocio cajaNegocio = new CajaNegocio();
        private Caja cajaActual;

        public FrmCaja()
        {
            InitializeComponent();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        // ===============================
        // 🔹 Actualiza todo el formulario
        // ===============================
        private void RefrescarDatos()
        {
            try
            {
                cajaActual = cajaNegocio.ObtenerCajaAbierta();

                if (cajaActual != null)
                {
                    lblEstado.Text = "ABIERTA";
                    lblEstado.ForeColor = Color.Green;

                    lblUser.Text = cajaActual.UsuarioApertura != null
                        ? cajaActual.UsuarioApertura.User
                        : "-";

                    LblFecha.Text = cajaActual.FechaApertura.ToShortDateString();

                    CargarResumen(cajaActual.IdCaja);
                    CargarMovimientos();
                }
                else
                {
                    lblEstado.Text = "CERRADA";
                    lblEstado.ForeColor = Color.Red;
                    lblUser.Text = "-";
                    LblFecha.Text = DateTime.Now.ToShortDateString();
                    LimpiarLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la caja: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarLabels();
            }
        }

        private void LimpiarLabels()
        {
            lblIngresos.Text = "0.00";
            lblEgresos.Text = "0.00";
            LblFinal.Text = "0.00";
            dgvDetallesMovimientos.DataSource = null;
        }

        private void CargarResumen(int idCaja)
        {
            var resumen = cajaNegocio.ObtenerResumenDiario(idCaja);
            lblIngresos.Text = resumen.TotalIngresos.ToString("C");
            lblEgresos.Text = resumen.TotalEgresos.ToString("C");
            LblFinal.Text = resumen.SaldoFinal.ToString("C");
        }

        private void CargarMovimientos()
        {
            dgvDetallesMovimientos.DataSource = cajaNegocio.ListarMovimientosDelDia();
            dgvDetallesMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ===============================
        // 🔹 Botón: Abrir Caja
        // ===============================
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (cajaNegocio.HayCajaAbierta())
                {
                    MessageBox.Show("Ya existe una caja abierta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ⚠️ Reemplazar con el usuario real logueado
                int idCaja = cajaNegocio.AbrirCaja(1, 0);
                MessageBox.Show($"Caja abierta correctamente (ID: {idCaja})", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================
        // 🔹 Botón: Cerrar Caja
        // ===============================
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (cajaActual == null)
                {
                    MessageBox.Show("No hay caja abierta actualmente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cajaNegocio.CerrarCaja(cajaActual.IdCaja, 1); // ⚠️ Usuario actual
                MessageBox.Show("Caja cerrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================
        // 🔹 Botón: Actualizar
        // ===============================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        // ===============================
        // 🔹 Botón: Salir
        // ===============================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
