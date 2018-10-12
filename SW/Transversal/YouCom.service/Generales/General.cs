using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Collections;
using Subgurim.Controles;
using System.Xml;

namespace YouCom.Service.Generales
{
    public static class General
    {
        public static DateTime getRecuperaDiaInicialMes()
        {
            DateTime dateTimeDesde;
            int var_mesActual = DateTime.Now.Month; // obtengo el mes actual
            int var_anio = DateTime.Now.Year; // obtengo el año actual
            int var_mesSiguiente = DateTime.Now.Month + 1; // obtengo el mes siguiente
            dateTimeDesde = Convert.ToDateTime("01/" + var_mesActual + "/" + var_anio);// pongo el 1 porque siempre es el primer día obvio

            return dateTimeDesde;

        }

        public static DateTime getRecuperaDiaFinalMes()
        {
            DateTime dateTimeHasta;
            int var_mesActual = DateTime.Now.Month; // obtengo el mes actual
            int var_anio = 0;

            if (!DateTime.Now.Month.Equals(12))
            {
                var_anio = DateTime.Now.Year; // obtengo el año actual
                int var_mesSiguiente = DateTime.Now.Month + 1; // obtengo el mes siguiente
                dateTimeHasta = Convert.ToDateTime("01/" + var_mesSiguiente + "/" + var_anio).AddDays(-1); //resto un día al mes y con esto obtengo el ultimo día
            }
            else
            {
                var_anio = DateTime.Now.Year + 1; // obtengo el año actual
                int var_mesSiguiente = 1; // obtengo el mes siguiente
                dateTimeHasta = Convert.ToDateTime("01/" + var_mesSiguiente + "/" + var_anio).AddDays(-1); //resto un día al mes y con esto obtengo el ultimo día
            }

            return dateTimeHasta;
        }

        public static DateTime getRecuperaDiaInicialMesAnterior(DateTime fecha)
        {
            DateTime dateTime;
            if (!DateTime.Now.Month.Equals(1))
            {
                int var_mesAnterior = fecha.Month; // obtengo el mes actual
                int var_anio = fecha.Year; // obtengo el año actual
                dateTime = new DateTime(var_anio, var_mesAnterior - 1, 1);
            }
            else
            {
                int var_mesAnterior = fecha.Month; // obtengo el mes actual
                int var_anio = fecha.Year; // obtengo el año actual
                dateTime = new DateTime(var_anio - 1, 12, 1);
            }

            return dateTime;
        }

        public static DateTime getRecuperaDiaFinalMesAnterior(DateTime fecha)
        {
            int var_mesAnterior = fecha.Month; // obtengo el mes actual
            int var_anio = fecha.Year; // obtengo el año actual
            DateTime dateTime = new DateTime(var_anio, var_mesAnterior, 1).AddDays(-1);

            return dateTime;
        }

        public static IList<YouCom.DTO.TrxHorasFechasDTO> getGeneraFechas(DateTime fecha, int cantidad, bool dias, bool mes)
        {
            int cont = 0;
            string fechas = string.Empty;
            IList<YouCom.DTO.TrxHorasFechasDTO> TrxHorasFechas = new List<YouCom.DTO.TrxHorasFechasDTO>();

            for (int i = 0; i < cantidad; i++)
            {
                YouCom.DTO.TrxHorasFechasDTO hrs = new YouCom.DTO.TrxHorasFechasDTO();

                if (cont == 0)
                {
                    cont += 1;
                    hrs.FechaHora = fecha;
                    TrxHorasFechas.Add(hrs);
                }
                else if (i == cantidad)
                {
                    if (dias)
                        hrs.FechaHora = fecha.AddDays(i + 1);
                    else if (mes)
                        hrs.FechaHora = fecha.AddMonths(i + 1);

                    TrxHorasFechas.Add(hrs);
                }
                else
                {
                    if (dias)
                        hrs.FechaHora = fecha.AddDays(i);
                    else if (mes)
                        hrs.FechaHora = fecha.AddMonths(i);

                    TrxHorasFechas.Add(hrs);
                }
            }

            return TrxHorasFechas;
        }

