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
    public class Posiciones : Conexion
    {
        public List<Modelo.Entidades.EPosiciones> Lista_de_posiciones()
        {
            List<Modelo.Entidades.EPosiciones> Lista_de_posiciones = new List<Modelo.Entidades.EPosiciones>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaPosiciones", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_posiciones = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPosiciones>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_posiciones;
        }


        public Result EnterToTheTournament(string nombrePersona, int numeroVerbosCorrectos, string direccion)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IPeopleInTheTournament(?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_nombrePersona", MySqlDbType.VarChar).Value = nombrePersona;
                    cmd.Parameters.Add("prm_numeroVerbosCorrectos", MySqlDbType.Int32).Value = numeroVerbosCorrectos;
                    cmd.Parameters.Add("prm_direccion", MySqlDbType.VarChar).Value = direccion;
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
