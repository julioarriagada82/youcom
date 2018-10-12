using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Comunidad
    {
        public static IList<YouCom.DTO.ComunidadDTO> getListadoComunidad()
        {
            IList<YouCom.DTO.ComunidadDTO> IComunidad = new List<YouCom.DTO.ComunidadDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ComunidadDAL.getListadoComunidad(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ComunidadDTO comunidad = new YouCom.DTO.ComunidadDTO();

                    comunidad.IdComunidad = decimal.Parse(wobjDataRow["IdComercio"].ToString());
                    comunidad.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    comunidad.RutComunidad = wobjDataRow["rutComunidad"].ToString();
                    comunidad.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    comunidad.DireccionComunidad = wobjDataRow["direccionComunidad"].ToString();
                    comunidad.TelefonoComunidad = wobjDataRow["telefonoComunidad"].ToString();
                    comunidad.CorreoComunidad = wobjDataRow["correoComunidad"].ToString();

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

        public static bool ValidaEliminacionComunidad(YouCom.DTO.ComunidadDTO theComunidadDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ComunidadDAL.ValidaEliminacionComunidad(theComunidadDTO, ref pobjDataTable))
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
