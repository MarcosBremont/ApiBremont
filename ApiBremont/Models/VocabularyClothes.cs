using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class VocabularyClothes : Conexion
    {

        public List<Modelo.Entidades.EVocabularyClothes> Lista_de_vocabulary_clothes()
        {
            List<Modelo.Entidades.EVocabularyClothes> Lista_de_vocabulary_clothes = new List<Modelo.Entidades.EVocabularyClothes>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SVocabularyClothes", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_vocabulary_clothes = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVocabularyClothes>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_vocabulary_clothes;
        }

       
    }
}
