using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria.Imagen
{
    public class ImagenMensajeNoticia
    {
        public static IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO> getListadoImagenMensajeNoticia()
        {
            IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO> IImagenMensajeNoticia = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Imagen.ImagenMensajeNoticiaDAL.getListadoImagenMensajeNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO imagen_mensaje_Noticia = new YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO();

                    imagen_mensaje_Noticia.IdImagenMensajeNoticia = decimal.Parse(wobjDataRow["IdImagenMensajeNoticia"].ToString());

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();
                    myMensajeNoticiaDTO.IdMensajeNoticia = decimal.Parse(wobjDataRow["idMensajeNoticia"].ToString());
                    imagen_mensaje_Noticia.TheMensajeNoticiaDTO = myMensajeNoticiaDTO;

                    imagen_mensaje_Noticia.TituloImagenMensajeNoticia = wobjDataRow["TituloImagenMensajeNoticia"].ToString();
                    imagen_mensaje_Noticia.ThumbailImagenMensajeNoticia = wobjDataRow["ThumbailImagenMensajeNoticia"].ToString();
                    imagen_mensaje_Noticia.GrandeImagenMensajeNoticia = wobjDataRow["GrandeImagenMensajeNoticia"].ToString();
                    
                    IImagenMensajeNoticia.Add(imagen_mensaje_Noticia);
                }
            }

            return IImagenMensajeNoticia;

        }
    }
}
