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
    public class UsuarioFFA : Conexion
    {
        public EUsuarioFFA IniciarSesion(string email, string password)
        {
            EUsuarioFFA eusuarioffa = new EUsuarioFFA();
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("IniciarSesionFFA", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_correo", MySqlDbType.Text).Value = email;
                cmd.Parameters.Add("prm_clave", MySqlDbType.Text).Value = password;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    eusuarioffa = JsonConvert.DeserializeObject<EUsuarioFFA>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    eusuarioffa.respuesta = "OK";
                }
                else
                {
                    eusuarioffa.respuesta = "NO";
                    eusuarioffa.mensaje = "¡Usuario o contraseña incorrectos!";
                }
            }
            catch (Exception ex)
            {
                WriteException(ex);
                eusuarioffa.respuesta = "NO";
                eusuarioffa.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return eusuarioffa;
        }

    }
}
