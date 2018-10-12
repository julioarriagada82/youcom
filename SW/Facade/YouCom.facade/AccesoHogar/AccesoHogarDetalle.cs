using System;
using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.AccesoHogar
{
    public class AccesoHogarDetalle
    {
        public static IList<YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO> getListadoAccesoHogarDetalle()
        {
            IList<YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO> IAccesoHogarDetalle = new List<YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AccesoHogar.AccesoHogarDetalleDAL.getListadoAccesoHogarDetalle(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO acceso_detalle = new YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO();

                    acceso_detalle.IdAccesoHogarDetalle = decimal.Parse(wobjDataRow["IdAccesoHogarDetalle"].ToString());

                    DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO = new DTO.AccesoHogar.AccesoHogarDTO();
                    myAccesoHogarDTO.IdAccesoHogar = decimal.Parse(wobjDataRow["idAccesoHogar"].ToString());
                    acceso_detalle.TheAccesoHogarDTO = myAccesoHogarDTO;

                    acceso_detalle.Fecha = DateTime.Parse(wobjDataRow["Fecha"].ToString());
                    acceso_detalle.FechaVisita = !string.IsNullOrEmpty(wobjDataRow["fechaVisita"].ToString()) ? DateTime.Parse(wobjDataRow["fechaVisita"].ToString()) : DateTime.MinValue;

                    acceso_detalle.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    acceso_detalle.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    acceso_detalle.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    acceso_detalle.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    acceso_detalle.Estado = wobjDataRow["estado"].ToString();

                    IAccesoHogarDetalle.Add(acceso_detalle);
                }
            }

            return IAccesoHogarDetalle;

        }
    }
}
