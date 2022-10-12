using System;
using System.Collections.Generic;

namespace PruebaTSistemaDePedidos.Models
{
    public partial class TdetallesPorPedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }

        public virtual Tpedido IdPedidoNavigation { get; set; } = null!;
        public virtual Tproducto IdProductoNavigation { get; set; } = null!;
    }
}
