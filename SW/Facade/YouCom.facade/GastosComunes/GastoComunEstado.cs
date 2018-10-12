using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.GastosComunes
{
    public class GastoComunEstado
    {
        public static IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> getListadoGastoComunEstado()
        {
            IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> IGastoComunEstado = new List<YouCom.DTO.GastosComunes.GastoComunEstadoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.GastosComunes.GastoComunEstadoDAL.getListadoGastoComunEstado(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.GastosComunes.GastoComunEstadoDTO avisos = new YouCom.DTO.GastosComunes.GastoComunEstadoDTO();

                    avisos.IdGastoComunEstado = decimal.Parse(wobjDataRow["IdGastoComunEstado"].ToString());
                    avisos.NombreGastoComunEstado = wobjDataRow["nombreGastoComunEstado"].ToString();

                    avisos.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    avisos.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    avisos.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    avisos.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    avisos.Estado = wobjDataRow["estado"].ToString();

                    IGastoComunEstado.Add(avisos);
                }
            }

            return IGastoComunEstado;

        }

        public static bool ValidaEliminacionGastoComunEstado(YouCom.DTO.GastosComunes.GastoComunEstadoDTO theGastoComunEstadoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.GastosComunes.GastoComunEstadoDAL.ValidaEliminacionGastoComunEstado(theGastoComunEstadoDTO, ref pobjDataTable))
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
