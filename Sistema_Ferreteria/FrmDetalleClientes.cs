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
    public partial class FrmDetalleClientes : Form
    {
        private Cliente Cliente = null;
        public FrmDetalleClientes()
        {
            InitializeComponent();
            Carga();
        }

        public FrmDetalleClientes(Cliente c)
        {
            InitializeComponent();
            Cliente = c;

            this.Text = "Detalle " + Cliente.Nombre + " " + Cliente.Apellido;


            if (c.Estado)
            {
                btnEstado.Text = "Inactivar";
            }
            else
            {
                btnEstado.Text = "Activar";

            }

            btnEstado.BackColor = Cliente.Estado ? Color.Red : Color.Green;
            btnEstado.Visible = true;
        }

        public void Carga()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            cboProvincia.DataSource = provinciaNegocio.ListarProvincias();

            cboProvincia.ValueMember = "ProvinciaId";
            cboProvincia.DisplayMember = "Nombre";

            if(Cliente != null)
            {
                IdCLiente.Text = Cliente.IdCliente.ToString();
                txtApellido.Text = Cliente.Apellido;
                txtNombre.Text = Cliente.Nombre;
                txtDni.Text = Cliente.Dni.ToString();
                txtCuit.Text = Cliente.Cuit.ToString();
                txtCalle.Text = Cliente.Calle.ToString();
                txtNumero.Text = Cliente.Numero.ToString();
                cboProvincia.SelectedValue = Cliente.Provincia.ProvinciaId;
                cboLocalidad.SelectedValue = Cliente.Localidad.LocalidadId;
            }

        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cboProvincia.SelectedIndex;
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            cboLocalidad.DataSource = null;
            cboLocalidad.DataSource = localidadNegocio.ListarLocalidades(id + 1);
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "Nombre";
        }

        private void FrmDetalleClientes_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || 
                string.IsNullOrEmpty(txtDni.Text) || 
                string.IsNullOrEmpty(txtCuit.Text) ||
                string.IsNullOrEmpty(txtCalle.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            try
            {
                if (Validar())
                {
                    if(Cliente == null)
                        Cliente = new Cliente();

                    Cliente.Nombre = txtNombre.Text;
                    Cliente.Apellido = txtApellido.Text;
                    Cliente.Dni = txtDni.Text;
                    Cliente.Calle = txtCalle.Text;
                    Cliente.Numero = txtNumero.Text;
                    Cliente.Localidad = (Localidad)cboLocalidad.SelectedItem;
                    Cliente.Cuit = txtCuit.Text;


                    if (Cliente.IdCliente == 0)
                    {
                        clienteNegocio.AgregarCliente(Cliente);
                        MessageBox.Show("Cliente Agregado Exitosamente");
                    }
                    else
                    {
                        clienteNegocio.ModificarCliente(Cliente);
                        MessageBox.Show("Cliente Modificado Exitosamente");
                    }

                    // Indicás que se cerró con éxito
                    this.DialogResult = DialogResult.OK;
                }

               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            ClienteNegocio ClienteNegocio= new ClienteNegocio();

            if (Cliente.Estado)
            {
                ClienteNegocio.InactivarCliente(Cliente.IdCliente);
                // Indicás que se cerró con éxito
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                ClienteNegocio.ActivarCliente(Cliente.IdCliente);
                // Indicás que se cerró con éxito
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
