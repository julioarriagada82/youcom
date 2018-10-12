using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace YouCom.facade
{
    public class Casa
    {
        public static IList<YouCom.DTO.CasaDTO> getListadoCasa()
        {
            IList<YouCom.DTO.CasaDTO> ICasa = new List<YouCom.DTO.CasaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.CasaDAL.getListadoCasas(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.CasaDTO casa = new YouCom.DTO.CasaDTO();

                    casa.IdCasa = decimal.Parse(wobjDataRow["IdCasa"].ToString());
                    casa.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    casa.NombreCasa = wobjDataRow["nombreCasa"].ToString();
                    casa.DireccionCasa = wobjDataRow["direccionCasa"].ToString();
                    casa.TelefonoCasa = wobjDataRow["telefonoCasa"].ToString();

                    casa.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    casa.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    casa.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    casa.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    casa.Estado = wobjDataRow["estado"].ToString();

                    ICasa.Add(casa);
                }
            }

            return ICasa;

        }

        public static bool ValidaEliminacionCasa(YouCom.DTO.CasaDTO theCasaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            List<YouCom.DTO.CasaDTO> collCasa = new List<YouCom.DTO.CasaDTO>();
            bool retorno = false;
            if (YouCom.DAL.CasaDAL.ValidaEliminacionCasa(theCasaDTO, ref pobjDataTable))
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
