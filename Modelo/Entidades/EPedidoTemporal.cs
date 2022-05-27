using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class EPedidoTemporal
    {
        public int idpedido_temporal_fast_food { get; set; }
        public int id_pedido_general { get; set; }
        public int idpedidos_fast_food { get; set; }
        public int idusuarios { get; set; }
        public int idmenu_fast_food { get; set; }
        public int cantidad { get; set; }
        public string direccion { get; set; }
        public string estado_del_pedido { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
        public string nombre_usuario { get; set; }
        public string nombre_producto { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public int precio { get; set; }
        public int total_por_producto { get; set; }
    }
}
