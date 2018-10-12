using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YouCom.facade.Mensajeria.Video
{
    public class VideoMensajeDirectiva
    {
        public static IList<YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO> getListadoVideoMensajeDirectiva()
        {
            Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);

            IList<YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO> IVideoMensajeDirectiva = new List<YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Video.VideoMensajeDirectivaDAL.getListadoVideoMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    string vCode;
                    string vUrl;

                    Match youtubeMatch = YoutubeVideoRegex.Match(wobjDataRow["UrlVideoMensajePropietario"].ToString());

                    if (youtubeMatch.Success)
                    {
                        YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO video_mensaje_directiva = new YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO();

                        video_mensaje_directiva.IdVideoMensajeDirectiva = decimal.Parse(wobjDataRow["IdVideoMensajeDirectiva"].ToString());

                        YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
                        myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(wobjDataRow["idMensajeDirectiva"].ToString());
                        video_mensaje_directiva.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                        video_mensaje_directiva.TituloVideoMensajeDirectiva = wobjDataRow["TituloVideoMensajeDirectiva"].ToString();
                        video_mensaje_directiva.UrlVideoMensajeDirectiva = wobjDataRow["UrlVideoMensajeDirectiva"].ToString();

                        vCode = video_mensaje_directiva.UrlVideoMensajeDirectiva.Substring((video_mensaje_directiva.UrlVideoMensajeDirectiva.LastIndexOf("v=") + 2));

                        if (vCode.Contains("&"))
                        {
                            vCode = vCode.Substring(0, vCode.LastIndexOf("&"));
                        }

                        vUrl = @"http://www.youtube.com/v/{0}&autoplay=0\";

                        string video = string.Format(vUrl, vCode);

                        video_mensaje_directiva.UrlWatchVideoMensajeDirectiva = video;

                        IVideoMensajeDirectiva.Add(video_mensaje_directiva);
                    }
                }
            }

            return IVideoMensajeDirectiva;

        }
    }
}
