using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class MensajeDirectiva
    {
        public static IList<YouCom.DTO.Mensajeria.MensajeDirectivaDTO> getListadoMensajeDirectiva()
        {
            IList<YouCom.DTO.Mensajeria.MensajeDirectivaDTO> IMensajeDirectiva = new List<YouCom.DTO.Mensajeria.MensajeDirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajeDirectivaDAL.getListadoMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO mensaje_directiva = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();

                    mensaje_directiva.IdMensajeDirectiva = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje_directiva.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje_directiva.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje_directiva.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    mensaje_directiva.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    mensaje_directiva.TheDirectivaDTO = myDirectivaDTO;

                    mensaje_directiva.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje_directiva.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje_directiva.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
                    myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = decimal.Parse(wobjDataRow["idMensajeTipoEnvio"].ToString());
                    mensaje_directiva.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

                    mensaje_directiva.IdPadre = !string.IsNullOrEmpty(wobjDataRow["idPadre"].ToString()) ? decimal.Parse(wobjDataRow["idPadre"].ToString()) : 0;

                    mensaje_directiva.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje_directiva.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje_directiva.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje_directiva.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje_directiva.Estado = wobjDataRow["estado"].ToString();

                    IMensajeDirectiva.Add(mensaje_directiva);
                }
            }

            return IMensajeDirectiva;

        }

        public static bool ValidaEliminacionMensajeDirectiva(YouCom.DTO.Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.MensajeDirectivaDAL.ValidaEliminacionMensajeDirectiva(theMensajeDirectivaDTO, ref pobjDataTable))
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
