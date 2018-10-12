using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class FrecuenciaBLL
    {
        public static IList<FrecuenciaDTO> getListadoFrecuencia()
        {
            YouCom.facade.Frecuencia FrecuenciaFA = new YouCom.facade.Frecuencia();
            var Frecuencia = YouCom.facade.Frecuencia.getListadoFrecuencia();
            return Frecuencia;
        }

        public static FrecuenciaDTO detalleFrecuencia(decimal idFrecuencia)
        {
            FrecuenciaDTO Frecuencias;
            Frecuencias = facade.Frecuencia.getListadoFrecuencia().Where(x => x.IdFrecuencia == idFrecuencia).First();
            return Frecuencias;
        }

        public static IList<FrecuenciaDTO> listaFrecuenciaActivo()
        {
            IList<FrecuenciaDTO> Frecuencias;
            Frecuencias = facade.Frecuencia.getListadoFrecuencia().Where(x => x.Estado == "1").ToList();
            return Frecuencias;
        }

        public static IList<FrecuenciaDTO> listaFrecuenciaInactivo()
        {
            IList<FrecuenciaDTO> Frecuencias;
            Frecuencias = facade.Frecuencia.getListadoFrecuencia().Where(x => x.Estado == "2").ToList();
            return Frecuencias;
        }

        public static bool Delete(DTO.FrecuenciaDTO myFrecuenciaDTO)
        {
            bool resultado = FrecuenciaDAL.Delete(myFrecuenciaDTO);
            return resultado;
        }

        public static bool Insert(DTO.FrecuenciaDTO myFrecuenciaDTO)
        {
            bool resultado = FrecuenciaDAL.Insert(myFrecuenciaDTO);
            return resultado;
        }

        public static bool Update(DTO.FrecuenciaDTO myFrecuenciaDTO)
        {
            bool resultado = FrecuenciaDAL.Update(myFrecuenciaDTO);
            return resultado;
        }

        public static bool ActivaFrecuencia(FrecuenciaDTO theFrecuenciaDTO)
        {
            bool respuesta = YouCom.DAL.FrecuenciaDAL.ActivaFrecuencia(theFrecuenciaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionFrecuencia(FrecuenciaDTO theFrecuenciaDTO)
        {
            bool respuesta = facade.Frecuencia.ValidaEliminacionFrecuencia(theFrecuenciaDTO);
            return respuesta;
        }
    }
}
