using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class EMenu
    {
        public int idmenu_fast_food { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string disponible { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
    }
}
