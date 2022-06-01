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
    public class AdjectivesSuperlatives : Conexion
    {
        public List<Modelo.Entidades.ESuperlatives> Lista_de_AdjectivesSuperlatives()
        {
            List<Modelo.Entidades.ESuperlatives> Lista_de_Adjectives_Superlatives = new List<Modelo.Entidades.ESuperlatives>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SSuperlativesAdjectives", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Adjectives_Superlatives = JsonConvert.DeserializeObject<List<Modelo.Entidades.ESuperlatives>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Adjectives_Superlatives;
        }


      

    }
}
