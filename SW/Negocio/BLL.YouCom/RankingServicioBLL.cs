using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Servicio;
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

        public static bool Insert(RankingServicioDTO myRankingServicioDTO)
        {
            bool resultado = RankingServicioDAL.Insert(myRankingServicioDTO);
            return resultado;
        }

        public static IList<RankingServicioDTO> listaRankingServicioActivo()
        {
            IList<RankingServicioDTO> ranking;
            ranking = facade.RankingServicio.getListadoRankingServicio().Where(x => x.Estado == "1").ToList();
            return ranking;
        }

        public static IList<RankingServicioDTO> listaRankingServicioInactivo()
        {
            IList<RankingServicioDTO> ranking;
            ranking = facade.RankingServicio.getListadoRankingServicio().Where(x => x.Estado == "2").ToList();
            return ranking;
        }

        public static IList<RankingServicioDTO> getListadoRankingServicioByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var ranking = listaRankingServicioActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return ranking;
        }

        public static RankingServicioDTO getListadoRankingServicioByFamilia(decimal idCondominio, decimal idComunidad, decimal idFamilia)
        {
            IList<RankingServicioDTO> theRankingServicioDTO = new List<RankingServicioDTO>();
            RankingServicioDTO myRankingServicioDTO = new RankingServicioDTO();

            theRankingServicioDTO = listaRankingServicioActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();

            if(theRankingServicioDTO.Any())
            {
                myRankingServicioDTO = theRankingServicioDTO.Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia).Single();
            }


            return myRankingServicioDTO;
        }

        public static int getNotaByEmpresaServicio(decimal idCondominio, decimal idComunidad, decimal idEmpresaServicio)
        {
            int nota = 0;
            IList<RankingServicioDTO> theRankingServicioDTO = new List<RankingServicioDTO>();
            RankingServicioDTO myRankingServicioDTO = new RankingServicioDTO();

            theRankingServicioDTO = listaRankingServicioActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();

            if (theRankingServicioDTO.Any())
            {
                theRankingServicioDTO = theRankingServicioDTO.Where(x => x.TheEmpresaServicioDTO.IdEmpresaServicio == idEmpresaServicio).ToList();
            }

            nota = theRankingServicioDTO.Sum(x => x.Nota) / theRankingServicioDTO.Count();

            return nota;
        }
    }
}
