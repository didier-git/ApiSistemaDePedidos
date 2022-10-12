namespace PruebaTSistemaDePedidos.Dtos
{
    public class PedidoDto
    {
        public int? Id { get; set; } 
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public List<ProductoDto>? detalle { get; set; }
    }
}
