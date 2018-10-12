using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL.Propietario;

namespace YouCom.bll
{
    public class OcupacionBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<DTO.Propietario.OcupacionDTO> getListadoOcupacion()
        {
            var casa = YouCom.facade.Ocupacion.getListadoOcupacion();
            return casa;
        }

        public static DTO.Propietario.OcupacionDTO detalleOcupacion(decimal idOcupacion)
        {
            DTO.Propietario.OcupacionDTO ocupaciones;
            ocupaciones = YouCom.facade.Ocupacion.getListadoOcupacion().Where(x => x.IdOcupacion == idOcupacion).First();
            return ocupaciones;
        }

        public static IList<DTO.Propietario.OcupacionDTO> listaOcupacionActivo()
        {
            IList<DTO.Propietario.OcupacionDTO> ocupaciones;
            ocupaciones = YouCom.facade.Ocupacion.getListadoOcupacion().Where(x => x.Estado == "1").ToList();
            return ocupaciones;
        }

        public static IList<DTO.Propietario.OcupacionDTO> listaOcupacionInactivo()
        {
            IList<DTO.Propietario.OcupacionDTO> ocupaciones;
            ocupaciones = YouCom.facade.Ocupacion.getListadoOcupacion().Where(x => x.Estado == "2").ToList();
            return ocupaciones;
        }

        public static bool Delete(DTO.Propietario.OcupacionDTO theOcupacionDTO)
        {
            bool resultado = OcupacionDAL.Delete(theOcupacionDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propietario.OcupacionDTO theOcupacionDTO)
        {
            bool resultado = OcupacionDAL.Insert(theOcupacionDTO);
            return resultado;
        }

        public static bool Update(DTO.Propietario.OcupacionDTO theOcupacionDTO)
        {
            bool resultado = OcupacionDAL.Update(theOcupacionDTO);
            return resultado;
        }

        public static bool ActivaOcupacion(DTO.Propietario.OcupacionDTO theOcupacionDTO)
        {
            bool respuesta = OcupacionDAL.ActivaOcupacion(theOcupacionDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionOcupacion(DTO.Propietario.OcupacionDTO theOcupacionDTO)
        {
            bool respuesta = facade.Ocupacion.ValidaEliminacionOcupacion(theOcupacionDTO);
            return respuesta;
        }
    }
}
