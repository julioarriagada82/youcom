using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ContenidoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ContenidoDTO> getListadoContenido()
        {
            var contenido = YouCom.facade.Contenido.getListadoContenido();
            return contenido;
        }

        public static ContenidoDTO detalleContenido(decimal idContenido)
        {
            ContenidoDTO contenido;
            contenido = YouCom.facade.Contenido.getListadoContenido().Where(x => x.ContenidoId == idContenido).First();
            return contenido;
        }

        public static IList<ContenidoDTO> listaContenidoActivo()
        {
            IList<ContenidoDTO> contenido;
            contenido = YouCom.facade.Contenido.getListadoContenido().Where(x => x.Estado == "1").ToList();
            return contenido;
        }

        public static IList<ContenidoDTO> listaContenidoInactivo()
        {
            IList<ContenidoDTO> contenido;
            contenido = YouCom.facade.Contenido.getListadoContenido().Where(x => x.Estado == "2").ToList();
            return contenido;
        }

        public static bool Delete(DTO.ContenidoDTO myContenidoDTO)
        {
            bool resultado = ContenidoDAL.Delete(myContenidoDTO);
            return resultado;
        }

        public static bool Insert(DTO.ContenidoDTO myContenidoDTO)
        {
            bool resultado = ContenidoDAL.Insert(myContenidoDTO);
            return resultado;
        }

        public static bool Update(DTO.ContenidoDTO myContenidoDTO)
        {
            bool resultado = ContenidoDAL.Update(myContenidoDTO);
            return resultado;
        }

        public static bool ActivaContenido(ContenidoDTO theContenidoDTO)
        {
            bool respuesta = YouCom.DAL.ContenidoDAL.ActivaContenido(theContenidoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionContenido(ContenidoDTO theContenidoDTO)
        {
            bool respuesta = facade.Contenido.ValidaEliminacionContenido(theContenidoDTO);
            return respuesta;
        }
    }
}
