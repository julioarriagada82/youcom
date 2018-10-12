using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Mensajeria
{
    public class MensajeTipo
    {
            public static IList<YouCom.DTO.Mensajeria.MensajeTipoDTO> getListadoMensajeTipo()
        {
            IList<YouCom.DTO.Mensajeria.MensajeTipoDTO> IMensajeTipo = new List<YouCom.DTO.Mensajeria.MensajeTipoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Mensajeria.MensajeTipoDAL.getListadoMensajeTipo(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeTipoDTO mensaje_tipo = new YouCom.DTO.Mensajeria.MensajeTipoDTO();

                    mensaje_tipo.IdMensajeTipo = decimal.Parse(wobjDataRow["IdMensajeTipo"].ToString());
                    mensaje_tipo.NombreMensajeTipo = wobjDataRow["NombreMensajeTipo"].ToString();

                    mensaje_tipo.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje_tipo.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje_tipo.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje_tipo.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje_tipo.Estado = wobjDataRow["estado"].ToString();

                    IMensajeTipo.Add(mensaje_tipo);
                }
            }

            return IMensajeTipo;

        }

        public static bool ValidaEliminacionMensajeTipo(YouCom.DTO.Mensajeria.MensajeTipoDTO theMensajeTipoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.Mensajeria.MensajeTipoDAL.ValidaEliminacionMensajeTipo(theMensajeTipoDTO, ref pobjDataTable))
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
