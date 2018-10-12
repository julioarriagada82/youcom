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
                    YouCom.DTO.HorarioTurnoDTO tipo_aviso = new YouCom.DTO.HorarioTurnoDTO();

                    tipo_aviso.IdHorarioTurno = decimal.Parse(wobjDataRow["IdHorarioTurno"].ToString());
                    tipo_aviso.IdPeriodo = decimal.Parse(wobjDataRow["IdPeriodo"].ToString());
                    tipo_aviso.HoraInicio = wobjDataRow["horaInicio"].ToString();
                    tipo_aviso.HoraTermino = wobjDataRow["horaTermino"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    IHorarioTurno.Add(tipo_aviso);
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
