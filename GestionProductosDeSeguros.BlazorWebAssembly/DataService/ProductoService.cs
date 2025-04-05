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

        public async Task<List<ObtenerProductosDTO>> ObtenerProductos()
        {
            var response = await _httpClient.GetAsync("Producto");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<ObtenerProductosDTO>>();
                return result ?? new List<ObtenerProductosDTO>();
            }
            return new List<ObtenerProductosDTO>();
        }

        public async Task<List<BuscarProductosDTO>> BuscarPorNombre(string nombre)
        {
            var response = await _httpClient.GetAsync($"Producto/buscar");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BuscarProductosDTO>>();
                return result ?? new List<BuscarProductosDTO>();
            }
            return new List<BuscarProductosDTO>();
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

        public async Task<bool> CrearProducto(CrearProductoDTO producto)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto", producto);
            return response.IsSuccessStatusCode;
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
