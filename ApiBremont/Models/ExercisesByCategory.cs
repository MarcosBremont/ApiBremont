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
    public class ExercisesByCategory : Conexion
    {
        public List<Modelo.Entidades.EExercisesByCategory> List_Of_ExercisesByCategory(string category)
        {
            List<Modelo.Entidades.EExercisesByCategory> list_of_exercisesbycategory = new List<Modelo.Entidades.EExercisesByCategory>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SExercisesByCategory(?)", GetCon());
            cmd.Parameters.Add("prm_category", MySqlDbType.VarChar).Value = category;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                list_of_exercisesbycategory = JsonConvert.DeserializeObject<List<Modelo.Entidades.EExercisesByCategory>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return list_of_exercisesbycategory;
        }


      

    }
}
