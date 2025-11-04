using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CajaNegocio
    {
        // 🟢 Abrir una nueva caja
        public int AbrirCaja(int usuarioApertura, decimal saldoInicial)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
                    INSERT INTO Caja (Sucursal_Id, Fecha_Apertura, Usuario_Apertura, Saldo_Inicial, Estado)
                    OUTPUT INSERTED.Caja_Id
                    VALUES (1, GETDATE(), @Usuario, @SaldoInicial, 'A')");
                datos.SetearParametros("@Usuario", usuarioApertura);
                datos.SetearParametros("@SaldoInicial", saldoInicial);

                int idCaja = Convert.ToInt32(datos.EjecutarEscalar());
                return idCaja;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la caja: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool HayCajaAbierta()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT COUNT(*) FROM Caja WHERE Estado = 'A'");
                int abiertas = Convert.ToInt32(datos.EjecutarEscalar());
                return abiertas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar caja abierta: " + ex.Message);
            }
        }

        // 🟢 Registrar movimiento (Ingreso o Egreso)
        public void RegistrarMovimiento(MovimientoCaja movimiento)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
                    INSERT INTO MovimientoCaja (Caja_Id, Fecha, Tipo, Monto, Concepto, Referencia_Id, Usuario_Id)
                    VALUES (@Caja_Id, GETDATE(), @Tipo, @Monto, @Concepto, @Referencia_Id, @Usuario_Id)");
                datos.SetearParametros("@Caja_Id", movimiento.Caja.IdCaja);
                datos.SetearParametros("@Tipo", movimiento.TipoMovimiento);
                datos.SetearParametros("@Monto", movimiento.Monto);
                datos.SetearParametros("@Concepto", movimiento.Concepto);
                datos.SetearParametros("@Referencia_Id", movimiento.ReferenciaId ?? (object)DBNull.Value);
                datos.SetearParametros("@Usuario_Id", movimiento.UsuarioId ?? (object)DBNull.Value);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar movimiento de caja: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // 🟢 Cerrar caja (calcula el saldo final automáticamente)
        public void CerrarCaja(int idCaja, int usuarioCierre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.IniciarTransaccion();

                // 1️⃣ Calcular totales del día
                datos.SetearConsulta(@"
                    SELECT 
                        SUM(CASE WHEN TipoMovimiento = 'I' THEN Monto ELSE 0 END) AS TotalIngresos,
                        SUM(CASE WHEN TipoMovimiento = 'E' THEN Monto ELSE 0 END) AS TotalEgresos
                    FROM MovimientoCaja
                    WHERE Caja_Id = @Caja_Id");
                datos.SetearParametros("@Caja_Id", idCaja);

                decimal ingresos = 0, egresos = 0;
                using (var lector = datos.EjecutarLecturaTransaccion())
                {
                    if (lector.Read())
                    {
                        ingresos = lector["TotalIngresos"] != DBNull.Value ? Convert.ToDecimal(lector["TotalIngresos"]) : 0;
                        egresos = lector["TotalEgresos"] != DBNull.Value ? Convert.ToDecimal(lector["TotalEgresos"]) : 0;
                    }
                }

                // 2️⃣ Obtener saldo inicial
                datos.LimpiarParametros();
                datos.SetearConsulta("SELECT Saldo_Inicial FROM Caja WHERE Caja_Id = @Id");
                datos.SetearParametros("@Id", idCaja);
                decimal saldoInicial = Convert.ToDecimal(datos.EjecutarEscalarTransaccion());

                decimal saldoFinal = saldoInicial + ingresos - egresos;

                // 3️⃣ Actualizar caja
                datos.LimpiarParametros();
                datos.SetearConsulta(@"
                    UPDATE Caja
                    SET Fecha_Cierre = GETDATE(),
                        Usuario_Cierre = @Usuario,
                        Saldo_Final = @SaldoFinal,
                        Estado = 'C'
                    WHERE Caja_Id = @Id");
                datos.SetearParametros("@Usuario", usuarioCierre);
                datos.SetearParametros("@SaldoFinal", saldoFinal);
                datos.SetearParametros("@Id", idCaja);

                datos.EjecutarAccionTransaccion();

                datos.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw new Exception("Error al cerrar la caja: " + ex.Message);
            }
        }

        public Caja ObtenerCajaAbierta()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
            SELECT TOP 1 
                c.Caja_Id, 
                c.Fecha_Apertura, 
                c.Saldo_Inicial, 
                c.Saldo_Final, 
                c.Estado,
                u.IdUsuario, 
                u.NombreUsuario AS Usuario, 
                e.Empleado_Id, 
                e.Nombre AS NombreEmpleado
            FROM Caja c
            LEFT JOIN Usuario u ON u.IdUsuario = c.Usuario_Apertura
            LEFT JOIN Empleado e ON e.Empleado_Id = u.EmpleadoId
            WHERE c.Estado = 'A'
            ORDER BY c.Fecha_Apertura DESC");

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    Caja caja = new Caja
                    {
                        IdCaja = Convert.ToInt32(datos.Lector["Caja_Id"]),
                        FechaApertura = Convert.ToDateTime(datos.Lector["Fecha_Apertura"]),
                        Estado = Convert.ToChar(datos.Lector["Estado"].ToString()[0]),
                        SaldoInicial = datos.Lector["Saldo_Inicial"] != DBNull.Value ? Convert.ToDecimal(datos.Lector["Saldo_Inicial"]) : 0,
                        SaldoFinal = datos.Lector["Saldo_Final"] != DBNull.Value ? Convert.ToDecimal(datos.Lector["Saldo_Final"]) : 0,
                        UsuarioApertura = new Usuario
                        {
                            IdUsuario = datos.Lector["IdUsuario"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdUsuario"]) : 0,
                            User = datos.Lector["Usuario"] != DBNull.Value ? datos.Lector["Usuario"].ToString() : "(sin usuario)", // ✅ corregido
                            Empleado = new Empleado
                            {
                                EmpleadoId = datos.Lector["Empleado_Id"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Empleado_Id"]) : 0, // ✅ corregido
                                Nombre = datos.Lector["NombreEmpleado"] != DBNull.Value ? datos.Lector["NombreEmpleado"].ToString() : "(sin nombre)" // ✅ corregido
                            }
                        }
                    };

                    return caja;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la caja abierta: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<MovimientoCaja> ListarMovimientosDelDia()
        {
            List<MovimientoCaja> lista = new List<MovimientoCaja>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
            SELECT Movimiento_Id, Caja_Id, Fecha, TipoMovimiento, Monto, Concepto, Usuario_Id
            FROM MovimientoCaja
            WHERE CONVERT(date, Fecha) = CONVERT(date, GETDATE())
            ORDER BY Fecha ASC");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    MovimientoCaja mov = new MovimientoCaja
                    {
                        IdMovimiento = Convert.ToInt32(datos.Lector["Movimiento_Id"]),
                        Caja = new Caja
                        {
                            IdCaja = datos.Lector["Caja_Id"] != DBNull.Value
                                ? Convert.ToInt32(datos.Lector["Caja_Id"])
                                : 0
                        },
                        Fecha = datos.Lector["Fecha"] != DBNull.Value
                            ? Convert.ToDateTime(datos.Lector["Fecha"])
                            : DateTime.MinValue,
                        // 🧩 corrección segura de TipoMovimiento
                        TipoMovimiento = datos.Lector["TipoMovimiento"] != DBNull.Value
                            ? datos.Lector["TipoMovimiento"].ToString().Trim()[0]
                            : ' ',
                        Monto = datos.Lector["Monto"] != DBNull.Value
                            ? Convert.ToDecimal(datos.Lector["Monto"])
                            : 0,
                        Concepto = datos.Lector["Concepto"] != DBNull.Value
                            ? datos.Lector["Concepto"].ToString()
                            : "(sin concepto)",
                        UsuarioId = datos.Lector["Usuario_Id"] != DBNull.Value
                            ? Convert.ToInt32(datos.Lector["Usuario_Id"])
                            : (int?)null
                    };

                    lista.Add(mov);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los movimientos del día: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }



        // 🟢 Consultar movimientos del día
        public List<MovimientoCaja> ListarMovimientosPorCaja(int idCaja)
        {
            List<MovimientoCaja> lista = new List<MovimientoCaja>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
            SELECT Movimiento_Id, Fecha, TipoMovimiento, Monto, Concepto, Referencia_Id, Usuario_Id
            FROM MovimientoCaja
            WHERE Caja_Id = @Caja_Id
            ORDER BY Fecha ASC");
                datos.SetearParametros("@Caja_Id", idCaja);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    MovimientoCaja mov = new MovimientoCaja();

                    // ID de movimiento
                    if (datos.Lector["Movimiento_Id"] != DBNull.Value)
                        mov.IdMovimiento = Convert.ToInt32(datos.Lector["Movimiento_Id"]);

                    // Caja asociada
                    mov.Caja = new Caja { IdCaja = idCaja };

                    // Fecha
                    mov.Fecha = datos.Lector["Fecha"] != DBNull.Value
                        ? Convert.ToDateTime(datos.Lector["Fecha"])
                        : DateTime.MinValue;

                    // TipoMovimiento (💡 CORREGIDO)
                    mov.TipoMovimiento = datos.Lector["TipoMovimiento"] != DBNull.Value
                        ? datos.Lector["TipoMovimiento"].ToString().Trim()[0]
                        : ' ';

                    // Monto
                    if (datos.Lector["Monto"] != DBNull.Value &&
                        decimal.TryParse(datos.Lector["Monto"].ToString(), out decimal monto))
                        mov.Monto = monto;
                    else
                        mov.Monto = 0;

                    // Concepto
                    mov.Concepto = datos.Lector["Concepto"] != DBNull.Value
                        ? datos.Lector["Concepto"].ToString()
                        : "(sin concepto)";

                    // Referencia opcional
                    mov.ReferenciaId = datos.Lector["Referencia_Id"] != DBNull.Value
                        ? Convert.ToInt32(datos.Lector["Referencia_Id"])
                        : (int?)null;

                    // Usuario opcional
                    mov.UsuarioId = datos.Lector["Usuario_Id"] != DBNull.Value
                        ? Convert.ToInt32(datos.Lector["Usuario_Id"])
                        : (int?)null;

                    lista.Add(mov);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar movimientos de caja: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }




        // 🟢 Obtener resumen diario (vista simplificada)
        public ResumenCaja ObtenerResumenDiario(int idCaja)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    SELECT 
                        SUM(CASE WHEN TipoMovimiento = 'I' THEN Monto ELSE 0 END) AS TotalIngresos,
                        SUM(CASE WHEN TipoMovimiento = 'E' THEN Monto ELSE 0 END) AS TotalEgresos
                    FROM MovimientoCaja
                    WHERE Caja_Id = @Caja_Id");
                datos.SetearParametros("@Caja_Id", idCaja);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    return new ResumenCaja
                    {
                        Fecha = DateTime.Today,
                        TotalIngresos = datos.Lector["TotalIngresos"] != DBNull.Value ? Convert.ToDecimal(datos.Lector["TotalIngresos"]) : 0,
                        TotalEgresos = datos.Lector["TotalEgresos"] != DBNull.Value ? Convert.ToDecimal(datos.Lector["TotalEgresos"]) : 0
                    };
                }

                return new ResumenCaja { Fecha = DateTime.Today };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener resumen diario: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }

}
