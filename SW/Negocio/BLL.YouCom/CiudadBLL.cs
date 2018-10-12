using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO;

namespace YouCom.bll
{
    public class CiudadBLL
    {
        public static IList<CiudadDTO> getListadoCiudad()
        {
            YouCom.facade.Ciudad CiudadFA = new YouCom.facade.Ciudad();
            var Ciudad = YouCom.facade.Ciudad.getListadoCiudad();
            return Ciudad;
        }

        public static CiudadDTO detalleCiudad(decimal idCiudad)
        {
            CiudadDTO Ciudads;
            Ciudads = facade.Ciudad.getListadoCiudad().Where(x => x.IdCiudad == idCiudad).First();
            return Ciudads;
        }

        public static IList<CiudadDTO> listaCiudadByRegion(decimal idRegion)
        {
            IList<CiudadDTO> ciudades;
            ciudades = facade.Ciudad.getListadoCiudad().Where(x => x.TheRegionDTO.IdRegion == idRegion).ToList();
            return ciudades;
        }

        public static IList<CiudadDTO> listaCiudadActivo()
        {
            IList<CiudadDTO> Ciudads;
            Ciudads = facade.Ciudad.getListadoCiudad().Where(x => x.Estado == "1").ToList();
            return Ciudads;
        }

        public static IList<CiudadDTO> listaCiudadInactivo()
        {
            IList<CiudadDTO> Ciudads;
            Ciudads = facade.Ciudad.getListadoCiudad().Where(x => x.Estado == "2").ToList();
            return Ciudads;
        }

        public static bool Delete(DTO.CiudadDTO myCiudadDTO)
        {
            bool resultado = CiudadDAL.Delete(myCiudadDTO);
            return resultado;
        }

        public static bool Insert(DTO.CiudadDTO myCiudadDTO)
        {
            bool resultado = CiudadDAL.Insert(myCiudadDTO);
            return resultado;
        }

        public static bool Update(DTO.CiudadDTO myCiudadDTO)
        {
            bool resultado = CiudadDAL.Update(myCiudadDTO);
            return resultado;
        }

        public static bool ActivaCiudad(CiudadDTO theCiudadDTO)
        {
            bool respuesta = CiudadDAL.ActivaCiudad(theCiudadDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionCiudad(CiudadDTO theCiudadDTO)
        {
            bool respuesta = facade.Ciudad.ValidaEliminacionCiudad(theCiudadDTO);
            return respuesta;
        }
    }
}
