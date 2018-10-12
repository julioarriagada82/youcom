using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.AccesoHogar;

namespace YouCom.bll.AccesoHogar
{
    public class AccesoHogarDetalleBLL
    {
        public static IList<AccesoHogarDetalleDTO> getListadoAccesoHogarDetalle()
        {
            var acceso_detalle = YouCom.facade.AccesoHogar.AccesoHogarDetalle.getListadoAccesoHogarDetalle();
            return acceso_detalle;
        }

        public static AccesoHogarDetalleDTO detalleAccesoHogar(decimal idAccesoHogarDetalle)
        {
            AccesoHogarDetalleDTO acceso_hogar;
            acceso_hogar = facade.AccesoHogar.AccesoHogarDetalle.getListadoAccesoHogarDetalle().Where(x => x.IdAccesoHogarDetalle == idAccesoHogarDetalle).First();
            return acceso_hogar;
        }
        
        public static IList<AccesoHogarDetalleDTO> getListadoAccesoHogarDetalleByAcceso(decimal idAccesoHogar)
        {
            var accesos = getListadoAccesoHogarDetalle().Where(x => x.TheAccesoHogarDTO.IdAccesoHogar == idAccesoHogar).ToList();
            return accesos;
        }

        public static bool Delete(DTO.AccesoHogar.AccesoHogarDetalleDTO myAccesoHogarDetalleDTO)
        {
            bool resultado = YouCom.DAL.AccesoHogar.AccesoHogarDetalleDAL.Delete(myAccesoHogarDetalleDTO);
            return resultado;
        }

        public static bool Insert(DTO.AccesoHogar.AccesoHogarDetalleDTO myAccesoHogarDetalleDTO)
        {
            bool resultado = YouCom.DAL.AccesoHogar.AccesoHogarDetalleDAL.Insert(myAccesoHogarDetalleDTO);
            return resultado;
        }

        public static bool Update(DTO.AccesoHogar.AccesoHogarDetalleDTO myAccesoHogarDetalleDTO)
        {
            bool resultado = YouCom.DAL.AccesoHogar.AccesoHogarDetalleDAL.Update(myAccesoHogarDetalleDTO);
            return resultado;
        }
    }
}
