using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Foro
{
    public class ForoComunidadEstado
    {
        public static IList<YouCom.DTO.Foro.ForoComunidadEstadoDTO> getListadoForoComunidadEstado()
        {
            IList<YouCom.DTO.Foro.ForoComunidadEstadoDTO> IForoComunidadEstado = new List<YouCom.DTO.Foro.ForoComunidadEstadoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ForoComunidadEstadoDAL.getListadoForoComunidadEstado(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Foro.ForoComunidadEstadoDTO foro_comunidad = new YouCom.DTO.Foro.ForoComunidadEstadoDTO();

                    foro_comunidad.IdForoComunidadEstado = decimal.Parse(wobjDataRow["IdForoComunidadEstado"].ToString());
                    foro_comunidad.NombreForoComunidadEstado = wobjDataRow["nombreForoComunidadEstado"].ToString();

                    foro_comunidad.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    foro_comunidad.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    foro_comunidad.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    foro_comunidad.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    foro_comunidad.Estado = wobjDataRow["estado"].ToString();

                    IForoComunidadEstado.Add(foro_comunidad);
                }
            }

            return IForoComunidadEstado;

        }

        public static bool ValidaEliminacionForoComunidadEstado(YouCom.DTO.Foro.ForoComunidadEstadoDTO theForoComunidadEstadoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ForoComunidadEstadoDAL.ValidaEliminacionForoComunidadEstado(theForoComunidadEstadoDTO, ref pobjDataTable))
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
