using Dominio;
using Negocio;
using Negocio.Utilidades;
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
    public partial class FrmDetallesProveedor : Form
    {
        private Proveedor Proveedor = null;
        public FrmDetallesProveedor()
        {
            InitializeComponent();
            
        }

        public FrmDetallesProveedor(Proveedor proveedor)
        {
            InitializeComponent();
            this.Proveedor = proveedor;
        }


        private void Carga()
        {
            CargarCbos();

            if(Proveedor != null && Proveedor.Estado)
            {
                btnEstado.Visible = true;
                btnEstado.Text = "Deshabilitar";
                btnEstado.BackColor = Color.Red;
            }
            else if(Proveedor != null && !Proveedor.Estado)
            {
                btnEstado.Visible = true;
                btnEstado.Text = "Habilitar";
                btnEstado.BackColor = Color.Green;
            }

            if (Proveedor != null)
            {
                txtId.Text = Proveedor.ProveedorId.ToString();
                txtRazonSocial.Text = Proveedor.RazonSocial;
                txtCuil.Text = Proveedor.Cuit;
                txtTel.Text = Proveedor.Telefono;
                txtCalle.Text = Proveedor.Direccion.Calle;
                txtNum.Text = Proveedor.Direccion.Numero;
                cboLocalidad.SelectedValue = Proveedor.Direccion.Localidad.LocalidadId;
                txtEmail.Text = Proveedor.Email;
            }
        }

        private void CargarCbos()
        {
            Utilidad utilidad = new Utilidad();
            cboLocalidad.DataSource = utilidad.ListadoLocalidad();
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "Nombre";
        }

        private void FrmDetallesProveedor_Load_1(object sender, EventArgs e)
        {
            Carga();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text) || string.IsNullOrEmpty(txtCuil.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrEmpty(txtNum.Text) || cboLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();


                if (Proveedor == null)
                    Proveedor = new Proveedor();

                Proveedor.RazonSocial = txtRazonSocial.Text;
                Proveedor.Cuit = txtCuil.Text;
                Proveedor.Telefono = txtTel.Text;
                Proveedor.Direccion = new Direccion();
                Proveedor.Direccion.Calle = txtCalle.Text;
                Proveedor.Direccion.Numero = txtNum.Text;
                Proveedor.Direccion.Localidad = (Localidad)cboLocalidad.SelectedItem;
                Proveedor.Email = txtEmail.Text;


                if (Proveedor.ProveedorId != 0)
                {
                    proveedorNegocio.ModificarProveedor(Proveedor);
                    MessageBox.Show("Proveedor modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    proveedorNegocio.AgregarProveedor(Proveedor);
                    MessageBox.Show("Proveedor agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;


            }

        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            if (Proveedor.Estado)
            {
                proveedorNegocio.CambiarEstadoProveedor(Proveedor.ProveedorId, false);
                MessageBox.Show("Proveedor deshabilitado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                proveedorNegocio.CambiarEstadoProveedor(Proveedor.ProveedorId, true);
                MessageBox.Show("Proveedor habilitado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
