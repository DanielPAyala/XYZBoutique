using Application.IServices;
using Domain.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task CambiarEstado(Pedido pedido)
        {
            await _pedidoRepository.CambiarEstado(pedido);
        }

        public async Task CreatePedido(Pedido pedido)
        {
            await _pedidoRepository.CreatePedido(pedido);
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _pedidoRepository.GetAll();
        }
    }
}
