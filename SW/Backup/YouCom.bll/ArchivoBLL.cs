using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ArchivoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ArchivoDTO> getListadoArchivo()
        {
            var archivo = YouCom.facade.Archivo.getListadoArchivo();
            return archivo;
        }

        public static ArchivoDTO detalleArchivo(decimal idArchivo)
        {
            ArchivoDTO Archivos;
            Archivos = facade.Archivo.getListadoArchivo().Where(x => x.ArchivoId == idArchivo).First();
            return Archivos;
        }

        public static IList<ArchivoDTO> listaArchivoActivo()
        {
            IList<ArchivoDTO> Archivos;
            Archivos = facade.Archivo.getListadoArchivo().Where(x => x.Estado == "1").ToList();
            return Archivos;
        }

        public static IList<ArchivoDTO> listaArchivoInactivo()
        {
            IList<ArchivoDTO> Archivos;
            Archivos = facade.Archivo.getListadoArchivo().Where(x => x.Estado == "2").ToList();
            return Archivos;
        }

        public static bool Delete(DTO.ArchivoDTO myArchivoDTO)
        {
            bool resultado = ArchivoDAL.Delete(myArchivoDTO);
            return resultado;
        }

        public static bool Insert(DTO.ArchivoDTO myArchivoDTO)
        {
            bool resultado = ArchivoDAL.Insert(myArchivoDTO);
            return resultado;
        }

        public static bool Update(DTO.ArchivoDTO myArchivoDTO)
        {
            bool resultado = ArchivoDAL.Update(myArchivoDTO);
            return resultado;
        }

        public static bool ActivaArchivo(ArchivoDTO theArchivoDTO)
        {
            bool respuesta = YouCom.DAL.ArchivoDAL.ActivaArchivo(theArchivoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionArchivo(ArchivoDTO theArchivoDTO)
        {
            bool respuesta = facade.Archivo.ValidaEliminacionArchivo(theArchivoDTO);
            return respuesta;
        }
    }
}
