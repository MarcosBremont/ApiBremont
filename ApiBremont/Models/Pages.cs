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
    public class Pages : Conexion
    {
        public List<Modelo.Entidades.EPages> Lista_de_pages()
        {
            List<Modelo.Entidades.EPages> Lista_de_pages = new List<Modelo.Entidades.EPages>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SPage", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_de_pages = JsonConvert.DeserializeObject<List<Modelo.Entidades.EPages>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_de_pages;
        }


      

    }
}
