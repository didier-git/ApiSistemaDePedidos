using Microsoft.AspNetCore.Mvc;
using PruebaTSistemaDePedidos.Dtos;
using PruebaTSistemaDePedidos.Models;

namespace PruebaTSistemaDePedidos.Interfaces
{
    public interface I_RepositorioProducto
    {
        Task<ProductoDto?> GetProducto(int Id);
        Task<List<ProductoDto>?> GetProductoList();
        Task<ProductoDto?> CreateProducto(ProductoDto Producto);
    }
}
