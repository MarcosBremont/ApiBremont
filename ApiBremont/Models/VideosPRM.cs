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
    public class VideosPRM : Conexion
    {
        public List<Modelo.Entidades.EVideos> Lista_Videos()
        {
            List<Modelo.Entidades.EVideos> Lista_Videos = new List<Modelo.Entidades.EVideos>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("Svideosprm", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                Lista_Videos = JsonConvert.DeserializeObject<List<Modelo.Entidades.EVideos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return Lista_Videos;
        }


      

    }
}
