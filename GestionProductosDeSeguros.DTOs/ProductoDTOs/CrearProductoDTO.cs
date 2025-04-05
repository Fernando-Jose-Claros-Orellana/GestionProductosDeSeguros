using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionProductosDeSeguros.DTOs.ProductoDTOs
{
   public class CrearProductoDTO
    {
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El Nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Tipo de Producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El Tipo de Producto no puede exceder los 100 caracteres.")]
        public string TipoProductoNombre { get; set; }

        [Required(ErrorMessage = "La Forma de Pago es obligatoria.")]
        [StringLength(50, ErrorMessage = "La Forma de Pago no puede exceder los 50 caracteres.")]
        public string FormaPagoNombre { get; set; }

        [Required(ErrorMessage = "La Prima Anual es obligatoria.")]
        [DataType(DataType.Currency)]
        public decimal PrimaAnual { get; set; }

        [Required(ErrorMessage = "La Suma Asegurada es obligatoria.")]
        [DataType(DataType.Currency)]
        public decimal SumaAsegurada { get; set; }
    }
}
