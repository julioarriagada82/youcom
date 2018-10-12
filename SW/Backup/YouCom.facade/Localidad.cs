using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using System.Data;

namespace YouCom.facade
{
    public class Localidad
    {
        public static bool ValidaEliminacionLocalidad(LocalidadDTO theLocalidadDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.mantenedores.DAL.MantenedoresDAL.ValidaEliminacionLocalidad(theLocalidadDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {

                    retorno = true;


                }

            }
            return retorno;
        }
        public static List<LocalidadDTO> ListadoLocalidadByRegion(int idRegion)
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.LocalidadDTO theLocalidadDTO;
            List<YouCom.DTO.LocalidadDTO> collLocalidad=new List<LocalidadDTO>();

            if (YouCom.Comun.DAL.Accesos.Localidad.ListadoLocalidadByRegion(idRegion, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theLocalidadDTO=new LocalidadDTO();
                    theLocalidadDTO.IdLocalidad = wobjDataRow["id_loc"] != null ? wobjDataRow["id_loc"].ToString() : string.Empty;
                    theLocalidadDTO.IdRegion = wobjDataRow["id_reg"] != null ? wobjDataRow["id_reg"].ToString() : string.Empty;
                    theLocalidadDTO.Descripcion = wobjDataRow["dsc_loc"] != null ? wobjDataRow["dsc_loc"].ToString() : string.Empty;
                    theLocalidadDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    theLocalidadDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    theLocalidadDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    theLocalidadDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    theLocalidadDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;

                    collLocalidad.Add(theLocalidadDTO);
                }
            }
            return collLocalidad;

        }
        public static List<LocalidadDTO> ListadoLocalidad()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.LocalidadDTO theLocalidadDTO;
            List<YouCom.DTO.LocalidadDTO> collLocalidad = new List<LocalidadDTO>();

            if (YouCom.Comun.DAL.Accesos.Localidad.ListadoLocalidad( ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theLocalidadDTO = new LocalidadDTO();
                    theLocalidadDTO.IdLocalidad = wobjDataRow["id_loc"] != null ? wobjDataRow["id_loc"].ToString() : string.Empty;
                    theLocalidadDTO.IdRegion = wobjDataRow["id_reg"] != null ? wobjDataRow["id_reg"].ToString() : string.Empty;
                    theLocalidadDTO.Descripcion = wobjDataRow["dsc_loc"] != null ? wobjDataRow["dsc_loc"].ToString() : string.Empty;
                    theLocalidadDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    theLocalidadDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    theLocalidadDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    theLocalidadDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    theLocalidadDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;

                    collLocalidad.Add(theLocalidadDTO);
                }
            }
            return collLocalidad;
        }
    }
}
