using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YouCom.DTO;

namespace YouCom.facade
{
    public class Ciudad
    {
        public static List<YouCom.DTO.CiudadDTO> getListadoCiudad()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.CiudadDTO theCiudadDTO;
            List<YouCom.DTO.CiudadDTO> collCiudad = new List<CiudadDTO>();

            if (YouCom.DAL.CiudadDAL.getListadoCiudad(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theCiudadDTO = new CiudadDTO();
                    theCiudadDTO.IdCiudad = wobjDataRow["idCiudad"] != null ? decimal.Parse(wobjDataRow["idCiudad"].ToString()) : 0;
                    theCiudadDTO.NombreCiudad = wobjDataRow["nombreCiudad"] != null ? wobjDataRow["nombreCiudad"].ToString() : string.Empty;
                    theCiudadDTO.DescripcionCiudad = wobjDataRow["descripcionCiudad"] != null ? wobjDataRow["descripcionCiudad"].ToString() : string.Empty;

                    YouCom.DTO.RegionDTO myRegion = new DTO.RegionDTO();

                    myRegion.IdRegion = wobjDataRow["idRegion"] != null ? decimal.Parse(wobjDataRow["idRegion"].ToString()) : 0;
                    myRegion.NombreRegion = wobjDataRow["nombreRegion"].ToString();

                    theCiudadDTO.TheRegionDTO = myRegion;

                    theCiudadDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    theCiudadDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    theCiudadDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    theCiudadDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    theCiudadDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;

                    collCiudad.Add(theCiudadDTO);
                }
            }
            return collCiudad;
        }
        public static bool ValidaEliminacionCiudad(CiudadDTO theCiudadDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.CiudadDAL.ValidaEliminacionCiudad(theCiudadDTO, ref pobjDataTable))
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
