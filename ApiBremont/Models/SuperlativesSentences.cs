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
    public class SuperlativesSentences : Conexion
    {
        public List<Modelo.Entidades.ESuperlaivesSentences> Lista_de_superlatives_Sentences()
        {
            List<Modelo.Entidades.ESuperlaivesSentences> Lista_de_superlatives_Sentences = new List<Modelo.Entidades.ESuperlaivesSentences>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaSuperlativesSentences", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_superlatives_Sentences = JsonConvert.DeserializeObject<List<Modelo.Entidades.ESuperlaivesSentences>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_superlatives_Sentences;
        }


      

    }
}
