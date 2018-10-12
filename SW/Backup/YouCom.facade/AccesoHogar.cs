using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class AccesoHogar
    {
        public static IList<YouCom.DTO.AccesoHogarDTO> getListadoAccesoHogar()
        {
            IList<YouCom.DTO.AccesoHogarDTO> IAccesoHogar = new List<YouCom.DTO.AccesoHogarDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AccesoHogarDAL.getListadoAccesoHogar(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AccesoHogarDTO accesoHogar = new YouCom.DTO.AccesoHogarDTO();

                    accesoHogar.IdAccesoHogar = decimal.Parse(wobjDataRow["IdAcceso"].ToString());
                    accesoHogar.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    accesoHogar.IdTipoVisita = decimal.Parse(wobjDataRow["idTipoVisita"].ToString());
                    accesoHogar.IdFrecuencia = decimal.Parse(wobjDataRow["idFrecuencia"].ToString());
                    accesoHogar.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    accesoHogar.FechaInicio = DateTime.Parse(wobjDataRow["FechaInicio"].ToString());
                    accesoHogar.FechaTermino = DateTime.Parse(wobjDataRow["fechaTermino"].ToString());
                    accesoHogar.NombreVisita = wobjDataRow["nombreVisita"].ToString();
                    accesoHogar.RutVisita = wobjDataRow["rutVisita"].ToString();
                    accesoHogar.Avisar = wobjDataRow["avisar"].ToString();

                    accesoHogar.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    accesoHogar.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    accesoHogar.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    accesoHogar.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    accesoHogar.Estado = wobjDataRow["estado"].ToString();

                    IAccesoHogar.Add(accesoHogar);
                }
            }

            return IAccesoHogar;

        }

        public static bool ValidaEliminacionAccesoHogar(YouCom.DTO.AccesoHogarDTO theAccesoHogarDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AccesoHogarDAL.ValidaEliminacionAccesoHogar(theAccesoHogarDTO, ref pobjDataTable))
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
