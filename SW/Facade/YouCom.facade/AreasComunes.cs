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
                    YouCom.DTO.AreasComunesDTO areas_comunes = new YouCom.DTO.AreasComunesDTO();

                    areas_comunes.IdAreasComunes = decimal.Parse(wobjDataRow["IdAreaComun"].ToString());
                    areas_comunes.NombreAreasComunes = wobjDataRow["nombreAreaComun"].ToString();
                    areas_comunes.CantidadHora = int.Parse(wobjDataRow["cantidadHora"].ToString());

                    areas_comunes.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    areas_comunes.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    areas_comunes.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    areas_comunes.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    areas_comunes.Estado = wobjDataRow["estado"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    areas_comunes.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    areas_comunes.TheComunidadDTO = myComunidadDTO;

                    IAreasComunes.Add(areas_comunes);
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
