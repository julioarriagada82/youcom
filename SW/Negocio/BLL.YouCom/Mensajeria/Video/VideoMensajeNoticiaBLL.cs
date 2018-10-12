using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Video;

namespace YouCom.bll.Mensajeria.Video
{
    public class VideoMensajeNoticiaBLL
    {
        public static IList<VideoMensajeNoticiaDTO> getListadoVideoMensajeNoticia()
        {
            var VideoMensajeNoticia = YouCom.facade.Mensajeria.Video.VideoMensajeNoticia.getListadoVideoMensajeNoticia();
            return VideoMensajeNoticia;
        }

        public static VideoMensajeNoticiaDTO detalleVideoMensajeNoticia(decimal idVideoMensajeNoticia)
        {
            VideoMensajeNoticiaDTO VideoMensajeNoticias;
            VideoMensajeNoticias = YouCom.facade.Mensajeria.Video.VideoMensajeNoticia.getListadoVideoMensajeNoticia().Where(x => x.IdVideoMensajeNoticia == idVideoMensajeNoticia).First();
            return VideoMensajeNoticias;
        }

        public static IList<VideoMensajeNoticiaDTO> getListadoVideoMensajeNoticiaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajeNoticia().Where(x => x.TheMensajeNoticiaDTO.IdMensajeNoticia == idMensaje).ToList();
            return mensajes;
        }

        public static VideoMensajeNoticiaDTO getListadoVideoMensajeNoticiaByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajeNoticia().Where(x => x.TheMensajeNoticiaDTO.IdMensajeNoticia == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(VideoMensajeNoticiaDTO myVideoMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajeNoticiaDAL.Delete(myVideoMensajeNoticiaDTO);
            return resultado;
        }

        public static bool Insert(VideoMensajeNoticiaDTO myVideoMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajeNoticiaDAL.Insert(myVideoMensajeNoticiaDTO);
            return resultado;
        }

        public static bool Update(VideoMensajeNoticiaDTO myVideoMensajeNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajeNoticiaDAL.Update(myVideoMensajeNoticiaDTO);
            return resultado;
        }
    }
}
