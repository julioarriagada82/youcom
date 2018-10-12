using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YouCom.DTO;

namespace YouCom.facade
{
    public class Comuna
    {
        public static List<YouCom.DTO.ComunaDTO> getListadoComuna()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.ComunaDTO theComunaDTO;
            List<YouCom.DTO.ComunaDTO> collComuna = new List<ComunaDTO>();

            if (YouCom.DAL.ComunaDAL.getListadoComuna(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theComunaDTO = new ComunaDTO();
                    theComunaDTO.IdComuna = wobjDataRow["idComuna"] != null ? decimal.Parse(wobjDataRow["idComuna"].ToString()) : 0;
                    theComunaDTO.NombreComuna = wobjDataRow["nombreComuna"] != null ? wobjDataRow["nombreComuna"].ToString() : string.Empty;
                    theComunaDTO.DescripcionComuna = wobjDataRow["descripcionComuna"] != null ? wobjDataRow["descripcionComuna"].ToString() : string.Empty;

                    YouCom.DTO.CiudadDTO myCiudad = new DTO.CiudadDTO();

                    myCiudad.IdCiudad = wobjDataRow["idCiudad"] != null ? decimal.Parse(wobjDataRow["idCiudad"].ToString()) : 0;
                    myCiudad.NombreCiudad = wobjDataRow["nombreCiudad"].ToString();

                    theComunaDTO.TheCiudadDTO = myCiudad;

                    theComunaDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    theComunaDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    theComunaDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    theComunaDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    theComunaDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;

                    collComuna.Add(theComunaDTO);
                }
            }
            return collComuna;
        }
        public static bool ValidaEliminacionComuna(ComunaDTO theComunaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ComunaDAL.ValidaEliminacionComuna(theComunaDTO, ref pobjDataTable))
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
