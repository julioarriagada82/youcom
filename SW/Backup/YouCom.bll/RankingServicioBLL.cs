using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class RankingServicioBLL
    {
        public static IList<RankingServicioDTO> getListadoServicios()
        {
            var Servicios = YouCom.facade.RankingServicio.getListadoRankingServicio();
            return Servicios;
        }

        public static bool Insert(DTO.RankingServicioDTO myRankingServicioDTO)
        {
            bool resultado = RankingServicioDAL.Insert(myRankingServicioDTO);
            return resultado;
        }
    }
}
