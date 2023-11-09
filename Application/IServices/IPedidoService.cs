using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPedidoService
    {
        Task CreatePedido(Pedido pedido);
        Task<List<Pedido>> GetAll();
        Task CambiarEstado(Pedido pedido);
    }
}
