﻿using Datos;
using Dominio;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> ListarProveedores()
        {

            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Proveedor> Proveedores = new List<Proveedor>();
                Datos.SetearConsulta("select P.Proveedor_Id ProveedorID,\r\nRazonSocial, \r\nCuit, \r\nTelefono ,\r\nEmail , \r\nEstado,\r\nD.Direccion_Id DireccionId,\r\nD.Calle Calle ,\r\nD.Numero Numero , \r\nL.Localidad_Id LocalidadId , \r\nL.Nombre Localidad,\r\nPr.Provincia_Id ProvinciaID,\r\nPr.Nombre Provincia\r\nfrom Proveedor P \r\ninner join Direccion D on D.Direccion_Id = P.Direccion_Id\r\ninner join Localidad L on L.Localidad_Id = D.Localidad_Id\r\ninner join Provincia Pr on L.Provincia_Id = Pr.Provincia_Id");
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Proveedor Aux = new Proveedor();
                    Aux.ProveedorId = (int)Datos.Lector["ProveedorID"];
                    Aux.RazonSocial = (string)Datos.Lector["RazonSocial"];
                    Aux.Cuit = (string)Datos.Lector["Cuit"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Email"];
                    Aux.Estado = Convert.ToBoolean(Datos.Lector["Estado"]);
                    Aux.Direccion = new Direccion();
                    Aux.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    Aux.Direccion.Calle = (string)Datos.Lector["Calle"];
                    Aux.Direccion.Numero = (string)Datos.Lector["Numero"];
                    Aux.Direccion.Localidad = new Localidad();
                    Aux.Direccion.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    Aux.Direccion.Localidad.Nombre = (string)Datos.Lector["Localidad"];
                    Aux.Direccion.Localidad.Provincia = new Provincia();
                    Aux.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    Aux.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];

                    Proveedores.Add(Aux);

                }

                return Proveedores;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Proveedor> ListarProveedoresActivos()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Proveedor> Proveedores = new List<Proveedor>();
                Datos.SetearConsulta("select P.Proveedor_Id ProveedorID,\r\nRazonSocial, \r\nCuit, \r\nTelefono ,\r\nEmail , \r\nEstado,\r\nD.Direccion_Id DireccionId,\r\nD.Calle Calle ,\r\nD.Numero Numero , \r\nL.Localidad_Id LocalidadId , \r\nL.Nombre Localidad,\r\nPr.Provincia_Id ProvinciaID,\r\nPr.Nombre Provincia\r\nfrom Proveedor P \r\ninner join Direccion D on D.Direccion_Id = P.Direccion_Id\r\ninner join Localidad L on L.Localidad_Id = D.Localidad_Id\r\ninner join Provincia Pr on L.Provincia_Id = Pr.Provincia_Id where  Estado = 1");
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Proveedor Aux = new Proveedor();
                    Aux.ProveedorId = (int)Datos.Lector["ProveedorID"];
                    Aux.RazonSocial = (string)Datos.Lector["RazonSocial"];
                    Aux.Cuit = (string)Datos.Lector["Cuit"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Email"];
                    Aux.Estado = Convert.ToBoolean(Datos.Lector["Estado"]);
                    Aux.Direccion = new Direccion();
                    Aux.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    Aux.Direccion.Calle = (string)Datos.Lector["Calle"];
                    Aux.Direccion.Numero = (string)Datos.Lector["Numero"];
                    Aux.Direccion.Localidad = new Localidad();
                    Aux.Direccion.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    Aux.Direccion.Localidad.Nombre = (string)Datos.Lector["Localidad"];
                    Aux.Direccion.Localidad.Provincia = new Provincia();
                    Aux.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    Aux.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];

                    Proveedores.Add(Aux);

                }

                return Proveedores;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Proveedor> ListarProveedoresInactivos()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Proveedor> Proveedores = new List<Proveedor>();
                Datos.SetearConsulta("select P.Proveedor_Id ProveedorID,\r\nRazonSocial, \r\nCuit, \r\nTelefono ,\r\nEmail , \r\nEstado,\r\nD.Direccion_Id DireccionId,\r\nD.Calle Calle ,\r\nD.Numero Numero , \r\nL.Localidad_Id LocalidadId , \r\nL.Nombre Localidad,\r\nPr.Provincia_Id ProvinciaID,\r\nPr.Nombre Provincia\r\nfrom Proveedor P \r\ninner join Direccion D on D.Direccion_Id = P.Direccion_Id\r\ninner join Localidad L on L.Localidad_Id = D.Localidad_Id\r\ninner join Provincia Pr on L.Provincia_Id = Pr.Provincia_Id where  Estado = 0");
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Proveedor Aux = new Proveedor();
                    Aux.ProveedorId = (int)Datos.Lector["ProveedorID"];
                    Aux.RazonSocial = (string)Datos.Lector["RazonSocial"];
                    Aux.Cuit = (string)Datos.Lector["Cuit"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Email"];
                    Aux.Estado = Convert.ToBoolean(Datos.Lector["Estado"]);
                    Aux.Direccion = new Direccion();
                    Aux.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    Aux.Direccion.Calle = (string)Datos.Lector["Calle"];
                    Aux.Direccion.Numero = (string)Datos.Lector["Numero"];
                    Aux.Direccion.Localidad = new Localidad();
                    Aux.Direccion.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    Aux.Direccion.Localidad.Nombre = (string)Datos.Lector["Localidad"];
                    Aux.Direccion.Localidad.Provincia = new Provincia();
                    Aux.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    Aux.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];

                    Proveedores.Add(Aux);

                }

                return Proveedores;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            ;

        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                // 🔹 Formatear CUIT antes de guardar
                proveedor.Cuit = Validaciones.FormatearCuil(proveedor.Cuit);

                Datos.SetearProcedimiento("AgregarProveedor");
                Datos.SetearParametros("@RazonSocial", proveedor.RazonSocial);
                Datos.SetearParametros("@Cuit", proveedor.Cuit);
                Datos.SetearParametros("@Calle", proveedor.Direccion.Calle);
                Datos.SetearParametros("@Numero", proveedor.Direccion.Numero);
                Datos.SetearParametros("@LocalidadID", proveedor.Direccion.Localidad.LocalidadId);
                Datos.SetearParametros("@Telefono", proveedor.Telefono);
                Datos.SetearParametros("@Email", proveedor.Email);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 200);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        public void ModificarProveedor(Proveedor proveedor)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                proveedor.Cuit = Validaciones.FormatearCuil(proveedor.Cuit);

                Datos.SetearProcedimiento("ModificarProveedor");
                Datos.SetearParametros("@ProveedorID", proveedor.ProveedorId);
                Datos.SetearParametros("@RazonSocial", proveedor.RazonSocial);
                Datos.SetearParametros("@Cuit", proveedor.Cuit);
                Datos.SetearParametros("@Calle", proveedor.Direccion.Calle);
                Datos.SetearParametros("@Numero", proveedor.Direccion.Numero);
                Datos.SetearParametros("@LocalidadID", proveedor.Direccion.Localidad.LocalidadId);
                Datos.SetearParametros("@Telefono", proveedor.Telefono);
                Datos.SetearParametros("@Email", proveedor.Email);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        public void CambiarEstadoProveedor(int proveedorId, bool nuevoEstado)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearProcedimiento("CambiarEstadoProveedor");
                Datos.SetearParametros("@ProveedorID", proveedorId);
                Datos.SetearParametros("@NuevoEstado", nuevoEstado);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

    }
}
