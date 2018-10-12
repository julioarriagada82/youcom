using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using YouCom.DTO;
using YouCom.DTO.Seguridad;


namespace YouCom.bll
{
    public class MantenedoresBLL
    {
        #region   Funcion

        public static bool InsertFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.InsertFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool UpdateFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.UpdateFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool DeleteFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.DeleteFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool ActivaFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.ActivaFuncion(theFuncionDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionFuncion(FuncionDTO theFuncionDTO)
        {
            bool respuesta = facade.Funcion.ValidaEliminacionFuncion(theFuncionDTO);
            return respuesta;
        }

        public static List<FuncionDTO> listaFuncionActivo()
        {
            List<FuncionDTO> funcion;
            funcion =facade.Funcion.ListadoFuncion().Where(x => x.Estado == "1").ToList();
            return funcion;
        }
        public static List<FuncionDTO> listaFuncionInactivo()
        {
            List<FuncionDTO> funcion;
            funcion = facade.Funcion.ListadoFuncion().Where(x => x.Estado == "2").ToList();
            return funcion;
        }
        public static List<FuncionDTO> listaFuncion()
        {
            List<FuncionDTO> funcion;
            funcion = facade.Funcion.ListadoFuncion();
            return funcion;
        }
        #endregion

        #region   FuncionTipo

        public static bool InsertFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.InsertFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool UpdateFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.UpdateFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool DeleteFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.DeleteFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool ActivaFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.ActivaFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool respuesta = facade.FuncionTipo.ValidaEliminacionFuncionTipo(theFuncionTipoDTO);
            return respuesta;
        }

        public static List<FuncionTipoDTO> listaFuncionTipoActivo()
        {
            List<FuncionTipoDTO> funcionTipo;
            funcionTipo =facade.FuncionTipo.ListadoFuncionTipo().Where(x => x.Estado == "1").ToList();
            return funcionTipo;
        }
        public static List<FuncionTipoDTO> listaFuncionTipoInactivo()
        {
            List<FuncionTipoDTO> funcionTipo;
            funcionTipo = facade.FuncionTipo.ListadoFuncionTipo().Where(x => x.Estado == "2").ToList();
            return funcionTipo;
        }
        public static List<FuncionTipoDTO> listaFuncionTipo()
        {
            List<FuncionTipoDTO> funcionTipo;
            funcionTipo = facade.FuncionTipo.ListadoFuncionTipo();
            return funcionTipo;
        }
        #endregion

        #region   FuncionGrupo

        public static bool InsertFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.InsertFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool UpdateFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.UpdateFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool DeleteFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.DeleteFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool ActivaFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.ActivaFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool respuesta = facade.FuncionGrupo.ValidaEliminacionFuncionGrupo(theFuncionGrupoDTO);
            return respuesta;
        }

        public static List<FuncionGrupoDTO> listaFuncionGrupoActivo()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo =facade.FuncionGrupo.ListadoFuncionGrupo().Where(x => x.Estado == "1").ToList();
            return funcionGrupo;
        }
        public static List<FuncionGrupoDTO> listaFuncionGrupoInactivo()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo = facade.FuncionGrupo.ListadoFuncionGrupo().Where(x => x.Estado == "2").ToList();
            return funcionGrupo;
        }
        public static List<FuncionGrupoDTO> listaFuncionGrupo()
        {
            List<FuncionGrupoDTO> funcionGrupo;
            funcionGrupo = facade.FuncionGrupo.ListadoFuncionGrupo();
            return funcionGrupo;
        }
        #endregion

        public static bool InsertLocalidad(LocalidadDTO theLocalidadDTO)
        {
            var respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.InsertLocalidad(theLocalidadDTO);
            return respuesta;
        }
        public static bool UpdateLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.UpdateLocalidad(theLocalidadDTO);
            return respuesta;
        }
        public static bool DeleteLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.DeleteLocalidad(theLocalidadDTO);
            return respuesta;
        }
        public static bool ActivaLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.ActivaLocalidad(theLocalidadDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool respuesta = facade.Localidad.ValidaEliminacionLocalidad(theLocalidadDTO);
            return respuesta;
        }

        public static List<LocalidadDTO> listaLocalidad(int region)
        {
            List<LocalidadDTO> localidades;
            localidades = facade.Localidad.ListadoLocalidadByRegion(region);
            return localidades;
        }
        public static List<LocalidadDTO> listaLocalidad()
        {
            List<LocalidadDTO> localidades;
            localidades = facade.Localidad.ListadoLocalidad();
            return localidades;
        }
        public static List<LocalidadDTO> listaLocalidadActivo()
        {
            List<LocalidadDTO> localidades;
            localidades = facade.Localidad.ListadoLocalidad().Where(x => x.Estado == "1").ToList();
            return localidades;
        }
        public static List<LocalidadDTO> listaLocalidadInactivo()
        {
            List<LocalidadDTO> localidades;
            localidades = facade.Localidad.ListadoLocalidad().Where(x => x.Estado == "2").ToList();
            return localidades;
        }

        public static IList listaRegiones()
        {
            IList regiones;
            regiones = facade.Region.ListadoRegiones();
            return regiones;
        }

        #region  Pais

        public static bool InsertPais(PaisDTO thePaisDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.InsertPais(thePaisDTO);
            return respuesta;
        }
        public static bool UpdatePais(PaisDTO thePaisDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.UpdatePais(thePaisDTO);
            return respuesta;
        }
        public static bool DeletePais(PaisDTO thePaisDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.DeletePais(thePaisDTO);
            return respuesta;
        }
        public static bool ActivaPais(PaisDTO thePaisDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.ActivaPais(thePaisDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionPais(PaisDTO thePaisDTO)
        {
            bool respuesta = facade.Pais.ValidaEliminacionPais(thePaisDTO);
            return respuesta;
        }

        public static List<PaisDTO> listaPaisActivo()
        {
            List<PaisDTO> pais;
            pais = facade.Pais.ListadoPais().Where(x => x.Estado == "1").ToList();
            return pais;
        }
        public static List<PaisDTO> listaPaisInactivo()
        {
            List<PaisDTO> pais;
            pais = facade.Pais.ListadoPais().Where(x => x.Estado == "2").ToList();
            return pais;
        }
        public static List<PaisDTO> listaPais()
        {
            List<PaisDTO> pais;
            pais = facade.Pais.ListadoPais();
            return pais;
        }
        #endregion


        #region  Region

        public static bool InsertRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.InsertRegion(theRegionDTO);
            return respuesta;
        }
        public static bool UpdateRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.UpdateRegion(theRegionDTO);
            return respuesta;
        }
        public static bool DeleteRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.DeleteRegion(theRegionDTO);
            return respuesta;
        }
        public static bool ActivaRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = YouCom.mantenedores.DAL.MantenedoresDAL.ActivaRegion(theRegionDTO);
            return respuesta;
        }
        public static bool ValidaEliminacionRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = facade.Region.ValidaEliminacionRegion(theRegionDTO);
            return respuesta;
        }

        public static List<RegionDTO> listaRegionActivo()
        {
            List<RegionDTO> region;
            region = facade.Region.ListadoRegiones().Where(x => x.Estado == "1").ToList();
            return region;
        }
        public static List<RegionDTO> listaRegionInactivo()
        {
            List<RegionDTO> region;
            region = facade.Region.ListadoRegiones().Where(x => x.Estado == "2").ToList();
            return region;
        }
        public static List<RegionDTO> listaRegion()
        {
            List<RegionDTO> region;
            region = facade.Region.ListadoRegiones();
            return region;
        }
        #endregion
    }
}
