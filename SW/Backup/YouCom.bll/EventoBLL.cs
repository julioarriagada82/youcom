using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class EventoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<EventoDTO> getListadoEvento()
        {
            var noticia = YouCom.facade.Evento.getListadoEvento();
            return noticia;
        }

        public static EventoDTO detalleEvento(decimal idEvento)
        {
            EventoDTO evento;
            evento = facade.Evento.getListadoEvento().Where(x => x.EventoId == idEvento).First();
            return evento;
        }

        public static IList<EventoDTO> listaEventoActivo()
        {
            IList<EventoDTO> evento;
            evento = facade.Evento.getListadoEvento().Where(x => x.Estado == "1").ToList();
            return evento;
        }

        public static IList<EventoDTO> listaEventoInactivo()
        {
            IList<EventoDTO> evento;
            evento = facade.Evento.getListadoEvento().Where(x => x.Estado == "2").ToList();
            return evento;
        }

        public static bool Delete(DTO.EventoDTO myEventoDTO)
        {
            bool resultado = EventoDAL.Delete(myEventoDTO);
            return resultado;
        }

        public static bool Insert(DTO.EventoDTO myEventoDTO)
        {
            bool resultado = EventoDAL.Insert(myEventoDTO);
            return resultado;
        }

        public static bool Update(DTO.EventoDTO myEventoDTO)
        {
            bool resultado = EventoDAL.Update(myEventoDTO);
            return resultado;
        }

        public static bool ActivaEvento(EventoDTO theEventoDTO)
        {
            bool respuesta = YouCom.DAL.EventoDAL.ActivaEvento(theEventoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionNoticia(EventoDTO theEventoDTO)
        {
            bool respuesta = facade.Evento.ValidaEliminacionEvento(theEventoDTO);
            return respuesta;
        }
    }
}
