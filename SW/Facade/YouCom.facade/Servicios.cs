using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Servicios
    {
        public static IList<YouCom.DTO.Servicio.ServiciosDTO> getListadoServicios()
        {
            IList<YouCom.DTO.Servicio.ServiciosDTO> IServicios = new List<YouCom.DTO.Servicio.ServiciosDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ServiciosDAL.getListadoServicios(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Servicio.ServiciosDTO servicio = new YouCom.DTO.Servicio.ServiciosDTO();

                    servicio.IdServicio = decimal.Parse(wobjDataRow["IdServicio"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    servicio.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    servicio.TheComunidadDTO = myComunidadDTO;
                    
                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    servicio.TheCategoriaDTO = myCategoriaDTO;

                    servicio.NombreServicio = wobjDataRow["nombreServicio"].ToString();
                    servicio.DescripcionServicio = wobjDataRow["descripcionServicio"].ToString();
                    servicio.ImagenServicio = wobjDataRow["imagenServicio"].ToString();

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

        public static bool ValidaEliminacionServicio(YouCom.DTO.Servicio.ServiciosDTO theServiciosDTO)
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
