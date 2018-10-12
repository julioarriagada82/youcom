using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.BLL
{
    public class PermisoBLL
    {
        public static bool Insert(PermisoDTO thePermisoDTO)
        {
            var resultado = YouCom.Seguridad.DAL.PermisoDAL.Insert(thePermisoDTO);
            return resultado;
        }
        public static bool Delete(PermisoDTO thePermisoDTO)
        {
            var resultado = YouCom.Seguridad.DAL.PermisoDAL.Delete(thePermisoDTO);
            return resultado;
        }
        public static IList<PermisoDTO> getListadoPermiso()
        {
            var resultado = YouCom.facade.Seguridad.Permiso.getListadoPermiso();
            return resultado;
        }
    }
}
