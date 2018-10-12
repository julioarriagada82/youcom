using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ComunidadBLL
    {
        public static IList<ComunidadDTO> getListadoComunidad()
        {
            YouCom.facade.Comunidad ComunidadFA = new YouCom.facade.Comunidad();
            var Comunidad = YouCom.facade.Comunidad.getListadoComunidad();
            return Comunidad;
        }

        public static ComunidadDTO detalleComunidad(decimal idComunidad)
        {
            ComunidadDTO comunidades;
            comunidades = facade.Comunidad.getListadoComunidad().Where(x => x.IdComunidad == idComunidad).First();
            return comunidades;
        }


        public static IList<ComunidadDTO> listaComunidadActivo()
        {
            IList<ComunidadDTO> Comunidads;
            Comunidads = facade.Comunidad.getListadoComunidad().Where(x => x.Estado == "1").ToList();
            return Comunidads;
        }

        public static IList<ComunidadDTO> listaComunidadInactivo()
        {
            IList<ComunidadDTO> Comunidads;
            Comunidads = facade.Comunidad.getListadoComunidad().Where(x => x.Estado == "2").ToList();
            return Comunidads;
        }

        public static bool Delete(DTO.ComunidadDTO myComunidadDTO)
        {
            bool resultado = ComunidadDAL.Delete(myComunidadDTO);
            return resultado;
        }

        public static bool Insert(DTO.ComunidadDTO myComunidadDTO)
        {
            bool resultado = ComunidadDAL.Insert(myComunidadDTO);
            return resultado;
        }

        public static bool Update(DTO.ComunidadDTO myComunidadDTO)
        {
            bool resultado = ComunidadDAL.Update(myComunidadDTO);
            return resultado;
        }

        public static bool ActivaComunidad(ComunidadDTO theComunidadDTO)
        {
            bool respuesta = YouCom.DAL.ComunidadDAL.ActivaComunidad(theComunidadDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionComunidad(ComunidadDTO theComunidadDTO)
        {
            bool respuesta = facade.Comunidad.ValidaEliminacionComunidad(theComunidadDTO);
            return respuesta;
        }
    }
}
