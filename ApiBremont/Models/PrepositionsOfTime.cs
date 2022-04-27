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
    public class PrepositionsOfTime : Conexion
    {
        public List<Modelo.Entidades.EPrepositionsOfTime> Lista_de_prepositions_Of_Time()
        {
            List<Modelo.Entidades.EPrepositionsOfTime> lista_prepositions_Of_Time = new List<Modelo.Entidades.EPrepositionsOfTime>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaPrepositionsOfTimeprm", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_prepositions_Of_Time = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPrepositionsOfTime>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_prepositions_Of_Time;
        }
    }
}
