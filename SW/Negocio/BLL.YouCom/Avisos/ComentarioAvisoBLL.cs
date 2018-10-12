using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Avisos;
using YouCom.DAL;

namespace YouCom.bll.Avisos
{
    public class ComentarioAvisoBLL
    {
        public static IList<ComentarioAvisoDTO> getListadoComentarioAviso()
        {
            var avisos = YouCom.facade.Avisos.ComentarioAviso.getListadoComentarioAviso();
            return avisos;
        }

        public static IList<ComentarioAvisoDTO> getListadoComentarioAvisoByAviso(decimal idAviso)
        {
            var Avisos = listaComentarioAvisoActivo().Where(x=> x.TheAvisosDTO.IdAviso == idAviso && x.IdPadre == 0).ToList();
            return Avisos;
        }

        public static IList<ComentarioAvisoDTO> getListadoComentarioAvisoByComentario(decimal idComentario)
        {
            var Avisos = listaComentarioAvisoActivo().Where(x => x.IdPadre == idComentario).ToList();
            return Avisos;
        }

        public static ComentarioAvisoDTO detalleComentarioAviso(decimal idComentarioAviso)
        {
            ComentarioAvisoDTO Avisoss;
            Avisoss = YouCom.facade.Avisos.ComentarioAviso.getListadoComentarioAviso().Where(x => x.IdComentarioAviso == idComentarioAviso).First();
            return Avisoss;
        }

        public static IList<ComentarioAvisoDTO> listaComentarioAvisoActivo()
        {
            IList<ComentarioAvisoDTO> Avisoss;
            Avisoss = YouCom.facade.Avisos.ComentarioAviso.getListadoComentarioAviso().Where(x => x.Estado == "1").ToList();
            return Avisoss;
        }

        public static IList<ComentarioAvisoDTO> listaComentarioAvisoInactivo()
        {
            IList<ComentarioAvisoDTO> Avisoss;
            Avisoss = YouCom.facade.Avisos.ComentarioAviso.getListadoComentarioAviso().Where(x => x.Estado == "2").ToList();
            return Avisoss;
        }

        public static bool Delete(ComentarioAvisoDTO myComentarioAvisoDTO)
        {
            bool resultado = ComentarioAvisoDAL.Delete(myComentarioAvisoDTO);
            return resultado;
        }

        public static bool Insert(ComentarioAvisoDTO myComentarioAvisoDTO)
        {
            bool resultado = ComentarioAvisoDAL.Insert(myComentarioAvisoDTO);
            return resultado;
        }

        public static bool ActivaComentarioAviso(ComentarioAvisoDTO theComentarioAvisoDTO)
        {
            bool respuesta = YouCom.DAL.ComentarioAvisoDAL.ActivaComentarioAviso(theComentarioAvisoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAvisos(ComentarioAvisoDTO theComentarioAvisoDTO)
        {
            bool respuesta = YouCom.facade.Avisos.ComentarioAviso.ValidaEliminacionComentarioAviso(theComentarioAvisoDTO);
            return respuesta;
        }
    }
}
