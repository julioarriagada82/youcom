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
        public static IList<YouCom.DTO.Propietario.FamiliaDTO> getListadoFamilia()
        {
            var familia = YouCom.facade.Familia.getListadoFamilia();
            return familia;
        }

        public static YouCom.DTO.Propietario.FamiliaDTO detalleFamilia(decimal idFamilia)
        {
            YouCom.DTO.Propietario.FamiliaDTO casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.IdFamilia == idFamilia).First();
            return casas;
        }
        public static IList<YouCom.DTO.Propietario.FamiliaDTO> getListadoFamiliaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var familias = listaFamiliaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return familias;
        }

        public static IList<YouCom.DTO.Propietario.FamiliaDTO> getListadoFamiliaByCasa(decimal idCasa)
        {
            var familias = listaFamiliaActivo().Where(x => x.TheCasaDTO.IdCasa == idCasa).ToList();
            return familias;
        }

        public static YouCom.DTO.Propietario.FamiliaDTO detalleFamiliabyRut(string rutFamilia)
        {
            YouCom.DTO.Propietario.FamiliaDTO casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.RutFamilia == rutFamilia).First();
            return casas;
        }

        public static IList<YouCom.DTO.Propietario.FamiliaDTO> listaFamiliaActivo()
        {
            IList<YouCom.DTO.Propietario.FamiliaDTO> casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.Estado == "1").ToList();
            return casas;
        }

        public static IList<YouCom.DTO.Propietario.FamiliaDTO> listaFamiliaInactivo()
        {
            IList<YouCom.DTO.Propietario.FamiliaDTO> casas;
            casas = YouCom.facade.Familia.getListadoFamilia().Where(x => x.Estado == "2").ToList();
            return casas;
        }

        public static bool Delete(DTO.Propietario.FamiliaDTO theFamiliaDTO)
        {
            bool resultado = YouCom.DAL.Propietario.FamiliaDAL.Delete(theFamiliaDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propietario.FamiliaDTO theFamiliaDTO)
        {
            bool resultado = YouCom.DAL.Propietario.FamiliaDAL.Insert(theFamiliaDTO);
            return resultado;
        }

        public static bool Update(DTO.Propietario.FamiliaDTO theFamiliaDTO)
        {
            bool resultado = YouCom.DAL.Propietario.FamiliaDAL.Update(theFamiliaDTO);
            return resultado;
        }

        public static bool ActivaFamilia(YouCom.DTO.Propietario.FamiliaDTO theFamiliaDTO)
        {
            bool respuesta = YouCom.DAL.Propietario.FamiliaDAL.ActivaFamilia(theFamiliaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionFamilia(YouCom.DTO.Propietario.FamiliaDTO theFamiliaDTO)
        {
            bool respuesta = facade.Familia.ValidaEliminacionFamilia(theFamiliaDTO);
            return respuesta;
        }
    }
}
