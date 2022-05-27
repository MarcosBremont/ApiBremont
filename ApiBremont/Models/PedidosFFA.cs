using Modelo.Entidades;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class PedidosFFA : Conexion
    {

        public Result AgregarPedido(int idusuarios)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IPedidoFFA(?)", GetCon());
                    cmd.Parameters.Add("prm_usuario", MySqlDbType.VarChar).Value = idusuarios;
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

        public Result ActualizarPedido(int concuantopagara, int devuelta, string latitud, string longitud, string estado_del_pedido, int idusuarios, int idpedidos_fast_food)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"UPedidoFFA(?,?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_concuantopagara", MySqlDbType.Int32).Value = concuantopagara;
                    cmd.Parameters.Add("prm_devuelta", MySqlDbType.Int32).Value = devuelta;
                    cmd.Parameters.Add("prm_latitud", MySqlDbType.VarChar).Value = latitud;
                    cmd.Parameters.Add("prm_longitud", MySqlDbType.VarChar).Value = longitud;
                    cmd.Parameters.Add("prm_estado_del_pedido", MySqlDbType.VarChar).Value = estado_del_pedido;
                    cmd.Parameters.Add("prm_idusuarios", MySqlDbType.Int32).Value = idusuarios;
                    cmd.Parameters.Add("prm_idpedidos_fast_food", MySqlDbType.Int32).Value = idpedidos_fast_food;
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

        public List<Modelo.Entidades.EPedidos> lista_pedidos(string estado_del_pedido, int idusuarios)
        {
            List<Modelo.Entidades.EPedidos> lista_pedidos = new List<Modelo.Entidades.EPedidos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaPedidosPorUsuario(?,?)", GetCon());
            cmd.Parameters.Add("prm_estado_del_pedido", MySqlDbType.String).Value = estado_del_pedido;
            cmd.Parameters.Add("prm_usuario", MySqlDbType.Int32).Value = idusuarios;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_pedidos = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPedidos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_pedidos;
        }

        public List<Modelo.Entidades.EPedidos> lista_numerodeorden(int idusuarios, string estado)
        {
            List<Modelo.Entidades.EPedidos> lista_numerodeorden = new List<Modelo.Entidades.EPedidos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SNumeroOrdenPorUsuarioEstadoFFA(?,?)", GetCon());
            cmd.Parameters.Add("prm_idusuarios", MySqlDbType.Int32).Value = idusuarios;
            cmd.Parameters.Add("prm_estado", MySqlDbType.String).Value = estado;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_numerodeorden = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPedidos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_numerodeorden;
        }

    }
}
