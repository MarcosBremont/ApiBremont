using ApiBremont.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastFoodController : ControllerBase
    {
        private string ContentRoot { get; set; }
        public FastFoodController(IConfiguration configuration)
        {
            this.ContentRoot = configuration.GetValue<string>(WebHostDefaults.ContentRootKey).ToString();
        }

        [HttpGet("IniciarSesion/{email}/{password}")]
        public ActionResult<EUsuarioFFA> IniciarSesion(string email, string password)
        {
            Models.Tecnico tecnico = new Models.Tecnico();
            var response = tecnico.IniciarSesion(usuario, clave, token_firebase);

            if (response.respuesta == "OK")
            {
                sesion.Nueva(0, response.token, response.codigo);
            }

            return response;
        }


        [HttpGet("ObtenerMenu")]
        public ActionResult<IEnumerable<Modelo.Entidades.EMenu>> ObtenerMenu()
        {
            Models.Menu menu = new Models.Menu();

            List<Modelo.Entidades.EMenu> lista_menu = menu.lista_menu();

            return lista_menu;
        }



        [HttpGet("ObtenerEmpresa")]
        public ActionResult<IEnumerable<Modelo.Entidades.EEmpresaFFA>> ObtenerEmpresa()
        {
            Models.EmpresaFFA empresa = new Models.EmpresaFFA();

            List<Modelo.Entidades.EEmpresaFFA> lista_empresa = empresa.lista_empresa();

            return lista_empresa;
        }


        [HttpGet("AgregarPedido/{usuario}/{email}/{telefono}/{concuantopagara}/{devuelta}/{direccion}/{producto}/{latitud}/{longitud}")]
        public ActionResult<Result> AgregarPedido(string usuario, string email, string telefono, int concuantopagara, int devuelta, string direccion, string producto, string latitud, string longitud)
        {
            Models.PedidosFFA pedidosFFA = new Models.PedidosFFA();
            return pedidosFFA.AgregarPedido(usuario, email, telefono, concuantopagara, devuelta, direccion, producto, latitud, longitud);
        }



    }
}
