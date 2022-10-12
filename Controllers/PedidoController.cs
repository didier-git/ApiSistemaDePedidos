using Microsoft.AspNetCore.Mvc;
using PruebaTSistemaDePedidos.Dtos;
using PruebaTSistemaDePedidos.Interfaces;
using System.ComponentModel;

namespace PruebaTSistemaDePedidos.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class PedidoController : ControllerBase
    {
        readonly I_RepositorioPedido _repositorio;

        public PedidoController(I_RepositorioPedido repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost("CreatePedido")]

        public async Task<PedidoDto> CreatePedido(PedidoDto PedidoToAdd)
        {
            var pedido = await _repositorio.CreatePedido(PedidoToAdd);

            return pedido;
        }


        [HttpGet("GetPedido")]
        public async Task<PedidoDto> GetPedido( int IdPedido)
        {
            return await _repositorio.GetPedido(IdPedido);
        }

        [HttpGet("GetListaPedidos")]
        public async Task<List<PedidoDto>> GetListaPedidos()
        {
            var listaDePedidos = await _repositorio.GetListaPedidos();
            return listaDePedidos;
        }
    }
}
