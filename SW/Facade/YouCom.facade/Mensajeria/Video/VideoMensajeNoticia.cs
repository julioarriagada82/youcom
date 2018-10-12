using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YouCom.facade.Mensajeria.Video
{
    public class VideoMensajeNoticia
    {
        public static IList<YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO> getListadoVideoMensajeNoticia()
        {
            Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);

            IList<YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO> IVideoMensajeNoticia = new List<YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Video.VideoMensajeNoticiaDAL.getListadoVideoMensajeNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    string vCode;
                    string vUrl;

                    Match youtubeMatch = YoutubeVideoRegex.Match(wobjDataRow["UrlVideoMensajePropietario"].ToString());

                    if (youtubeMatch.Success)
                    {
                        YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO video_mensaje_noticia = new YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO();

                        video_mensaje_noticia.IdVideoMensajeNoticia = decimal.Parse(wobjDataRow["IdVideoMensajeNoticia"].ToString());

                        YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();
                        myMensajeNoticiaDTO.IdMensajeNoticia = decimal.Parse(wobjDataRow["idMensajeNoticia"].ToString());
                        video_mensaje_noticia.TheMensajeNoticiaDTO = myMensajeNoticiaDTO;

                        video_mensaje_noticia.TituloVideoMensajeNoticia = wobjDataRow["TituloVideoMensajeNoticia"].ToString();
                        video_mensaje_noticia.UrlVideoMensajeNoticia = wobjDataRow["UrlVideoMensajeNoticia"].ToString();

                        vCode = video_mensaje_noticia.UrlVideoMensajeNoticia.Substring((video_mensaje_noticia.UrlVideoMensajeNoticia.LastIndexOf("v=") + 2));

                        if (vCode.Contains("&"))
                        {
                            vCode = vCode.Substring(0, vCode.LastIndexOf("&"));
                        }

                        vUrl = @"http://www.youtube.com/v/{0}&autoplay=0\";

                        string video = string.Format(vUrl, vCode);

                        video_mensaje_noticia.UrlWatchVideoMensajeNoticia = video;

                        IVideoMensajeNoticia.Add(video_mensaje_noticia);
                    }
                }
            }

            return IVideoMensajeNoticia;

        }
    }
}
