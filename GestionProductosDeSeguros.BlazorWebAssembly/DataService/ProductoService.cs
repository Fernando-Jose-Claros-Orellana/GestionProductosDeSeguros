using GestionProductosDeSeguros.DTOs.ProductoDTOs;
using System.Net.Http.Json;

namespace GestionProductosDeSeguros.BlazorWebAssembly.DataService
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;
        public ProductoService(IHttpClientFactory httpCli)
        {
            _httpClient = httpCli.CreateClient("API");
        }

        public async Task<List<BuscarProductosDTO>> ObtenerProductos()
        {
            var response = await _httpClient.GetAsync("Producto");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BuscarProductosDTO>>();
                return result ?? new List<BuscarProductosDTO>();
            }
            return new List<BuscarProductosDTO>();
        }

        public async Task<List<BuscarProductosDTO>> BuscarPorNombre(string nombre = null)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return await ObtenerProductos();
            }
            else
            {
                var response = await _httpClient.GetAsync($"Producto/buscar?nombre={Uri.EscapeDataString(nombre)}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<BuscarProductosDTO>>();
                    return result ?? new List<BuscarProductosDTO>();
                }
                return new List<BuscarProductosDTO>();
            }
        }

        public async Task<ActualizaProductoDTO> ObtenerProductoId(int id)
        {
            var response = await _httpClient.GetAsync($"Producto/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ActualizaProductoDTO>();
                return result ?? new ActualizaProductoDTO();
            }
            return new ActualizaProductoDTO();
        }

        public async Task<string> CrearProducto(CrearProductoDTO producto)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto", producto);
            if (response.IsSuccessStatusCode)
            {
                return null; // Indica éxito
            }

            // Retorna el mensaje de error
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> ActualizarProducto(ActualizaProductoDTO producto)
        {
            var response = await _httpClient.PutAsJsonAsync($"Producto/{producto.Id}", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarProducto(int id)
        {
            var response = await _httpClient.DeleteAsync($"Producto/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
