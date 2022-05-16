using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class EmpresaFFA : Conexion
    {
        public List<Modelo.Entidades.EEmpresaFFA> lista_empresa()
        {
            List<Modelo.Entidades.EEmpresaFFA> lista_empresa = new List<Modelo.Entidades.EEmpresaFFA>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaEmpresaFastFood", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_empresa = JsonConvert.DeserializeObject<List<Modelo.Entidades.EEmpresaFFA>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_empresa;
        }

    }
}
