using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YouCom.DTO;

namespace YouCom.facade
{
    public class Region
    {
        public static List<YouCom.DTO.RegionDTO> getListadoRegion()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.RegionDTO theRegionDTO;
            List<YouCom.DTO.RegionDTO> collRegion = new List<RegionDTO>();

            if (YouCom.DAL.RegionDAL.getListadoRegion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theRegionDTO = new RegionDTO();
                    theRegionDTO.IdRegion = wobjDataRow["idRegion"] != null ? decimal.Parse(wobjDataRow["idRegion"].ToString()) : 0;
                    theRegionDTO.NombreRegion = wobjDataRow["nombreRegion"] != null ? wobjDataRow["nombreRegion"].ToString() : string.Empty;
                    theRegionDTO.DescripcionRegion = wobjDataRow["descripcionRegion"] != null ? wobjDataRow["descripcionRegion"].ToString() : string.Empty;

                    PaisDTO myPaisDTO = new PaisDTO();
                    myPaisDTO.IdPais = wobjDataRow["idPais"] != null ? decimal.Parse(wobjDataRow["idPais"].ToString()) : 0;
                    myPaisDTO.NombrePais = wobjDataRow["nombrePais"] != null ? wobjDataRow["nombrePais"].ToString() : string.Empty;
                    theRegionDTO.ThePaisDTO = myPaisDTO;

                    theRegionDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    theRegionDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    theRegionDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    theRegionDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    theRegionDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;


                    collRegion.Add(theRegionDTO);
                }
            }
            return collRegion;
        }
        public static bool ValidaEliminacionRegion(RegionDTO theRegionDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.RegionDAL.ValidaEliminacionRegion(theRegionDTO, ref pobjDataTable))
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
