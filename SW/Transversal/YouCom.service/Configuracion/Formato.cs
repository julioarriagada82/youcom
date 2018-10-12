using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YouCom.Service.Configuracion
{
    [Serializable()]
    public class Formato
    {
        public static String LimpiarRutsinDv(string pvarRut)
        {
            return pvarRut.Substring(0, pvarRut.Length - 1).Replace(".", "").Replace("-", "");
        }

        public static String FormatoRutSinDV(string Rut)
        {
            String Rut2 = Rut.Substring(0, Rut.Length - 1);

            return Rut2;
        }

        public static String getFormatoCelularMascara(string pvarCelular)
        {
            string salida = string.Empty;

            try
            {
                salida = "xxxxx" + pvarCelular.Substring(5, pvarCelular.Length - 5);

                return salida;
            }
            catch (Exception ex)
            {
                return pvarCelular;
            }
        }
        public static String getFormatoCorreoMascara(string pvarCorreo)
        {
            string salida = string.Empty;

            try
            {
                char[] separador = { '@' };
                char[] separador_punto = { '.' };
                string[] separador_correo;
                string[] separador_correo1;
                separador_correo = pvarCorreo.ToLower().Split(separador);
                separador_correo1 = separador_correo[1].Split(separador_punto);

                salida = "xxxx" + separador_correo[0].Substring(5, separador_correo[0].Length - 5) + "@" + "xxxx" + separador_correo1[0].Substring(4, separador_correo1[0].Length - 4) + "." + separador_correo1[1].ToString();

                return salida;
            }
            catch (Exception ex)
            {
                return pvarCorreo;
            }
        }
        public static String FormatoFechaMovimientos(string pvarFecha)
        {
            if (pvarFecha != "")
            {
                char[] separador = { '/', '-' };

                string[] words = pvarFecha.Split(separador);
                return words[1].PadLeft(2, '0') + "/" + words[0].PadLeft(2, '0') + "/" + words[2];
            }
            else
                return "";
        }
        public static String FormatoFechaMovimientosDiaMesAño(string pvarFecha)
        {
            if (pvarFecha != "")
            {
                char[] separador = { '/', '-' };

                string[] words = pvarFecha.Split(separador);
                return words[1].PadLeft(2, '0') + "/" + words[0].PadLeft(2, '0') + "/" + words[2];
            }
            else
                return "";
        }

        public static string replace(String tag, String reemplazo, String html)
        {
            return html.Replace(tag, reemplazo);
        }
        public static string getRutClienteTC(YouCom.DTO.Seguridad.UsuarioDTO myUsuario)
        {
            string rut_cliente = string.Empty;

            if (myUsuario.RutCondominio != null)
                rut_cliente = string.Copy(myUsuario.RutCondominioSinDv);
            else
                rut_cliente = string.Copy(myUsuario.RutSinDV);

            return rut_cliente;
        }
        public static string getDVClienteTC(YouCom.DTO.Seguridad.UsuarioDTO myUsuario)
        {
            string rut_cliente = string.Empty;

            if (myUsuario.RutCondominio != null)
                rut_cliente = string.Copy(myUsuario.DVCondominio);
            else
                rut_cliente = string.Copy(myUsuario.DV);

            return rut_cliente;
        }

        public static string formatodenitivorut(string rutp)
        {
            string output;
            output = LimpiarRut(rutp);
            output = FormatoRut(output);
            return output;
        }
        public static String montodefinitivo(string monto, string moneda)
        {
            string montodv = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(monto))
                {

                    char[] separador = { '.' };
                    string[] montodiv;
                    double num;
                    bool isNumeric = double.TryParse(monto, out num);
                    if (isNumeric)
                    {
                        montodiv = monto.Split(separador);
                        montodv = montodiv[0];

                        if (moneda == "CLP" || moneda == "JPY")
                        {
                            montodv = Convert.ToInt32(montodiv[0]).ToString("N0");
                        }
                        else
                        {
                            //if (moneda == "USD" || moneda == "EUR" || moneda == "")
                            //{
                            if (montodiv[0] != "0")
                                montodv = Convert.ToInt32(montodiv[0]).ToString("N0") + "," + montodiv[1].ToString().Substring(0, 2);
                            else
                                montodv = Convert.ToInt32(montodiv[0]).ToString("N0") + ",00";
                            //}
                        }
                    }
                    else
                        montodv = monto;
                }
            }
            catch (Exception ex)
            {
                montodv = monto;
            }


            return montodv;

        }

        public static String FormatoHora(string pvarHora)
        {
            string retorno = string.Empty;
            if (!pvarHora.Contains(":"))
                retorno = pvarHora.Substring(0, 2) + ":" + pvarHora.Substring(2, 2);
            else
                retorno = pvarHora;

            return retorno;
        }

        /// <summary>
        /// si existe error de Dato se devuelve el dato sin formatear
        /// </summary>
        /// <param name="pvarFecha"></param>
        /// <returns></returns>
        public static String FormatoFechaWSDAP(string pvarFecha)
        {
            try
            {
                if (pvarFecha.Contains("/"))
                {
                    return pvarFecha;
                }
                else
                {
                    return pvarFecha.Substring(8, 2) + "/" + pvarFecha.Substring(5, 2) + "/" + pvarFecha.Substring(0, 4);
                }

            }
            catch (Exception ex)
            {
                return pvarFecha;
            }
        }

        public static String FormatoFecha(string pvarFecha)
        {
            return pvarFecha.Substring(0, 2) + "/" + pvarFecha.Substring(3, 2) + "/" + pvarFecha.Substring(6, 4);
        }

        public static String FormatoFechaCredito(string pvarFecha)
        {
            return pvarFecha.Substring(0, 2) + "/" + pvarFecha.Substring(2, 2) + "/" + pvarFecha.Substring(4, 4);
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
            char[] separador = { '/', '-', ' ' };

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
            if (!string.IsNullOrEmpty(Rut))
            {
                String DV = Rut.Substring(Rut.Length - 1, 1);
                String Rut2 = Rut.Substring(0, Rut.Length - 1);
                Int64 Rut3 = Convert.ToInt64(Rut2);
                Rut2 = Convert.ToString(Rut3);

                Rut = Convert.ToDecimal(Rut2).ToString("###,###,##0") + "-" + DV;
            }

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
            {
                if (!string.IsNullOrEmpty(monto))
                {
                    return Convert.ToDouble(monto).ToString("$###,###,##0");
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(monto))
                {
                    return Convert.ToDouble(monto).ToString("###,###,##0");
                }
                else
                {
                    return "0";
                }
            }
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
            //si es peso
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

        public static String LimpiaXml(string xmlEntrada)
        {
            string sXmlResponse = string.Empty;

            string valor = "xmlns=\"http://tempuri.org/\"";
            string otro = "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"";
            string otro1 = "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"";
            string otro2 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaClientesFiltrados/OpConsultarClientesFiltradosResponse\"";
            string otro3 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaResumenCuentaPorCliente/OpConsultarResumenCuentaPorClienteResponse\"";
            string otro4 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaTasasDepositosPlazo/OpConsultarTasasDepositosPlazoResponse\"";
            string otro5 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaResumenDocumentos/OpConsultarResumenDocumentosResponse\"";
            string otro6 = "xmlns=\"http://www.bancointernacional.cl/ESB/ObtieneDetalleProductoDap/OpObtenerDetalleProductoDapResponse\"";
            string otro7 = "xmlns=\"http://www.bancointernacional.cl/ESB/CalculaMontosDAP/OpCalcularMontosDAPResponse\"";
            string otro8 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaDAPVigentes/OpConsultarDAPVigentesResponse\"";
            string otro9 = "xmlns=\"http://www.bancointernacional.cl/ESB/DetalleDeposito/OpDetallarDepositoResponse\"";
            string otro10 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaChequeraDisponible/OpConsultarChequeraDisponibleResponse\"";
            string otro11 = "xsi:nil=\"true\"";
            string otro12 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaTasasDepositosPlazo/OpConsultarTasasDepositosPlazoRequest\"";
            string otro13 = "xmlns=\"http://www.bancointernacional.cl/ESB/ObtieneDetalleProductoDap/OpObtenerDetalleProductoDapRequest\"";
            string otro14 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaPagoHistoricoTarjeta/OpConsultarPagoHistoricoTarjetaResponse\"";
            string otro15 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaCreditosVigentes/OpConsultarCreditosVigentesResponse\"";
            string otro16 = "<?xml version=\"1.0\" encoding=\"utf-16\" ?> ";
            string otro17 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaCuadroPagoCredito/OpConsultarCuadroPagoCreditoResponse\"";
            string otro18 = "xmlns=\"http://www.bancointernacional.cl/ESB/CreaPagoOperacionCredito/OpCrearPagoOperacionCreditoResponse\"";
            string otro19 = "xmlns=\"http://www.bancointernacional.cl/ESB/CalculoPagoPrestamo/OpCalcularPagoPrestamoResponse\"";
            string otro20 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaPagoHistoricoTarjeta/OpConsultarPagoHistoricoTarjetaRequest\"";
            string otro21 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaCreditosVigentes/OpConsultarCreditosVigentesRequest\"";
            string otro22 = "xmlns=\"http://www.bancointernacional.cl/ESB/SimulacionCuadroPago/OpSimularCuadroPagoResponse\"";
            string otro23 = "xmlns=\"http://www.bancointernacional.cl/ESB/SimulacionCuadroPago/OpSimularCuadroPagoRequest\"";

            string otro24 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaDetalleLiquidacion/OpConsultarDetalleLiquidacionResponse\"";
            string otro25 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaDetalleLiquidacion/OpConsultarDetalleLiquidacionRequest\"";
            string otro26 = "xmlns:opc=\"http://www.bancointernacional.cl/ESB/ConsultaDetalleLiquidacion/OpConsultarDetalleLiquidacionResponse\"";
            string otro27 = "xmlns:con=\"http://www.bancointernacional.cl/ConsultaDetalleLiquidacion\"";

            string otro28 = "xmlns:opc=\"http://www.bancointernacional.cl/ESB/ConsultaDeOperaciones/OpConsultarOperacionesResponse\"";
            string otro29 = "xmlns:con=\"http://www.bancointernacional.cl/ConsultaDeOperaciones\"";


            string otro30 = "xmlns:opc=\"http://www.bancointernacional.cl/ESB/ConsultaDetalleOperacion/OpConsultarDetalleOperacionResponse\"";
            string otro31 = "xmlns:con=\"http://www.bancointernacional.cl/ConsultaDetalleOperacion\"";

            string otro32 = "opc:";

            string otro33 = "xmlns=\"http://www.bancointernacional.cl/ESB/ObtienePagoGastoCobranza/OpObtenerPagoGastoCobranzaResponse\"";
            string otro34 = "xmlns:opc=\"http://www.bancointernacional.cl/ESB/ConsultaGastoDeCobranza/OpConsultarGastoDeCobranzaResponse\"";

            string otro35 = "con:";

            string otro36 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaIndicadoresFinancieros/OpConsultarIndicadoresFinancierosResponse\"";

            string otro37 = "obt:";
            string otro38 = "opob:";
            string otro39 = "xmlns:opob=\"http://www.bancointernacional.cl/ESB/ObtieneCorrespondenciaElectronica/OpObtenerCorrespondenciaElectronicaResponse\"";
            string otro40 = "xmlns:obt=\"http://www.bancointernacional.cl/ObtieneCorrespondenciaElectronica\"";
            string otro41 = "oper:";
            string otro42 = "opm:";
            string otro43 = "xmlns:oper=\"http://www.bancointernacional.cl/OperacionesDatosCliente\"";
            string otro44 = "xmlns:opm=\"http://www.bancointernacional.cl/ESB/OperacionesDatosCliente/OpModificarDatosClienteResponse\"";

            string otro45 = "xmlns=\"http://www.bancointernacional.cl/ESB/InputaGastoDeCobranza/OpInputarGastoDeCobranzaResponse\"";

            //DID
            string otro46 = "xmlns=\"http://www.bancointernacional.cl/ESB/ValidaCodigoDeEmail/OpValidarCodigoDeEmailResponse\"";
            string otro47 = "xmlns=\"http://www.bancointernacional.cl/ESB/ActualizaCliente/OpActualizarClienteResponse\"";
            string otro48 = "xmlns=\"http://www.bancointernacional.cl/ESB/CreaNuevoCodigoDeEmail/OpCrearNuevoCodigoDeEmailResponse\"";
            string otro49 = "xmlns=\"http://www.bancointernacional.cl/ESB/CreaNuevaOTP/OpCrearNuevaOTPResponse\"";
            string otro50 = "xmlns=\"http://www.bancointernacional.cl/ESB/InsertaNumeroDeTelefono/OpInsertarNumeroDeTelefonoResponse\"";
            string otro51 = "xmlns=\"http://www.bancointernacional.cl/ESB/ValidaCodigoDeSMS/OpValidarCodigoDeSMSResponse\"";
            string otro52 = "xmlns=\"http://www.bancointernacional.cl/ESB/InsertaEmailDeCliente/OpInsertarEmailDeClienteResponse\"";
            string otro53 = "xmlns=\"http://www.bancointernacional.cl/ESB/EvaluaTransaccion/OpEvaluarTransaccionResponse\"";
            string otro54 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaCodigoDeEmail/OpConsultarCodigoDeEmailRequest\"";
            string otro55 = "xmlns=\"http://www.bancointernacional.cl/ESB/CreaNuevoCodigoDeSMS/OpCrearNuevoCodigoDeSMSRequest\"";
            string otro56 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaConfiguracionDeEmail/OpConsultarConfiguracionDeEmailResponse\"";
            string otro57 = "xmlns=\"http://www.bancointernacional.cl/ESB/CreaNuevoCodigoDeSMS/OpCrearNuevoCodigoDeSMSResponse\"";
            string otro58 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaEmailDeCliente/OpConsultarEmailDeClienteResponse\"";
            string otro59 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaTelefonoDeCliente/OpConsultarTelefonoDeClienteResponse\"";
            string otro60 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaConfiguracionDeEmail/OpConsultarConfiguracionDeEmailRequest\"";
            string otro61 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaSaldoPorCuenta/OpConsultarSaldoPorCuentaRequest\"";

            ///log detectid
            string otro62 = "xmlns=\"http://www.bancointernacional.cl/ESB/InsertaEmailDeCliente/OpInsertarEmailDeClienteRequest\"";
            string otro63 = "xmlns=\"http://www.bancointernacional.cl/ESB/ActualizaCliente/OpActualizarClienteRequest\"";
            string otro64 = "xmlns=\"http://www.bancointernacional.cl/ESB/InsertaNumeroDeTelefono/OpInsertarNumeroDeTelefonoRequest\"";
            string otro65 = "xmlns=\"http://www.bancointernacional.cl/ESB/ValidaCodigoDeSMS/OpValidarCodigoDeSMSRequest\"";
            string otro66 = "xmlns=\"http://www.bancointernacional.cl/ESB/ValidaCodigoDeEmail/OpValidarCodigoDeEmailRequest\"";
            string otro67 = "xmlns=\"http://www.bancointernacional.cl/ESB/CreaNuevoCodigoDeEmail/OpCrearNuevoCodigoDeEmailRequest\"";
            string otro68 = "xmlns=\"http://www.bancointernacional.cl/ESB/ConsultaMovimientosCuenta/OpConsultarMovimientosCuentaRequest\"";

            //Gasto Cobranza
            string otro69 = "xmlns:con=\"http://www.bancointernacional.cl/ConsultaGastoDeCobranza\"";
            string otro70 = "xmlns:opc=\"http://www.bancointernacional.cl/ESB/ConsultaGastoDeCobranza/OpConsultarGastoDeCobranzaResponse\"";
            string otro71 = "xmlns=\"http://www.bancointernacional.cl/ESB/ReversaGastoCobranza/OpReversarGastoCobranzaResponse\"";

            //Credito Comercial
            string otro72 = "xmlns:opc1=\"http://www.bancointernacional.cl/ESB/ConsultaResumenCreditosVigentes/OpConsultarResumenCreditosVigentesResponse\"";
            string otro73 = "xmlns:opc=\"http://www.bancointernacional.cl/ESB/ConsultaResumenCreditosVigentes/OpConsultarResumenCreditosVigentesRequest\"";
            string otro74 = "xmlns:head=\"http://www.bancointernacional.cl/common/HeaderRequest\"";
            string otro75 = "xmlns:con=\"http://www.bancointernacional.cl/ConsultaResumenCreditosVigentes\"";
            string otro76 = "opc1:";
            string otro77 = "xmlns:con=\"http://www.bancointernacional.cl/ConsultaResumenCreditosVigentes/\"";

            sXmlResponse = xmlEntrada.Replace(valor, "").Replace(otro, "").Replace(otro1, "").Replace(otro2, "").Replace(otro3, "").Replace(otro4, "").Replace(otro5, "").Replace(otro6, "").Replace(otro7, "").Replace(otro8, "").Replace(otro9, "").Replace(otro10, "").Replace(otro11, "").Replace(otro12, "").Replace(otro13, "").Replace(otro14, "").Replace(otro15, "").Replace(otro16, "").Replace(otro17, "").Replace(otro18, "").Replace(otro19, "").Replace(otro20, "").Replace(otro21, "").Replace(otro22, "").Replace(otro23, "").Replace(otro24, "").Replace(otro25, "").Replace(otro26, "").Replace(otro27, "").Replace(otro28, "").Replace(otro29, "").Replace(otro30, "").Replace(otro31, "").Replace(otro32, "").Replace(otro33, "").Replace(otro34, "").Replace(otro35, "").Replace(otro36, "").Replace(otro37, "").Replace(otro38, "").Replace(otro39, "").Replace(otro40, "").Replace(otro41, "").Replace(otro42, "").Replace(otro43, "").Replace(otro44, "").Replace(otro45, "").Replace(otro46, "").Replace(otro47, "").Replace(otro48, "").Replace(otro49, "").Replace(otro50, "").Replace(otro51, "").Replace(otro52, "").Replace(otro53, "").Replace(otro54, "").Replace(otro55, "").Replace(otro56, "").Replace(otro57, "").Replace(otro58, "").Replace(otro59, "").Replace(otro60, "").Replace(otro61, "").Replace(otro62, "").Replace(otro63, "").Replace(otro64, "").Replace(otro65, "").Replace(otro66, "").Replace(otro67, "").Replace(otro68, "").Replace(otro69, "").Replace(otro70, "").Replace(otro71, "").Replace(otro72, "").Replace(otro73, "").Replace(otro74, "").Replace(otro75, "").Replace(otro76, "").Replace(otro77, "");

            return sXmlResponse;
        }
        public static bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }

            return bValid;
        }

        public static bool IsMail(string email)
        {

            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {

                if (Regex.Replace(email, expresion, String.Empty).Length == 0)

                { return true; }

                else

                { return false; }

            }
            else
            { return false; }

        }
        public static bool IsInt(String num)
        {
            try
            {
                
                Int64.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static String LimpiarMensaje(string pvarMensaje)
        {
            string retorno = string.Empty;

            retorno = pvarMensaje.Replace("<br/>", "\\n").Replace("<strong>", "").Replace("</strong>", "");

            return retorno;
        }




    }
}
