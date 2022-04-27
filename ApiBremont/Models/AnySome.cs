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
    public class AnySome : Conexion
    {
        public List<Modelo.Entidades.EAnySome> Lista_de_Any_Some()
        {
            List<Modelo.Entidades.EAnySome> Lista_de_Any_Some = new List<Modelo.Entidades.EAnySome>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaAnySome", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Any_Some = JsonConvert.DeserializeObject<List<Modelo.Entidades.EAnySome>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Any_Some;
        }
    }
}
