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
    public class Family : Conexion
    {
        public List<Modelo.Entidades.EFamilyVocabulary> Lista_de_Family()
        {
            List<Modelo.Entidades.EFamilyVocabulary> Lista_de_Family = new List<Modelo.Entidades.EFamilyVocabulary>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaFamily", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Family = JsonConvert.DeserializeObject<List<Modelo.Entidades.EFamilyVocabulary>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Family;
        }
    }
}
