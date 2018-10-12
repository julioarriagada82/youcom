using System.Collections.Generic;
using System.Data;

namespace YouCom.facade
{
    public class Comunidad
    {
        public static IList<YouCom.DTO.Seguridad.ComunidadDTO> getListadoComunidad()
        {
            IList<YouCom.DTO.Seguridad.ComunidadDTO> IComunidad = new List<YouCom.DTO.Seguridad.ComunidadDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Seguridad.DAL.ComunidadDAL.getListadoComunidad(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Seguridad.ComunidadDTO comunidad = new YouCom.DTO.Seguridad.ComunidadDTO();

                    comunidad.IdComunidad = decimal.Parse(wobjDataRow["IdComunidad"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    comunidad.TheCondominioDTO = myCondominio;

                    comunidad.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    comunidad.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    comunidad.DireccionComunidad = wobjDataRow["direccionComunidad"].ToString();
                    
                    comunidad.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    comunidad.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    comunidad.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    comunidad.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    comunidad.Estado = wobjDataRow["estado"].ToString();

                    IComunidad.Add(comunidad);
                }
            }

            return IComunidad;

        }

        public static bool ValidaEliminacionComunidad(YouCom.DTO.Seguridad.ComunidadDTO theComunidadDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Seguridad.DAL.ComunidadDAL.ValidaEliminacionComunidad(theComunidadDTO, ref pobjDataTable))
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
