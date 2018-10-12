using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ForoComunidadBLL
    {
        public static IList<ForoComunidadDTO> getListadoForoComunidad()
        {
            YouCom.facade.ForoComunidad ForoComunidadFA = new YouCom.facade.ForoComunidad();
            var ForoComunidad = YouCom.facade.ForoComunidad.getListadoForoComunidad();
            return ForoComunidad;
        }

        public static ForoComunidadDTO detalleForoComunidad(decimal idAviso)
        {
            ForoComunidadDTO ForoComunidads;
            ForoComunidads = facade.ForoComunidad.getListadoForoComunidad().Where(x => x.IdForoComunidad == idAviso).First();
            return ForoComunidads;
        }

        public static IList<ForoComunidadDTO> listaForoComunidadActivo()
        {
            IList<ForoComunidadDTO> ForoComunidads;
            ForoComunidads = facade.ForoComunidad.getListadoForoComunidad().Where(x => x.Estado == "1").ToList();
            return ForoComunidads;
        }

        public static IList<ForoComunidadDTO> listaForoComunidadInactivo()
        {
            IList<ForoComunidadDTO> ForoComunidads;
            ForoComunidads = facade.ForoComunidad.getListadoForoComunidad().Where(x => x.Estado == "2").ToList();
            return ForoComunidads;
        }

        public static bool Delete(DTO.ForoComunidadDTO myForoComunidadDTO)
        {
            bool resultado = ForoComunidadDAL.Delete(myForoComunidadDTO);
            return resultado;
        }

        public static bool Insert(DTO.ForoComunidadDTO myForoComunidadDTO)
        {
            bool resultado = ForoComunidadDAL.Insert(myForoComunidadDTO);
            return resultado;
        }

        public static bool Update(DTO.ForoComunidadDTO myForoComunidadDTO)
        {
            bool resultado = ForoComunidadDAL.Update(myForoComunidadDTO);
            return resultado;
        }

        public static bool ActivaForoComunidad(ForoComunidadDTO theForoComunidadDTO)
        {
            bool respuesta = YouCom.DAL.ForoComunidadDAL.ActivaAviso(theForoComunidadDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionForoComunidad(ForoComunidadDTO theForoComunidadDTO)
        {
            bool respuesta = facade.ForoComunidad.ValidaEliminacionForoComunidad(theForoComunidadDTO);
            return respuesta;
        }
    }
}
