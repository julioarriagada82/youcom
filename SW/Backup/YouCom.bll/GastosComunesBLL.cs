using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;
namespace YouCom.bll
{
    public class GastosComunesBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<GastosComunesDTO> getListadoGastoComunes()
        {
            var gastos = YouCom.facade.GastosComunes.getListadoGastosComunes();
            return gastos;
        }

        public static GastosComunesDTO detalleGastosComunes(decimal idGastos)
        {
            GastosComunesDTO gastos;
            gastos = YouCom.facade.GastosComunes.getListadoGastosComunes().Where(x => x.IdGastoComun == idGastos).First();
            return gastos;
        }

        public static IList<GastosComunesDTO> listaGastosComunesActivo()
        {
            IList<GastosComunesDTO> gastos;
            gastos = YouCom.facade.GastosComunes.getListadoGastosComunes().Where(x => x.Estado == "1").ToList();
            return gastos;
        }

        public static IList<GastosComunesDTO> listaGastosComunesInactivo()
        {
            IList<GastosComunesDTO> gastos;
            gastos = YouCom.facade.GastosComunes.getListadoGastosComunes().Where(x => x.Estado == "2").ToList();
            return gastos;
        }

        public static bool Delete(DTO.GastosComunesDTO myGastosComunesDTO)
        {
            bool resultado = GastosComunesDAL.Delete(myGastosComunesDTO);
            return resultado;
        }

        public static bool Insert(DTO.GastosComunesDTO myGastosComunesDTO)
        {
            bool resultado = GastosComunesDAL.Insert(myGastosComunesDTO);
            return resultado;
        }

        public static bool Update(DTO.GastosComunesDTO myGastosComunesDTO)
        {
            bool resultado = GastosComunesDAL.Update(myGastosComunesDTO);
            return resultado;
        }

        public static bool ActivaGastoComun(GastosComunesDTO theGastosComunesDTO)
        {
            bool respuesta = YouCom.DAL.GastosComunesDAL.ActivaGastoComun(theGastosComunesDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionGastoComun(GastosComunesDTO theGastosComunesDTO)
        {
            bool respuesta = facade.GastosComunes.ValidaEliminacionGastoComun(theGastosComunesDTO);
            return respuesta;
        }
    }
}
