namespace PruebaTSistemaDePedidos.Dtos
{
    public class ProductoDto
    {
        public int? Id { get; set; }    
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public int Precio { get; set; }

        public int? Cantidad { get; set; }
    }
}
