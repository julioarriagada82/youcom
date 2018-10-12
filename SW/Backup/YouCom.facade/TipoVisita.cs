using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class TipoVisita
    {
        public static IList<YouCom.DTO.TipoVisitaDTO> getListadoTipoVisita()
        {
            IList<YouCom.DTO.TipoVisitaDTO> ITipoVisita = new List<YouCom.DTO.TipoVisitaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.TipoVisitaDAL.getListadoTipoVisita(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.TipoVisitaDTO tipo_Visita = new YouCom.DTO.TipoVisitaDTO();

                    tipo_Visita.IdTipoVisita = decimal.Parse(wobjDataRow["IdTipoVisita"].ToString());
                    tipo_Visita.NombreTipoVisita = wobjDataRow["nombreTipoVisita"].ToString();

                    tipo_Visita.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_Visita.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_Visita.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_Visita.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_Visita.Estado = wobjDataRow["estado"].ToString();

                    ITipoVisita.Add(tipo_Visita);
                }
            }

            return ITipoVisita;

        }

        public static bool ValidaEliminacionTipoVisita(YouCom.DTO.TipoVisitaDTO theTipoVisitaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.TipoVisitaDAL.ValidaEliminacionTipoVisita(theTipoVisitaDTO, ref pobjDataTable))
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
