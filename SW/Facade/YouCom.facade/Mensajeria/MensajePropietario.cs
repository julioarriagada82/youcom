using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class MensajePropietario
    {
        public static IList<YouCom.DTO.Mensajeria.MensajePropietarioDTO> getListadoMensajePropietario()
        {
            IList<YouCom.DTO.Mensajeria.MensajePropietarioDTO> IMensajePropietario = new List<YouCom.DTO.Mensajeria.MensajePropietarioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajePropietarioDAL.getListadoMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajePropietarioDTO mensaje_propietario = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

                    mensaje_propietario.IdMensajePropietario = decimal.Parse(wobjDataRow["IdMensajePropietario"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje_propietario.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje_propietario.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje_propietario.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    mensaje_propietario.TheFamiliaOrigenDTO = myFamiliaDTO;

                    if(!string.IsNullOrEmpty(wobjDataRow["idFamiliaDestino"].ToString()))
                    {
                        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaDestino"].ToString());
                        myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaDestino"].ToString();
                        myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaDestino"].ToString();
                        myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaDestino"].ToString();
                        mensaje_propietario.TheFamiliaDestinoDTO = myFamiliaDTO;
                    }

                    mensaje_propietario.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje_propietario.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje_propietario.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    mensaje_propietario.IdPadre = !string.IsNullOrEmpty(wobjDataRow["idPadre"].ToString()) ? decimal.Parse(wobjDataRow["idPadre"].ToString()) : 0;

                    mensaje_propietario.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje_propietario.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje_propietario.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje_propietario.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje_propietario.Estado = wobjDataRow["estado"].ToString();

                    IMensajePropietario.Add(mensaje_propietario);
                }
            }

            return IMensajePropietario;

        }

        public static bool ValidaEliminacionMensajePropietario(YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.MensajePropietarioDAL.ValidaEliminacionMensajePropietario(theMensajePropietarioDTO, ref pobjDataTable))
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
