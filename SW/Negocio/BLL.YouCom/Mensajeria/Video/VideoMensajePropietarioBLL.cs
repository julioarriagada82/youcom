using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Video;

namespace YouCom.bll.Mensajeria.Video
{
    public class VideoMensajePropietarioBLL
    {
        public static IList<VideoMensajePropietarioDTO> getListadoVideoMensajePropietario()
        {
            var VideoMensajePropietario = YouCom.facade.Mensajeria.Video.VideoMensajePropietario.getListadoVideoMensajePropietario();
            return VideoMensajePropietario;
        }

        public static VideoMensajePropietarioDTO detalleVideoMensajePropietario(decimal idVideoMensajePropietario)
        {
            VideoMensajePropietarioDTO VideoMensajePropietarios;
            VideoMensajePropietarios = YouCom.facade.Mensajeria.Video.VideoMensajePropietario.getListadoVideoMensajePropietario().Where(x => x.IdVideoMensajePropietario == idVideoMensajePropietario).First();
            return VideoMensajePropietarios;
        }

        public static IList<VideoMensajePropietarioDTO> getListadoVideoMensajePropietarioByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajePropietario().Where(x => x.TheMensajePropietarioDTO.IdMensajePropietario == idMensaje).ToList();
            return mensajes;
        }

        public static VideoMensajePropietarioDTO getListadoVideoMensajePropietarioByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoVideoMensajePropietario().Where(x => x.TheMensajePropietarioDTO.IdMensajePropietario == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(VideoMensajePropietarioDTO myVideoMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajePropietarioDAL.Delete(myVideoMensajePropietarioDTO);
            return resultado;
        }

        public static bool Insert(VideoMensajePropietarioDTO myVideoMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajePropietarioDAL.Insert(myVideoMensajePropietarioDTO);
            return resultado;
        }

        public static bool Update(VideoMensajePropietarioDTO myVideoMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Video.VideoMensajePropietarioDAL.Update(myVideoMensajePropietarioDTO);
            return resultado;
        }
    }
}
