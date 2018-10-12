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
                    YouCom.DTO.PeriodoHorarioDTO periodo_horario = new YouCom.DTO.PeriodoHorarioDTO();

                    periodo_horario.IdPeriodoHorario = decimal.Parse(wobjDataRow["IdPeriodoHorario"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    periodo_horario.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    periodo_horario.TheComunidadDTO = myComunidadDTO;

                    periodo_horario.NombrePeriodoHorario = wobjDataRow["nombrePeriodoHorario"].ToString();

                    periodo_horario.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    periodo_horario.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    periodo_horario.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    periodo_horario.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    periodo_horario.Estado = wobjDataRow["estado"].ToString();

                    IPeriodoHorario.Add(periodo_horario);
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
