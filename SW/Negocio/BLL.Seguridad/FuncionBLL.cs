using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.BLL
{
    public class FuncionBLL
    {
        #region   Funcion

        public static bool InsertFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionDAL.InsertFuncion(theFuncionDTO);
            return respuesta;
        }

        public static FuncionDTO detalleFuncion(string codFuncion)
        {
            FuncionDTO funciones;
            funciones = facade.Seguridad.Funcion.ListadoFuncion().Where(x => x.FuncionCod == codFuncion).First();
            return funciones;
        }
        public static bool UpdateFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionDAL.UpdateFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool DeleteFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionDAL.DeleteFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool ActivaFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionDAL.ActivaFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = facade.Seguridad.Funcion.ValidaEliminacionFuncion(theFuncionDTO);
            return respuesta;
        }

        public static List<FuncionDTO> listaFuncionActivo()
        {
            List<FuncionDTO> funcion;
            funcion = facade.Seguridad.Funcion.ListadoFuncion().Where(x => x.Estado == "1").ToList();
            return funcion;
        }
        public static List<FuncionDTO> listaFuncionInactivo()
        {
            List<FuncionDTO> funcion;
            funcion = facade.Seguridad.Funcion.ListadoFuncion().Where(x => x.Estado == "2").ToList();
            return funcion;
        }
        public static List<FuncionDTO> listaFuncion()
        {
            List<FuncionDTO> funcion;
            funcion = facade.Seguridad.Funcion.ListadoFuncion();
            return funcion;
        }

        public static List<FuncionDTO> listaFuncion(int FuncionGrupo)
        {
            List<FuncionDTO> funcion;
            funcion = facade.Seguridad.Funcion.ListaFunciones(FuncionGrupo);
            return funcion;
        }

        public static List<FuncionDTO> ListaFuncionGrupoSistema()
        {
            List<FuncionDTO> funcion;
            funcion = facade.Seguridad.Funcion.ListaFuncionGrupoSistema();
            return funcion;
        }

        #endregion
    }
}
