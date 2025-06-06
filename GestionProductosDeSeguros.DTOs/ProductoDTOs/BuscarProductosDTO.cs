﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductosDeSeguros.DTOs.ProductoDTOs
{
  public  class BuscarProductosDTO
    {
        public string NombreBusqueda { get; set; }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoProductoNombre { get; set; }
        public string FormaPagoNombre { get; set; }
        public decimal PrimaAnual { get; set; }
        public decimal SumaAsegurada { get; set; }
        public decimal PrimaCalculada { get; set; }
    }
}
