using System.Collections.Generic;
using GestionProductosDeSeguros.API.Services;
using GestionProductosDeSeguros.DTOs.ProductoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionProductosDeSeguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        public async Task<ActionResult> CrearProducto([FromBody] CrearProductoDTO crearProductoDTO)
        {
            try
            {
                var productoId = Task.Run(() => _productoService.CrearProducto(crearProductoDTO));
                return CreatedAtAction(nameof(ObtenerPorId), new { id = productoId }, productoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<BuscarProductosDTO>> ObtenerProductos()
        {
            var productos = _productoService.ObtenerProductos();
            return Ok(productos);
        }

        [HttpGet("buscar")]
        public ActionResult<List<BuscarProductosDTO>> ObtenerProductosPorNombre(string nombre)
        {
            var productos = _productoService.BuscarProductos(nombre);
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public ActionResult<BuscarProductosDTO> ObtenerPorId(int id)
        {
            var producto = _productoService.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);

        }

        [HttpPut("{id}")]
        public ActionResult ActualizarProducto(int id, [FromBody] ActualizaProductoDTO actualizaProductoDTO)
        {
            if (id != actualizaProductoDTO.Id)
            {
                return BadRequest("El ID en la ruta no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                _productoService.ActualizarProducto(actualizaProductoDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProducto(int id)
        {
            try
            {
                var producto = _productoService.ObtenerProductoPorId(id);
                if (producto == null)
                {
                    return NotFound();
                }
                _productoService.EliminarProducto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
