using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YouCom.facade.Mensajeria.Video
{
    public class VideoMensajePorteria
    {
        public static IList<YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO> getListadoVideoMensajePorteria()
        {
            Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);

            IList<YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO> IVideoMensajePorteria = new List<YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Video.VideoMensajePorteriaDAL.getListadoVideoMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    string vCode;
                    string vUrl;

                    Match youtubeMatch = YoutubeVideoRegex.Match(wobjDataRow["UrlVideoMensajePropietario"].ToString());

                    if (youtubeMatch.Success)
                    {

                        YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO video_mensaje_porteria = new YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO();

                        video_mensaje_porteria.IdVideoMensajePorteria = decimal.Parse(wobjDataRow["IdVideoMensajePorteria"].ToString());

                        YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
                        myMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(wobjDataRow["idMensajePorteria"].ToString());
                        video_mensaje_porteria.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                        video_mensaje_porteria.TituloVideoMensajePorteria = wobjDataRow["TituloVideoMensajePorteria"].ToString();
                        video_mensaje_porteria.UrlVideoMensajePorteria = wobjDataRow["UrlVideoMensajePorteria"].ToString();

                        vCode = video_mensaje_porteria.UrlVideoMensajePorteria.Substring((video_mensaje_porteria.UrlVideoMensajePorteria.LastIndexOf("v=") + 2));

                        if (vCode.Contains("&"))
                        {
                            vCode = vCode.Substring(0, vCode.LastIndexOf("&"));
                        }

                        vUrl = @"http://www.youtube.com/v/{0}&autoplay=0\";

                        string video = string.Format(vUrl, vCode);

                        video_mensaje_porteria.UrlWatchVideoMensajePorteria = video;

                        IVideoMensajePorteria.Add(video_mensaje_porteria);
                    }
                }
            }

            return IVideoMensajePorteria;

        }
    }
}
