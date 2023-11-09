using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaDespacho { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int VendedorId { get; set; }
        public int RepartidorId { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Estado Estado { get; set; }
        public List<PedidoDetalle> ListPedidoDetalle { get; set; }

    }
}
