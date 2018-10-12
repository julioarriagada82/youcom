using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Frecuencia
    {
        public static IList<YouCom.DTO.FrecuenciaDTO> getListadoFrecuencia()
        {
            IList<YouCom.DTO.FrecuenciaDTO> IFrecuencia = new List<YouCom.DTO.FrecuenciaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.FrecuenciaDAL.getListadoFrecuencia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.FrecuenciaDTO frecuencia = new YouCom.DTO.FrecuenciaDTO();

                    frecuencia.IdFrecuencia = decimal.Parse(wobjDataRow["IdFrecuencia"].ToString());
                    frecuencia.NombreFrecuencia = wobjDataRow["nombreFrecuencia"].ToString();

                    frecuencia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    frecuencia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    frecuencia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    frecuencia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    frecuencia.Estado = wobjDataRow["estado"].ToString();

                    IFrecuencia.Add(frecuencia);
                }
            }

            return IFrecuencia;

        }

        public static bool ValidaEliminacionFrecuencia(YouCom.DTO.FrecuenciaDTO theFrecuenciaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.FrecuenciaDAL.ValidaEliminacionFrecuencia(theFrecuenciaDTO, ref pobjDataTable))
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