        public static string getDespliegueDiaSemana(string pDia)
        {
            switch (pDia)
            {
                case "Monday": return "Lunes";
                case "Tuesday": return "Martes";
                case "Wednesday": return "Miercoles";
                case "Thursday": return "Jueves";
                case "Friday": return "Viernes";
                case "Saturday": return "Sabado";
                case "Sunday": return "Domingo";
                default: return pDia;
            }
        }

        public static string replace(String tag, String reemplazo, String html)
        {
            return html.Replace(tag, reemplazo);
        }

        public static string GetPropiedad(string pvarPropiedad)
        {
            AppSettingsReader appSettings = null;

            try
            {
                appSettings = new AppSettingsReader();

                return (string)appSettings.GetValue(pvarPropiedad, typeof(string));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string getGeneraClave(int largo)
        {
            string retorno = string.Empty;
            Guid guid = Guid.NewGuid();

            retorno = guid.ToString().Replace("-", "");

            retorno = retorno.Substring(0, largo);

            return retorno;
        }

        public static YouCom.DTO.Seguridad.OperadorDTO Informacionusuario()
        {
            List<YouCom.DTO.Seguridad.OperadorDTO> operador = new List<YouCom.DTO.Seguridad.OperadorDTO>();
            operador = (HttpContext.Current.Session["InformacionUsuario"] as List<YouCom.DTO.Seguridad.OperadorDTO>);

            YouCom.DTO.Seguridad.OperadorDTO theOperadorDTO = new YouCom.DTO.Seguridad.OperadorDTO();

            foreach (var item in operador)
            {
                theOperadorDTO.Usuario = item.Usuario;
                //theOperadorDTO.Nombres = item.Nombres;
                //theOperadorDTO.Paterno = item.Paterno;
                //theOperadorDTO.Materno = item.Materno;

            }
            return theOperadorDTO;
            {

            }
        }

        public static ArrayList getRecuperaCoordenadas(string pDireccion)
        {
            ArrayList myArray = new ArrayList();

            GMap GMap1 = new GMap();

            string skey = "";

            GeoCode geocode;

            geocode = GMap1.getGeoCodeRequest(pDireccion);

            myArray.Add(geocode.Placemark.coordinates.lat);
            myArray.Add(geocode.Placemark.coordinates.lng);

            return myArray;
        }

        public static string truncaTitulo(string texto, int largo)
        {
            if (texto.Length > largo)
                return String.Concat(texto.Substring(0, largo), "...");
            else
            {
                return texto;
            }
        }

        public static string getObtieneIP()
        {
            string localIP = "";

            //IPHostEntry host;
            //host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (IPAddress ip in host.AddressList)
            //{
            //    if (ip.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        localIP = ip.ToString();
            //    }
            //}

            localIP = HttpContext.Current.Request.UserHostAddress;

            return localIP;
        }
    }

    public class Formato
    {
        public static String FormatoHora(string pvarHora)
        {
            string retorno = string.Empty;
            if (!pvarHora.Contains(":"))
                retorno = pvarHora.Substring(0, 2) + ":" + pvarHora.Substring(2, 2);
            else
                retorno = pvarHora;

            return retorno;
        }

        public static String FormatoFechaWSDAP(string pvarFecha)
        {
            return pvarFecha.Substring(8, 2) + "/" + pvarFecha.Substring(5, 2) + "/" + pvarFecha.Substring(0, 4);
        }

        public static String FormatoFecha(string pvarFecha)
        {
            return pvarFecha.Substring(0, 2) + "/" + pvarFecha.Substring(3, 2) + "/" + pvarFecha.Substring(6, 4);
        }

        public static String FormatoFechaChequera(string pvarFecha)
        {
            return pvarFecha.Substring(0, 2) + "/" + pvarFecha.Substring(2, 2) + "/" + pvarFecha.Substring(4, 4);
        }
        public static String FormatoFechaTarjeta(string pvarFecha)
        {
            return pvarFecha.Substring(6, 2) + "/" + pvarFecha.Substring(4, 2) + "/" + pvarFecha.Substring(0, 4);
        }

        public static String FormatoFechaCartola(string pvarFecha)
        {
            char[] separador = { '/', ' ' };

            string[] words = pvarFecha.Split(separador);

            return words[1].PadLeft(2, '0') + "/" + words[0].PadLeft(2, '0') + "/" + words[2];
        }

        public static String FormatoFechaCalificador(string pvarFecha)
        {
            if (pvarFecha != "")
            {
                char[] separador = { '/', ' ' };

                string[] words = pvarFecha.Split(separador);
                return words[0].PadLeft(2, '0') + "/" + words[1].PadLeft(2, '0') + "/" + words[2].Substring(words[2].Length - 2, 2) + "." + words[3];
            }
            else
                return "";
        }

        public static String FormatoFechaIndexa(string pvarFecha)
        {
            string svarDia = Convert.ToDateTime(pvarFecha).Day.ToString().PadLeft(2, '0');
            string svarMes = Convert.ToDateTime(pvarFecha).Month.ToString().PadLeft(2, '0');
            string svarAnio = Convert.ToDateTime(pvarFecha).Year.ToString();
            string svarFecha = svarMes + "-" + svarDia + "-" + svarAnio;

            return svarFecha;
        }

        public static String FormatoRut(string Rut)
        {
            String DV = Rut.Substring(Rut.Length - 1, 1);
            String Rut2 = Rut.Substring(0, Rut.Length - 1);
            int Rut3 = Convert.ToInt32(Rut2);
            Rut2 = Convert.ToString(Rut3);

            Rut = Convert.ToDecimal(Rut2).ToString("###,###,##0") + "-" + DV;

            return Rut;
        }

        public static String GeneraFechaActual()
        {
            return DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
        }

        public static String LimpiarMonto(string pvarMonto)
        {
            string retorno = string.Empty;

            retorno = pvarMonto.Replace(".", "").Replace("$", "").Replace("U.F. ", "").Replace("UF ", "").Replace("US", "");

            retorno = retorno.Equals("") ? "0" : retorno;

            return retorno;
        }

        public static string RutConsulta(string rut)
        {
            return rut.Substring(0, rut.Length - 1).PadLeft(10, '0');
        }

        public static string FechaInicial(string mes, string anio)
        {
            return anio + mes + "01";
        }

        public static string RutConsultaLeasing(string rut)
        {
            return rut.Substring(0, rut.Length - 1).ToUpper();
        }

        public static string RutConsultaCompleto(string rut)
        {
            return rut.PadLeft(10, '0').ToUpper();
        }

        public static string RutConsultaCheques(string rut)
        {
            return rut.PadLeft(12, '0').ToUpper();
        }

        public static string RutConsultaCalificador(string rut)
        {
            return rut.PadLeft(11, '0').ToUpper();
        }

        public static string RutCalificador(string rut)
        {
            return rut.Replace(".", "").Replace("-", "").PadLeft(10, '0').ToUpper();
        }

        public static String FormatoNumeroUF(string pvarMonto, int largo)
        {
            string valor = string.Empty;
            int contador = 0;
            string relleno = string.Empty;
            char[] separador = { ',' };

            string[] words = pvarMonto.Split(separador);

            foreach (string s in words)
                contador += 1;

            if (contador == 2)
            {
                if (words[1].Length >= largo)
                    valor = Convert.ToDecimal(words[0]).ToString("###,###,##0") + "," + words[1].Substring(0, largo);
                else
                    valor = Convert.ToDecimal(words[0]).ToString("###,###,##0") + "," + words[1];
            }
            else
                valor = Convert.ToDecimal(words[0]).ToString("###,###,##0") + "," + relleno.PadLeft(largo, '0');

            return valor;
        }

        public static String FormatoNumeroUF_DAP(string pvarMonto, int largo)
        {
            string valor = string.Empty;
            int contador = 0;
            string relleno = string.Empty;
            char[] separador = { ',' };

            string[] words = pvarMonto.Split(separador);

            foreach (string s in words)
                contador += 1;

            if (contador == 2)
            {
                if (words[1].Length >= largo)
                    valor = Convert.ToDecimal(words[0]).ToString("###,###,##0") + "," + words[1].Substring(0, largo).PadRight(4, '0');
                else
                    valor = Convert.ToDecimal(words[0]).ToString("###,###,##0") + "," + words[1].PadRight(4, '0');
            }
            else
                valor = Convert.ToDecimal(words[0]).ToString("###,###,##0") + "," + relleno.PadLeft(largo + 1, '0');

            return valor;
        }

        public static string FechaSistemaCorta()
        {
            return DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year;
        }

        public static string FechaSistemaCortaResumen()
        {
            return DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year;
        }

        public static string FormatoMoneda(string pMoneda)
        {
            switch (pMoneda)
            {
                case "CLP": return "$ ";
                case "USD": return "US$ ";
                case "201": return "U.F. ";
                default: return string.Empty;
            }
        }

        public static String FechaTalonario(string pvarFecha)
        {
            return pvarFecha.Substring(5, 2) + "/" + pvarFecha.Substring(6, 2) + "/" + pvarFecha.Substring(0, 4);
        }

        public static String FechaTarjeta(string pvarFecha)
        {
            return pvarFecha.Substring(6, 2) + "/" + pvarFecha.Substring(4, 2) + "/" + pvarFecha.Substring(0, 4);
        }

        public static String FechaTalonarioCheque(string pvarFecha)
        {
            return pvarFecha.Substring(6, 2) + "/" + pvarFecha.Substring(4, 2) + "/" + pvarFecha.Substring(0, 4);
        }

        public static string FechaActualSinSeparacion()
        {
            return DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year + "_" + DateTime.Now.ToLongTimeString();
        }

        public static String FormatoRut2daClave(string Rut)
        {
            String DV = Rut.Substring(Rut.Length - 1, 1);
            String Rut2 = Rut.Substring(0, Rut.Length - 1);
            int Rut3 = Convert.ToInt32(Rut2);
            Rut2 = Convert.ToString(Rut3);

            Rut = Convert.ToDecimal(Rut2).ToString() + "-" + DV;

            return Rut;
        }

        public static String LimpiarRut(string pvarRut)
        {
            return pvarRut.Replace(".", "").Replace("-", "");
        }

        public static String FormatoMontoPeso(string monto, bool signo)
        {
            if (signo)
                return Convert.ToDouble(monto.Replace('.', ',')).ToString("$###,###,##0");
            else
                return Convert.ToDouble(monto.Replace('.', ',')).ToString("###,###,##0");
        }

        public static String FormatoMontoPesoSinReplace(string monto, bool signo)
        {
            if (signo)
                return Convert.ToDouble(monto).ToString("$###,###,##0");
            else
                return Convert.ToDouble(monto).ToString("###,###,##0");
        }

        public static String FormatoMontoPesoSinReplace(string monto, bool signo, string moneda)
        {
            string retorno = string.Empty;
            if (signo)
            {
                if (moneda.Equals("CLP"))
                    retorno = Convert.ToDouble(monto).ToString("$###,###,##0");
                else if (moneda.Equals("USD"))
                    retorno = Convert.ToDouble(monto).ToString("US$###,###,##0");
                else if (moneda.Equals("UFR"))
                    retorno = Formato.FormatoNumeroUF(monto, 2);
            }
            else
                retorno = Convert.ToDouble(monto).ToString("###,###,##0");

            return retorno;
        }

        public static String FormatoMontoDolarSinReplace(string monto)
        {
            return Convert.ToDouble(monto).ToString("US$###,###,##0");
        }

        public static String CambiaSeparador(string monto)
        {
            return monto.Replace('.', ',');
        }

        public static String LimpiaParametro(string strIn)
        {
            string salida = string.Empty;

            if (strIn != null)
            {
                // Replace invalid characters with empty strings.

                char[] separador = { ' ' };

                string[] words = strIn.Split(separador);

                foreach (string s in words)
                {
                    salida = salida + System.Text.RegularExpressions.Regex.Replace(s.ToString(), @"[^\w\./:@-]", "") + " ";
                }
            }

            return salida.TrimEnd();
        }

        public static String LimpiaComentario(string strIn)
        {
            string retorno = strIn;

            retorno = retorno.Replace("char(34)", "");
            retorno = retorno.Replace("'", "");
            retorno = retorno.Replace("--", "");
            retorno = retorno.Replace("<", "");
            retorno = retorno.Replace("[", "");
            retorno = retorno.Replace("&lt;", "");
            retorno = retorno.Replace(">", "");
            retorno = retorno.Replace("&gt", "");
            retorno = retorno.Replace("&quot", "");
            retorno = retorno.Replace("&#x27", "");
            retorno = retorno.Replace("%", "");
            retorno = retorno.Replace("&#x2F", "");
            retorno = retorno.Replace("/*", "");
            retorno = retorno.Replace("*/", "");
            retorno = retorno.Replace("request", "");
            retorno = retorno.Replace("select", "");
            retorno = retorno.Replace("declare", "");
            retorno = retorno.Replace("insert", "");
            retorno = retorno.Replace("update", "");
            retorno = retorno.Replace("delete", "");
            retorno = retorno.Replace("drop", "");
            retorno = retorno.Replace("exec(", "");
            retorno = retorno.Replace("execute(", "");
            retorno = retorno.Replace("cast(", "");
            retorno = retorno.Replace("char", "");
            retorno = retorno.Replace("nchar", "");
            retorno = retorno.Replace("varchar", "");
            retorno = retorno.Replace("nvarchar", "");
            retorno = retorno.Replace("substring", "");
            retorno = retorno.Replace("sysobject", "");
            retorno = retorno.Replace("iframe", "");
            retorno = retorno.Replace("syscolumns", "");
            retorno = retorno.Replace("truncate", "");

            return retorno;
        }

        public static String GeneraFechaPagoCompleta(DateTime fecha)
        {
            return fecha.Year + fecha.Month.ToString("00") + fecha.Day.ToString("00") + fecha.Hour.ToString("00") + fecha.Minute.ToString("00") + fecha.Second.ToString("00");
        }

        public static String GeneraFechaPagoCorta(DateTime fecha)
        {
            return fecha.Year + fecha.Month.ToString("00") + fecha.Day.ToString("00");
        }

        public static String FormatoMonto(string pvarMonto)
        {
            string valor = string.Empty;
            char[] separador = { '.' };

            string[] words = pvarMonto.Split(separador);

            return words[0];
        }

        public static string QuitaCerosIzq(string valor)
        {
            int j;

            for (j = 0; j < valor.Length; j++)
            {
                if (valor.Substring(j, 1) != "0")
                {
                    valor = valor.Substring(j, valor.Length - j);
                    break;
                }

            }

            return valor;
        }

        public static List<string> getObtieneDatos(int inicio, int termino)
        {
            List<string> myList = new List<string>();

            for (int i = inicio; i <= termino; i++)
            {
                myList.Add(i.ToString().PadLeft(2, '0'));
            }

            return myList;
        }
    }

    public static class Compression
    {
        public static string Zip(string text)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();

            byte[] compressed = new byte[ms.Length];

            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];

            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);

            return Convert.ToBase64String(gzBuffer);

        }
        public static string UnZip(string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);

                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;

                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                return System.Text.Encoding.UTF8.GetString(buffer);
            }
        }
    }

    public static class IMFile
    {
        public static long FileSize(string file)
        {
            System.IO.FileInfo fileProps = new System.IO.FileInfo(file);
            long peso = fileProps.Length;
            fileProps = null;
            return peso;
        }
    }
}
