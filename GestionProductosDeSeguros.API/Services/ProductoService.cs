using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using GestionProductosDeSeguros.DTOs.ProductoDTOs;

namespace GestionProductosDeSeguros.API.Services
{
    public class ProductoService
    {
        private readonly string _connectionString;

        public ProductoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Cnn");
        }

        public int CrearProducto(CrearProductoDTO crearProductoDTO)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("CrearProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nombre", crearProductoDTO.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", crearProductoDTO.Descripcion);
                        command.Parameters.AddWithValue("@TipoProductoNombre", crearProductoDTO.TipoProductoNombre);
                        command.Parameters.AddWithValue("@FormaPagoNombre", crearProductoDTO.FormaPagoNombre);
                        command.Parameters.AddWithValue("@PrimaAnual", crearProductoDTO.PrimaAnual);
                        command.Parameters.AddWithValue("@SumaAsegurada", crearProductoDTO.SumaAsegurada);

                        // Convertir explícitamente el resultado de ExecuteScalar a int
                        var result = command.ExecuteScalar();
                        return Convert.ToInt32(result); // Conversión explícita de decimal a int
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error en la base de datos: {ex.Message}");
                }

            }
        }

        public List<ObtenerProductosDTO> ObtenerProductos()
        {
            List<ObtenerProductosDTO> productos = new List<ObtenerProductosDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ObtenerProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var producto = new ObtenerProductosDTO
                            {
                                Id = Convert.ToInt32(reader["ProductoId"]),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                TipoProductoNombre = reader["TipoProducto"].ToString(),
                                FormaPagoNombre = reader["FormaPago"].ToString(),
                                PrimaAnual = Convert.ToDecimal(reader["PrimaAnual"]),
                                SumaAsegurada = Convert.ToDecimal(reader["SumaAsegurada"]),
                                PrimaCalculada = Convert.ToDecimal(reader["PrimaCalculada"])
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }

        public List<BuscarProductosDTO> BuscarProductos(string nombreBusqueda)
        {
            List<BuscarProductosDTO> productos = new List<BuscarProductosDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("BuscarProductosPorNombre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreBusqueda", nombreBusqueda);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var producto = new BuscarProductosDTO
                            {
                                Id = Convert.ToInt32(reader["ProductoId"]),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                TipoProductoNombre = reader["TipoProducto"].ToString(),
                                FormaPagoNombre = reader["FormaPago"].ToString(),
                                PrimaAnual = Convert.ToDecimal(reader["PrimaAnual"]),
                                SumaAsegurada = Convert.ToDecimal(reader["SumaAsegurada"]),
                                PrimaCalculada = Convert.ToDecimal(reader["PrimaCalculada"])
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }

        public ActualizaProductoDTO ObtenerProductoPorId(int id)
        {
            ActualizaProductoDTO producto = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ObtenerProductoPorId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductoId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new ActualizaProductoDTO
                            {
                                Id = Convert.ToInt32(reader["ProductoId"]),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                TipoProductoNombre = reader["TipoProducto"].ToString(),
                                FormaPagoNombre = reader["FormaPago"].ToString(),
                                PrimaAnual = Convert.ToDecimal(reader["PrimaAnual"]),
                                SumaAsegurada = Convert.ToDecimal(reader["SumaAsegurada"])
                            };
                        }
                    }
                }
            }
            return producto;
        }

        public void ActualizarProducto(ActualizaProductoDTO actualizarProductoDTO)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("ActualizarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductoId", actualizarProductoDTO.Id);
                        command.Parameters.AddWithValue("@Nombre", actualizarProductoDTO.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", actualizarProductoDTO.Descripcion);
                        command.Parameters.AddWithValue("@TipoProductoNombre", actualizarProductoDTO.TipoProductoNombre);
                        command.Parameters.AddWithValue("@FormaPagoNombre", actualizarProductoDTO.FormaPagoNombre);
                        command.Parameters.AddWithValue("@PrimaAnual", actualizarProductoDTO.PrimaAnual);
                        command.Parameters.AddWithValue("@SumaAsegurada", actualizarProductoDTO.SumaAsegurada);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error en la base de datos: {ex.Message}");
                }
            }
        }

        public void EliminarProducto(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("EliminarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductoId", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error en la base de datos: {ex.Message}");
                }

            }

        }
    }
}
