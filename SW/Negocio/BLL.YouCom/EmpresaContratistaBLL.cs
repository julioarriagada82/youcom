using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO;

namespace YouCom.bll
{
    public class EmpresaContratistaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<EmpresaContratistaDTO> getListadoEmpresaContratista()
        {
            var EmpresaContratista = YouCom.facade.EmpresaContratista.getListadoEmpresaContratista();
            return EmpresaContratista;
        }

        public static EmpresaContratistaDTO detalleEmpresaContratista(decimal idEmpresaContratista)
        {
            EmpresaContratistaDTO EmpresaContratista;
            EmpresaContratista = facade.EmpresaContratista.getListadoEmpresaContratista().Where(x => x.IdEmpresaContratista == idEmpresaContratista).First();
            return EmpresaContratista;
        }

        public static IList<EmpresaContratistaDTO> getListadoEmpresaContratistaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var empresas = listaEmpresaContratistaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return empresas;
        }

        public static IList<EmpresaContratistaDTO> listaEmpresaContratistaActivo()
        {
            IList<EmpresaContratistaDTO> EmpresaContratista;
            EmpresaContratista = facade.EmpresaContratista.getListadoEmpresaContratista().Where(x => x.Estado == "1").ToList();
            return EmpresaContratista;
        }

        public static IList<EmpresaContratistaDTO> listaEmpresaContratistaInactivo()
        {
            IList<EmpresaContratistaDTO> EmpresaContratista;
            EmpresaContratista = facade.EmpresaContratista.getListadoEmpresaContratista().Where(x => x.Estado == "2").ToList();
            return EmpresaContratista;
        }

        public static bool Delete(DTO.EmpresaContratistaDTO myEmpresaContratistaDTO)
        {
            bool resultado = EmpresaContratistaDAL.Delete(myEmpresaContratistaDTO);
            return resultado;
        }

        public static bool Insert(DTO.EmpresaContratistaDTO myEmpresaContratistaDTO)
        {
            bool resultado = EmpresaContratistaDAL.Insert(myEmpresaContratistaDTO);
            return resultado;
        }

        public static bool Update(DTO.EmpresaContratistaDTO myEmpresaContratistaDTO)
        {
            bool resultado = EmpresaContratistaDAL.Update(myEmpresaContratistaDTO);
            return resultado;
        }

        public static bool ActivaEmpresaContratista(EmpresaContratistaDTO theEmpresaContratistaDTO)
        {
            bool respuesta = EmpresaContratistaDAL.ActivaEmpresaContratista(theEmpresaContratistaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionEmpresaContratista(EmpresaContratistaDTO theEmpresaContratistaDTO)
        {
            bool respuesta = facade.EmpresaContratista.ValidaEliminacionEmpresaContratista(theEmpresaContratistaDTO);
            return respuesta;
        }
    }
}
