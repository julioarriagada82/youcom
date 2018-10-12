using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.BLL
{
    public class FuncionTipoBLL
    {
        #region   FuncionTipo

        public static bool InsertFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionTipoDAL.InsertFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool UpdateFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionTipoDAL.UpdateFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool DeleteFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionTipoDAL.DeleteFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool ActivaFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionTipoDAL.ActivaFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = facade.Seguridad.FuncionTipo.ValidaEliminacionFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }

        public static List<FuncionTipoDTO> listaFuncionTipoActivo()
        {
            List<FuncionTipoDTO> funcionTipo;
            funcionTipo = facade.Seguridad.FuncionTipo.ListadoFuncionTipo().Where(x => x.Estado == "1").ToList();
            return funcionTipo;
        }
        public static List<FuncionTipoDTO> listaFuncionTipoInactivo()
        {
            List<FuncionTipoDTO> funcionTipo;
            funcionTipo = facade.Seguridad.FuncionTipo.ListadoFuncionTipo().Where(x => x.Estado == "2").ToList();
            return funcionTipo;
        }
        public static List<FuncionTipoDTO> listaFuncionTipo()
        {
            List<FuncionTipoDTO> funcionTipo;
            funcionTipo = facade.Seguridad.FuncionTipo.ListadoFuncionTipo();
            return funcionTipo;
        }
        #endregion
    }
}
