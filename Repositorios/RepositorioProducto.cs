using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PruebaTSistemaDePedidos.Context;
using PruebaTSistemaDePedidos.Dtos;
using PruebaTSistemaDePedidos.Interfaces;
using PruebaTSistemaDePedidos.Models;

namespace PruebaTSistemaDePedidos.Repositorios
{
    public class RepositorioProducto : I_RepositorioProducto
    {
        private readonly DatabaseContext _dataBaseContext;

        public RepositorioProducto(DatabaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ProductoDto?> CreateProducto(ProductoDto Producto)
        {
            Tproducto NewProducto = new()
            {
                Codigo = Producto.Codigo,
                Nombre = Producto.Nombre,
                Precio = Producto.Precio

            };

            await _dataBaseContext.AddAsync(NewProducto);
            await _dataBaseContext.SaveChangesAsync();


            return Producto;
        }

        public async Task<ProductoDto?> GetProducto(int Id)
        {
            var producto = await _dataBaseContext.Tproductos.FirstOrDefaultAsync(p => p.IdProducto == Id);

            if (producto != null)
            {
                ProductoDto productoDto = new()
                {
                    Id= producto.IdProducto,
                    Codigo = producto.Codigo,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio
                };

                return productoDto;

            }

            return null;

        }

        public async Task<List<ProductoDto>?> GetProductoList()
        {
            List<Tproducto> listaDeProductos = await _dataBaseContext.Tproductos.ToListAsync();

            List<ProductoDto> lista = new List<ProductoDto>();

            foreach (var producto in listaDeProductos)
            {
                lista.Add(new ProductoDto()
                {
                    Id = producto.IdProducto,
                    Codigo = producto.Codigo,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio
                });
            }

            return lista;


        }
    }
}
