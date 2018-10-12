using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class FamiliaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<FamiliaDTO> getListadoFamilia()
        {
            var familia = YouCom.facade.Familia.getListadoFamilia();
            return familia;
        }

        public static FamiliaDTO detalleFamilia(decimal idFamilia)
        {
            FamiliaDTO casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.IdFamilia == idFamilia).First();
            return casas;
        }

        public static FamiliaDTO detalleFamiliabyRut(string rutFamilia)
        {
            FamiliaDTO casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.RutFamilia == rutFamilia).First();
            return casas;
        }

        public static IList<FamiliaDTO> listaFamiliaActivo()
        {
            IList<FamiliaDTO> casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.Estado == "1").ToList();
            return casas;
        }

        public static IList<FamiliaDTO> listaFamiliaInactivo()
        {
            IList<FamiliaDTO> casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.Estado == "2").ToList();
            return casas;
        }

        public static bool Delete(DTO.FamiliaDTO theFamiliaDTO)
        {
            bool resultado = FamiliaDAL.Delete(theFamiliaDTO);
            return resultado;
        }

        public static bool Insert(DTO.FamiliaDTO theFamiliaDTO)
        {
            bool resultado = FamiliaDAL.Insert(theFamiliaDTO);
            return resultado;
        }

        public static bool Update(DTO.FamiliaDTO theFamiliaDTO)
        {
            bool resultado = FamiliaDAL.Update(theFamiliaDTO);
            return resultado;
        }

        public static bool ActivaFamilia(FamiliaDTO theFamiliaDTO)
        {
            bool respuesta = YouCom.DAL.FamiliaDAL.ActivaFamilia(theFamiliaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionFamilia(FamiliaDTO theFamiliaDTO)
        {
            bool respuesta = facade.Familia.ValidaEliminacionFamilia(theFamiliaDTO);
            return respuesta;
        }
    }
}
