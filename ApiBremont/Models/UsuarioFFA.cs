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
        public Result RegistrarUsuario(string nombre, string apellido, string direccion, string telefono, string correo, string latitud, string longitud, string clave)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IUsuarioFFA(?,?,?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_nombre", MySqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("prm_apellido", MySqlDbType.VarChar).Value = apellido;
                    cmd.Parameters.Add("prm_direccion", MySqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("prm_telefono", MySqlDbType.VarChar).Value = telefono;
                    cmd.Parameters.Add("prm_correo", MySqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("prm_latitud", MySqlDbType.VarChar).Value = latitud;
                    cmd.Parameters.Add("prm_longitud", MySqlDbType.VarChar).Value = longitud;
                    cmd.Parameters.Add("prm_clave", MySqlDbType.VarChar).Value = clave;
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

        public EUsuarioFFA IniciarSesion(string email, string password, string token_firebase)
        {
            EUsuarioFFA eusuarioffa = new EUsuarioFFA();
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("IniciarSesionFFA", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_correo", MySqlDbType.Text).Value = email;
                cmd.Parameters.Add("prm_clave", MySqlDbType.Text).Value = password;
                cmd.Parameters.Add("prm_token_firebase", MySqlDbType.Text).Value = token_firebase;
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

        public Result ActualizarUsuario(string nombre, string apellido, string direccion, string telefono, string correo, string clave, int idusuarios)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"UUsuariosPorIdUsuarioFFA(?,?,?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_nombre", MySqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("prm_apellido", MySqlDbType.VarChar).Value = apellido;
                    cmd.Parameters.Add("prm_direccion", MySqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("prm_telefono", MySqlDbType.VarChar).Value = telefono;
                    cmd.Parameters.Add("prm_correo", MySqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("prm_clave", MySqlDbType.VarChar).Value = clave;
                    cmd.Parameters.Add("prm_idusuarios", MySqlDbType.Int32).Value = idusuarios;
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

        public EUsuarioFFA GrabarUrlFotoPerfil(int idusuarios, string foto)
        {
            EUsuarioFFA eUsuarioFFA = new EUsuarioFFA();
            try
            {
                // Actualizar Foto
                var sql = @"update usuarios_fast_food set foto=@foto where idusuarios = @idusuarios";
                MySqlCommand cmd = new MySqlCommand(sql, GetCon());
                cmd.Parameters.Add("@idusuarios", MySqlDbType.Int32).Value = idusuarios;
                cmd.Parameters.Add("@foto", MySqlDbType.Text).Value = foto;
                Conectar();
                cmd.ExecuteNonQuery();
                Desconectar();

                try
                {
                    sql = @"SELECT concat('C:/inetpub/wwwroot/apibremont.tecnolora.com/wwwroot','/images/',u.foto) foto FROM usuarios_fast_food u
                                where u.idusuarios = @idusuarios";
                    cmd = new MySqlCommand(sql, GetCon());
                    cmd.Parameters.Add("@idusuarios", MySqlDbType.Int32).Value = idusuarios;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                        eUsuarioFFA = JsonConvert.DeserializeObject<EUsuarioFFA>(result, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        eUsuarioFFA.encontrado = true;
                        eUsuarioFFA.result = "OK";
                    }
                    else
                    {
                        eUsuarioFFA.result = "ERROR";
                    }

                }
                catch (Exception ex)
                {
                    eUsuarioFFA.result = "ERROR";
                }

                return eUsuarioFFA;
            }
            catch (Exception ex)
            {
                WriteException(ex);
                eUsuarioFFA.result = "ERROR";
            }

            return eUsuarioFFA;
        }


        public Result ActualizarClave(string correo, string clave)
        {
            Result result = new Result();

            string sql = "UClaveUsuario";
            MySqlCommand cmd = new MySqlCommand(sql, GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_correo", MySqlDbType.Text).Value = correo;
            cmd.Parameters.Add("@prm_clave", MySqlDbType.Text).Value = clave;
            Conectar();
            cmd.ExecuteNonQuery();
            result.Respuesta = "OK";
            Desconectar();

            return result;


        }

    }

}
