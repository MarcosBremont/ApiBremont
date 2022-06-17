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

        [HttpPost("GrabarImagenEmpesa")]
        async public Task<ActionResult> GrabarImagenEmpresa([FromBody] EEmpresaFFA eempresa)
        {
            var nombreFoto = await GrabarFoto(eempresa.logo_empresa);

            if (nombreFoto == "ERROR")
            {
                eempresa.result = nombreFoto;
            }
            else
            {
                // grabar el nombre de la imagen en cliente
                eempresa = new EmpresaFFA().GrabarUrlFotoPerfil(eempresa.idempresa, "http://apibremont.tecnolora.com/images/" + nombreFoto);
            }

            return new JsonResult(eempresa);
        }


        [HttpPost("ResetearClave")]
        public ActionResult<Result> ResetearClave([FromBody] EUsuarioFFA datos)
        {
            try
            {

                UsuarioFFA Usuario = new UsuarioFFA();
                // validar si el correo está registrado

                var nuevaClave = Guid.NewGuid().ToString().Substring(0, 6);
                new Correo().EnviarResetearClave(datos.correo, nuevaClave);

                return Usuario.ActualizarClave(datos.correo, nuevaClave);
                // enviar correo de válidación

            }
            catch (Exception ex)
            {
                //WriteExeption(ex);
                return new JsonResult(new EBase() { HayError = true, Mensaje = "No se pudo realizar la operación solicitada, intentelo mas tarde." });
            }

        }

        [HttpGet("EnviarNotificacion/{mensaje}/{disponibilidad}")]
        public ActionResult<Result> EnviarNotificaciones(string mensaje, string disponibilidad)
        {
            Models.EmpresaFFA empresa = new Models.EmpresaFFA();
            return empresa.EnviarNotificacion(mensaje, disponibilidad);
        }

        [HttpGet("ActualizarNotificacion/{idnotificaciones_empresa}/{disponibilidad}")]
        public ActionResult<Result> ActualizarNotificacion(int idnotificaciones_empresa, string disponibilidad)
        {
            Models.EmpresaFFA empresa = new Models.EmpresaFFA();
            return empresa.ActualizarNotificacion(idnotificaciones_empresa, disponibilidad);
        }


        [HttpGet("SNotificacionesFFA/{idnotificaciones_empresa}/{disponibilidad}")]
        public ActionResult<IEnumerable<Modelo.Entidades.ENotificaciones_empresa>> ObtenerNotificaciones(int idnotificaciones_empresa, string disponibilidad)
        {
            Models.EmpresaFFA empresaffa = new Models.EmpresaFFA();

            List<Modelo.Entidades.ENotificaciones_empresa> lista_notificaciones = empresaffa.lista_notificaciones(idnotificaciones_empresa, disponibilidad);

            return lista_notificaciones;
        }

        [HttpGet("UProgresoPedido/{idpedidos_fast_food}/{estado_del_pedido}")]
        public ActionResult<Result> ActualizarPedido(int idpedidos_fast_food, string estado_del_pedido)
        {
            Models.PedidosFFA pedidosFFA = new Models.PedidosFFA();
            return pedidosFFA.ActualizarProgresoPedido(idpedidos_fast_food, estado_del_pedido);
        }

        [HttpGet("ActualizarEmpresa/{nombreEmpresa}/{DireccionEmpresa}/{TelefonoEmpresa}/{WhatsappEmpresa}/{CorreoEmpresa}/{PrecioEnvio}/{ClaveEMpresa}/{idempresa}")]
        public ActionResult<Result> ActualizarEmpresa(string nombreEmpresa, string DireccionEmpresa, string TelefonoEmpresa, string WhatsappEmpresa, string CorreoEmpresa, string PrecioEnvio, string ClaveEMpresa, int idempresa)
        {
            Models.EmpresaFFA empresaFFA = new Models.EmpresaFFA();
            return empresaFFA.ActualizarEmpresa(nombreEmpresa, DireccionEmpresa, TelefonoEmpresa, WhatsappEmpresa, CorreoEmpresa, PrecioEnvio, ClaveEMpresa, idempresa);
        }

    }
}
