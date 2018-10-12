using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class CasaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<CasaDTO> getListadoCasa()
        {
            YouCom.facade.Casa CasaFA = new YouCom.facade.Casa();
            var casa = YouCom.facade.Casa.getListadoCasa();
            return casa;
        }

        public static CasaDTO detalleCasa(decimal idCasa)
        {
            CasaDTO casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.IdCasa == idCasa).First();
            return casas;
        }

        public static IList<CasaDTO> listaCasaActivo()
        {
            IList<CasaDTO> casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.Estado == "1").ToList();
            return casas;
        }

        public static IList<CasaDTO> listaCasaInactivo()
        {
            IList<CasaDTO> casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.Estado == "2").ToList();
            return casas;
        }

        public static bool Delete(DTO.CasaDTO myCasaDTO)
        {
            bool resultado = CasaDAL.Delete(myCasaDTO);
            return resultado;
        }

        public static bool Insert(DTO.CasaDTO myCasaDTO)
        {
            bool resultado = CasaDAL.Insert(myCasaDTO);
            return resultado;
        }

        public static bool Update(DTO.CasaDTO myCasaDTO)
        {
            bool resultado = CasaDAL.Update(myCasaDTO);
            return resultado;
        }

        public static bool ActivaCasa(CasaDTO theCasaDTO)
        {
            bool respuesta = YouCom.DAL.CasaDAL.ActivaCasa(theCasaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionCasa(CasaDTO theCasaDTO)
        {
            bool respuesta = facade.Casa.ValidaEliminacionCasa(theCasaDTO);
            return respuesta;
        }
    }
}
