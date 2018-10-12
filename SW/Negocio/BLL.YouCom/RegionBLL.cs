using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class RegionBLL
    {
        public static IList<RegionDTO> getListadoRegion()
        {
            YouCom.facade.Region RegionFA = new YouCom.facade.Region();
            var Region = YouCom.facade.Region.getListadoRegion();
            return Region;
        }

        public static RegionDTO detalleRegion(decimal idRegion)
        {
            RegionDTO Regions;
            Regions = facade.Region.getListadoRegion().Where(x => x.IdRegion == idRegion).First();
            return Regions;
        }

        public static IList<RegionDTO> listaRegionByPais(decimal idPais)
        {
            IList<RegionDTO> Regiones;
            Regiones = facade.Region.getListadoRegion().Where(x => x.ThePaisDTO.IdPais == idPais).ToList();
            return Regiones;
        }

        public static IList<RegionDTO> listaRegionActivo()
        {
            IList<RegionDTO> Regions;
            Regions = facade.Region.getListadoRegion().Where(x => x.Estado == "1").ToList();
            return Regions;
        }

        public static IList<RegionDTO> listaRegionInactivo()
        {
            IList<RegionDTO> Regions;
            Regions = facade.Region.getListadoRegion().Where(x => x.Estado == "2").ToList();
            return Regions;
        }

        public static bool Delete(DTO.RegionDTO myRegionDTO)
        {
            bool resultado = RegionDAL.Delete(myRegionDTO);
            return resultado;
        }

        public static bool Insert(DTO.RegionDTO myRegionDTO)
        {
            bool resultado = RegionDAL.Insert(myRegionDTO);
            return resultado;
        }

        public static bool Update(DTO.RegionDTO myRegionDTO)
        {
            bool resultado = RegionDAL.Update(myRegionDTO);
            return resultado;
        }

        public static bool ActivaRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = RegionDAL.ActivaRegion(theRegionDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionRegion(RegionDTO theRegionDTO)
        {
            bool respuesta = facade.Region.ValidaEliminacionRegion(theRegionDTO);
            return respuesta;
        }
    }
}
