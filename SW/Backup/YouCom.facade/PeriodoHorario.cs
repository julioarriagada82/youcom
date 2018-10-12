using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class PeriodoHorario
    {
        public static IList<YouCom.DTO.PeriodoHorarioDTO> getListadoPeriodoHorario()
        {
            IList<YouCom.DTO.PeriodoHorarioDTO> IPeriodoHorario = new List<YouCom.DTO.PeriodoHorarioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.PeriodoHorarioDAL.getListadoPeriodoHorario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.PeriodoHorarioDTO tipo_aviso = new YouCom.DTO.PeriodoHorarioDTO();

                    tipo_aviso.IdPeriodoHorario = decimal.Parse(wobjDataRow["IdPeriodoHorario"].ToString());
                    tipo_aviso.NombrePeriodoHorario = wobjDataRow["nombrePeriodoHorario"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    IPeriodoHorario.Add(tipo_aviso);
                }
            }

            return IPeriodoHorario;

        }

        public static bool ValidaEliminacionPeriodoHorario(YouCom.DTO.PeriodoHorarioDTO thePeriodoHorarioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.PeriodoHorarioDAL.ValidaEliminacionPeriodoHorario(thePeriodoHorarioDTO, ref pobjDataTable))
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
