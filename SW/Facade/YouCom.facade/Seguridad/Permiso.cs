using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class Permiso
    {
        public static IList<YouCom.DTO.Seguridad.PermisoDTO> getListadoPermiso()
        {
            IList<YouCom.DTO.Seguridad.PermisoDTO> IPermiso = new List<YouCom.DTO.Seguridad.PermisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Seguridad.DAL.PermisoDAL.ListadoPermiso(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Seguridad.PermisoDTO permiso = new YouCom.DTO.Seguridad.PermisoDTO();

                    permiso.Empresa = wobjDataRow["IdComunidad"].ToString();
                    permiso.Funcion = wobjDataRow["nombreCondominio"].ToString();
                    permiso.Usuario = wobjDataRow["direccionCondominio"].ToString();

                    IPermiso.Add(permiso);
                }
            }

            return IPermiso;

        }
    }
}
