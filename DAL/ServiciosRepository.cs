using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class ServiciosRepository
    {
        private readonly SqlConnection _connection;
        public ServiciosRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }


        public void Guardar(Servicio Servicio)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Servicios (CodigoServicio,NombreServicio,PrecioServicio) 
                                        values (@CodigoServicio,@NombreServicio,@PrecioServicio)";
                command.Parameters.AddWithValue("@CodigoServicio", Servicio.CodigodeServicio);
                command.Parameters.AddWithValue("@NombreServicio", Servicio.NombreServicio);
                command.Parameters.AddWithValue("@PrecioServicio", Servicio.PrecioServicio);

                var filas = command.ExecuteNonQuery();
            }

        }

        public void Eliminar(Servicio Servicio)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Servicios where CodigoServicio=@CodigoServicio";
                command.Parameters.AddWithValue("@CodigoServicio", Servicio.CodigodeServicio);
                command.ExecuteNonQuery();
            }
        }


        public Servicio Buscar(string codigoServicio)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Servicios where CodigoServicio=@CodigoServicio";
                command.Parameters.AddWithValue("@CodigoServicio", codigoServicio);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return Mapear(dataReader);
            }
        }

        private Servicio Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Servicio servicio = new Servicio();
            servicio.CodigodeServicio = (string)dataReader["CodigoServicio"];
            servicio.NombreServicio = (string)dataReader["NombreServicio"];
            servicio.PrecioServicio = (decimal)dataReader["PrecioServicio"];


            return servicio;
        }



        public IList<Servicio> ConsultarServicios()
        {
            SqlDataReader dataReader;
            List<Servicio> servicios = new List<Servicio>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Servicios";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Servicio servicio = Mapear(dataReader);
                        servicios.Add(servicio);
                    }
                }
            }
            return servicios;
        }


        public void Modificar(Servicio Servicio)

        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Servicios set  nombreServicio=@NombreServicio, precioServicio=@PrecioServicio where codigoServicio=@CodigoServicio";
                command.Parameters.AddWithValue("@CodigoServicio", Servicio.CodigodeServicio);
                command.Parameters.AddWithValue("@NombreServicio", Servicio.NombreServicio);
                command.Parameters.AddWithValue("@PrecioServicio", Servicio.PrecioServicio);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}
