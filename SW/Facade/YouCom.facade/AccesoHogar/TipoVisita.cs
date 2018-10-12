using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class TipoVisita
    {
        public static IList<YouCom.DTO.AccesoHogar.TipoVisitaDTO> getListadoTipoVisita()
        {
            IList<YouCom.DTO.AccesoHogar.TipoVisitaDTO> ITipoVisita = new List<YouCom.DTO.AccesoHogar.TipoVisitaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AccesoHogar.TipoVisitaDAL.getListadoTipoVisita(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AccesoHogar.TipoVisitaDTO tipo_Visita = new YouCom.DTO.AccesoHogar.TipoVisitaDTO();

                    tipo_Visita.IdTipoVisita = decimal.Parse(wobjDataRow["IdTipoVisita"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    tipo_Visita.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    tipo_Visita.TheComunidadDTO = myComunidadDTO;

                    tipo_Visita.NombreTipoVisita = wobjDataRow["nombreTipoVisita"].ToString();

                    tipo_Visita.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_Visita.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_Visita.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_Visita.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_Visita.Estado = wobjDataRow["estado"].ToString();

                    ITipoVisita.Add(tipo_Visita);
                }
            }

            return ITipoVisita;

        }

        public static bool ValidaEliminacionTipoVisita(YouCom.DTO.AccesoHogar.TipoVisitaDTO theTipoVisitaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AccesoHogar.TipoVisitaDAL.ValidaEliminacionTipoVisita(theTipoVisitaDTO, ref pobjDataTable))
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
