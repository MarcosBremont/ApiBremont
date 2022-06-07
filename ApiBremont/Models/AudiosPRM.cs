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
    public class AudiosPRM : Conexion
    {
        public List<Modelo.Entidades.EAudios> Lista_audios()
        {
            List<Modelo.Entidades.EAudios> Lista_audios = new List<Modelo.Entidades.EAudios>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("Saudiosprm", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_audios = JsonConvert.DeserializeObject<List<Modelo.Entidades.EAudios>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_audios;
        }


      

    }
}
