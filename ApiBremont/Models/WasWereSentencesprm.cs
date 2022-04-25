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
    public class WasWereSentencesprm : Conexion
    {
        public List<Modelo.Entidades.EWasWereSentencesprm> Lista_de_Sentences()
        {
            List<Modelo.Entidades.EWasWereSentencesprm> Lista_de_Sentences = new List<Modelo.Entidades.EWasWereSentencesprm>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaWasWereSentencesPrm", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Sentences = JsonConvert.DeserializeObject<List<Modelo.Entidades.EWasWereSentencesprm>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Sentences;
        }


      

    }
}
