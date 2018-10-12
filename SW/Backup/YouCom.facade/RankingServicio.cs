using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class RankingServicio
    {
        public static IList<YouCom.DTO.RankingServicioDTO> getListadoRankingServicio()
        {
            IList<YouCom.DTO.RankingServicioDTO> IRankingServicio = new List<YouCom.DTO.RankingServicioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.RankingServicioDAL.getListadoRanking(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.RankingServicioDTO ranking = new YouCom.DTO.RankingServicioDTO();

                    ranking.IdRanking = decimal.Parse(wobjDataRow["IdRanking"].ToString());
                    ranking.IdServicio = decimal.Parse(wobjDataRow["idServicio"].ToString());
                    ranking.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    ranking.Comentario = wobjDataRow["comentario"].ToString();
                    ranking.Nota = int.Parse(wobjDataRow["nota"].ToString());

                    ranking.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    ranking.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    ranking.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    ranking.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    ranking.Estado = wobjDataRow["estado"].ToString();

                    IRankingServicio.Add(ranking);
                }
            }

            return IRankingServicio;

        }
    }
}

