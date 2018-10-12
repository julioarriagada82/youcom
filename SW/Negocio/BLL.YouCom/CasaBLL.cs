using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL.Propietario;

namespace YouCom.bll
{
    public class CasaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<DTO.Propietario.CasaDTO> getListadoCasa()
        {
            YouCom.facade.Casa CasaFA = new YouCom.facade.Casa();
            var casa = YouCom.facade.Casa.getListadoCasa();
            return casa;
        }

        public static DTO.Propietario.CasaDTO detalleCasa(decimal idCasa)
        {
            DTO.Propietario.CasaDTO casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.IdCasa == idCasa).First();
            return casas;
        }

        public static IList<DTO.Propietario.CasaDTO> getListadoCasaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var casas = listaCasaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return casas;
        }

        public static IList<DTO.Propietario.CasaDTO> getListadoCasaByComunidad(decimal idComunidad)
        {
            IList<DTO.Propietario.CasaDTO> casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return casas;
        }

        public static IList<DTO.Propietario.CasaDTO> listaCasaActivo()
        {
            IList<DTO.Propietario.CasaDTO> casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.Estado == "1").ToList();
            return casas;
        }

        public static IList<DTO.Propietario.CasaDTO> listaCasaInactivo()
        {
            IList<DTO.Propietario.CasaDTO> casas;
            casas = facade.Casa.getListadoCasa().Where(x => x.Estado == "2").ToList();
            return casas;
        }

        public static bool Delete(DTO.Propietario.CasaDTO myCasaDTO)
        {
            bool resultado = CasaDAL.Delete(myCasaDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propietario.CasaDTO myCasaDTO)
        {
            bool resultado = CasaDAL.Insert(myCasaDTO);
            return resultado;
        }

        public static bool Update(DTO.Propietario.CasaDTO myCasaDTO)
        {
            bool resultado = CasaDAL.Update(myCasaDTO);
            return resultado;
        }

        public static bool ActivaCasa(DTO.Propietario.CasaDTO theCasaDTO)
        {
            bool respuesta = CasaDAL.ActivaCasa(theCasaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionCasa(DTO.Propietario.CasaDTO theCasaDTO)
        {
            bool respuesta = facade.Casa.ValidaEliminacionCasa(theCasaDTO);
            return respuesta;
        }
    }
}
