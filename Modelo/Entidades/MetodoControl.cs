using System;
using System.Reflection;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.IO;

namespace Entidad
{
    public class MetodoControl
    {

        public string MensajeEstadoCablemodem(string estado, int codigoCli)
        {
            switch (estado)
            {
                case "A": return "El módem está asignado al cliente: " + codigoCli;
                case "N": return "Cablemodem no disponible.";
                default: return "";
            }
        }

        public string MensajeEstadoCaja(string estado, string estatus)
        {
            switch (estado)
            {
                case "A": return "Esta Caja ya está asignada.";
                case "N": return "Caja no disponible.";
            }
            switch (estatus)
            {
                case "A": return "Este cablemodem ya está activada.";
                default: return "";
            }
        }

        public string MensajeEstadoSmc(string estado, string estatus)
        {
            switch (estado)
            {
                case "A": return "Esta SMC ya está asignada.";
                case "N": return "SMC no disponible.";
            }
            switch (estatus)
            {
                case "A": return "Esta SMC ya está activada.";
                default: return "";
            }
        }

        public int IntParse(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            int numero_int;
            int.TryParse(numeroString, out numero_int);
            return numero_int;
        }

        public double DoubleParse(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            double numero_double;
            double.TryParse(numeroString, out numero_double);
            return double.IsNaN(numero_double) || double.IsInfinity(numero_double) ? 0 : numero_double;
        }

        public decimal DecimalParse(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            decimal numero_double;
            decimal.TryParse(numeroString, out numero_double);
            return numero_double;
        }

        public Int64 IntParse64(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            Int64 numero_int;
            Int64.TryParse(numeroString, out numero_int);
            return numero_int;
        }

        public DateTime DateTimeParse(object valor)
        {
            string fechaString = valor != null ? valor.ToString() : "";
            DateTime fechaParsed;
            DateTime.TryParse(fechaString, out fechaParsed);
            return fechaParsed;
        }

        public string FechaString(string fecha, bool fecha_hora)
        {
            DateTime fecha_test;
            if (DateTime.TryParse(fecha, out fecha_test))
            {
                return fecha_hora ? fecha_test.ToString("dd/MM/yyyy hh:mm:ss") : fecha_test.ToString("dd/MM/yyyy");
            }

            return "";
        }



  
        public string QuitarCaracteres(string cadena, char caracter)
        {
            return UnirArray(cadena.Split(caracter), "");
        }

        public string UnirArray(string[] array, string separador)
        {
            return string.Join(separador, array);
        }

        public string SustituirCaracter(string cadena, char caracterAQuitar, char caracterAPoner)
        {
            string[] arreglo = null;
            arreglo = cadena.Split(new char[] { caracterAQuitar }, StringSplitOptions.RemoveEmptyEntries);
            cadena = UnirArray(arreglo, caracterAPoner.ToString());

            return cadena;
        }

        public string LimpiarNombreCliente(string nombreCli)
        {
            string nombreLimpio = "";
            nombreLimpio = StringParse(nombreCli).ToUpper().Replace("Ñ", "N");
            nombreLimpio = Regex.Replace(nombreLimpio, "[^A-Za-z- ]", "");

            return nombreLimpio;
        }

        public string ObtenerPrecio(string texto, char separador)
        {
            string[] partes = texto.Split(separador);
            return partes.Length > 1 ? partes[1] : "0.00";
        }

        public string QuitarPrecio(string texto, char separador)
        {
            string[] partes = texto.Split(separador);
            return partes.Length > 1 ? partes[0] : "";
        }

        public int NumeroFila(DataTable dt, string columna, int valor)
        {
            var fila = dt.AsEnumerable().Select(row => row.Field<int?>(columna)).ToList().FindIndex(col => col == valor);
            return fila;
        }

        public int NumeroFilaString(DataTable dt, string columna, string valor)
        {
            var fila = dt.AsEnumerable().Select(row => row.Field<string>(columna)).ToList().FindIndex(col => col == valor);
            return fila;
        }

