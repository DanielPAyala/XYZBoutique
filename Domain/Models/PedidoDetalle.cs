using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
