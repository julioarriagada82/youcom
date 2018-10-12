using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class MensajeNoticia
    {
        public static IList<YouCom.DTO.Mensajeria.MensajeNoticiaDTO> getListadoMensajeNoticia()
        {
            IList<YouCom.DTO.Mensajeria.MensajeNoticiaDTO> IMensajeNoticia = new List<YouCom.DTO.Mensajeria.MensajeNoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajeNoticiaDAL.getListadoMensajeNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO mensaje_Noticia = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();

                    mensaje_Noticia.IdMensajeNoticia = decimal.Parse(wobjDataRow["IdMensajeNoticia"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje_Noticia.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje_Noticia.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje_Noticia.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    if (!string.IsNullOrEmpty(wobjDataRow["idFamiliaOrigen"].ToString()))
                    {
                        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                        myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                        myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
                        myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                        mensaje_Noticia.TheFamiliaOrigenDTO = myFamiliaDTO;
                    }

                    if(!string.IsNullOrEmpty(wobjDataRow["idFamiliaDestino"].ToString()))
                    {
                        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaDestino"].ToString());
                        myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaDestino"].ToString();
                        myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaDestino"].ToString();
                        myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaDestino"].ToString();
                        mensaje_Noticia.TheFamiliaDestinoDTO = myFamiliaDTO;
                    }

                    mensaje_Noticia.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje_Noticia.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje_Noticia.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    mensaje_Noticia.IdPadre = !string.IsNullOrEmpty(wobjDataRow["idPadre"].ToString()) ? decimal.Parse(wobjDataRow["idPadre"].ToString()) : 0;

                    mensaje_Noticia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje_Noticia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje_Noticia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje_Noticia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje_Noticia.Estado = wobjDataRow["estado"].ToString();

                    IMensajeNoticia.Add(mensaje_Noticia);
                }
            }

            return IMensajeNoticia;

        }

        public static bool ValidaEliminacionMensajeNoticia(YouCom.DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.MensajeNoticiaDAL.ValidaEliminacionMensajeNoticia(theMensajeNoticiaDTO, ref pobjDataTable))
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
