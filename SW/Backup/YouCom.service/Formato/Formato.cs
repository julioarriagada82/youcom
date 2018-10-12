using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.Service.Formato
{
    public class Formato
    {
        protected string formateaRut(string rut)
        {
            rut = rut.Replace(".", string.Empty).Replace("-", string.Empty).ToString();
            return rut;
        }
        public static string limpiarRut(string rut)
        {
            rut = rut.Replace(".", "").Replace("-", "");
            return rut;

        }
        public static Boolean stringValidarut(string rut)
        {
            string[] rutD;
            long number = 0;
            rutD = rut.Split('-');
            rutD[0] = rutD[0].Replace(".", "");
            bool canConvert = long.TryParse(rutD[0], out number);
            if (canConvert)
            {
                return validaRut(Convert.ToInt64(rutD[0]), Convert.ToChar(rutD[1]));
            }
            return false;
        }

        public static Boolean validaRut(Int64 rut, char dig)
        {
            if (digitoVerificador(rut) == dig.ToString().ToUpper())
                return true;
            else
                return false;
        }

        private static string digitoVerificador(Int64 rut)
        {
            Int64 Digito;
            int Contador;
            Int64 Multiplo;
            Int64 Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                    Contador = 2;
            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
                RutDigito = "K";
            if (Digito == 11)
                RutDigito = "0";

            return (RutDigito);
        }
    }
}
