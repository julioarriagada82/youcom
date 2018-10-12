using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YouCom.facade.Mensajeria.Video
{
    public class VideoMensajePropietario
    {
        public static IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO> getListadoVideoMensajePropietario()
        {
            Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);

            IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO> IVideoMensajePropietario = new List<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Video.VideoMensajePropietarioDAL.getListadoVideoMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    string vCode;
                    string vUrl;

                    Match youtubeMatch = YoutubeVideoRegex.Match(wobjDataRow["UrlVideoMensajePropietario"].ToString());

                    if (youtubeMatch.Success)
                    {
                        YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO video_mensaje_propietario = new YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO();

                        video_mensaje_propietario.IdVideoMensajePropietario = decimal.Parse(wobjDataRow["IdVideoMensajePropietario"].ToString());

                        YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                        myMensajePropietarioDTO.IdMensajePropietario = decimal.Parse(wobjDataRow["idMensajePropietario"].ToString());
                        video_mensaje_propietario.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                        video_mensaje_propietario.TituloVideoMensajePropietario = wobjDataRow["TituloVideoMensajePropietario"].ToString();
                        video_mensaje_propietario.UrlVideoMensajePropietario = wobjDataRow["UrlVideoMensajePropietario"].ToString();

                        vCode = video_mensaje_propietario.UrlVideoMensajePropietario.Substring((video_mensaje_propietario.UrlVideoMensajePropietario.LastIndexOf("v=") + 2));

                        if (vCode.Contains("&"))
                        {
                            vCode = vCode.Substring(0, vCode.LastIndexOf("&"));
                        }

                        vUrl = @"http://www.youtube.com/v/{0}&autoplay=0\";

                        string video = string.Format(vUrl, vCode);

                        video_mensaje_propietario.UrlWatchVideoMensajePropietario = video;

                        IVideoMensajePropietario.Add(video_mensaje_propietario);
                    }
                }
            }

            return IVideoMensajePropietario;

        }
    }
}
