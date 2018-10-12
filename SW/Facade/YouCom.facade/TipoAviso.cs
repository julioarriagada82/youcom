using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class TipoAviso
    {
        public static IList<YouCom.DTO.Avisos.TipoAvisoDTO> getListadoTipoAviso()
        {
            IList<YouCom.DTO.Avisos.TipoAvisoDTO> ITipoAviso = new List<YouCom.DTO.Avisos.TipoAvisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.TipoAvisoDAL.getListadoTipoAviso(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Avisos.TipoAvisoDTO tipo_aviso = new YouCom.DTO.Avisos.TipoAvisoDTO();

                    tipo_aviso.IdTipoAviso = decimal.Parse(wobjDataRow["IdTipoAviso"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    tipo_aviso.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    tipo_aviso.TheComunidadDTO = myComunidadDTO;

                    tipo_aviso.NombreTipoAviso = wobjDataRow["nombreTipoAviso"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    ITipoAviso.Add(tipo_aviso);
                }
            }

            return ITipoAviso;

        }

        public static bool ValidaEliminacionTipoAviso(YouCom.DTO.Avisos.TipoAvisoDTO theTipoAvisoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.TipoAvisoDAL.ValidaEliminacionTipoAviso(theTipoAvisoDTO, ref pobjDataTable))
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
