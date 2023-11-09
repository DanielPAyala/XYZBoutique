using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utils;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pedido pedido)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JwtConfigurator.GetIdUsuario(identity!);

                pedido.UsuarioId = id;
                pedido.FechaPedido = DateTime.Now;

                await _pedidoService.CreatePedido(pedido);

                return Ok(new { message = "Pedido creado exitosamente"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetPedidos")]
        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                var listaPedidos = await _pedidoService.GetAll();
                return Ok(listaPedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CambiarEstado")]
        public async Task<IActionResult> CambiarEstadoPedido(Pedido pedido)
        {
            try
            {
                await _pedidoService.CambiarEstado(pedido);
                return Ok(new
                {
                    message = "Estado modificado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
