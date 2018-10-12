using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.AccesoHogar;

namespace YouCom.bll.AccesoHogar
{
    public class AccesoHogarBLL
    {
        public static IList<AccesoHogarDTO> getListadoAccesoHogar()
        {
            YouCom.facade.AccesoHogar.AccesoHogar AccesoHogarFA = new YouCom.facade.AccesoHogar.AccesoHogar();
            var AccesoHogar = YouCom.facade.AccesoHogar.AccesoHogar.getListadoAccesoHogar();
            return AccesoHogar;
        }

        public static AccesoHogarDTO detalleAccesoHogar(decimal idAccesoHogar)
        {
            AccesoHogarDTO AccesoHogars;
            AccesoHogars = facade.AccesoHogar.AccesoHogar.getListadoAccesoHogar().Where(x => x.IdAccesoHogar == idAccesoHogar).First();
            return AccesoHogars;
        }

        public static IList<AccesoHogarDTO> getListadoAccesoHogarByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var accesos = listaAccesoHogarActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return accesos;
        }

        public static IList<AccesoHogarDTO> getListadoAccesoHogarByCasa(decimal idCondominio, decimal idComunidad, decimal idCasa)
        {
            var accesos = listaAccesoHogarActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad && x.TheCasaDTO.IdCasa == idCasa).ToList();
            return accesos;
        }

        public static IList<AccesoHogarDTO> listaAccesoHogarActivo()
        {
            IList<AccesoHogarDTO> AccesoHogars;
            AccesoHogars = facade.AccesoHogar.AccesoHogar.getListadoAccesoHogar().Where(x => x.Estado == "1").ToList();
            return AccesoHogars;
        }

        public static IList<AccesoHogarDTO> listaAccesoHogarInactivo()
        {
            IList<AccesoHogarDTO> AccesoHogars;
            AccesoHogars = facade.AccesoHogar.AccesoHogar.getListadoAccesoHogar().Where(x => x.Estado == "2").ToList();
            return AccesoHogars;
        }

        public static bool Delete(DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool resultado = YouCom.DAL.AccesoHogar.AccesoHogarDAL.Delete(myAccesoHogarDTO);
            return resultado;
        }

        public static bool Insert(DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool resultado = YouCom.DAL.AccesoHogar.AccesoHogarDAL.Insert(myAccesoHogarDTO);
            return resultado;
        }

        public static bool Update(DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool resultado = YouCom.DAL.AccesoHogar.AccesoHogarDAL.Update(myAccesoHogarDTO);
            return resultado;
        }

        public static bool ActivaAccesoHogar(AccesoHogarDTO theAccesoHogarDTO)
        {
            bool respuesta = YouCom.DAL.AccesoHogar.AccesoHogarDAL.ActivaAccesoHogar(theAccesoHogarDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAccesoHogar(AccesoHogarDTO theAccesoHogarDTO)
        {
            bool respuesta = facade.AccesoHogar.AccesoHogar.ValidaEliminacionAccesoHogar(theAccesoHogarDTO);
            return respuesta;
        }
    }
}
