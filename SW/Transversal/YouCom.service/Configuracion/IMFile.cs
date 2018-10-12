using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YouCom.Service.Configuracion
{
    [Serializable()]
    public static class IMFile
    {
        public static long FileSize(string file)
        {
            System.IO.FileInfo fileProps = new System.IO.FileInfo(file);
            long peso = fileProps.Length;
            fileProps = null;
            return peso;
        }

        public static void EncodeBinaryFileToTextFile(string inputFileName, string outputFileName)
        {
            FileStream inFile;
            byte[] binaryData;

            //Convert file to binary file
            try
            {
                inFile = new System.IO.FileStream(inputFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                binaryData = new Byte[inFile.Length];
                long bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
                inFile.Close();
            }
            catch (System.Exception exp)
            {
                throw exp;
            }

            // Convert the binary input into Base64 UUEncoded output.
            string base64String;
            try
            {
                base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
            }
            catch (System.ArgumentNullException)
            {
                throw new ArgumentException("Binary data array is null.");
            }

            // Write the UUEncoded version to the output file.
            System.IO.StreamWriter outFile;
            try
            {
                outFile = new System.IO.StreamWriter(outputFileName, false, System.Text.Encoding.ASCII);
                outFile.Write(base64String);
                outFile.Close();
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        public static string getDevuelteStringToBase64(string inputFileName)
        {
            FileStream inFile;
            byte[] binaryData;
            string base64String = string.Empty;

            //Convert file to binary file
            try
            {
                inFile = new System.IO.FileStream(inputFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                binaryData = new Byte[inFile.Length];
                long bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
                inFile.Close();

                base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
            }
            catch (System.ArgumentNullException)
            {
                throw new ArgumentException("Binary data array is null.");
            }
            catch (System.Exception exp)
            {
                throw exp;
            }

            return inputFileName + ";" + base64String;

        }
        public static void DecodeTextFileFromBinaryFile(string inputFileName, string outputFileName)
        {
            System.IO.StreamReader inFile;
            string base64String;

            try
            {
                //get string from the text file
                char[] base64CharArray;
                inFile = new System.IO.StreamReader(inputFileName, System.Text.Encoding.ASCII);
                base64CharArray = new char[inFile.BaseStream.Length];
                inFile.Read(base64CharArray, 0, (int)inFile.BaseStream.Length);
                base64String = new string(base64CharArray);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }

            // Convert the Base64 UUEncoded input into binary output.
            byte[] binaryData;
            try
            {
                binaryData = System.Convert.FromBase64String(base64String);
            }
            catch (System.ArgumentNullException)
            {
                throw new ArgumentNullException("Base 64 string is null.");
            }
            catch (System.FormatException)
            {
                throw new FormatException("Binary data array is null.");
            }

            // Write out the decoded data.
            System.IO.FileStream outFile;
            try
            {
                outFile = new System.IO.FileStream(outputFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                outFile.Write(binaryData, 0, binaryData.Length);
                outFile.Close();
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
    }
}
