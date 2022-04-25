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
    public class ProductosController : ControllerBase
    {
        private string ContentRoot { get; set; }
        public ProductosController(IConfiguration configuration)
        {
            this.ContentRoot = configuration.GetValue<string>(WebHostDefaults.ContentRootKey).ToString();
        }

        [HttpGet("ConsultarListaDeProductos/{cod}")]
        public ActionResult<IEnumerable<Modelo.Entidades.EProductos>> ConsultarListadoDeProductosPorID(int cod)
        {
            Models.Producto producto = new Models.Producto();

            List<Modelo.Entidades.EProductos> lista_de_productos = producto.Lista_de_productos_Por_ID(cod);

            return lista_de_productos;
        }

        [HttpGet("ConsultarListaDeProductos/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EProductos>> ConsultarListadoDeProductos()
        {
            Models.Producto producto = new Models.Producto();

            List<Modelo.Entidades.EProductos> lista_de_productos = producto.Lista_de_productos();

            return lista_de_productos;
        }

        [HttpGet("ConsultarListaDeGanancias/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EProductos>> ConsultarListaDeGanancias()
        {
            Models.Producto producto = new Models.Producto();

            List<Modelo.Entidades.EProductos> lista_de_ganancias = producto.Lista_de_ganancias();

            return lista_de_ganancias;
        }

        //[HttpGet("SentenciaProductos")]
        [HttpGet("SentenciaProductos/{Nombre}/{Precio}/{Cantidad}/{CantidadProductosEnLaCompra}/{PrecioDelEnvioEnLaCompra}/{PrecioSinGanancias}")]
        public ActionResult<Result> SetHistorialProgresoOrden(string Nombre, int Precio, int Cantidad, int CantidadProductosEnLaCompra, int PrecioDelEnvioEnLaCompra, int PrecioSinGanancias)
        {
            Models.Producto producto = new Models.Producto();
            return producto.Sentencia(Nombre, Precio, Cantidad, CantidadProductosEnLaCompra, PrecioDelEnvioEnLaCompra, PrecioSinGanancias);
        }


        [HttpGet("DProducto/{Cod}/")]
        public ActionResult<Result> DProductos(int Cod)
        {
            Models.Producto producto = new Models.Producto();
            return producto.DProducto(Cod);
        }

        [HttpGet("UProducto/{cantidad}/{Cod}")]
        public ActionResult<Result> UProductos(int cantidad, int Cod)
        {
            Models.Producto producto = new Models.Producto();
            return producto.UProducto(cantidad, Cod);
        }

        [HttpGet("UProductoVender/{cantidad}/{Cod}")]
        public ActionResult<Result> UProductoVender(int cantidad, int Cod)
        {
            Models.Producto producto = new Models.Producto();
            return producto.UProductoVender(cantidad, Cod);
        }



        [HttpGet("IProductoVendido/{Nombre}/{Precio}/{Cantidad}/{Ganancia}/{CantidadProductosEnLaCompra}/{PrecioDelEnvioEnLaCompra}/{PrecioSinGanancias}")]
        public ActionResult<Result> SetHistorialProgresoOrden(string Nombre, int Precio, int Cantidad, int Ganancia, int CantidadProductosEnLaCompra, int PrecioDelEnvioEnLaCompra, int PrecioSinGanancias)
        {
            Models.Producto producto = new Models.Producto();
            return producto.IProductoVendido(Nombre, Precio, Cantidad, Ganancia, CantidadProductosEnLaCompra, PrecioDelEnvioEnLaCompra, PrecioSinGanancias);
        }

    }
}
