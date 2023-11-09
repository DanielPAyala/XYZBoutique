using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CambiarEstado(Pedido pedido)
        {
            var buscarPedido = await _context.Pedido.Where(x => x.Id == pedido.Id).FirstOrDefaultAsync();
            if (buscarPedido != null)
            {
                var estadoActual = buscarPedido.EstadoId;

                switch (estadoActual)
                {   
                    case 1:
                        if (pedido.EstadoId is not 1)
                        {
                            buscarPedido.EstadoId = pedido.EstadoId;
                            ActualizarFecha(buscarPedido);
                        }
                        break;
                    case 2:
                        if (pedido.EstadoId != 1 && pedido.EstadoId != 2)
                        {
                            buscarPedido.EstadoId = pedido.EstadoId;
                            ActualizarFecha(buscarPedido);
                        }
                        break;
                    case 3:
                        if (pedido.EstadoId != 1 && pedido.EstadoId != 2 && pedido.EstadoId != 3)
                        {
                            buscarPedido.EstadoId = pedido.EstadoId;
                            ActualizarFecha(buscarPedido);
                        }
                        break;
                }

                _context.Update(buscarPedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePedido(Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _context.Pedido.ToListAsync();
        }


        void ActualizarFecha(Pedido pedido)
        {
            switch (pedido.EstadoId)
            {
                case 2:
                    pedido.FechaRecepcion = DateTime.Now;
                    break;
                case 3:
                    pedido.FechaDespacho = DateTime.Now;
                    break;
                case 4:
                    pedido.FechaEntrega = DateTime.Now;
                    break;
            }
        }
    }
}
