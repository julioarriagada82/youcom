using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace cl.intermedia.classes.util
{
    /// <summary>
    /// Summary description for IMUtil
    /// </summary>
    public class IMUtil
    {
        public IMUtil()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetLastRightOf(string LookFor, string myString)
        {
            int pos;
            pos = myString.LastIndexOf(LookFor);
            return myString.Substring(pos + 1);
        }

        public static string GetIndexOf(string LookFor, string myString)
        {
            int pos;
            pos = myString.IndexOf(LookFor);
            if (pos == 0) pos = 1;
            return myString.Substring(0, pos);
        }


        public static bool IsInteger(string theValue)
        {
            Regex IMIsNumber = new Regex(@"^\d+$");
            Match m = IMIsNumber.Match(theValue);
            return m.Success;
        }

        public static string ConvertirNumero(string valor)
        {
            string ValorTexto = valor;
            string ValorFinal = string.Empty;
            int z = 0;
            int x = 0;
            string Cantidad = null;

            char[] separador = { ',','.' };

            string[] words = ValorTexto.Split(separador);

            foreach (string s in words)
            {
                z += 1;
            }

            Cantidad = Convert.ToString(z).ToString();
            switch (Cantidad)
            {
                case "1":
                    foreach (string s in words)
                    {
                        if (x == 0)
                        {
                            if (s.Length.ToString() == "4")
                            {
                                ValorFinal = s.Substring(0, 1) + "." + s.Substring(1, 3);
                            }
                            else if (s.Length.ToString() == "5")
                            {
                                ValorFinal = s.Substring(0, 2) + "." + s.Substring(2, 3);
                            }
                            else if (s.Length.ToString() == "6")
                            {
                                ValorFinal = s.Substring(0, 3) + "." + s.Substring(3, 3);
                            }
                            else if (s.Length.ToString() == "7")
                            {
                                ValorFinal = s.Substring(0, 1) + "." + s.Substring(1, 3) + "." + s.Substring(4, 3);
                            }
                            else if (s.Length.ToString() == "8")
                            {
                                ValorFinal = s.Substring(0, 2) + "." + s.Substring(2, 3) + "." + s.Substring(5, 3);
                            }
                            else if (s.Length.ToString() == "9")
                            {
                                ValorFinal = s.Substring(0, 3) + "." + s.Substring(3, 3) + "." + s.Substring(6, 3);
                            }
                            else if (s.Length.ToString() == "10")
                            {
                                ValorFinal = s.Substring(0, 1) + "." + s.Substring(1, 3) + "." + s.Substring(4, 3) + "." + s.Substring(7, 3);
                            }
                            else if (s.Length.ToString() == "11")
                            {
                                ValorFinal = s.Substring(0, 2) + "." + s.Substring(2, 3) + "." + s.Substring(5, 3) + "." + s.Substring(8, 3);
                            }
                            else if (s.Length.ToString() == "12")
                            {
                                ValorFinal = s.Substring(0, 3) + "." + s.Substring(3, 3) + "." + s.Substring(6, 3) + "." + s.Substring(9, 3);
                            }
                            else if (s.Length <= 3)
                            {
                                ValorFinal = s;
                            }
                        }
                        x += 1;
                    }
                    break;
                default:
                    foreach (string s in words)
                    {
                        if (x == 0)
                        {
                            if (s.Length.ToString() == "4")
                            {
                                ValorFinal = s.Substring(0, 1) + "." + s.Substring(1, 3);
                            }
                            else if (s.Length.ToString() == "5")
                            {
                                ValorFinal = s.Substring(0, 2) + "." + s.Substring(2, 3);
                            }
                            else if (s.Length.ToString() == "6")
                            {
                                ValorFinal = s.Substring(0, 3) + "." + s.Substring(3, 3);
                            }
                            else if (s.Length.ToString() == "7")
                            {
                                ValorFinal = s.Substring(0, 1) + "." + s.Substring(1, 3) + "." + s.Substring(4, 3);
                            }
                            else if (s.Length.ToString() == "8")
                            {
                                ValorFinal = s.Substring(0, 2) + "." + s.Substring(2, 3) + "." + s.Substring(5, 3);
                            }
                            else if (s.Length.ToString() == "9")
                            {
                                ValorFinal = s.Substring(0, 3) + "." + s.Substring(3, 3) + "." + s.Substring(6, 3);
                            }
                            else if (s.Length.ToString() == "10")
                            {
                                ValorFinal = s.Substring(0, 1) + "." + s.Substring(1, 3) + "." + s.Substring(4, 3) + "." + s.Substring(7, 3);
                            }
                            else if (s.Length.ToString() == "11")
                            {
                                ValorFinal = s.Substring(0, 2) + "." + s.Substring(2, 3) + "." + s.Substring(5, 3) + "." + s.Substring(8, 3);
                            }
                            else if (s.Length.ToString() == "12")
                            {
                                ValorFinal = s.Substring(0, 3) + "." + s.Substring(3, 3) + "." + s.Substring(6, 3) + "." + s.Substring(9, 3);
                            }
                            else if (s.Length <= 3)
                            {
                                ValorFinal = s;
                            }
                        }
                        if (x == 1)
                        {
                            ValorFinal += "," + s;
                        }
                        x += 1;
                    }
                    break;
            }
            return ValorFinal;
        }
    }
}
