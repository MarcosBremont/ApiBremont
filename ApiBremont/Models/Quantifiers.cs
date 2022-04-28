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
    public class Quantifiers : Conexion
    {
        public List<Modelo.Entidades.EQuantifiers> Lista_de_quantifiers()
        {
            List<Modelo.Entidades.EQuantifiers> Lista_de_Quantifiers = new List<Modelo.Entidades.EQuantifiers>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaQuantifiers", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Quantifiers = JsonConvert.DeserializeObject<List<Modelo.Entidades.EQuantifiers>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Quantifiers;
        }
    }
}
