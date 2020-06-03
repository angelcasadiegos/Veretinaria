using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class MascotaService
    {
        private readonly ConnectionManager conexion;
        private readonly MascotaRepository mascotarepositorio;

        public MascotaService(string connectionString)
        { 
            conexion = new ConnectionManager(connectionString);
            mascotarepositorio = new MascotaRepository(conexion);
        }

        public string Guardar(Mascota mascota)
        {
            try
            {
                 conexion.Open();
                 mascotarepositorio.Guardar(mascota);
                 conexion.Close();
                return $"Se guardaron los datos de la mascota satisfactoriamente";
            }
            catch (Exception e)
            {
                return $"Cliente No Existe En Base De Datos: {e.Message}";
            }
            finally { conexion.Close(); }
        }


        public string Eliminar(string codigo)
        {
            try
            {
                conexion.Open();
                var mascota = mascotarepositorio.Buscar(codigo);
                if (mascota!= null)
                {
                   mascotarepositorio.Eliminar(mascota);
                    conexion.Close();
                    return ($"El cliente {mascota.NombreMascota} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {codigo} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public ResponseMascotaBusqueda Buscar(string codigo)
        {
            ResponseMascotaBusqueda respuesta = new ResponseMascotaBusqueda();
            
            try
            {
                conexion.Open();
                respuesta.mascota= mascotarepositorio.Buscar(codigo);
                conexion.Close();
                respuesta.Mensaje = (respuesta.mascota!= null) ? "Se encontró la mascota solicitada" : "la mascota buscada no existe";
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




        public ResponseConsultaMascota Consultar()
        {
            ResponseConsultaMascota respuesta = new ResponseConsultaMascota();
            try
            {

                conexion.Open();
                respuesta.mascotas= mascotarepositorio.ConsultarMascotas();
                conexion.Close();
                if (respuesta.mascotas.Count > 0)
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



        public string Modificar(Mascota mascotaNueva)
        {
            try
            {
                conexion.Open();
                var mascotaantigua = mascotarepositorio.Buscar(mascotaNueva.Codigo);
                if (mascotaantigua != null)
                {
                   mascotarepositorio.Modificar(mascotaNueva);
                    conexion.Close();
                    return ($"El registro {mascotaNueva.NombreMascota} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {mascotaNueva.Codigo} no se encuentra registrada.");
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
