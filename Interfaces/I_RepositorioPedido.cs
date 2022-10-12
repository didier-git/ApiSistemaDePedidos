using PruebaTSistemaDePedidos.Dtos;

namespace PruebaTSistemaDePedidos.Interfaces
{
    public interface I_RepositorioPedido
    {
        Task<PedidoDto> CreatePedido(PedidoDto pedido);

        Task<List<PedidoDto>> GetListaPedidos();

        Task<PedidoDto> GetPedido(int IdPedido);
    }
}
