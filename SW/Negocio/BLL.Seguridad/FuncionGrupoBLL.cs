using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.BLL
{
    public class FuncionGrupoBLL
    {
        #region   FuncionGrupo

        public static bool InsertFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionGrupoDAL.InsertFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }

        public static FuncionGrupoDTO detalleFuncionGrupo(string codFuncionGrupo)
        {
            FuncionGrupoDTO funcionGrupo;
            funcionGrupo = facade.Seguridad.FuncionGrupo.ListadoFuncionGrupo().Where(x => x.FuncionGrupoCod == codFuncionGrupo).First();
            return funcionGrupo;
        }

        public static bool UpdateFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionGrupoDAL.UpdateFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool DeleteFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionGrupoDAL.DeleteFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool ActivaFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.Seguridad.DAL.FuncionGrupoDAL.ActivaFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = facade.Seguridad.FuncionGrupo.ValidaEliminacionFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }

        public static List<FuncionGrupoDTO> listaFuncionGrupoActivo()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo = facade.Seguridad.FuncionGrupo.ListadoFuncionGrupo().Where(x => x.Estado == "1").ToList();
            return funcionGrupo;
        }
        public static List<FuncionGrupoDTO> listaFuncionGrupoInactivo()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo = facade.Seguridad.FuncionGrupo.ListadoFuncionGrupo().Where(x => x.Estado == "2").ToList();
            return funcionGrupo;
        }
        public static List<FuncionGrupoDTO> listaFuncionGrupo()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo = facade.Seguridad.FuncionGrupo.ListadoFuncionGrupo();
            return funcionGrupo;
        }

        public static List<FuncionGrupoDTO> ListaGruposSistema()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo = facade.Seguridad.FuncionGrupo.ListaGruposSistema();
            return funcionGrupo;
        }
        #endregion
    }
}