        public int[] ListaDeFilas(DataTable dt, string columna, int valor)
        {
            var fila = dt.AsEnumerable().
                Select(row => row.Field<int?>(columna)).
                ToList().
                Select((elemento, index) => elemento == valor ? index : -1).
                Where(index => index >= 0).
                ToArray();

            return fila;
        }

        public int[] ListaDeFilasString(DataTable dt, string columna, string valor)
        {
            var fila = dt.AsEnumerable().
                Select(row => row.Field<string>(columna)).
                ToList().
                Select((elemento, index) => elemento == valor ? index : -1).
                Where(index => index >= 0).
                ToArray();

            return fila;
        }

        public DataRow ObtenerFila(DataTable dt, string columna, int valor)
        {
            DataRow dRow = dt.AsEnumerable().Where(fila => fila.Field<int?>(columna) == valor).FirstOrDefault();
            return dRow;
        }

        public DataRow ObtenerFilaDefault(DataTable dt, string columna, int valor)
        {
            DataRow dRow = dt.AsEnumerable().Where(fila => fila.Field<int?>(columna) == valor).FirstOrDefault();

            if (dRow == null)
            {
                dRow = dt.NewRow();
            }
            return dRow;
        }

        public DataRow ObtenerFilaString(DataTable dt, string columna, string valor)
        {
            DataRow dRow = dt.AsEnumerable().Where(fila => fila.Field<string>(columna) == valor).FirstOrDefault();
            return dRow;
        }

        public DataRow ObtenerUltimaFila(DataTable dt, string columna, int valor)
        {
            DataRow dRow = dt.AsEnumerable().Where(fila => fila.Field<int>(columna) == valor).LastOrDefault();
            return dRow;
        }

        public DataRow ObtenerFilaNoMarcada(DataTable dt, string columna, int valor, string columnaMira)
        {
            DataRow dRow = dt.AsEnumerable().
                           Where(fila => fila.Field<int>(columna) == valor &&
                                         ((fila.Field<int?>(columnaMira).HasValue && fila.Field<int?>(columnaMira) <= 0) || !fila.Field<int?>(columnaMira).HasValue)).
                           FirstOrDefault();
            return dRow;
        }

        public DataRow ObtenerFilaNoMarcadaDefault(DataTable dt, string columna, int valor, string columnaMira)
        {
            DataRow dRow = dt.AsEnumerable().
                           Where(fila => fila.Field<int>(columna) == valor &&
                                         ((fila.Field<int?>(columnaMira).HasValue && fila.Field<int?>(columnaMira) <= 0) || !fila.Field<int?>(columnaMira).HasValue)).
                           FirstOrDefault();

            if (dRow == null)
            {
                dRow = dt.NewRow();
            }
            return dRow;
        }

        public DataRow ObtenerFilaNoMarcadaString(DataTable dt, string columna, string valor, string columnaMira)
        {
            DataRow dRow = dt.AsEnumerable().
                           Where(fila => fila.Field<string>(columna) == valor &&
                                         ((fila.Field<int?>(columnaMira).HasValue && fila.Field<int?>(columnaMira) <= 0) || !fila.Field<int?>(columnaMira).HasValue)).
                           FirstOrDefault();
            return dRow;
        }

        public int TamanioSerieCas(string codigo_cas)
        {
            if (codigo_cas == "2")
                return 12;
            else
                return 16;
        }

        public int TamanioSerieCasCaja(string codigo_cas)
        {
            if (codigo_cas == "5")
                return 16;
            else
                return 50;
        }

        public DateTime FechaHora()
        {
            TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            DateTime fechaHora = TimeZoneInfo.ConvertTime(DateTime.Now, zona).AddHours(-4);
            return fechaHora;
        }

