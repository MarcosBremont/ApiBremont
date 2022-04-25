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
    public class Clothes : Conexion
    {
        public List<Modelo.Entidades.EClothes> Lista_de_clothes()
        {
            List<Modelo.Entidades.EClothes> Lista_de_clothes = new List<Modelo.Entidades.EClothes>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaClothes", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_clothes = JsonConvert.DeserializeObject<List<Modelo.Entidades.EClothes>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_clothes;
        }
    }
}
