using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria.Imagen
{
    public class ImagenMensajePropietario
    {
        public static IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO> getListadoImagenMensajePropietario()
        {
            IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO> IImagenMensajePropietario = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Imagen.ImagenMensajePropietarioDAL.getListadoImagenMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO imagen_mensaje_Propietario = new YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO();

                    imagen_mensaje_Propietario.IdImagenMensajePropietario = decimal.Parse(wobjDataRow["IdImagenMensajePropietario"].ToString());

                    YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                    myMensajePropietarioDTO.IdMensajePropietario = decimal.Parse(wobjDataRow["idMensajePropietario"].ToString());
                    imagen_mensaje_Propietario.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                    imagen_mensaje_Propietario.TituloImagenMensajePropietario = wobjDataRow["TituloImagenMensajePropietario"].ToString();
                    imagen_mensaje_Propietario.ThumbailImagenMensajePropietario = wobjDataRow["ThumbailImagenMensajePropietario"].ToString();
                    imagen_mensaje_Propietario.GrandeImagenMensajePropietario = wobjDataRow["GrandeImagenMensajePropietario"].ToString();
                    
                    IImagenMensajePropietario.Add(imagen_mensaje_Propietario);
                }
            }

            return IImagenMensajePropietario;

        }
    }
}
