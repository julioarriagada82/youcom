using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class AccesoHogarBLL
    {
        public static IList<AccesoHogarDTO> getListadoAccesoHogar()
        {
            YouCom.facade.AccesoHogar AccesoHogarFA = new YouCom.facade.AccesoHogar();
            var AccesoHogar = YouCom.facade.AccesoHogar.getListadoAccesoHogar();
            return AccesoHogar;
        }

        public static AccesoHogarDTO detalleAccesoHogar(decimal idAccesoHogar)
        {
            AccesoHogarDTO AccesoHogars;
            AccesoHogars = facade.AccesoHogar.getListadoAccesoHogar().Where(x => x.IdAccesoHogar == idAccesoHogar).First();
            return AccesoHogars;
        }

        public static IList<AccesoHogarDTO> listaAccesoHogarActivo()
        {
            IList<AccesoHogarDTO> AccesoHogars;
            AccesoHogars = facade.AccesoHogar.getListadoAccesoHogar().Where(x => x.Estado == "1").ToList();
            return AccesoHogars;
        }

        public static IList<AccesoHogarDTO> listaAccesoHogarInactivo()
        {
            IList<AccesoHogarDTO> AccesoHogars;
            AccesoHogars = facade.AccesoHogar.getListadoAccesoHogar().Where(x => x.Estado == "2").ToList();
            return AccesoHogars;
        }

        public static bool Delete(DTO.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool resultado = AccesoHogarDAL.Delete(myAccesoHogarDTO);
            return resultado;
        }

        public static bool Insert(DTO.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool resultado = AccesoHogarDAL.Insert(myAccesoHogarDTO);
            return resultado;
        }

        public static bool Update(DTO.AccesoHogarDTO myAccesoHogarDTO)
        {
            bool resultado = AccesoHogarDAL.Update(myAccesoHogarDTO);
            return resultado;
        }

        public static bool ActivaAccesoHogar(AccesoHogarDTO theAccesoHogarDTO)
        {
            bool respuesta = YouCom.DAL.AccesoHogarDAL.ActivaAccesoHogar(theAccesoHogarDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAccesoHogar(AccesoHogarDTO theAccesoHogarDTO)
        {
            bool respuesta = facade.AccesoHogar.ValidaEliminacionAccesoHogar(theAccesoHogarDTO);
            return respuesta;
        }
    }
}
