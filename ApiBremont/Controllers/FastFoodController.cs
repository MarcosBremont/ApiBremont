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
    public class FastFoodController : ControlBase
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


        [HttpGet("AgregarPedidoTemporal/{idmenu_fast_food}/{idusuarios}/{cantidad}/{descripcion}")]
        public ActionResult<Result> AgregarPedidoTemporal(int idmenu_fast_food, int idusuarios, int cantidad, string descripcion)
        {
            Models.PedidoTemporalFFA pedidotemporalFFA = new Models.PedidoTemporalFFA();
            return pedidotemporalFFA.AgregarPedidoTemporal(idmenu_fast_food, idusuarios, cantidad, descripcion);
        }


        [HttpGet("ObtenerPedidos/{estado_del_pedido}/{idusuarios}")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPedidos>> ObtenerPedidos(string estado_del_pedido, int idusuarios)
        {
            Models.PedidosFFA pedidosffa = new Models.PedidosFFA();

            List<Modelo.Entidades.EPedidos> lista_pedidos = pedidosffa.lista_pedidos(estado_del_pedido, idusuarios);

            return lista_pedidos;
        }


        [HttpGet("RegistrarUsuario/{nombre}/{apellido}/{direccion}/{telefono}/{latitud}/{longitud}/{clave}")]
        public ActionResult<Result> RegistrarUsuario(string nombre, string apellido, string direccion, string telefono, string correo, string latitud, string longitud, string clave)
        {
            Models.UsuarioFFA usuarioFFA = new Models.UsuarioFFA();
            return usuarioFFA.RegistrarUsuario(nombre, apellido, direccion, telefono, correo, latitud, longitud, clave);
        }

        [HttpGet("ObtenerCarritoPorUsuario/{idpedidos}/{idusuarios}/{estado}")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPedidoTemporal>> ObtenerCarritoPorID(int idpedidos, int idusuarios, string estado)
        {
            Models.PedidoTemporalFFA pedidotemporalffa = new Models.PedidoTemporalFFA();

            List<Modelo.Entidades.EPedidoTemporal> lista_pedidoTemporal = pedidotemporalffa.lista_pedidotemporal(idpedidos, idusuarios, estado);

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


        [HttpGet("SNumeroDeOrdenGeneral/{idusuarios}/{estado}")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPedidos>> ObtenerCarritoPorID(int idusuarios, string estado)
        {
            Models.PedidosFFA pedidoffa = new Models.PedidosFFA();

            List<Modelo.Entidades.EPedidos> lista_pedido = pedidoffa.lista_numerodeorden(idusuarios, estado);

            return lista_pedido;
        }

        [HttpGet("ActualizarUsuario/{nombre}/{apellido}/{direccion}/{telefono}/{correo}/{clave}/{idusuarios}")]
        public ActionResult<Result> ActualizarUsuario(string nombre, string apellido, string direccion, string telefono, string correo, string clave, int idusuarios)
        {
            Models.UsuarioFFA usuarioFFA = new Models.UsuarioFFA();
            return usuarioFFA.ActualizarUsuario(nombre, apellido, direccion, telefono, correo, clave, idusuarios);
        }

        [HttpGet("AgregarProductoAlMenu/{nombre}/{precio}/{disponible}/{foto}/{descripcion}")]
        public ActionResult<Result> AgregarProductoAlMenu(string nombre, int precio, string disponible, string foto, string descripcion)
        {
            Models.Menu menu = new Models.Menu();
            return menu.AgregarProductoAlMenu(nombre, precio, disponible, foto, descripcion); 
        }

        [HttpPost("GrabarImagen")]
        async public Task<ActionResult> GrabarImagen([FromBody] EMenu menu)
        {
            var nombreFoto = await GrabarFoto(menu.foto);

            if (nombreFoto == "ERROR")
            {
                menu = new EMenu();
                menu.result = "ERROR";
            }
            else
            {
                // grabar el nombre de la imagen en cliente
                menu = new Menu().GrabarUrlFotoPerfil(menu.idmenu_fast_food, "http://apibremont.tecnolora.com/images/" + nombreFoto);
            }

            return new JsonResult(menu);
        }



    }
}
