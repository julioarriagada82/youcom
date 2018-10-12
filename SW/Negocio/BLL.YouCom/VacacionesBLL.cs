using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class VacacionesBLL
    {
        public static IList<VacacionesDTO> getListadoVacaciones()
        {
            YouCom.facade.Vacaciones VacacionesFA = new YouCom.facade.Vacaciones();
            var Vacaciones = YouCom.facade.Vacaciones.getListadoVacaciones();
            return Vacaciones;
        }

        public static VacacionesDTO detalleVacaciones(decimal idVacaciones)
        {
            VacacionesDTO Vacacioness;
            Vacacioness = facade.Vacaciones.getListadoVacaciones().Where(x => x.IdVacaciones == idVacaciones).First();
            return Vacacioness;
        }

        public static IList<VacacionesDTO> getListadoVacacionesByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var vacaciones = listaVacacionesActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return vacaciones;
        }

        public static IList<VacacionesDTO> getListadoVacacionesByCasa(decimal idCondominio, decimal idComunidad, decimal idCasa)
        {
            var vacaciones = listaVacacionesActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad && x.TheCasaDTO.IdCasa == idCasa).ToList();
            return vacaciones;
        }

        public static IList<VacacionesDTO> listaVacacionesActivo()
        {
            IList<VacacionesDTO> Vacacioness;
            Vacacioness = facade.Vacaciones.getListadoVacaciones().Where(x => x.Estado == "1").ToList();
            return Vacacioness;
        }

        public static IList<VacacionesDTO> listaVacacionesInactivo()
        {
            IList<VacacionesDTO> Vacacioness;
            Vacacioness = facade.Vacaciones.getListadoVacaciones().Where(x => x.Estado == "2").ToList();
            return Vacacioness;
        }

        public static bool Delete(DTO.VacacionesDTO myVacacionesDTO)
        {
            bool resultado = VacacionesDAL.Delete(myVacacionesDTO);
            return resultado;
        }

        public static bool Insert(DTO.VacacionesDTO myVacacionesDTO)
        {
            bool resultado = VacacionesDAL.Insert(myVacacionesDTO);
            return resultado;
        }

        public static bool Update(DTO.VacacionesDTO myVacacionesDTO)
        {
            bool resultado = VacacionesDAL.Update(myVacacionesDTO);
            return resultado;
        }

        public static bool ActivaVacaciones(VacacionesDTO theVacacionesDTO)
        {
            bool respuesta = YouCom.DAL.VacacionesDAL.ActivaVacaciones(theVacacionesDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionVacaciones(VacacionesDTO theVacacionesDTO)
        {
            bool respuesta = facade.Vacaciones.ValidaEliminacionVacaciones(theVacacionesDTO);
            return respuesta;
        }
    }
}
