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
    public class Pronouns : Conexion
    {
        public List<Modelo.Entidades.EPronouns> Lista_de_pronouns()
        {
            List<Modelo.Entidades.EPronouns> lista_pronouns = new List<Modelo.Entidades.EPronouns>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaPronouns", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_pronouns = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPronouns>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_pronouns;
        }
    }
}
