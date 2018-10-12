using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Porteria
    {
        public static IList<YouCom.DTO.PorteriaDTO> getListadoPorteria()
        {
            IList<YouCom.DTO.PorteriaDTO> IPorteria = new List<YouCom.DTO.PorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.PorteriaDAL.getListadoPorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.PorteriaDTO portero = new YouCom.DTO.PorteriaDTO();

                    portero.IdPorteria = decimal.Parse(wobjDataRow["IdPorteria"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    portero.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    portero.TheComunidadDTO = myComunidadDTO;

                    portero.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    portero.ApellidoPaternoPorteria = wobjDataRow["apellidoPaternoPorteria"].ToString();
                    portero.ApellidoMaternoPorteria = wobjDataRow["apellidoMaternoPorteria"].ToString();
                    portero.RutPorteria = wobjDataRow["rutPorteria"].ToString();
                    portero.TelefonoPorteria = wobjDataRow["telefonoPorteria"].ToString();
                    portero.EmailPorteria = wobjDataRow["emailPorteria"].ToString();
                    portero.FechaNacimientoPorteria = Convert.ToDateTime(wobjDataRow["fechaNacimientoPorteria"].ToString());

                    portero.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    portero.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    portero.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    portero.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    portero.Estado = wobjDataRow["estado"].ToString();

                    IPorteria.Add(portero);
                }
            }

            return IPorteria;

        }

        public static bool ValidaEliminacionPorteria(YouCom.DTO.PorteriaDTO thePorteriaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.PorteriaDAL.ValidaEliminacionPorteria(thePorteriaDTO, ref pobjDataTable))
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
