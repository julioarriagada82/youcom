using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class DirectivaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<DirectivaDTO> getListadoDirectiva()
        {
            YouCom.facade.Directiva DirectivaFA = new YouCom.facade.Directiva();
            var directiva = YouCom.facade.Directiva.getListadoDirectiva();
            return directiva;
        }

        public static DirectivaDTO detalleDirectiva(decimal idDirectiva)
        {
            DirectivaDTO directivas;
            directivas = facade.Directiva.getListadoDirectiva().Where(x => x.IdDirectiva == idDirectiva).First();
            return directivas;
        }

        public static IList<DirectivaDTO> getListadoDirectivaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var directivas = listaDirectivaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return directivas;
        }

        public static IList<DirectivaDTO> getListadoDirectivaByComunidad(decimal idComunidad)
        {
            var directivas = listaDirectivaActivo().Where(x => x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return directivas;
        }

        public static IList<DirectivaDTO> listaDirectivaActivo()
        {
            IList<DirectivaDTO> directivas;
            directivas = facade.Directiva.getListadoDirectiva().Where(x => x.Estado == "1").ToList();
            return directivas;
        }

        public static IList<DirectivaDTO> listaDirectivaInactivo()
        {
            IList<DirectivaDTO> directivas;
            directivas = facade.Directiva.getListadoDirectiva().Where(x => x.Estado == "2").ToList();
            return directivas;
        }

        public static bool Delete(DTO.DirectivaDTO myDirectivaDTO)
        {
            bool resultado = DirectivaDAL.Delete(myDirectivaDTO);
            return resultado;
        }

        public static bool Insert(DTO.DirectivaDTO myDirectivaDTO)
        {
            bool resultado = DirectivaDAL.Insert(myDirectivaDTO);
            return resultado;
        }

        public static bool Update(DTO.DirectivaDTO myDirectivaDTO)
        {
            bool resultado = DirectivaDAL.Update(myDirectivaDTO);
            return resultado;
        }

        public static bool ActivaDirectiva(DirectivaDTO theDirectivaDTO)
        {
            bool respuesta = DirectivaDAL.ActivaDirectiva(theDirectivaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionDirectiva(DirectivaDTO theDirectivaDTO)
        {
            bool respuesta = facade.Directiva.ValidaEliminacionDirectiva(theDirectivaDTO);
            return respuesta;
        }
    }
}
