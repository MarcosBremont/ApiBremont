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
    public class QuestionsWithHow : Conexion
    {
        public List<Modelo.Entidades.EQuestionWithHow> Lista_de_questionWithHow()
        {
            List<Modelo.Entidades.EQuestionWithHow> Lista_de_QuestionsWithHow = new List<Modelo.Entidades.EQuestionWithHow>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaQuestionsWithHow", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_QuestionsWithHow = JsonConvert.DeserializeObject<List<Modelo.Entidades.EQuestionWithHow>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_QuestionsWithHow;
        }
    }
}
