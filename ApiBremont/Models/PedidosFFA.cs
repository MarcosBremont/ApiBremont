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

        public Result AgregarPedido(string usuario, string email, string telefono, int concuantopagara, int devuelta, string direccion, string producto, string latitud, string longitud)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IPedido(?,?,?,?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_usuario", MySqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("prm_email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("prm_telefono", MySqlDbType.VarChar).Value = telefono;
                    cmd.Parameters.Add("prm_concuantopagara", MySqlDbType.Int32).Value = concuantopagara;
                    cmd.Parameters.Add("prm_devuelta", MySqlDbType.Int32).Value = devuelta;
                    cmd.Parameters.Add("prm_direccion", MySqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("prm_producto", MySqlDbType.VarChar).Value = producto;
                    cmd.Parameters.Add("prm_latitud", MySqlDbType.VarChar).Value = latitud;
                    cmd.Parameters.Add("prm_longitud", MySqlDbType.VarChar).Value = longitud;
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

        public List<Modelo.Entidades.EPedidos> lista_pedidos()
        {
            List<Modelo.Entidades.EPedidos> lista_pedidos = new List<Modelo.Entidades.EPedidos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaPedidosPorUsuario", GetCon());
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


    }
}
