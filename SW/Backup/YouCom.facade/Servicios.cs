using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Servicios
    {
        public static IList<YouCom.DTO.ServiciosDTO> getListadoServicios()
        {
            IList<YouCom.DTO.ServiciosDTO> IServicios = new List<YouCom.DTO.ServiciosDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ServiciosDAL.getListadoServicios(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ServiciosDTO servicio = new YouCom.DTO.ServiciosDTO();

                    servicio.IdServicio = decimal.Parse(wobjDataRow["IdServicio"].ToString());
                    servicio.IdRespServicio = decimal.Parse(wobjDataRow["idRespServicio"].ToString());
                    servicio.NombreServicio = wobjDataRow["nombreServicio"].ToString();
                    servicio.DescripcionServicio = wobjDataRow["descripcionServicio"].ToString();
                    servicio.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    servicio.IdAdministracion = decimal.Parse(wobjDataRow["idAdministracion"].ToString());
                    servicio.FechaInicio = DateTime.Parse(wobjDataRow["fechaInicio"].ToString());
                    servicio.FechaTermino = DateTime.Parse(wobjDataRow["fechaTermino"].ToString());

                    servicio.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    servicio.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    servicio.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    servicio.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    servicio.Estado = wobjDataRow["estado"].ToString();

                    IServicios.Add(servicio);
                }
            }

            return IServicios;

        }

        public static bool ValidaEliminacionServicio(YouCom.DTO.ServiciosDTO theServiciosDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ServiciosDAL.ValidaEliminacionServicio(theServiciosDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
    }
}