        public DataTable SLista(DataTable tabla, string nombreColumna, int id)
        {
            if (tabla != null)
            {
                var lista = tabla.AsEnumerable().Where(row => row.Field<int>(nombreColumna) == id);

                if (lista.Count() > 0)
                {
                    tabla = lista.CopyToDataTable<DataRow>();
                }
                else
                    tabla = null;
            }

            return tabla;
        }

        public DataTable ListaConValor(DataTable tabla, string nombreColumna, int valor)
        {
            if (tabla != null)
            {
                var lista = tabla.AsEnumerable().Where(row => row.Field<int?>(nombreColumna) > valor);

                if (lista.Count() > 0)
                    return lista.CopyToDataTable();
            }

            return ColumnasTabla(tabla);
        }

        public DataTable ListaConValorCadena(DataTable tabla, string nombreColumna, string valor)
        {
            if (tabla != null)
            {
                var lista = tabla.AsEnumerable().Where(row => row.Field<string>(nombreColumna) == valor);

                if (lista.Count() > 0)
                    return lista.CopyToDataTable();
            }

            return ColumnasTabla(tabla);
        }

        public DataTable ColumnasTabla(DataTable dt)
        {
            if (dt == null)
                return new DataTable();

            DataTable dtColumnas = new DataTable();
            dtColumnas.Columns.AddRange(dt.Columns.Cast<DataColumn>().Select(columna => new DataColumn(columna.ColumnName)).ToArray());

            return dtColumnas;
        }

        public string FormatearSerie(string serie, int? idCas)
        {
            return idCas == 2 ? serie.Substring(0, 10).PadLeft(12, '0') : serie;
        }

        public string ParametroPorCas(string comando, int? idCas)
        {
            if (comando == "DES")
                return idCas == 2 ? "1" : "NO";

            if (comando == "DEL")
                return idCas == 2 ? "1" : "NO";

            if (comando == "CREAR")
                return "CREAR CLIENTE";

            if (comando == "ACT")
                return idCas == 2 ? "0" : "YES";

            return "";
        }

        public string EjecutarSentenciaEnApiLibre(string url_request)
        {
            string result = "Error";

            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var response = client.GetAsync(url_request);
                response.Wait();

                response.Result.EnsureSuccessStatusCode();

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = response.Result.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    result = jsonString.Result;
                }
            }

