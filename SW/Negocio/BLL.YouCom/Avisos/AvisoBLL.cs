using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;
using YouCom.DTO.Avisos;

namespace YouCom.bll.Avisos
{
    public class AvisoBLL
    {
        public static IList<AvisoDTO> getListadoAvisos()
        {
            var avisos = YouCom.facade.Avisos.Aviso.getListadoAvisos();
            return avisos;
        }

        public static AvisoDTO getObtenerUltimoAviso()
        {
            var mensajes = listaAvisosActivo().OrderByDescending(x => x.IdAviso).First();
            return mensajes;
        }

        public static AvisoDTO detalleAviso(decimal idAviso)
        {
            AvisoDTO avisos;
            avisos = YouCom.facade.Avisos.Aviso.getListadoAvisos().Where(x => x.IdAviso == idAviso).First();
            return avisos;
        }

        public static IList<AvisoDTO> getListadoAvisoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var avisos = listaAvisosActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return avisos;
        }

        public static IList<AvisoDTO> getListadoAvisoByCondominioByComunidadVigentes(decimal idCondominio, decimal idComunidad)
        {
            var avisos = listaAvisosActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad && x.FechaTermino > DateTime.Now && x.TheAvisosEstadoDTO.IdAvisoEstado == 1).ToList();
            return avisos;
        }

        public static IList<AvisoDTO> listaAvisosActivo()
        {
            IList<AvisoDTO> avisos;
            avisos = YouCom.facade.Avisos.Aviso.getListadoAvisos().Where(x => x.Estado == "1").ToList();
            return avisos;
        }

        public static IList<AvisoDTO> listaAvisosInactivo()
        {
            IList<AvisoDTO> avisos;
            avisos = YouCom.facade.Avisos.Aviso.getListadoAvisos().Where(x => x.Estado == "2").ToList();
            return avisos;
        }

        public static bool Delete(AvisoDTO myAvisosDTO)
        {
            bool resultado = AvisosDAL.Delete(myAvisosDTO);
            return resultado;
        }

        public static bool Insert(AvisoDTO myAvisosDTO)
        {
            bool resultado = AvisosDAL.Insert(myAvisosDTO);
            return resultado;
        }

        public static bool Update(AvisoDTO myAvisosDTO)
        {
            bool resultado = AvisosDAL.Update(myAvisosDTO);
            return resultado;
        }

        public static bool ActivaAvisos(AvisoDTO theAvisosDTO)
        {
            bool respuesta = YouCom.DAL.AvisosDAL.ActivaAviso(theAvisosDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAvisos(AvisoDTO theAvisosDTO)
        {
            bool respuesta = facade.Avisos.Aviso.ValidaEliminacionAvisos(theAvisosDTO);
            return respuesta;
        }
    }
}
