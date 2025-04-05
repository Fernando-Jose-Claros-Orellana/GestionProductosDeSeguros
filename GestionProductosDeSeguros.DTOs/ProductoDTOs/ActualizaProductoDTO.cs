using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductosDeSeguros.DTOs.ProductoDTOs
{
   public class ActualizaProductoDTO
    {
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "El Nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoProductoNombre { get; set; }
        public string FormaPagoNombre { get; set; }
        [DataType(DataType.Currency)]
        [Range(0.01, 300, ErrorMessage = "La Prima Anual debe ser mayor a 0 y no puede exceder 300.")]
        public decimal PrimaAnual { get; set; }

        [Required(ErrorMessage = "La Suma Asegurada es obligatoria.")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "9999999999", ErrorMessage = "La suma asegurada debe ser mayor a la prima anual.")]
        public decimal SumaAsegurada { get; set; }

        // Validación personalizada
        public bool IsSumaAseguradaValida()
        {
            return SumaAsegurada > PrimaAnual;
        }

    }
}