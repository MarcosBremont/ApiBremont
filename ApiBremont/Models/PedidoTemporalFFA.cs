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
    public class PedidoTemporalFFA : Conexion
    {

        public Result AgregarPedidoTemporal(int idmenu_fast_food, int idusuarios, int cantidad)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IPedidoProductosFFA(?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_idmenu_fast_food", MySqlDbType.Int32).Value = idmenu_fast_food;
                    cmd.Parameters.Add("prm_idusuarios", MySqlDbType.Int32).Value = idusuarios;
                    cmd.Parameters.Add("prm_cantidad", MySqlDbType.Int32).Value = cantidad;
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

        public List<Modelo.Entidades.EPedidoTemporal> lista_pedidotemporal(int idusuarios, int idpedidos)
        {
            List<Modelo.Entidades.EPedidoTemporal> lista_pedido_temporal = new List<Modelo.Entidades.EPedidoTemporal>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SPedidoPorUsuarioNumeroDeOrden(?,?)", GetCon());
            cmd.Parameters.Add("prm_idusuarios", MySqlDbType.Int32).Value = idusuarios;
            cmd.Parameters.Add("prm_idpedidos", MySqlDbType.Int32).Value = idpedidos;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_pedido_temporal = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPedidoTemporal>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_pedido_temporal;
        }


    }
}
