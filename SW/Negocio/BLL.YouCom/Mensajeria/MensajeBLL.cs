using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class MensajeBLL
    {

        public static IList<MensajeDTO> getListadoMensajesByIdMensaje(decimal pIdMensaje, string pQuienEnvia)
        {
            var mensajes = getListadoTodosMensajes().Where(x => x.IdMensaje == pIdMensaje && x.TheMensajeTipoDTO.NombreMensajeTipo == pQuienEnvia).ToList();
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoMensajesByCategoria(decimal pIdCategoria)
        {
            var mensajes = getListadoTodosMensajes().Where(x => x.TheCategoriaDTO.IdCategoria == pIdCategoria).ToList();
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoMensajesByUsuario(string pUsuario)
        {
            var mensajes = getListadoMensajesPropietarios().Where(x => x.TheFamiliaDTO.NombreCompleto.Contains(pUsuario)).ToList();
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoMensajesByTitulo(string pTitulo)
        {
            var mensajes = getListadoTodosMensajes().Where(x => x.MensajeTitulo.Contains(pTitulo) || x.MensajeDescripcion.Contains(pTitulo)).ToList();
            return mensajes;
        }
        public static IList<MensajeDTO> getListadoMensajes(decimal idFamilia)
        {
            var mensajes = YouCom.facade.Mensajeria.Mensaje.getListadoMensajes(idFamilia);
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoMensajesPropietarios()
        {
            var mensajes = YouCom.facade.Mensajeria.Mensaje.getListadoMensajesPropietarios().Where(x => x.IdPadre == 0).OrderByDescending(x => x.MensajeFecha).ToList();
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoMensajesInternos()
        {
            var mensajes = YouCom.facade.Mensajeria.Mensaje.getListadoMensajesInternos().Where(x => x.IdPadre == 0).OrderByDescending(x => x.MensajeFecha).ToList();
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoTodosMensajes()
        {
            var mensajes = YouCom.facade.Mensajeria.Mensaje.getListadoTodosMensajes().Where(x => x.IdPadre == 0).OrderByDescending(x => x.MensajeFecha).ToList();
            return mensajes;
        }

        public static MensajeDTO detalleMensaje(decimal idFamilia, decimal idMensaje)
        {
            var mensajes = YouCom.facade.Mensajeria.Mensaje.getListadoMensajes(idFamilia).Where(x => x.IdMensaje == idMensaje).First();
            return mensajes;
        }

        public static IList<MensajeDTO> getListadoMensajeByCondominioByComunidad(decimal idCondominio, decimal idComunidad, decimal idFamilia)
        {
            var mensajes = getListadoMensajes(idFamilia).Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }
    }
}
