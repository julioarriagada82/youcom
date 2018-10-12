using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Avisos
{
    public class ImagenAviso
    {
        public static IList<YouCom.DTO.Avisos.ImagenAvisoDTO> getListadoImagenAviso()
        {
            IList<YouCom.DTO.Avisos.ImagenAvisoDTO> IImagenAviso = new List<YouCom.DTO.Avisos.ImagenAvisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Avisos.ImagenAvisoDAL.getListadoImagenAviso(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Avisos.ImagenAvisoDTO imagen_aviso = new YouCom.DTO.Avisos.ImagenAvisoDTO();

                    imagen_aviso.IdImagenAviso = decimal.Parse(wobjDataRow["IdImagenAviso"].ToString());

                    YouCom.DTO.Avisos.AvisoDTO myAvisosDTO = new YouCom.DTO.Avisos.AvisoDTO();
                    myAvisosDTO.IdAviso = decimal.Parse(wobjDataRow["idAviso"].ToString());
                    imagen_aviso.TheAvisosDTO = myAvisosDTO;

                    imagen_aviso.TituloImagenAviso = wobjDataRow["TituloImagenAviso"].ToString();
                    imagen_aviso.ThumbailImagenAviso = wobjDataRow["ThumbailImagenAviso"].ToString();
                    imagen_aviso.GrandeImagenAviso = wobjDataRow["GrandeImagenAviso"].ToString();

                    IImagenAviso.Add(imagen_aviso);
                }
            }

            return IImagenAviso;

        }
    }
}
