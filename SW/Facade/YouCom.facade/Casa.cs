using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace YouCom.facade
{
    public class Casa
    {
        public static IList<YouCom.DTO.Propietario.CasaDTO> getListadoCasa()
        {
            IList<YouCom.DTO.Propietario.CasaDTO> ICasa = new List<YouCom.DTO.Propietario.CasaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Propietario.CasaDAL.getListadoCasas(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propietario.CasaDTO casa = new YouCom.DTO.Propietario.CasaDTO();

                    casa.IdCasa = decimal.Parse(wobjDataRow["IdCasa"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    casa.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    casa.TheComunidadDTO = myComunidadDTO;

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

        public static bool ValidaEliminacionCasa(YouCom.DTO.Propietario.CasaDTO theCasaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            List<YouCom.DTO.Propietario.CasaDTO> collCasa = new List<YouCom.DTO.Propietario.CasaDTO>();
            bool retorno = false;
            if (YouCom.DAL.Propietario.CasaDAL.ValidaEliminacionCasa(theCasaDTO, ref pobjDataTable))
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
