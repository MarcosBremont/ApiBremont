using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Entidades
{
    public class EProductos : EBase
    {
        [Key]
        [Required(ErrorMessage = "Campo Requerido")]
        public int Cod { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Cantidad { get; set; } = string.Empty;
        public int CantidadProductosEnLaCompra { get; set; }
        public int PrecioDelEnvioEnLaCompra { get; set; }
        public int PrecioSinGanancias { get; set; }
        public int Ganancia { get; set; }
        public string Foto { get; set; } = string.Empty;


    }

}