using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Servicio;
using YouCom.DAL;

namespace YouCom.bll
{
    public class EmpresaServicioBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<EmpresaServicioDTO> getListadoEmpresaServicio()
        {
            var empresa_servicio = YouCom.facade.EmpresaServicio.getListadoEmpresaServicio();
            return empresa_servicio;
        }

        public static EmpresaServicioDTO detalleEmpresaServicio(decimal idEmpresaServicio)
        {
            EmpresaServicioDTO empresa_servicio;
            empresa_servicio = facade.EmpresaServicio.getListadoEmpresaServicio().Where(x => x.IdEmpresaServicio == idEmpresaServicio).First();
            return empresa_servicio;
        }

        public static EmpresaServicioDTO detalleEmpresaServicioByRut(string rutEmpresa)
        {
            EmpresaServicioDTO empresa_servicio;
            empresa_servicio = facade.EmpresaServicio.getListadoEmpresaServicio().Where(x => x.RutEmpresaServicio == rutEmpresa).First();
            return empresa_servicio;
        }

        public static IList<EmpresaServicioDTO> getListadoEmpresaServicioByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var empresas = listaEmpresaServicioActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return empresas;
        }

        public static IList<EmpresaServicioDTO> listaEmpresaServicioActivo()
        {
            IList<EmpresaServicioDTO> empresa_servicio;
            empresa_servicio = facade.EmpresaServicio.getListadoEmpresaServicio().Where(x => x.Estado == "1").ToList();
            return empresa_servicio;
        }

        public static IList<EmpresaServicioDTO> listaEmpresaServicioInactivo()
        {
            IList<EmpresaServicioDTO> empresa_servicio;
            empresa_servicio = facade.EmpresaServicio.getListadoEmpresaServicio().Where(x => x.Estado == "2").ToList();
            return empresa_servicio;
        }

        public static bool Delete(DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO)
        {
            bool resultado = EmpresaServicioDAL.Delete(myEmpresaServicioDTO);
            return resultado;
        }

        public static bool Insert(DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO)
        {
            bool resultado = EmpresaServicioDAL.Insert(myEmpresaServicioDTO);
            return resultado;
        }

        public static bool Update(DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO)
        {
            bool resultado = EmpresaServicioDAL.Update(myEmpresaServicioDTO);
            return resultado;
        }

        public static bool ActivaEmpresaServicio(EmpresaServicioDTO theEmpresaServicioDTO)
        {
            bool respuesta = EmpresaServicioDAL.ActivaEmpresaServicio(theEmpresaServicioDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionEmpresaServicio(EmpresaServicioDTO theEmpresaServicioDTO)
        {
            bool respuesta = facade.EmpresaServicio.ValidaEliminacionEmpresaServicio(theEmpresaServicioDTO);
            return respuesta;
        }
    }
}
