using Entidad;
using Modelo;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Producto : Conexion
    {
        MetodoControl metodoControl = new MetodoControl();
        public List<Modelo.Entidades.EProductos> Lista_de_productos_Por_ID(int cod)
        {
            List<Modelo.Entidades.EProductos> lista_de_Productos = new List<Modelo.Entidades.EProductos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaProductos(?)", GetCon());
            cmd.Parameters.Add("prm_cod", MySqlDbType.VarChar).Value = cod;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_Productos = JsonConvert.DeserializeObject<List<Modelo.Entidades.EProductos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_de_Productos;
        }

        public List<Modelo.Entidades.EProductos> Lista_de_productos()
        {
            List<Modelo.Entidades.EProductos> lista_de_Productos = new List<Modelo.Entidades.EProductos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaProductos", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_Productos = JsonConvert.DeserializeObject<List<Modelo.Entidades.EProductos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_de_Productos;
        }



        public List<Modelo.Entidades.EProductos> Lista_de_ganancias()
        {
            List<Modelo.Entidades.EProductos> Lista_de_ganancias = new List<Modelo.Entidades.EProductos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaGanancias", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_ganancias = JsonConvert.DeserializeObject<List<Modelo.Entidades.EProductos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_ganancias;
        }


        public Result Sentencia(string Nombre, int Precio, int Cantidad, int CantidadProductosEnLaCompra, int PrecioDelEnvioEnLaCompra, int PrecioSinGanancias)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IProducto_Inventario(?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_Nombre", MySqlDbType.VarChar).Value = Nombre;
                    cmd.Parameters.Add("prm_Precio", MySqlDbType.Int32).Value = Precio;
                    cmd.Parameters.Add("prm_Cantidad", MySqlDbType.Int32).Value = Cantidad;
                    cmd.Parameters.Add("prm_CantidadProductosEnLaCompra", MySqlDbType.Int32).Value = CantidadProductosEnLaCompra;
                    cmd.Parameters.Add("prm_PrecioDelEnvioEnLaCompra", MySqlDbType.Int32).Value = PrecioDelEnvioEnLaCompra;
                    cmd.Parameters.Add("prm_PrecioSinGanancias", MySqlDbType.Int32).Value = PrecioSinGanancias;
                    Conectar();
                    cmd.ExecuteNonQuery();
                    result.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Respuesta = "ERROR";
                result.Mensaje = ex.Message;
            }

            return result;

        }

        public Result DProducto(int Cod)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"DProducto(?)", GetCon());
                    cmd.Parameters.Add("prm_Cod", MySqlDbType.VarChar).Value = Cod;
                    Conectar();
                    cmd.ExecuteNonQuery();
                    result.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Respuesta = "ERROR";
                result.Mensaje = ex.Message;
            }

            return result;

        }


        public Result UProducto(int cantidad, int Cod)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"UProducto(?,?)", GetCon());
                    cmd.Parameters.Add("prm_cantidad", MySqlDbType.VarChar).Value = cantidad;
                    cmd.Parameters.Add("prm_Cod", MySqlDbType.VarChar).Value = Cod;
                    Conectar();
                    cmd.ExecuteNonQuery();
                    result.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Respuesta = "ERROR";
                result.Mensaje = ex.Message;
            }

            return result;

        }

        public Result UProductoVender(int cantidad, int Cod)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"UProductoVender(?,?)", GetCon());
                    cmd.Parameters.Add("prm_cantidad", MySqlDbType.VarChar).Value = cantidad;
                    cmd.Parameters.Add("prm_Cod", MySqlDbType.VarChar).Value = Cod;
                    Conectar();
                    cmd.ExecuteNonQuery();
                    result.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Respuesta = "ERROR";
                result.Mensaje = ex.Message;
            }

            return result;

        }

        public Result IProductoVendido(string Nombre, int Precio, int Cantidad, int Ganancia, int CantidadProductosEnLaCompra, int PrecioDelEnvioEnLaCompra, int PrecioSinGanancias)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IProductoVendido(?,?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_Nombre", MySqlDbType.VarChar).Value = Nombre;
                    cmd.Parameters.Add("prm_Precio", MySqlDbType.Int32).Value = Precio;
                    cmd.Parameters.Add("prm_Cantidad", MySqlDbType.Int32).Value = Cantidad;
                    cmd.Parameters.Add("prm_Ganancia", MySqlDbType.Int32).Value = Ganancia;
                    cmd.Parameters.Add("prm_CantidadProductosEnLaCompra", MySqlDbType.Int32).Value = CantidadProductosEnLaCompra;
                    cmd.Parameters.Add("prm_PrecioDelEnvioEnLaCompra", MySqlDbType.Int32).Value = PrecioDelEnvioEnLaCompra;
                    cmd.Parameters.Add("prm_PrecioSinGanancias", MySqlDbType.Int32).Value = PrecioSinGanancias;
                    Conectar();
                    cmd.ExecuteNonQuery();
                    result.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Respuesta = "ERROR";
                result.Mensaje = ex.Message;
            }

            return result;

        }

    }
}
