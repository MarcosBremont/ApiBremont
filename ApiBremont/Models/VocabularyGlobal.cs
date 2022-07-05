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
    public class VocabularyGlobal : Conexion
    {
        public List<Modelo.Entidades.EVocabularyGlobal> List_Of_VocabularyGlobalByCategory(string category)
        {
            List<Modelo.Entidades.EVocabularyGlobal> List_Of_VocabularyGlobalByCategory = new List<Modelo.Entidades.EVocabularyGlobal>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SVocabularyGlobal(?)", GetCon());
            cmd.Parameters.Add("prm_Vocabulary_category", MySqlDbType.VarChar).Value = category;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                List_Of_VocabularyGlobalByCategory = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVocabularyGlobal>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return List_Of_VocabularyGlobalByCategory;
        }


      

    }
}
