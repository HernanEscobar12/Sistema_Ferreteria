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
    public partial class FrmDetallesEmpleados : Form
    {
        public Empleado Empleado = null;
        public FrmDetallesEmpleados()
        {
            InitializeComponent();
            Carga();
        }

        public FrmDetallesEmpleados(Empleado empleado)
        {
            this.Empleado = empleado;

            this.Text = "Detalles de " + empleado.Nombre;


            InitializeComponent();
            Carga();
            Estado();

        }



        public void Carga()
        {

            // Cargar Combo Box Localidad
            LocalidadNegocio LocalidadNegocio = new LocalidadNegocio();
            cboLocalidad.DataSource = LocalidadNegocio.Listado();
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "Nombre";

            // Cargar Combo box Sucursal
            SucursalNegocio sucursalNegocio = new SucursalNegocio();
            cboSucursal.DataSource = sucursalNegocio.Sucursales();
            cboSucursal.ValueMember = "SucursalId";
            cboSucursal.DisplayMember = "Nombre";


            // Carga Combo Box Cargo
            Utilidad utilidad = new Utilidad();
            cboCargo.DataSource = utilidad.ListadoDeCargo();
            cboCargo.ValueMember = "IdCargo";
            cboCargo.DisplayMember = "Descripcion";

            if (Empleado != null)
            {
                txtNombre.Text = Empleado.Nombre;
                txtCuil.Text = Empleado.Cuil;
                txtCalle.Text = Empleado.Direccion.Calle;
                txtNumero.Text = Empleado.Direccion.Numero;
                txtEmail.Text = Empleado.Email;
                txtTelefono.Text = Empleado.Telefono;
                cboLocalidad.SelectedValue = Empleado.Direccion.Localidad.LocalidadId;
                cboSucursal.SelectedValue = Empleado.Sucursal.SucursalId;

            }

        }


        // Función Inactivar / Activar empleado.  
        private void Estado()
        {

            if (Empleado.Estado)
            {
                btnEstado.Text = "Inactivar";
                btnEstado.BackColor = Color.Red;
            }
            else
            {
                btnEstado.Text = "Activar";
                btnEstado.BackColor = Color.Green;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCuil.Text) || string.IsNullOrEmpty(txtCalle.Text) ||
                string.IsNullOrEmpty(txtNumero.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTelefono.Text)
                )
            {
                MessageBox.Show("Debes completar todos los campos");
            }
            else
            {
                if (Empleado == null)
                    Empleado = new Empleado();


                Empleado.Nombre = txtNombre.Text;
                Empleado.Cuil = txtCuil.Text;
                Empleado.Telefono = txtTelefono.Text;
                Empleado.Direccion = new Direccion();
                Empleado.Direccion.Calle = txtCalle.Text;
                Empleado.Direccion.Numero = txtNumero.Text;
                Empleado.Email = txtEmail.Text;
                Empleado.Direccion.Localidad = (Localidad)cboLocalidad.SelectedItem;
                Empleado.Sucursal = (Sucursal)cboSucursal.SelectedItem;
                Empleado.Cargo = (Cargo)cboCargo.SelectedItem;


                EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

                if (Empleado.EmpleadoId != 0)
                {
                    //MessageBox.Show("Modificar");
                    empleadoNegocio.Modificar(Empleado);

                }
                else
                {
                    empleadoNegocio.Agregar(Empleado);
                }

                this.DialogResult = DialogResult.OK;
            }

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

            try
            {
                if (Empleado.Estado)
                {
                    empleadoNegocio.Inactivar(Empleado.EmpleadoId);
                    MessageBox.Show("Empleado Inactivo");
                }
                else
                {
                    empleadoNegocio.Activar(Empleado.EmpleadoId);
                    MessageBox.Show("Empleado Activo");
                }
                
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
