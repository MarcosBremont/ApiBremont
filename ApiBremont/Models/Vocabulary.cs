using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Vocabulary : Conexion
    {

        public List<Modelo.Entidades.EVocabulary> Lista_de_vocabulary()
        {
            List<Modelo.Entidades.EVocabulary> Lista_de_vocabulary = new List<Modelo.Entidades.EVocabulary>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaVerbos", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_vocabulary = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVocabulary>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_vocabulary;
        }

       
    }
}
