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
            Carga();
        }

        public void Carga()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            cboProvincia.DataSource = provinciaNegocio.ListarProvincias();

            cboProvincia.ValueMember = "ProvinciaId";
            cboProvincia.DisplayMember = "Nombre";

            if(Cliente != null)
            {
                txtApellido.Text = Cliente.Apellido;
                txtNombre.Text = Cliente.Nombre;
                txtDni.Text = Cliente.Dni.ToString();
                txtCuit.Text = Cliente.Cuit.ToString();
                txtDireccion.Text = Cliente.Direccion.ToString();
                cboProvincia.SelectedValue = Cliente.Localidad.Provincia.ProvinciaId;
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
    }
}
