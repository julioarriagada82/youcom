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
                    tipo_Visita.IdPortero = decimal.Parse(wobjDataRow["IdTurnoDiario"].ToString());
                    tipo_Visita.IdHorario = decimal.Parse(wobjDataRow["IdTurnoDiario"].ToString());
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
