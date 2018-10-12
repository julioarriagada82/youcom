using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class EleccionNoticia
    {
        public static IList<YouCom.DTO.Mensajeria.EleccionNoticiaDTO> getListadoEleccionNoticia()
        {
            IList<YouCom.DTO.Mensajeria.EleccionNoticiaDTO> IEleccionNoticia = new List<YouCom.DTO.Mensajeria.EleccionNoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.EleccionNoticiaDAL.getListadoEleccionNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.EleccionNoticiaDTO eleccion_noticia = new YouCom.DTO.Mensajeria.EleccionNoticiaDTO();

                    eleccion_noticia.IdEleccionNoticia = decimal.Parse(wobjDataRow["IdEleccionNoticia"].ToString());

                    YouCom.DTO.NoticiaDTO myNoticiaDTO = new YouCom.DTO.NoticiaDTO();
                    myNoticiaDTO.NoticiaId = decimal.Parse(wobjDataRow["idNoticia"].ToString());
                    eleccion_noticia.TheNoticiaDTO = myNoticiaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    eleccion_noticia.TheFamiliaDTO = myFamiliaDTO;

                    eleccion_noticia.EleccionNoticiaFecha = DateTime.Parse(wobjDataRow["eleccionNoticiaFecha"].ToString());
                    eleccion_noticia.EleccionNoticiaMeGusta = wobjDataRow["eleccionNoticiaMeGusta"].ToString();

                    IEleccionNoticia.Add(eleccion_noticia);
                }
            }

            return IEleccionNoticia;

        }
    }
}
