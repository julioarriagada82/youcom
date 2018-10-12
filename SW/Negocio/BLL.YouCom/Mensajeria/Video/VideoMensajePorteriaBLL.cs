using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Video;

namespace YouCom.bll.Mensajeria.Video
{
    public class VideoMensajePorteriaBLL
    {
        public static IList<VideoMensajePorteriaDTO> getListadoVideoMensajePorteria()
        {
            var VideoMensajePorteria = YouCom.facade.Mensajeria.Video.VideoMensajePorteria.getListadoVideoMensajePorteria();
            return VideoMensajePorteria;
        }

        public static VideoMensajePorteriaDTO detalleVideoMensajePorteria(decimal idVideoMensajePorteria)
        {
            VideoMensajePorteriaDTO VideoMensajePorterias;
            VideoMensajePorterias = YouCom.facade.Mensajeria.Video.VideoMensajePorteria.getListadoVideoMensajePorteria().Where(x => x.IdVideoMensajePorteria == idVideoMensajePorteria).First();
            return VideoMensajePorterias;
        }

        public static IList<VideoMensajePorteriaDTO> getListadoVideoMensajePorteriaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajePorteria().Where(x => x.TheMensajePorteriaDTO.IdMensajePorteria == idMensaje).ToList();
            return mensajes;
        }

        public static VideoMensajePorteriaDTO getListadoVideoMensajePorteriaByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajePorteria().Where(x => x.TheMensajePorteriaDTO.IdMensajePorteria == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(VideoMensajePorteriaDTO myVideoMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajePorteriaDAL.Delete(myVideoMensajePorteriaDTO);
            return resultado;
        }

        public static bool Insert(VideoMensajePorteriaDTO myVideoMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajePorteriaDAL.Insert(myVideoMensajePorteriaDTO);
            return resultado;
        }

        public static bool Update(VideoMensajePorteriaDTO myVideoMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajePorteriaDAL.Update(myVideoMensajePorteriaDTO);
            return resultado;
        }
    }
}