            return result;
        }

        public void SetScopeDefaultTimeOut(TimeSpan value)
        {
            var timespan = TransactionManager.MaximumTimeout;
            timespan = TransactionManager.MaximumTimeout;

            SetTransactionManagerField("_cachedMaxTimeout", true);
            SetTransactionManagerField("_maximumTimeout", value);
        }

        public void SetTransactionManagerField(string fieldName, object value)
        {
            var cacheField = typeof(TransactionManager).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);

            if (cacheField != null)
            {
                cacheField.SetValue(null, value);
            }
        }

        public string StringParse(object valor)
        {
            return valor != null ? valor.ToString() : "";
        }

    
      

        public string ConvertirTablaEnJson(object dt)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "yyyy/MM/dd hh:mm:ss"
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(dt, settings);
        }

        public List<T> ConvertirJsonEnLista<T>(string tablaStr)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(tablaStr, settings);
        }

        public List<T> ConvertirTablaEnLista<T>(DataTable dt)
        {
            string tablaStr = ConvertirTablaEnJson(dt);
            return ConvertirJsonEnLista<T>(tablaStr);
        }

        public T ConvertirTablaEnObjeto<T>(DataTable dt)
        {
            string tablaStr = ConvertirTablaEnJson(dt);
            List<T> lista = new List<T>();
            T obj = (T)Activator.CreateInstance(typeof(T));

            lista = ConvertirTablaEnLista<T>(dt);

            return lista.ToList().Count > 0 ? lista[0] : obj;
        }

        public string GenerarNombreUsuarioMikrotik(int codigoCli, string nombreCli, string mac)
        {
            try
            {
                string usuario = "";
                string[] nombreSeparado = new string[] { };
                string macSinPuntos = mac.Replace(":", "");

                nombreSeparado = nombreCli.ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (nombreSeparado.Length > 0)
                {
                    usuario = codigoCli + "-" + nombreSeparado[0] + "-" + macSinPuntos.Substring(macSinPuntos.Length - 4);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando el nombre de usuario mikrotik. Cliente: " + codigoCli + ". Mac: " + mac + ". " + ex.Message);
            }
        }

        public string GenerarNombreUsuarioMikrotikRango(string nombreCli, DateTime fechaCreacion, int rango)
        {
            try
            {
                string usuario = "";
                string[] nombreSeparado = new string[] { };

                nombreSeparado = nombreCli.ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (nombreSeparado.Length > 0)
                {
                    usuario = nombreSeparado[0] + "-" + fechaCreacion.ToString("ddMMyyyy") + "-" + rango;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando el nombre de usuario mikrotik. Cliente: " + nombreCli + ". " + ex.Message);
            }
        }

        public int GenerarRangoModem(DataTable dtCablemodem)
        {
            try
            {
                int rangoMaximo = 0;
                List<int> listaRango = dtCablemodem.AsEnumerable().Select(row => row.Field<int>("rango")).ToList();

                rangoMaximo = listaRango.Count > 0 ? listaRango.Max() : 0;

                return rangoMaximo + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando el rango del módem." + ex.Message);
            }
        }

        public DataTable EquipoMarcadoValorEspecificoInt(DataTable dtEquipo, string columna, int valor)
        {
            if (dtEquipo != null && dtEquipo.Rows.Count > 0)
            {
                var filas = dtEquipo.AsEnumerable().Where(row =>
                          IntParse(row[columna].ToString()) == valor);

                if (filas.Count() > 0)
                    return filas.CopyToDataTable();
            }

            return ColumnasTabla(dtEquipo);
        }

        public string ObtenerTelefonos(string telefonos, int cantidad)
        {
            string[] lista;

            lista = telefonos.Split(',');

            if (lista.Length > 0)
            {
                if (cantidad > lista.Length)
                {
                    cantidad = lista.Length;
                }

                return string.Join(", ", lista, 0, cantidad);
            }

            return "";
        }

        public string ApiPostRequest(string request_url, string request_body)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    LogWrite("Step 1");
                    client.Timeout = new TimeSpan(0, 0, 30);
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    string bvody_data_formated = "\"" + request_body.Replace("\"", "\\" + "\"") + "\"";

                    LogWrite("Step 2");
                    var content = new StringContent(request_body, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(request_url, content);
                    response.Wait();

                    LogWrite("Step 3");
                    response.Result.EnsureSuccessStatusCode();

                    if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        LogWrite("Step 4");
                        var jsonString = response.Result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        return jsonString.Result.ToString();
                    }
                    else
                    {
                        LogWrite("Step 5");
                        return "Error: " + response.Result.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    LogWrite("Step 6");
                    LogWrite(ex);
                    return ex.Message;
                }
            }
        }

        public void LogWrite(string logMessage)
        {
            // string m_exePath = HttpRuntime.AppDomainAppPath;
            string m_exePath = new System.Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            m_exePath = m_exePath.Replace("\\Entidad.DLL", "");
            m_exePath = m_exePath.Replace("/Entidad.DLL", "");

            try
            {
                using (StreamWriter w = System.IO.File.AppendText(m_exePath + "/log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }

        public void LogWrite(Exception ex)
        {
            try
            {
                if (!ex.Message.Contains("Thread was being aborted."))
                {
                    string logMessage = "Exception:" + Environment.NewLine + "StackTrace: " + ex.StackTrace + Environment.NewLine + "Exception message:" + ex.Message;
                    string m_exePath = new System.Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
                    try
                    {
                        using (StreamWriter w = System.IO.File.AppendText(m_exePath + "/log.txt"))
                        {
                            Log(logMessage, w);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("");
                txtWriter.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss"));
                txtWriter.WriteLine("{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch { }
        }
    }
}