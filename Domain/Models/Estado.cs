using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Estado
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public int Descripcion { get; set; }
    }
}
