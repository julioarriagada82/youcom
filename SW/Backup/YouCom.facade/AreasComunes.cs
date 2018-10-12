using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class AreasComunes
    {
        public static IList<YouCom.DTO.AreasComunesDTO> getListadoAreasComunes()
        {
            IList<YouCom.DTO.AreasComunesDTO> IAreasComunes = new List<YouCom.DTO.AreasComunesDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AreasComunesDAL.getListadoAreasComunes(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AreasComunesDTO tipo_aviso = new YouCom.DTO.AreasComunesDTO();

                    tipo_aviso.IdAreasComunes = decimal.Parse(wobjDataRow["IdAreaComun"].ToString());
                    tipo_aviso.NombreAreasComunes = wobjDataRow["nombreAreaComun"].ToString();
                    tipo_aviso.CantidadHora = int.Parse(wobjDataRow["cantidadHora"].ToString());

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    IAreasComunes.Add(tipo_aviso);
                }
            }

            return IAreasComunes;

        }

        public static bool ValidaEliminacionAreasComunes(YouCom.DTO.AreasComunesDTO theAreasComunesDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AreasComunesDAL.ValidaEliminacionAreasComunes(theAreasComunesDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
    }
}
