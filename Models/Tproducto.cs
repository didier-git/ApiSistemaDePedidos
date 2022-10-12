using System;
using System.Collections.Generic;

namespace PruebaTSistemaDePedidos.Models
{
    public partial class Tproducto
    {
        public Tproducto()
        {
            TdetallesPorPedidos = new HashSet<TdetallesPorPedido>();
        }

        public int IdProducto { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }

        public virtual ICollection<TdetallesPorPedido> TdetallesPorPedidos { get; set; }
    }
}
