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
    public class Categories : Conexion
    {
        public List<Modelo.Entidades.ECategories> Lista_de_Categories()
        {
            List<Modelo.Entidades.ECategories> Lista_de_Categories = new List<Modelo.Entidades.ECategories>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SCategories", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_Categories = JsonConvert.DeserializeObject<List<Modelo.Entidades.ECategories>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_Categories;
        }


      

    }
}
