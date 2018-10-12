using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade.Mensajeria
{
    public class MensajePorteria
    {
        public static IList<YouCom.DTO.Mensajeria.MensajePorteriaDTO> getListadoMensajePorteria()
        {
            IList<YouCom.DTO.Mensajeria.MensajePorteriaDTO> IMensajePorteria = new List<YouCom.DTO.Mensajeria.MensajePorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.getListadoMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajePorteriaDTO mensaje_porteria = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

                    mensaje_porteria.IdMensajePorteria = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje_porteria.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje_porteria.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje_porteria.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    mensaje_porteria.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    mensaje_porteria.ThePorteriaDTO = myPorteriaDTO;

                    YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
                    myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = decimal.Parse(wobjDataRow["idMensajeTipoEnvio"].ToString());
                    mensaje_porteria.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

                    mensaje_porteria.IdPadre = !string.IsNullOrEmpty(wobjDataRow["idPadre"].ToString()) ? decimal.Parse(wobjDataRow["idPadre"].ToString()) : 0;

                    mensaje_porteria.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje_porteria.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje_porteria.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    mensaje_porteria.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje_porteria.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje_porteria.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje_porteria.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje_porteria.Estado = wobjDataRow["estado"].ToString();

                    IMensajePorteria.Add(mensaje_porteria);
                }
            }

            return IMensajePorteria;

        }

        public static bool ValidaEliminacionMensajePorteria(YouCom.DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.ValidaEliminacionMensajePorteria(theMensajePorteriaDTO, ref pobjDataTable))
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
