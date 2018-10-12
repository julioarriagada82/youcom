using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class TurnoDiario
    {
        public static IList<YouCom.DTO.TurnoDiarioDTO> getListadoTurnoDiario()
        {
            IList<YouCom.DTO.TurnoDiarioDTO> ITurnoDiario = new List<YouCom.DTO.TurnoDiarioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.TurnoDiarioDAL.getListadoTurnoDiario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.TurnoDiarioDTO tipo_Visita = new YouCom.DTO.TurnoDiarioDTO();

                    tipo_Visita.IdTurnoDiario = decimal.Parse(wobjDataRow["IdTurnoDiario"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    tipo_Visita.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    tipo_Visita.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    tipo_Visita.ThePorteriaDTO = myPorteriaDTO;

                    YouCom.DTO.HorarioTurnoDTO myHorarioTurnoDTO = new YouCom.DTO.HorarioTurnoDTO();
                    myHorarioTurnoDTO.IdHorarioTurno = decimal.Parse(wobjDataRow["IdHorarioTurno"].ToString());
                    tipo_Visita.TheHorarioTurnoDTO = myHorarioTurnoDTO;

                    tipo_Visita.NombreTurnoDiario = wobjDataRow["nombreTurnoDiario"].ToString();

                    tipo_Visita.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_Visita.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_Visita.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_Visita.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_Visita.Estado = wobjDataRow["estado"].ToString();

                    ITurnoDiario.Add(tipo_Visita);
                }
            }

            return ITurnoDiario;

        }

        public static bool ValidaEliminacionTurnoDiario(YouCom.DTO.TurnoDiarioDTO theTurnoDiarioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.TurnoDiarioDAL.ValidaEliminacionTurnoDiario(theTurnoDiarioDTO, ref pobjDataTable))
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
