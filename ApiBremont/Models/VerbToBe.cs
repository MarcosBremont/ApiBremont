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
    public class VerbToBe : Conexion
    {
        public List<Modelo.Entidades.EVerbToBe> Lista_de_verbtobe()
        {
            List<Modelo.Entidades.EVerbToBe> Lista_de_verbtobe = new List<Modelo.Entidades.EVerbToBe>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaVerbToBeSentences", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_verbtobe = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVerbToBe>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_verbtobe;
        }


        

    }
}
