using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Video;

namespace YouCom.bll.Mensajeria.Video
{
    public class VideoMensajeDirectivaBLL
    {
        public static IList<VideoMensajeDirectivaDTO> getListadoVideoMensajeDirectiva()
        {
            var VideoMensajeDirectiva = YouCom.facade.Mensajeria.Video.VideoMensajeDirectiva.getListadoVideoMensajeDirectiva();
            return VideoMensajeDirectiva;
        }

        public static VideoMensajeDirectivaDTO detalleVideoMensajeDirectiva(decimal idVideoMensajeDirectiva)
        {
            VideoMensajeDirectivaDTO VideoMensajeDirectivas;
            VideoMensajeDirectivas = YouCom.facade.Mensajeria.Video.VideoMensajeDirectiva.getListadoVideoMensajeDirectiva().Where(x => x.IdVideoMensajeDirectiva == idVideoMensajeDirectiva).First();
            return VideoMensajeDirectivas;
        }

        public static IList<VideoMensajeDirectivaDTO> getListadoVideoMensajeDirectivaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajeDirectiva().Where(x => x.TheMensajeDirectivaDTO.IdMensajeDirectiva == idMensaje).ToList();
            return mensajes;
        }

        public static VideoMensajeDirectivaDTO getListadoVideoMensajeDirectivaByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajeDirectiva().Where(x => x.TheMensajeDirectivaDTO.IdMensajeDirectiva == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(VideoMensajeDirectivaDTO myVideoMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajeDirectivaDAL.Delete(myVideoMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Insert(VideoMensajeDirectivaDTO myVideoMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajeDirectivaDAL.Insert(myVideoMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Update(VideoMensajeDirectivaDTO myVideoMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajeDirectivaDAL.Update(myVideoMensajeDirectivaDTO);
            return resultado;
        }
    }
}
