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
        public static List<YouCom.DTO.RegionDTO> ListadoRegiones()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.RegionDTO theRegionDTO;
            List<YouCom.DTO.RegionDTO> collRegion = new List<RegionDTO>();

            if (YouCom.Comun.DAL.Accesos.Region.ListadoRegiones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theRegionDTO = new RegionDTO();
                    theRegionDTO.IdRegion = wobjDataRow["id_reg"] != null ? wobjDataRow["id_reg"].ToString() : string.Empty;
                    theRegionDTO.Descripcion = wobjDataRow["dsc_reg"] != null ? wobjDataRow["dsc_reg"].ToString() : string.Empty;
                    theRegionDTO.IdPais = wobjDataRow["idPais"] != null ? wobjDataRow["idPais"].ToString() : string.Empty;
                    theRegionDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    theRegionDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    theRegionDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    theRegionDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    theRegionDTO.IdCondominio = !string.IsNullOrEmpty(wobjDataRow["empresa"].ToString()) ? decimal.Parse(wobjDataRow["empresa"].ToString()) : 0;
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
            if (YouCom.mantenedores.DAL.MantenedoresDAL.ValidaEliminacionRegion(theRegionDTO, ref pobjDataTable))
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
