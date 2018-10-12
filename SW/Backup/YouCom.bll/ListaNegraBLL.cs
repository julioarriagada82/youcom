using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ListaNegraBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ListaNegraDTO> getListadoListaNegra()
        {
            var lista_negra = YouCom.facade.ListaNegra.getListadoListaNegra();
            return lista_negra;
        }

        public static ListaNegraDTO detalleListaNegra(decimal idListaNegra)
        {
            ListaNegraDTO lista_negra;
            lista_negra = YouCom.facade.ListaNegra.getListadoListaNegra().Where(x => x.IdListaNegra == idListaNegra).First();
            return lista_negra;
        }

        public static IList<ListaNegraDTO> listaListaNegraActivo()
        {
            IList<ListaNegraDTO> lista_negra;
            lista_negra = YouCom.facade.ListaNegra.getListadoListaNegra().Where(x => x.Estado == "1").ToList();
            return lista_negra;
        }

        public static IList<ListaNegraDTO> listaListaNegraInactivo()
        {
            IList<ListaNegraDTO> lista_negra;
            lista_negra = YouCom.facade.ListaNegra.getListadoListaNegra().Where(x => x.Estado == "2").ToList();
            return lista_negra;
        }

        public static bool Delete(DTO.ListaNegraDTO myListaNegraDTO)
        {
            bool resultado = ListaNegraDAL.Delete(myListaNegraDTO);
            return resultado;
        }

        public static bool Insert(DTO.ListaNegraDTO myListaNegraDTO)
        {
            bool resultado = ListaNegraDAL.Insert(myListaNegraDTO);
            return resultado;
        }

        public static bool Update(DTO.ListaNegraDTO myListaNegraDTO)
        {
            bool resultado = ListaNegraDAL.Update(myListaNegraDTO);
            return resultado;
        }

        public static bool ActivaListaNegra(ListaNegraDTO theListaNegraDTO)
        {
            bool respuesta = YouCom.DAL.ListaNegraDAL.ActivaListaNegra(theListaNegraDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionListaNegra(ListaNegraDTO theListaNegraDTO)
        {
            bool respuesta = facade.ListaNegra.ValidaEliminacionListaNegra(theListaNegraDTO);
            return respuesta;
        }
    }
}
