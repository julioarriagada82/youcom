using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Imagen;

namespace YouCom.bll.Mensajeria.Imagen
{
    public class ImagenMensajePorteriaBLL
    {
        public static IList<ImagenMensajePorteriaDTO> getListadoImagenMensajePorteria()
        {
            var ImagenMensajePorteria = YouCom.facade.Mensajeria.Imagen.ImagenMensajePorteria.getListadoImagenMensajePorteria();
            return ImagenMensajePorteria;
        }

        public static ImagenMensajePorteriaDTO detalleImagenMensajePorteria(decimal idImagenMensajePorteria)
        {
            ImagenMensajePorteriaDTO ImagenMensajePorterias;
            ImagenMensajePorterias = YouCom.facade.Mensajeria.Imagen.ImagenMensajePorteria.getListadoImagenMensajePorteria().Where(x => x.IdImagenMensajePorteria == idImagenMensajePorteria).First();
            return ImagenMensajePorterias;
        }

        public static IList<ImagenMensajePorteriaDTO> getListadoImagenMensajePorteriaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajePorteria().Where(x => x.TheMensajePorteriaDTO.IdMensajePorteria == idMensaje).ToList();
            return mensajes;
        }

        public static ImagenMensajePorteriaDTO getListadoImagenMensajePorteriaByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajePorteria().Where(x => x.TheMensajePorteriaDTO.IdMensajePorteria == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(ImagenMensajePorteriaDTO myImagenMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajePorteriaDAL.Delete(myImagenMensajePorteriaDTO);
            return resultado;
        }

        public static bool Insert(ImagenMensajePorteriaDTO myImagenMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajePorteriaDAL.Insert(myImagenMensajePorteriaDTO);
            return resultado;
        }

        public static bool Update(ImagenMensajePorteriaDTO myImagenMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajePorteriaDAL.Update(myImagenMensajePorteriaDTO);
            return resultado;
        }
    }
}
