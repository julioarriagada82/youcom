using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class AvisosBLL
    {
        public static IList<AvisosDTO> getListadoAvisos()
        {
            YouCom.facade.Avisos AvisosFA = new YouCom.facade.Avisos();
            var Avisos = YouCom.facade.Avisos.getListadoAvisos();
            return Avisos;
        }

        public static AvisosDTO detalleAviso(decimal idAviso)
        {
            AvisosDTO Avisoss;
            Avisoss = facade.Avisos.getListadoAvisos().Where(x => x.IdAviso == idAviso).First();
            return Avisoss;
        }

        public static IList<AvisosDTO> listaAvisosActivo()
        {
            IList<AvisosDTO> Avisoss;
            Avisoss = facade.Avisos.getListadoAvisos().Where(x => x.Estado == "1").ToList();
            return Avisoss;
        }

        public static IList<AvisosDTO> listaAvisosInactivo()
        {
            IList<AvisosDTO> Avisoss;
            Avisoss = facade.Avisos.getListadoAvisos().Where(x => x.Estado == "2").ToList();
            return Avisoss;
        }

        public static bool Delete(DTO.AvisosDTO myAvisosDTO)
        {
            bool resultado = AvisosDAL.Delete(myAvisosDTO);
            return resultado;
        }

        public static bool Insert(DTO.AvisosDTO myAvisosDTO)
        {
            bool resultado = AvisosDAL.Insert(myAvisosDTO);
            return resultado;
        }

        public static bool Update(DTO.AvisosDTO myAvisosDTO)
        {
            bool resultado = AvisosDAL.Update(myAvisosDTO);
            return resultado;
        }

        public static bool ActivaAvisos(AvisosDTO theAvisosDTO)
        {
            bool respuesta = YouCom.DAL.AvisosDAL.ActivaAviso(theAvisosDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAvisos(AvisosDTO theAvisosDTO)
        {
            bool respuesta = facade.Avisos.ValidaEliminacionAvisos(theAvisosDTO);
            return respuesta;
        }
    }
}
