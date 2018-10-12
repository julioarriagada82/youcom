using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO;

namespace YouCom.bll
{
    public class ParametrosBLL
    {
        public static IList<ParametrosDTO> getListadoParametros()
        {
            YouCom.facade.Parametros ParametrosFA = new YouCom.facade.Parametros();
            var Parametros = YouCom.facade.Parametros.getListadoParametros();
            return Parametros;
        }

        public static IList<ParametrosDTO> getListadoParametrosByConcepto(string pConcepto)
        {
            YouCom.facade.Parametros ParametrosFA = new YouCom.facade.Parametros();
            var Parametros = YouCom.facade.Parametros.getListadoParametros().Where(x => x.Concepto == pConcepto).ToList();
            return Parametros;
        }

        public static ParametrosDTO detalleParametros(decimal idParametros)
        {
            ParametrosDTO Parametross;
            Parametross = facade.Parametros.getListadoParametros().Where(x => x.IdParametro == idParametros).First();
            return Parametross;
        }

        public static IList<ParametrosDTO> listaParametrosActivo()
        {
            IList<ParametrosDTO> Parametross;
            Parametross = facade.Parametros.getListadoParametros().Where(x => x.Estado == "1").ToList();
            return Parametross;
        }

        public static IList<ParametrosDTO> listaParametrosInactivo()
        {
            IList<ParametrosDTO> Parametross;
            Parametross = facade.Parametros.getListadoParametros().Where(x => x.Estado == "2").ToList();
            return Parametross;
        }

        public static bool Delete(DTO.ParametrosDTO myParametrosDTO)
        {
            bool resultado = ParametrosDAL.Delete(myParametrosDTO);
            return resultado;
        }

        public static bool Insert(DTO.ParametrosDTO myParametrosDTO)
        {
            bool resultado = ParametrosDAL.Insert(myParametrosDTO);
            return resultado;
        }

        public static bool Update(DTO.ParametrosDTO myParametrosDTO)
        {
            bool resultado = ParametrosDAL.Update(myParametrosDTO);
            return resultado;
        }

        public static bool ActivaParametros(ParametrosDTO theParametrosDTO)
        {
            bool respuesta = YouCom.DAL.ParametrosDAL.ActivaParametros(theParametrosDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionParametros(ParametrosDTO theParametrosDTO)
        {
            bool respuesta = facade.Parametros.ValidaEliminacionParametros(theParametrosDTO);
            return respuesta;
        }
    }
}
