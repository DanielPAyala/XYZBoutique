using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Codigo { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Correo { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        [Required]
        public int RolId { get; set; }

        public Rol Rol { get; set; }
    }
}
