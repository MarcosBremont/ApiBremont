using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class VocabularyFamily : Conexion
    {

        public List<Modelo.Entidades.EVocabularyFamily> Lista_de_vocabulary_family()
        {
            List<Modelo.Entidades.EVocabularyFamily> Lista_de_vocabulary_family = new List<Modelo.Entidades.EVocabularyFamily>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SVocabularyFamily", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_vocabulary_family = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVocabularyFamily>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_vocabulary_family;
        }

       
    }
}
