using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Seguridad;
using YouCom.Seguridad.DAL;

namespace YouCom.Seguridad.BLL
{
    public class PerfilBLL
    {
        public static IList<PerfilDTO> getListadoPerfil()
        {
            var Perfil = YouCom.facade.Seguridad.Perfil.getListadoPerfil();
            return Perfil;
        }

        public static PerfilDTO detallePerfil(decimal idPerfil)
        {
            PerfilDTO Perfils;
            Perfils = facade.Seguridad.Perfil.getListadoPerfil().Where(x => x.IdPerfil == idPerfil).First();
            return Perfils;
        }

        public static IList<PerfilDTO> getListadoPerfilByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var Perfils = listaPerfilActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return Perfils;
        }

        public static IList<PerfilDTO> listaPerfilActivo()
        {
            IList<PerfilDTO> Perfils;
            Perfils = facade.Seguridad.Perfil.getListadoPerfil().Where(x => x.Estado == "1").ToList();
            return Perfils;
        }

        public static IList<PerfilDTO> listaPerfilInactivo()
        {
            IList<PerfilDTO> Perfils;
            Perfils = facade.Seguridad.Perfil.getListadoPerfil().Where(x => x.Estado == "2").ToList();
            return Perfils;
        }

        public static bool Delete(PerfilDTO myPerfilDTO)
        {
            bool resultado = PerfilDAL.Delete(myPerfilDTO);
            return resultado;
        }

        public static bool Insert(PerfilDTO myPerfilDTO)
        {
            bool resultado = PerfilDAL.Insert(myPerfilDTO);
            return resultado;
        }

        public static bool Update(PerfilDTO myPerfilDTO)
        {
            bool resultado = PerfilDAL.Update(myPerfilDTO);
            return resultado;
        }

        public static bool ActivaPerfil(PerfilDTO thePerfilDTO)
        {
            bool respuesta = PerfilDAL.ActivaPerfil(thePerfilDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPerfil(PerfilDTO thePerfilDTO)
        {
            bool respuesta = facade.Seguridad.Perfil.ValidaEliminacionPerfil(thePerfilDTO);
            return respuesta;
        }
    }
}
