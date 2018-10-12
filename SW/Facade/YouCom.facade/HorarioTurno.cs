using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class HorarioTurno
    {
        public static IList<YouCom.DTO.HorarioTurnoDTO> getListadoHorarioTurno()
        {
            IList<YouCom.DTO.HorarioTurnoDTO> IHorarioTurno = new List<YouCom.DTO.HorarioTurnoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.HorarioTurnoDAL.getListadoHorarioTurno(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.HorarioTurnoDTO horario = new YouCom.DTO.HorarioTurnoDTO();

                    horario.IdHorarioTurno = decimal.Parse(wobjDataRow["IdHorarioTurno"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    horario.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    horario.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.PeriodoHorarioDTO myPeriodoHorarioDTO = new YouCom.DTO.PeriodoHorarioDTO();
                    myPeriodoHorarioDTO.IdPeriodoHorario = decimal.Parse(wobjDataRow["idPeriodoHorario"].ToString());
                    horario.ThePeriodoHorarioDTO = myPeriodoHorarioDTO;

                    horario.HoraInicio = wobjDataRow["horaInicio"].ToString();
                    horario.HoraTermino = wobjDataRow["horaTermino"].ToString();

                    horario.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    horario.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    horario.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    horario.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    horario.Estado = wobjDataRow["estado"].ToString();

                    IHorarioTurno.Add(horario);
                }
            }

            return IHorarioTurno;

        }

        public static bool ValidaEliminacionHorarioTurno(YouCom.DTO.HorarioTurnoDTO theHorarioTurnoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.HorarioTurnoDAL.ValidaEliminacionHorarioTurno(theHorarioTurnoDTO, ref pobjDataTable))
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
