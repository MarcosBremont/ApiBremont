using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class EPedidoTemporal
    {
        public int idpedido_temporal_fast_food { get; set; }
        public int id_pedido_general { get; set; }
        public int idusuarios { get; set; }
        public int idmenu_fast_food { get; set; }
        public int cantidad { get; set; }
    }
}
