using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll.GastosComunes
{
    public class GastoComunBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<DTO.GastosComunes.GastoComunDTO> getListadoGastoComunes()
        {
            var gastos = YouCom.facade.GastosComunes.GastoComun.getListadoGastosComunes();
            return gastos;
        }

        public static DTO.GastosComunes.GastoComunDTO detalleGastosComunes(decimal idGastos)
        {
            DTO.GastosComunes.GastoComunDTO gastos;
            gastos = YouCom.facade.GastosComunes.GastoComun.getListadoGastosComunes().Where(x => x.IdGastoComun == idGastos).First();
            return gastos;
        }

        public static IList<DTO.GastosComunes.GastoComunDTO> getListadoEventoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var gastos = listaGastosComunesActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return gastos;
        }

        public static IList<DTO.GastosComunes.GastoComunDTO> getListadoEventoByCasa(decimal idCondominio, decimal idComunidad, decimal idCasa)
        {
            var gastos = listaGastosComunesActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad && x.TheCasaDTO.IdCasa == idCasa).ToList();
            return gastos;
        }

        public static IList<DTO.GastosComunes.GastoComunDTO> listaGastosComunesActivo()
        {
            IList<DTO.GastosComunes.GastoComunDTO> gastos;
            gastos = YouCom.facade.GastosComunes.GastoComun.getListadoGastosComunes().Where(x => x.Estado == "1").ToList();
            return gastos;
        }

        public static IList<DTO.GastosComunes.GastoComunDTO> listaGastosComunesInactivo()
        {
            IList<YouCom.DTO.GastosComunes.GastoComunDTO> gastos;
            gastos = YouCom.facade.GastosComunes.GastoComun.getListadoGastosComunes().Where(x => x.Estado == "2").ToList();
            return gastos;
        }

        public static bool Delete(DTO.GastosComunes.GastoComunDTO myGastosComunesDTO)
        {
            bool resultado = DAL.GastosComunes.GastoComunDAL.Delete(myGastosComunesDTO);
            return resultado;
        }

        public static bool Insert(DTO.GastosComunes.GastoComunDTO myGastosComunesDTO)
        {
            bool resultado = DAL.GastosComunes.GastoComunDAL.Insert(myGastosComunesDTO);
            return resultado;
        }

        public static bool Update(DTO.GastosComunes.GastoComunDTO myGastosComunesDTO)
        {
            bool resultado = DAL.GastosComunes.GastoComunDAL.Update(myGastosComunesDTO);
            return resultado;
        }

        public static bool ActivaGastoComun(DTO.GastosComunes.GastoComunDTO theGastosComunesDTO)
        {
            bool respuesta = DAL.GastosComunes.GastoComunDAL.ActivaGastoComun(theGastosComunesDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionGastoComun(DTO.GastosComunes.GastoComunDTO theGastosComunesDTO)
        {
            bool respuesta = facade.GastosComunes.GastoComun.ValidaEliminacionGastoComun(theGastosComunesDTO);
            return respuesta;
        }
    }
}
