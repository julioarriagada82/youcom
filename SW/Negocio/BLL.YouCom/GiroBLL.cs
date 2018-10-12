using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class GiroBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<GiroDTO> getListadoGiro()
        {
            var casa = YouCom.facade.Giro.getListadoGiro();
            return casa;
        }

        public static GiroDTO detalleGiro(decimal idGiro)
        {
            GiroDTO Giroes;
            Giroes = YouCom.facade.Giro.getListadoGiro().Where(x => x.IdGiro == idGiro).First();
            return Giroes;
        }

        public static IList<GiroDTO> listaGiroActivo()
        {
            IList<GiroDTO> Giroes;
            Giroes = YouCom.facade.Giro.getListadoGiro().Where(x => x.Estado == "1").ToList();
            return Giroes;
        }

        public static IList<GiroDTO> listaGiroInactivo()
        {
            IList<GiroDTO> Giroes;
            Giroes = YouCom.facade.Giro.getListadoGiro().Where(x => x.Estado == "2").ToList();
            return Giroes;
        }

        public static bool Delete(GiroDTO theGiroDTO)
        {
            bool resultado = GiroDAL.Delete(theGiroDTO);
            return resultado;
        }

        public static bool Insert(DTO.GiroDTO theGiroDTO)
        {
            bool resultado = GiroDAL.Insert(theGiroDTO);
            return resultado;
        }

        public static bool Update(DTO.GiroDTO theGiroDTO)
        {
            bool resultado = GiroDAL.Update(theGiroDTO);
            return resultado;
        }

        public static bool ActivaGiro(GiroDTO theGiroDTO)
        {
            bool respuesta = GiroDAL.ActivaGiro(theGiroDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionGiro(GiroDTO theGiroDTO)
        {
            bool respuesta = facade.Giro.ValidaEliminacionGiro(theGiroDTO);
            return respuesta;
        }
    }
}
