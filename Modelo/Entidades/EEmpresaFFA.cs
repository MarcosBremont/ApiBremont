using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class EEmpresaFFA
    {
        public int idempresa { get; set; }
        public string nombre { get; set; }
        public string rnc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string whatsapp { get; set; }
        public string correo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string clave { get; set; }
        public string instagram { get; set; }
        public string facebook { get; set; }
        public string encargado_empresa { get; set; }
        public int envio { get; set; }
        public string result { get; set; }
        public string mensaje { get; set; }
        public bool encontrado { get; set; }
        public string logo_empresa { get; set; }
    }
}
