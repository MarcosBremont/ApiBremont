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
    public class SimplePresent : Conexion
    {
        public List<Modelo.Entidades.ESimplePresent> Lista_de_simple_present()
        {
            List<Modelo.Entidades.ESimplePresent> lista_simplepresent = new List<Modelo.Entidades.ESimplePresent>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("Slistasimplepresentexercises", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_simplepresent = JsonConvert.DeserializeObject<List<Modelo.Entidades.ESimplePresent>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_simplepresent;
        }
    }
}
