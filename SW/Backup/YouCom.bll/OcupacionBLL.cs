using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class OcupacionBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<OcupacionDTO> getListadoOcupacion()
        {
            var casa = YouCom.facade.Ocupacion.getListadoOcupacion();
            return casa;
        }

        public static OcupacionDTO detalleOcupacion(decimal idOcupacion)
        {
            OcupacionDTO ocupaciones;
            ocupaciones = YouCom.facade.Ocupacion.getListadoOcupacion().Where(x => x.IdOcupacion == idOcupacion).First();
            return ocupaciones;
        }

        public static IList<OcupacionDTO> listaOcupacionActivo()
        {
            IList<OcupacionDTO> ocupaciones;
            ocupaciones = YouCom.facade.Ocupacion.getListadoOcupacion().Where(x => x.Estado == "1").ToList();
            return ocupaciones;
        }

        public static IList<OcupacionDTO> listaOcupacionInactivo()
        {
            IList<OcupacionDTO> ocupaciones;
            ocupaciones = YouCom.facade.Ocupacion.getListadoOcupacion().Where(x => x.Estado == "2").ToList();
            return ocupaciones;
        }

        public static bool Delete(OcupacionDTO theOcupacionDTO)
        {
            bool resultado = OcupacionDAL.Delete(theOcupacionDTO);
            return resultado;
        }

        public static bool Insert(DTO.OcupacionDTO theOcupacionDTO)
        {
            bool resultado = OcupacionDAL.Insert(theOcupacionDTO);
            return resultado;
        }

        public static bool Update(DTO.OcupacionDTO theOcupacionDTO)
        {
            bool resultado = OcupacionDAL.Update(theOcupacionDTO);
            return resultado;
        }

        public static bool ActivaOcupacion(OcupacionDTO theOcupacionDTO)
        {
            bool respuesta = YouCom.DAL.OcupacionDAL.ActivaOcupacion(theOcupacionDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionOcupacion(OcupacionDTO theOcupacionDTO)
        {
            bool respuesta = facade.Ocupacion.ValidaEliminacionOcupacion(theOcupacionDTO);
            return respuesta;
        }
    }
}
