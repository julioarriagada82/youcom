using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace YouCom.Service.Seguridad
{
    public class Crypt
    {

        static byte[] marrSalto = new byte[] { 0x42, 0x67, 0x61, 0x4f, 0x20, 0x4d, 0x62, 0x84, 0x76, 0x62, 0x64, 0x68, 0x36, 0x22 };

        //Encripta un string en un string usando una password 
        public static string Encriptar(string pvarString,
                                       string pvarPassword)
        {
            try
            {
                PasswordDeriveBytes wobjPasswordDeriveBytes = null;

                //String a byte array. 
                byte[] warrString = System.Text.Encoding.Unicode.GetBytes(pvarString);


                //Password a Key and IV con salto.
                wobjPasswordDeriveBytes = new PasswordDeriveBytes(pvarPassword,
                                                                  marrSalto);

                byte[] warrStringEnc = Encriptar(warrString,
                                                 wobjPasswordDeriveBytes.GetBytes(32),
                                                 wobjPasswordDeriveBytes.GetBytes(16));

                return Convert.ToBase64String(warrStringEnc);
            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }



        public static byte[] Encriptar(byte[] parrString,
                                       byte[] parrKey,
                                       byte[] parrIV)
        {
            try
            {
                MemoryStream wobjMemoryStream = null;
                Rijndael wobjRijndael = null;
                CryptoStream wobjCryptoStream = null;

                wobjMemoryStream = new MemoryStream();

                //Symmetric algorithm. 
                wobjRijndael = Rijndael.Create();

                //Seteo la key y el IV. 
                wobjRijndael.Key = parrKey;
                wobjRijndael.IV = parrIV;


                wobjCryptoStream = new CryptoStream(wobjMemoryStream,
                                                    wobjRijndael.CreateEncryptor(),
                                                    CryptoStreamMode.Write);

                wobjCryptoStream.Write(parrString,
                                       0,
                                       parrString.Length);

                wobjCryptoStream.Close();

                byte[] warrStringEnc = wobjMemoryStream.ToArray();

                return warrStringEnc;
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }
        }





        public static string Desencriptar(string pvarStringEnc,
                                          string pvarPassword)
        {
            try
            {
                PasswordDeriveBytes wobjPasswordDeriveBytes = null;

                if (pvarStringEnc == "")
                    throw new Exception("Error Formato String encriptado");

                byte[] warrStringEnc = Convert.FromBase64String(pvarStringEnc);

                wobjPasswordDeriveBytes = new PasswordDeriveBytes(pvarPassword,
                                                                  marrSalto);

                byte[] warrKey = wobjPasswordDeriveBytes.GetBytes(32);

                byte[] warrIV = wobjPasswordDeriveBytes.GetBytes(16);

                byte[] warrString = Desencriptar(warrStringEnc,
                                                 warrKey,
                                                 warrIV);

                return System.Text.Encoding.Unicode.GetString(warrString);
            }

            catch (System.ArgumentNullException)
            {
                throw new ArgumentNullException("Error Formato String encriptado", new Exception());
            }

            catch (System.FormatException)
            {
                throw new FormatException("Error Formato String encriptado");
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

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
        public static byte[] Desencriptar(byte[] parrStringEnc,
                                          byte[] parrKey,
                                          byte[] parrIV)
        {
            try
            {
                MemoryStream wobjMemoryStream = null;
                Rijndael wobjRijndael = null;
                CryptoStream wobjCryptoStream = null;

                wobjMemoryStream = new MemoryStream();

                wobjRijndael = Rijndael.Create();

                wobjRijndael.Key = parrKey;

                wobjRijndael.IV = parrIV;

                wobjCryptoStream = new CryptoStream(wobjMemoryStream,
                                                    wobjRijndael.CreateDecryptor(),
                                                    CryptoStreamMode.Write);

                wobjCryptoStream.Write(parrStringEnc,
                                       0,
                                       parrStringEnc.Length);

                wobjCryptoStream.Close();

                byte[] warrString = wobjMemoryStream.ToArray();

                return warrString;
            }

            catch (CryptographicException eobjCryptographicException)
            {
                throw new CryptographicException(eobjCryptographicException.Message);
            }

            catch (Exception eobjException)
            {
                throw eobjException;
            }

        }
    }
}
