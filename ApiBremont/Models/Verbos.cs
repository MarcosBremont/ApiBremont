using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Verbos : Conexion
    {

        public List<Modelo.Entidades.EVerbos> Lista_de_verbos()
        {
            List<Modelo.Entidades.EVerbos> Lista_de_verbos = new List<Modelo.Entidades.EVerbos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaVerbos", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_verbos = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVerbos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_verbos;
        }

       
    }
}
