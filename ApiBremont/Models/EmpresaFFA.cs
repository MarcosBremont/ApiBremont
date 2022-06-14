using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class EmpresaFFA : Conexion
    {
        public List<Modelo.Entidades.EEmpresaFFA> lista_empresa()
        {
            List<Modelo.Entidades.EEmpresaFFA> lista_empresa = new List<Modelo.Entidades.EEmpresaFFA>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaEmpresaFastFood", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_empresa = JsonConvert.DeserializeObject<List<Modelo.Entidades.EEmpresaFFA>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_empresa;
        }

        public List<Modelo.Entidades.ENotificaciones_empresa> lista_notificaciones(int idnotificaciones_empresa, string disponibilidad)
        {
            List<Modelo.Entidades.ENotificaciones_empresa> lista_notificaciones = new List<Modelo.Entidades.ENotificaciones_empresa>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand($"SNotificacionesFFA(?,?)", GetCon());
            cmd.Parameters.Add("prm_idnotificaciones_empresa", MySqlDbType.VarChar).Value = idnotificaciones_empresa;
            cmd.Parameters.Add("prm_disponibilidad", MySqlDbType.VarChar).Value = disponibilidad;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_notificaciones = JsonConvert.DeserializeObject<List<Modelo.Entidades.ENotificaciones_empresa>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_notificaciones;
        }

        public Result EnviarNotificacion(string mensaje, string disponibilidad)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"INotificacionesFFA(?,?)", GetCon());
                    cmd.Parameters.Add("prm_mensaje", MySqlDbType.VarChar).Value = mensaje;
                    cmd.Parameters.Add("prm_disponibilidad", MySqlDbType.VarChar).Value = disponibilidad;
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

        public Result ActualizarNotificacion(int idnotificaciones_empresa, string disponibilidad)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"UNotificacionesFFA(?,?)", GetCon());
                    cmd.Parameters.Add("prm_idnotificaciones_empresa", MySqlDbType.VarChar).Value = idnotificaciones_empresa;
                    cmd.Parameters.Add("prm_disponibilidad", MySqlDbType.VarChar).Value = disponibilidad;
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
