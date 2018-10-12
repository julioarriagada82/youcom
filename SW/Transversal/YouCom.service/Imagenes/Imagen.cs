using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace YouCom.Service.Imagenes
{
    public class Imagen
    {
        public static string ProcessFileResize(System.Web.UI.WebControls.FileUpload file, string ruta, int width, int height, Page pag)
        {
            string nombre_archivo = "";
            Random myRandom = new Random();
            string xName = myRandom.Next(1, 1000000).ToString();
            if (Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Length > 16)
            {
                nombre_archivo = xName + "_" + Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Substring(0, 16) + Intermedia.IMSystem.IMFile.IMFile.GetExtensionFile(file.PostedFile.FileName);
            }
            else
            {
                nombre_archivo = xName + "_" + Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Substring(0, Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.PostedFile.FileName).Length) + Intermedia.IMSystem.IMFile.IMFile.GetExtensionFile(file.PostedFile.FileName);
            }

            System.Drawing.Bitmap originalBMP = new System.Drawing.Bitmap(file.FileContent);

            // Calculate the new image dimensions
            //int origWidth = originalBMP.Width;
            //int origHeight = originalBMP.Height;
            //int sngRatio = origWidth / origHeight;
            int newWidth = width;
            int newHeight = height;

            // Create a new bitmap which will hold the previous resized bitmap
            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(originalBMP, newWidth, newHeight);

            // Create a graphic based on the new bitmap
            System.Drawing.Graphics oGraphics = System.Drawing.Graphics.FromImage(newBMP);
            // Set the properties for the new graphic file
            oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
            // Save the new graphic file to the server
            newBMP.Save(pag.Server.MapPath(ruta + nombre_archivo));

            // Once finished with the bitmap objects, we deallocate them.
            originalBMP.Dispose();
            newBMP.Dispose();
            oGraphics.Dispose();

            return nombre_archivo;
        }
    }
}
