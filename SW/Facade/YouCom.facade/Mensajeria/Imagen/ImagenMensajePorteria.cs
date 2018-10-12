using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria.Imagen
{
    public class ImagenMensajePorteria
    {
        public static IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO> getListadoImagenMensajePorteria()
        {
            IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO> IImagenMensajePorteria = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Imagen.ImagenMensajePorteriaDAL.getListadoImagenMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO imagen_mensaje_Porteria = new YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO();

                    imagen_mensaje_Porteria.IdImagenMensajePorteria = decimal.Parse(wobjDataRow["IdImagenMensajePorteria"].ToString());

                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
                    myMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(wobjDataRow["idMensajePorteria"].ToString());
                    imagen_mensaje_Porteria.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                    imagen_mensaje_Porteria.TituloImagenMensajePorteria = wobjDataRow["TituloImagenMensajePorteria"].ToString();
                    imagen_mensaje_Porteria.ThumbailImagenMensajePorteria = wobjDataRow["ThumbailImagenMensajePorteria"].ToString();
                    imagen_mensaje_Porteria.GrandeImagenMensajePorteria = wobjDataRow["GrandeImagenMensajePorteria"].ToString();
                    
                    IImagenMensajePorteria.Add(imagen_mensaje_Porteria);
                }
            }

            return IImagenMensajePorteria;

        }
    }
}
