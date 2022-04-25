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
    public class MatchSentences : Conexion
    {
        public List<Modelo.Entidades.EMatchSentences> Lista_de_Match()
        {
            List<Modelo.Entidades.EMatchSentences> Lista_de_Match = new List<Modelo.Entidades.EMatchSentences>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaMatchSentencesPrm", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Match = JsonConvert.DeserializeObject<List<Modelo.Entidades.EMatchSentences>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Match;
        }


      

    }
}
