namespace PruebaTSistemaDePedidos.Dtos
{
    public class DetallePedidoDto
    { 
        public int? Id { get; set; } 
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
