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
        [Column(TypeName = "varchar(20)")]
        public string Codigo { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Correo { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Telefono { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Puesto { get; set; }
        public int RolId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
