using Microsoft.AspNetCore.Mvc;
using PruebaTSistemaDePedidos.Dtos;
using PruebaTSistemaDePedidos.Interfaces;

namespace PruebaTSistemaDePedidos.Controllers
{

    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductoController : ControllerBase
    {
        public readonly I_RepositorioProducto _repositorio;
        public ProductoController(I_RepositorioProducto repositorio)
        {
            _repositorio = repositorio;

        }

        [HttpPost("CreateProducto")]
        public async Task<ProductoDto?> CrearProducto(ProductoDto producto)
        {
            return await _repositorio.CreateProducto(producto);
        }

        [HttpGet("GetListaDeProductos")]
        public async Task<List<ProductoDto>?> GetlistaDeProducto()
        {
            return await _repositorio.GetProductoList();
        }

        [HttpGet("GetProducto")]
        public async Task<ProductoDto?> GetProducto(int id)
        {
            var producto = await _repositorio.GetProducto(id);

            return producto;

        }
    }
}
