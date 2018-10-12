using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class TipoAviso
    {
        public static IList<YouCom.DTO.TipoAvisoDTO> getListadoTipoAviso()
        {
            IList<YouCom.DTO.TipoAvisoDTO> ITipoAviso = new List<YouCom.DTO.TipoAvisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.TipoAvisoDAL.getListadoTipoAviso(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.TipoAvisoDTO tipo_aviso = new YouCom.DTO.TipoAvisoDTO();

                    tipo_aviso.IdTipoAviso = decimal.Parse(wobjDataRow["IdTipoAviso"].ToString());
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

        public static bool ValidaEliminacionTipoAviso(YouCom.DTO.TipoAvisoDTO theTipoAvisoDTO)
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
