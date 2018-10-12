using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace cl.intermedia.clases.global.file
{
    /// <summary>
    /// Summary description for IMFile
    /// </summary>
    public class IMFile
    {
        public IMFile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static long FileSize(string file)
        {
            System.IO.FileInfo fileProps = new System.IO.FileInfo(file);
            long peso = fileProps.Length;
            fileProps = null;
            return peso;
        }

        public static string FileType(string file)
        {
            System.IO.FileInfo fileProps = new System.IO.FileInfo(file);
            string type = fileProps.Extension;
            fileProps = null;
            return type;
        }

        public static void Rename(string lastName, string newName)
        {
            File.Move(lastName, newName);
        }

        public static void Delete(string fileName)
        {
            File.Delete(fileName);
        }

        public static string[] GetFiles(string directory)
        {
            //Obtiene la lista de archivos del directorio segun Path.
            string[] files = Directory.GetFiles(directory);
            return files;
        }

        public static string[] GetFolders(string directory)
        {
            string[] directorys = Directory.GetDirectories(directory);
            return directorys;
        }

        public static bool ExistDirectory(string folderName)
        {
            return Directory.Exists(folderName);
        }

        public static bool ExistFile(string fileName)
        {
            return File.Exists(fileName);
        }

        public static string GetNameFile(string file)
        {
            string fileName;
            FileInfo archivoInfo = new FileInfo(file);
            fileName = archivoInfo.Name;
            return fileName;
        }

    }
}
