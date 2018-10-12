using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class MensajeDirectivaBLL
    {

        public static IList<MensajeDirectivaDTO> getListadoMensajeDirectivaByPadre(decimal idPadre)
        {
            var mensajes = listaMensajeDirectivaActivo().Where(x => x.IdPadre == idPadre).ToList();
            return mensajes;
        }

        public static IList<MensajeDirectivaDTO> getListadoMensajeDirectiva()
        {
            var MensajeDirectiva = YouCom.facade.Mensajeria.MensajeDirectiva.getListadoMensajeDirectiva();
            return MensajeDirectiva;
        }

        public static MensajeDirectivaDTO detalleMensajeDirectiva(decimal idMensajeDirectiva)
        {
            IList<MensajeDirectivaDTO> collMensajeDirectiva;
            MensajeDirectivaDTO MensajeDirectiva = new MensajeDirectivaDTO();

            collMensajeDirectiva = getListadoMensajeDirectiva();

            if (collMensajeDirectiva.Any())
            {
                MensajeDirectiva = collMensajeDirectiva.Where(x => x.IdMensajeDirectiva == idMensajeDirectiva).First();
            }

            return MensajeDirectiva;
        }

        public static IList<MensajeDirectivaDTO> getListadoMensajeDirectivaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaMensajeDirectivaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<MensajeDirectivaDTO> listaMensajeDirectivaActivo()
        {
            IList<MensajeDirectivaDTO> MensajeDirectivas;
            MensajeDirectivas = facade.Mensajeria.MensajeDirectiva.getListadoMensajeDirectiva().Where(x => x.Estado == "1").ToList();
            return MensajeDirectivas;
        }

        public static IList<MensajeDirectivaDTO> listaMensajeDirectivaInactivo()
        {
            IList<MensajeDirectivaDTO> MensajeDirectivas;
            MensajeDirectivas = facade.Mensajeria.MensajeDirectiva.getListadoMensajeDirectiva().Where(x => x.Estado == "2").ToList();
            return MensajeDirectivas;
        }

        public static bool Delete(MensajeDirectivaDTO myMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajeDirectivaDAL.Delete(myMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Insert(MensajeDirectivaDTO myMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajeDirectivaDAL.Insert(myMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Update(MensajeDirectivaDTO myMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.MensajeDirectivaDAL.Update(myMensajeDirectivaDTO);
            return resultado;
        }

        public static bool ActivaMensajeDirectiva(MensajeDirectivaDTO theMensajeDirectivaDTO)
        {
            bool respuesta = YouCom.Mensajeria.DAL.MensajeDirectivaDAL.ActivaMensajeDirectiva(theMensajeDirectivaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionMensajeDirectiva(MensajeDirectivaDTO theMensajeDirectivaDTO)
        {
            bool respuesta = facade.Mensajeria.MensajeDirectiva.ValidaEliminacionMensajeDirectiva(theMensajeDirectivaDTO);
            return respuesta;
        }
    }
}
