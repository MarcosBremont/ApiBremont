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

        public Result AgregarPedido(string usuario, string email, string telefono, int concuantopagara, int devuelta, string direccion, string producto)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IPedido(?,?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_usuario", MySqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("prm_email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("prm_telefono", MySqlDbType.VarChar).Value = telefono;
                    cmd.Parameters.Add("prm_concuantopagara", MySqlDbType.Int32).Value = concuantopagara;
                    cmd.Parameters.Add("prm_devuelta", MySqlDbType.Int32).Value = devuelta;
                    cmd.Parameters.Add("prm_direccion", MySqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("prm_producto", MySqlDbType.VarChar).Value = producto;
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
