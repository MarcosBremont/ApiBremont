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
    public class CompleteSentences : Conexion
    {
        public List<Modelo.Entidades.ECompleteSentences> Lista_de_Complete_Sentences()
        {
            List<Modelo.Entidades.ECompleteSentences> Lista_de_Complete_Sentences = new List<Modelo.Entidades.ECompleteSentences>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaCompleteSentences", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Complete_Sentences = JsonConvert.DeserializeObject<List<Modelo.Entidades.ECompleteSentences>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Complete_Sentences;
        }


      

    }
}
