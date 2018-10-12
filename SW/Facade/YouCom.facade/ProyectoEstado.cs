using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class ProyectoEstado
    {
        public static IList<YouCom.DTO.ProyectoEstadoDTO> getListadoProyectoEstado()
        {
            IList<YouCom.DTO.ProyectoEstadoDTO> IProyectoEstado = new List<YouCom.DTO.ProyectoEstadoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ProyectoEstadoDAL.getListadoProyectoEstado(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ProyectoEstadoDTO ProyectoEstado = new YouCom.DTO.ProyectoEstadoDTO();

                    ProyectoEstado.IdProyectoEstado = decimal.Parse(wobjDataRow["IdProyectoEstado"].ToString());
                    ProyectoEstado.NombreProyectoEstado = wobjDataRow["nombreProyectoEstado"].ToString();
                    
                    ProyectoEstado.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    ProyectoEstado.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    ProyectoEstado.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    ProyectoEstado.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    ProyectoEstado.Estado = wobjDataRow["estado"].ToString();

                    IProyectoEstado.Add(ProyectoEstado);
                }
            }

            return IProyectoEstado;

        }

        public static bool ValidaEliminacionProyectoEstado(YouCom.DTO.ProyectoEstadoDTO theProyectoEstadoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ProyectoEstadoDAL.ValidaEliminacionProyectoEstado(theProyectoEstadoDTO, ref pobjDataTable))
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
