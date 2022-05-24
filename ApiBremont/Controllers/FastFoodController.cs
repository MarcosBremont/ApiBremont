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
            Models.UsuarioFFA usuarioFFA = new Models.UsuarioFFA();
            var response = usuarioFFA.IniciarSesion(email, password);
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


        [HttpGet("AgregarPedidoTemporal/{idmenu_fast_food}/{idusuarios}/{cantidad}")]
        public ActionResult<Result> AgregarPedidoTemporal(int idmenu_fast_food, int idusuarios, int cantidad)
        {
            Models.PedidoTemporalFFA pedidotemporalFFA = new Models.PedidoTemporalFFA();
            return pedidotemporalFFA.AgregarPedidoTemporal(idmenu_fast_food,  idusuarios,  cantidad);
        }


        [HttpGet("ObtenerPedidos")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPedidos>> ObtenerPedidos()
        {
            Models.PedidosFFA pedidosffa = new Models.PedidosFFA();

            List<Modelo.Entidades.EPedidos> lista_pedidos = pedidosffa.lista_pedidos();

            return lista_pedidos;
        }


        [HttpGet("RegistrarUsuario/{nombre}/{apellido}/{direccion}/{telefono}/{latitud}/{longitud}/{clave}")]
        public ActionResult<Result> RegistrarUsuario(string nombre, string apellido, string direccion, string telefono, string correo, string latitud, string longitud, string clave)
        {
            Models.UsuarioFFA usuarioFFA = new Models.UsuarioFFA();
            return usuarioFFA.RegistrarUsuario(nombre, apellido, direccion, telefono, correo, latitud, longitud, clave);
        }

        [HttpGet("ObtenerCarritoPorUsuario/{idusuarios}/{idpedidos}")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPedidoTemporal>> ObtenerCarritoPorID(int idusuarios, int idpedidos)
        {
            Models.PedidoTemporalFFA pedidotemporalffa = new Models.PedidoTemporalFFA();

            List<Modelo.Entidades.EPedidoTemporal> lista_pedidoTemporal = pedidotemporalffa.lista_pedidotemporal(idusuarios, idpedidos);

            return lista_pedidoTemporal;
        }


        [HttpGet("AgregarPedido/{idusuarios}")]
        public ActionResult<Result> AgregarPedido(int idusuarios)
        {
            Models.PedidosFFA pedidosFFA = new Models.PedidosFFA();
            return pedidosFFA.AgregarPedido(idusuarios);
        }



        [HttpGet("ActualizarPedido/{concuantopagara}/{devuelta}/{latitud}/{longitud}/{estado_del_pedido}/{idusuarios}/{idpedidos_fast_food}")]
        public ActionResult<Result> ActualizarPedido(int concuantopagara, int devuelta, string latitud, string longitud, string estado_del_pedido, int idusuarios, int idpedidos_fast_food)
        {
            Models.PedidosFFA pedidosFFA = new Models.PedidosFFA();
            return pedidosFFA.ActualizarPedido(concuantopagara, devuelta, latitud, longitud, estado_del_pedido, idusuarios, idpedidos_fast_food);
        }
    }
}
