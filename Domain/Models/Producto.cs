using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Etiqueta { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; }
    }
}
