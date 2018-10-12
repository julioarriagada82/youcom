using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Frecuencia
    {
        public static IList<YouCom.DTO.AccesoHogar.FrecuenciaDTO> getListadoFrecuencia()
        {
            IList<YouCom.DTO.AccesoHogar.FrecuenciaDTO> IFrecuencia = new List<YouCom.DTO.AccesoHogar.FrecuenciaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AccesoHogar.FrecuenciaDAL.getListadoFrecuencia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AccesoHogar.FrecuenciaDTO frecuencia = new YouCom.DTO.AccesoHogar.FrecuenciaDTO();

                    frecuencia.IdFrecuencia = decimal.Parse(wobjDataRow["IdFrecuencia"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    frecuencia.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    frecuencia.TheComunidadDTO = myComunidadDTO;

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

        public static bool ValidaEliminacionFrecuencia(YouCom.DTO.AccesoHogar.FrecuenciaDTO theFrecuenciaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AccesoHogar.FrecuenciaDAL.ValidaEliminacionFrecuencia(theFrecuenciaDTO, ref pobjDataTable))
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
