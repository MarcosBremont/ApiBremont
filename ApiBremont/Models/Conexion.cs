using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Conexion : ClassBase
    {
        private readonly string conexion = "server=mysql.tecnolora.com;user=apibremont;password=apibremont;database=api_bremont;port=7100;max pool size=1000;SslMode=none;Convert Zero Datetime=True;";

        //private readonly string conexion = "server=localhost;user=userwnm;password=bI!34q7z;database=sistecsoft_dbwnm2;port=3307;max pool size=1000;SslMode=none;Convert Zero Datetime=True;";
        //TELEMON CONEXIÓN
        //private readonly string conexion = "server=localhost;user=userwnm;password=bI!34q7z;database=sistecsoft_dbwnm2;port=3307;max pool size=1000;SslMode=none;Convert Zero Datetime=True;";
        //private readonly string conexion = "server=localhost;uid=root;pwd=a123-;database=dboficable_mao;port=3307;max pool size=1000;SslMode=none;Convert Zero Datetime=True;CharSet=utf8";
        //private readonly string conexion = "server=localhost;uid=root;pwd=a123-;database=dboficable;port=3306;max pool size=1000;SslMode=none;Convert Zero Datetime=True;CharSet=utf8";
        //private readonly string conexion = "server=localhost;uid=root;pwd=a123-;database=dboficable_micable;port=3306;max pool size=1000;SslMode=none;Convert Zero Datetime=True;CharSet=utf8";
        //private readonly string conexion = "server=localhost;user=userwnm;password=bI!34q7z;database=sistecsoft_dbwnm2;port=3307;max pool size=1000;SslMode=none;Convert Zero Datetime=True;";
        //private readonly string conexion = "server=localhost;uid=root;pwd=1234;database=dboficable_elfactor;port=3306;max pool size=1000;SslMode=none;Convert Zero Datetime=True;CharSet=utf8";


        private readonly MySqlConnection con;

        public Conexion()
        {
            this.con = new MySqlConnection(conexion);
        }
        public MySqlConnection GetCon()
        {
            return this.con;
        }
        public void Conectar()
        {
            if (this.con.State == System.Data.ConnectionState.Closed)
                this.con.Open();
        }
        public void Desconectar()
        {
            if (this.con.State == System.Data.ConnectionState.Open)
                this.con.Close();
        }


    }

}
