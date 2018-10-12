using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Imagen;

namespace YouCom.bll.Mensajeria.Imagen
{
    public class ImagenMensajeNoticiaBLL
    {
        public static IList<ImagenMensajeNoticiaDTO> getListadoImagenMensajeNoticia()
        {
            var ImagenMensajeNoticia = YouCom.facade.Mensajeria.Imagen.ImagenMensajeNoticia.getListadoImagenMensajeNoticia();
            return ImagenMensajeNoticia;
        }

        public static ImagenMensajeNoticiaDTO detalleImagenMensajeNoticia(decimal idImagenMensajeNoticia)
        {
            ImagenMensajeNoticiaDTO ImagenMensajeNoticias;
            ImagenMensajeNoticias = YouCom.facade.Mensajeria.Imagen.ImagenMensajeNoticia.getListadoImagenMensajeNoticia().Where(x => x.IdImagenMensajeNoticia == idImagenMensajeNoticia).First();
            return ImagenMensajeNoticias;
        }

        public static IList<ImagenMensajeNoticiaDTO> getListadoImagenMensajeNoticiaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajeNoticia().Where(x => x.TheMensajeNoticiaDTO.IdMensajeNoticia == idMensaje).ToList();
            return mensajes;
        }

        public static ImagenMensajeNoticiaDTO getListadoImagenMensajeNoticiaByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajeNoticia().Where(x => x.TheMensajeNoticiaDTO.IdMensajeNoticia == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(ImagenMensajeNoticiaDTO myImagenMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajeNoticiaDAL.Delete(myImagenMensajeNoticiaDTO);
            return resultado;
        }

        public static bool Insert(ImagenMensajeNoticiaDTO myImagenMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajeNoticiaDAL.Insert(myImagenMensajeNoticiaDTO);
            return resultado;
        }

        public static bool Update(ImagenMensajeNoticiaDTO myImagenMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajeNoticiaDAL.Update(myImagenMensajeNoticiaDTO);
            return resultado;
        }
    }
}
