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
    public class Adjectives : Conexion
    {
        public List<Modelo.Entidades.EAdjectives> Lista_de_Adjectives()
        {
            List<Modelo.Entidades.EAdjectives> Lista_de_Adjectives = new List<Modelo.Entidades.EAdjectives>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaAdjectives", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Adjectives = JsonConvert.DeserializeObject<List<Modelo.Entidades.EAdjectives>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Adjectives;
        }


      

    }
}
