using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Mensajeria.Imagen
{
    public class ImagenMensajeDirectiva
    {
        public static IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO> getListadoImagenMensajeDirectiva()
        {
            IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO> IImagenMensajeDirectiva = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Imagen.ImagenMensajeDirectivaDAL.getListadoImagenMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO imagen_mensaje_directiva = new YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO();

                    imagen_mensaje_directiva.IdImagenMensajeDirectiva = decimal.Parse(wobjDataRow["IdImagenMensajeDirectiva"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
                    myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(wobjDataRow["idMensajeDirectiva"].ToString());
                    imagen_mensaje_directiva.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    imagen_mensaje_directiva.TituloImagenMensajeDirectiva = wobjDataRow["TituloImagenMensajeDirectiva"].ToString();
                    imagen_mensaje_directiva.ThumbailImagenMensajeDirectiva = wobjDataRow["ThumbailImagenMensajeDirectiva"].ToString();
                    imagen_mensaje_directiva.GrandeImagenMensajeDirectiva = wobjDataRow["GrandeImagenMensajeDirectiva"].ToString();
                    
                    IImagenMensajeDirectiva.Add(imagen_mensaje_directiva);
                }
            }

            return IImagenMensajeDirectiva;

        }
    }
}
