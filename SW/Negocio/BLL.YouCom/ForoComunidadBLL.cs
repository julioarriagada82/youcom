using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Foro;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ForoComunidadBLL
    {
        public static IList<ForoComunidadDTO> getListadoForoComunidad()
        {
            var ForoComunidad = YouCom.facade.Foro.ForoComunidad.getListadoForoComunidad();
            return ForoComunidad;
        }

        public static ForoComunidadDTO detalleForoComunidad(decimal idForoComunidad)
        {
            ForoComunidadDTO ForoComunidads;
            ForoComunidads = facade.Foro.ForoComunidad.getListadoForoComunidad().Where(x => x.IdForoComunidad == idForoComunidad).First();
            return ForoComunidads;
        }

        public static IList<ForoComunidadDTO> getListadoForoComunidadByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var foros = listaForoComunidadActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return foros;
        }
        public static IList<ForoComunidadDTO> listaForoComunidadActivo()
        {
            IList<ForoComunidadDTO> ForoComunidads;
            ForoComunidads = facade.Foro.ForoComunidad.getListadoForoComunidad().Where(x => x.Estado == "1").ToList();
            return ForoComunidads;
        }

        public static IList<ForoComunidadDTO> listaForoComunidadInactivo()
        {
            IList<ForoComunidadDTO> ForoComunidads;
            ForoComunidads = facade.Foro.ForoComunidad.getListadoForoComunidad().Where(x => x.Estado == "2").ToList();
            return ForoComunidads;
        }

        public static bool Delete(ForoComunidadDTO myForoComunidadDTO)
        {
            bool resultado = ForoComunidadDAL.Delete(myForoComunidadDTO);
            return resultado;
        }

        public static bool Insert(ForoComunidadDTO myForoComunidadDTO)
        {
            bool resultado = ForoComunidadDAL.Insert(myForoComunidadDTO);
            return resultado;
        }

        public static bool Update(ForoComunidadDTO myForoComunidadDTO)
        {
            bool resultado = ForoComunidadDAL.Update(myForoComunidadDTO);
            return resultado;
        }

        public static bool ActivaForoComunidad(ForoComunidadDTO theForoComunidadDTO)
        {
            bool respuesta = ForoComunidadDAL.ActivaForoComunidad(theForoComunidadDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionForoComunidad(ForoComunidadDTO theForoComunidadDTO)
        {
            bool respuesta = facade.Foro.ForoComunidad.ValidaEliminacionForoComunidad(theForoComunidadDTO);
            return respuesta;
        }
    }
}
