using System;
using System.Collections.Generic;

namespace PruebaTSistemaDePedidos.Models
{
    public partial class Tpedido
    {
        public Tpedido()
        {
            TdetallesPorPedidos = new HashSet<TdetallesPorPedido>();
        }

        public int IdPedido { get; set; }
        public string IdentificacionCliente { get; set; } = null!;
        public string NombreCliente { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<TdetallesPorPedido> TdetallesPorPedidos { get; set; }
    }
}
