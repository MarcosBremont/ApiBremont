using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Menu : Conexion
    {
        public List<Modelo.Entidades.EMenu> lista_menu()
        {
            List<Modelo.Entidades.EMenu> lista_menu = new List<Modelo.Entidades.EMenu>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaMenuFastFood", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_menu = JsonConvert.DeserializeObject<List<Modelo.Entidades.EMenu>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_menu;
        }

    }
}
