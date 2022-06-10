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
    public class HowToUse : Conexion
    {
        public List<Modelo.Entidades.EHowToUseByCategory> List_Of_ExamplesByCategory(string category)
        {
            List<Modelo.Entidades.EHowToUseByCategory> List_Of_ExamplesByCategory = new List<Modelo.Entidades.EHowToUseByCategory>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SHowToUse(?)", GetCon());
            cmd.Parameters.Add("prm_howtouse_category", MySqlDbType.VarChar).Value = category;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                List_Of_ExamplesByCategory = JsonConvert.DeserializeObject<List<Modelo.Entidades.EHowToUseByCategory>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return List_Of_ExamplesByCategory;
        }


      

    }
}
