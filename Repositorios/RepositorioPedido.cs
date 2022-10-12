using Microsoft.EntityFrameworkCore;
using PruebaTSistemaDePedidos.Context;
using PruebaTSistemaDePedidos.Dtos;
using PruebaTSistemaDePedidos.Interfaces;
using PruebaTSistemaDePedidos.Models;

namespace PruebaTSistemaDePedidos.Repositorios
{
    public class RepositorioPedido : I_RepositorioPedido
    {
        readonly DatabaseContext _dataBaseContext;

        public RepositorioPedido(DatabaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<PedidoDto> CreatePedido(PedidoDto pedido)
        {
            Tpedido NewPedido = new()
            { 
                IdentificacionCliente = pedido.Identificacion,
                NombreCliente = pedido.Nombre,
                Direccion= pedido.Direccion,
                Telefono= pedido.Telefono
            };
            var NPedidos = await _dataBaseContext.Tpedidos.CountAsync();

            NewPedido.IdPedido = NPedidos + 1;

            foreach(var detalle in pedido.detalle)
            {
                TdetallesPorPedido detalles = new();
                detalles.IdPedidoNavigation= NewPedido;
                detalles.IdProductoNavigation = await _dataBaseContext.Tproductos.FindAsync(detalle.Id);
                detalles.Cantidad = detalle.Cantidad;


                await _dataBaseContext.TdetallesPorPedidos.AddAsync(detalles);
               
            };


            await _dataBaseContext.Tpedidos.AddAsync(NewPedido);
            
            await _dataBaseContext.SaveChangesAsync();
                
            return pedido;

        }

        public async Task<List<PedidoDto>> GetListaPedidos()
        {
            
            //var pedidos = await _dataBaseContext.Tpedidos.ToListAsync();
            var pedidos = await _dataBaseContext.Tpedidos.Include(pedido => pedido.TdetallesPorPedidos).ToListAsync();
            
            List<ProductoDto> ProductosToSend = new List<ProductoDto>();
            List<PedidoDto> PedidosToSend = new List<PedidoDto>();
           
            foreach ( var pedido in pedidos)
            {
                PedidoDto pedidoToSend = new PedidoDto();
                pedidoToSend.Id = pedido.IdPedido;
                pedidoToSend.Identificacion = pedido.IdentificacionCliente;
                pedidoToSend.Nombre = pedido.NombreCliente;
                pedidoToSend.Direccion = pedido.Direccion;
                pedidoToSend.Telefono = pedido.Telefono;

                pedidoToSend.detalle = new List<ProductoDto>();

                foreach(var detalle in pedido.TdetallesPorPedidos)
                {
                    pedidoToSend.detalle.Add(new()
                    {
                        Id = detalle.IdProducto,
                        Cantidad = detalle.Cantidad    
                    });


                };

                PedidosToSend.Add(pedidoToSend);




            }


                return PedidosToSend;
        }

        public async Task<PedidoDto> GetPedido(int IdPedido)
        {

            var pedido = await _dataBaseContext.Tpedidos.FirstOrDefaultAsync(p => p.IdPedido == IdPedido);
            var Detalles = await _dataBaseContext.TdetallesPorPedidos.Where(d => d.IdPedido == IdPedido).ToListAsync();
            PedidoDto pedidoDto = new()
            {
                Id = pedido.IdPedido,
                Identificacion = pedido.IdentificacionCliente,
                Nombre = pedido.NombreCliente,
                Direccion = pedido.Direccion,
                Telefono = pedido.Telefono,
            };
            
            pedidoDto.detalle = new List<ProductoDto>();

            foreach (var item in Detalles)
            {
                pedidoDto.detalle.Add(new()
                {
                    Id = item.IdProducto,
                    Cantidad = item.Cantidad
                });
            }
            return pedidoDto ;


        }
    }
}
