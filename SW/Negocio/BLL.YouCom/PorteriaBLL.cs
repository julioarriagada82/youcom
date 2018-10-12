using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class PorteriaBLL
    {
        public static IList<PorteriaDTO> getListadoPorteria()
        {
            YouCom.facade.Porteria PorteriaFA = new YouCom.facade.Porteria();
            var Porteria = YouCom.facade.Porteria.getListadoPorteria();
            return Porteria;
        }

        public static PorteriaDTO detallePorteria(decimal idPorteria)
        {
            PorteriaDTO Porterias;
            Porterias = facade.Porteria.getListadoPorteria().Where(x => x.IdPorteria == idPorteria).First();
            return Porterias;
        }

        public static IList<PorteriaDTO> getListadoPorteriaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var porterias = listaPorteriaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return porterias;
        }

        public static IList<PorteriaDTO> getListadoPorteriaByComunidad(decimal idComunidad)
        {
            var porterias = listaPorteriaActivo().Where(x => x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return porterias;
        }

        public static IList<PorteriaDTO> listaPorteriaActivo()
        {
            IList<PorteriaDTO> Porterias;
            Porterias = facade.Porteria.getListadoPorteria().Where(x => x.Estado == "1").ToList();
            return Porterias;
        }

        public static IList<PorteriaDTO> listaPorteriaInactivo()
        {
            IList<PorteriaDTO> Porterias;
            Porterias = facade.Porteria.getListadoPorteria().Where(x => x.Estado == "2").ToList();
            return Porterias;
        }

        public static bool Delete(DTO.PorteriaDTO myPorteriaDTO)
        {
            bool resultado = PorteriaDAL.Delete(myPorteriaDTO);
            return resultado;
        }

        public static bool Insert(DTO.PorteriaDTO myPorteriaDTO)
        {
            bool resultado = PorteriaDAL.Insert(myPorteriaDTO);
            return resultado;
        }

        public static bool Update(DTO.PorteriaDTO myPorteriaDTO)
        {
            bool resultado = PorteriaDAL.Update(myPorteriaDTO);
            return resultado;
        }

        public static bool ActivaPorteria(PorteriaDTO thePorteriaDTO)
        {
            bool respuesta = PorteriaDAL.ActivaPorteria(thePorteriaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPorteria(PorteriaDTO thePorteriaDTO)
        {
            bool respuesta = facade.Porteria.ValidaEliminacionPorteria(thePorteriaDTO);
            return respuesta;
        }
    }
}
