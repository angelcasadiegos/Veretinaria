using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
   public class MascotaRepository
    {
        private readonly SqlConnection _connection;
        public MascotaRepository(ConnectionManager connection) {
            _connection = connection._conexion;
        }

  
        public void Guardar(Mascota Mascota)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into mascotas (Codigo,NombreMascota,IdCliente,TipoMascota,LaRaza,Color,FechaNacimiento) 
                                        values (@Codigo,@NombreMascota,@IdCliente,@TipoMascota,@LaRaza,@Color,@FechaNacimiento)";
                command.Parameters.AddWithValue("@Codigo", Mascota.Codigo);
                command.Parameters.AddWithValue("@NombreMascota", Mascota.NombreMascota);
                command.Parameters.AddWithValue("@IdCliente", Mascota.IdCliente);
                command.Parameters.AddWithValue("@TipoMascota", Mascota.TipoMascota);
                command.Parameters.AddWithValue("@LaRaza", Mascota.laRaza);
                command.Parameters.AddWithValue("@Color", Mascota.Color);
                command.Parameters.AddWithValue("@FechaNacimiento", Mascota.FechaNacimiento);
            
                var filas = command.ExecuteNonQuery();
            }

        }

             public void Eliminar(Mascota Mascota)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from mascotas where Codigo=@Codigo";
                command.Parameters.AddWithValue("@Codigo",Mascota.Codigo );
                command.ExecuteNonQuery();
            }
        }


        public Mascota Buscar(string codigo)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from mascotas where Codigo=@Codigo";
                command.Parameters.AddWithValue("@Codigo", codigo);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return Mapear(dataReader);
            }
        }

        private Mascota Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
           Mascota mascota = new Mascota();
            mascota.Codigo = (string)dataReader["Codigo"];
            mascota.NombreMascota = (string)dataReader["NombreMascota"];
            mascota.IdCliente = (string)dataReader["IdCliente"];
            mascota.TipoMascota= (string)dataReader["TipoMascota"];
            mascota.laRaza = (string)dataReader["LaRaza"];
            mascota.Color = (string)dataReader["Color"];
            mascota.FechaNacimiento= (DateTime)dataReader["FechaNacimiento"];
           
          
            return mascota;
        }



        public IList<Mascota> ConsultarMascotas()
        {
            SqlDataReader dataReader;
            List<Mascota> mascotas = new List<Mascota>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from mascotas";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Mascota mascota = Mapear(dataReader);
                        mascotas.Add(mascota);
                    }
                }
            }
            return mascotas;
        }


        public void Modificar(Mascota Mascota)

        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update mascotas set  nombremascota=@NombreMascota, laraza=@LaRaza, color=@Color,fechanacimiento=@FechaNacimiento,idcliente=@IdCliente,tipomascota=@TipoMascota where codigo=@Codigo";
                command.Parameters.AddWithValue("@Codigo", Mascota.Codigo);
                command.Parameters.AddWithValue("@NombreMascota", Mascota.NombreMascota);
                command.Parameters.AddWithValue("@IdCliente", Mascota.IdCliente);
                command.Parameters.AddWithValue("@TipoMascota", Mascota.TipoMascota);
                command.Parameters.AddWithValue("@LaRaza", Mascota.laRaza);
                command.Parameters.AddWithValue("@Color", Mascota.Color);
                command.Parameters.AddWithValue("@FechaNacimiento", Mascota.FechaNacimiento);
                var filas = command.ExecuteNonQuery();
            }
        }
    }


    }

