using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ComentarioAvisoBLL
    {
        public static IList<ComentarioAvisoDTO> getListadoComentarioAviso()
        {
            YouCom.facade.ComentarioAviso AvisosFA = new YouCom.facade.ComentarioAviso();
            var Avisos = YouCom.facade.ComentarioAviso.getListadoComentarioAviso();
            return Avisos;
        }

        public static ComentarioAvisoDTO detalleComentarioAviso(decimal idComentarioAviso)
        {
            ComentarioAvisoDTO Avisoss;
            Avisoss = facade.ComentarioAviso.getListadoComentarioAviso().Where(x => x.IdComentarioAviso == idComentarioAviso).First();
            return Avisoss;
        }

        public static IList<ComentarioAvisoDTO> listaComentarioAvisoActivo()
        {
            IList<ComentarioAvisoDTO> Avisoss;
            Avisoss = facade.ComentarioAviso.getListadoComentarioAviso().Where(x => x.Estado == "1").ToList();
            return Avisoss;
        }

        public static IList<ComentarioAvisoDTO> listaComentarioAvisoInactivo()
        {
            IList<ComentarioAvisoDTO> Avisoss;
            Avisoss = facade.ComentarioAviso.getListadoComentarioAviso().Where(x => x.Estado == "2").ToList();
            return Avisoss;
        }

        public static bool Delete(DTO.ComentarioAvisoDTO myComentarioAvisoDTO)
        {
            bool resultado = ComentarioAvisoDAL.Delete(myComentarioAvisoDTO);
            return resultado;
        }

        public static bool Insert(DTO.ComentarioAvisoDTO myComentarioAvisoDTO)
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
            bool respuesta = facade.ComentarioAviso.ValidaEliminacionComentarioAviso(theComentarioAvisoDTO);
            return respuesta;
        }
    }
}
