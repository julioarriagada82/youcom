using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class PaisBLL
    {
        public static IList<PaisDTO> getListadoPais()
        {
            YouCom.facade.Pais PaisFA = new YouCom.facade.Pais();
            var Pais = YouCom.facade.Pais.getListadoPais();
            return Pais;
        }

        public static PaisDTO detallePais(decimal idPais)
        {
            PaisDTO Paiss;
            Paiss = facade.Pais.getListadoPais().Where(x => x.IdPais == idPais).First();
            return Paiss;
        }


        public static IList<PaisDTO> listaPaisActivo()
        {
            IList<PaisDTO> Paiss;
            Paiss = facade.Pais.getListadoPais().Where(x => x.Estado == "1").ToList();
            return Paiss;
        }

        public static IList<PaisDTO> listaPaisInactivo()
        {
            IList<PaisDTO> Paiss;
            Paiss = facade.Pais.getListadoPais().Where(x => x.Estado == "2").ToList();
            return Paiss;
        }

        public static bool Delete(DTO.PaisDTO myPaisDTO)
        {
            bool resultado = PaisDAL.Delete(myPaisDTO);
            return resultado;
        }

        public static bool Insert(DTO.PaisDTO myPaisDTO)
        {
            bool resultado = PaisDAL.Insert(myPaisDTO);
            return resultado;
        }

        public static bool Update(DTO.PaisDTO myPaisDTO)
        {
            bool resultado = PaisDAL.Update(myPaisDTO);
            return resultado;
        }

        public static bool ActivaPais(PaisDTO thePaisDTO)
        {
            bool respuesta = PaisDAL.ActivaPais(thePaisDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPais(PaisDTO thePaisDTO)
        {
            bool respuesta = facade.Pais.ValidaEliminacionPais(thePaisDTO);
            return respuesta;
        }
    }
}
