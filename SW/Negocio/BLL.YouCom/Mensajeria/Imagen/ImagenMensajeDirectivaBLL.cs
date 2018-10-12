using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Mensajeria.Imagen;

namespace YouCom.bll.Mensajeria.Imagen
{
    public class ImagenMensajeDirectivaBLL
    {
        public static IList<ImagenMensajeDirectivaDTO> getListadoImagenMensajeDirectiva()
        {
            var ImagenMensajeDirectiva = YouCom.facade.Mensajeria.Imagen.ImagenMensajeDirectiva.getListadoImagenMensajeDirectiva();
            return ImagenMensajeDirectiva;
        }

        public static ImagenMensajeDirectivaDTO detalleImagenMensajeDirectiva(decimal idImagenMensajeDirectiva)
        {
            ImagenMensajeDirectivaDTO ImagenMensajeDirectivas;
            ImagenMensajeDirectivas = YouCom.facade.Mensajeria.Imagen.ImagenMensajeDirectiva.getListadoImagenMensajeDirectiva().Where(x => x.IdImagenMensajeDirectiva == idImagenMensajeDirectiva).First();
            return ImagenMensajeDirectivas;
        }

        public static IList<ImagenMensajeDirectivaDTO> getListadoImagenMensajeDirectivaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajeDirectiva().Where(x => x.TheMensajeDirectivaDTO.IdMensajeDirectiva == idMensaje).ToList();
            return mensajes;
        }

        public static ImagenMensajeDirectivaDTO getListadoImagenMensajeDirectivaByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajeDirectiva().Where(x => x.TheMensajeDirectivaDTO.IdMensajeDirectiva == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(ImagenMensajeDirectivaDTO myImagenMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajeDirectivaDAL.Delete(myImagenMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Insert(ImagenMensajeDirectivaDTO myImagenMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajeDirectivaDAL.Insert(myImagenMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Update(ImagenMensajeDirectivaDTO myImagenMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajeDirectivaDAL.Update(myImagenMensajeDirectivaDTO);
            return resultado;
        }
    }
}
