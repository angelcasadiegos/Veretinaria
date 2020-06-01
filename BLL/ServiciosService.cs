using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class ServiciosService
    {
        private readonly ConnectionManager conexion;
        private readonly ServiciosRepository serviciorepositorio;

        public ServiciosService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            serviciorepositorio = new ServiciosRepository(conexion);
        }

        public string Guardar(Servicio servicio)
        {
            try
            {
                conexion.Open();
                serviciorepositorio.Guardar(servicio);
                conexion.Close();
                return $"Se guardaron los datos del servicio satisfactoriamente";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }
        }


        public string Eliminar(string codigoServicio)
        {
            try
            {
                conexion.Open();
                var servicio = serviciorepositorio.Buscar(codigoServicio);
                if (servicio != null)
                {
                    serviciorepositorio.Eliminar(servicio);
                    conexion.Close();
                    return ($"El Servicio {servicio.NombreServicio} con codigo {servicio.CodigodeServicio} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, el servicio {codigoServicio} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public ResponseBusquedaServicio Buscar(string codigoServicio)
        {
            ResponseBusquedaServicio respuesta = new ResponseBusquedaServicio();

            try
            {
                conexion.Open();
                respuesta.servicio = serviciorepositorio.Buscar(codigoServicio);
                conexion.Close();
                respuesta.Mensaje = (respuesta.servicio != null) ? "Se encontró el servicio solicitado" : "el servicio solicitado no existe";
                respuesta.Error = false;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }
        }




        public RespuestaConsultaServicio Consultar()
        {
            RespuestaConsultaServicio respuesta = new RespuestaConsultaServicio();
            try
            {

                conexion.Open();
                respuesta.servicios = serviciorepositorio.ConsultarServicios();
                conexion.Close();
                if (respuesta.servicios.Count > 0)
                {
                    respuesta.Mensaje = "Se consultan los Datos";
                }
                else
                {
                    respuesta.Mensaje = "No hay datos para consultar";
                }
                respuesta.Error = false;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }

        }



        public string Modificar(Servicio servicioNuevo)
        {
            try
            {
                conexion.Open();
                var servicioantiguo = serviciorepositorio.Buscar(servicioNuevo.CodigodeServicio);
                if (servicioantiguo != null)
                {
                    serviciorepositorio.Modificar(servicioNuevo);
                    conexion.Close();
                    return ($"El registro {servicioNuevo.NombreServicio} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {servicioNuevo.CodigodeServicio} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }


    }
}
