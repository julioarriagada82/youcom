using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade.Avisos
{
    public class Aviso
    {
        public static IList<YouCom.DTO.Avisos.AvisoDTO> getListadoAvisos()
        {
            IList<YouCom.DTO.Avisos.AvisoDTO> IAvisos = new List<YouCom.DTO.Avisos.AvisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AvisosDAL.getListadoAvisos(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Avisos.AvisoDTO aviso = new YouCom.DTO.Avisos.AvisoDTO();

                    aviso.IdAviso = decimal.Parse(wobjDataRow["idAvisos"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    aviso.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    aviso.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamilia = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamilia.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamilia.RutFamilia = wobjDataRow["rutFamilia"].ToString();
                    myFamilia.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamilia.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamilia.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    aviso.TheFamiliaDTO = myFamilia;

                    aviso.TituloAviso = wobjDataRow["tituloAviso"].ToString();
                    aviso.DescripcionAviso = wobjDataRow["descripcionAviso"].ToString();
                    aviso.ImagenAviso = wobjDataRow["imagenAviso"].ToString();

                    YouCom.DTO.Avisos.TipoAvisoDTO myTipoAviso = new YouCom.DTO.Avisos.TipoAvisoDTO();
                    myTipoAviso.IdTipoAviso = decimal.Parse(wobjDataRow["idTipoAviso"].ToString());
                    myTipoAviso.NombreTipoAviso = wobjDataRow["nombreTipoAviso"].ToString();
                    aviso.TheTipoAvisoDTO = myTipoAviso;

                    YouCom.DTO.CategoriaDTO myCategoria = new YouCom.DTO.CategoriaDTO();
                    myCategoria.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoria.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    aviso.TheCategoriaDTO = myCategoria;

                    aviso.PrecioAviso = decimal.Parse(wobjDataRow["precio"].ToString());

                    YouCom.DTO.MonedaDTO myMoneda = new YouCom.DTO.MonedaDTO();
                    myMoneda.IdMoneda = decimal.Parse(wobjDataRow["idMoneda"].ToString());
                    aviso.TheMonedaDTO = myMoneda;

                    YouCom.DTO.Avisos.AvisoEstadoDTO myAvisosEstadoDTO = new YouCom.DTO.Avisos.AvisoEstadoDTO();
                    myAvisosEstadoDTO.IdAvisoEstado = decimal.Parse(wobjDataRow["idAvisoEstado"].ToString());
                    myAvisosEstadoDTO.NombreAvisoEstado = wobjDataRow["nombreAvisoEstado"].ToString();
                    aviso.TheAvisosEstadoDTO = myAvisosEstadoDTO;

                    aviso.MotivoAvisoEstado = wobjDataRow["motivoAvisoEstado"].ToString();

                    aviso.FechaPublicacion = !string.IsNullOrEmpty(wobjDataRow["fechaPublicacion"].ToString()) ? DateTime.Parse(wobjDataRow["fechaPublicacion"].ToString()) : DateTime.MinValue;
                    aviso.FechaTermino = !string.IsNullOrEmpty(wobjDataRow["fechaTermino"].ToString()) ? DateTime.Parse(wobjDataRow["fechaTermino"].ToString()) : DateTime.MinValue;
                    aviso.FechaCompra = !string.IsNullOrEmpty(wobjDataRow["fechaCompra"].ToString()) ? DateTime.Parse(wobjDataRow["fechaCompra"].ToString()) : DateTime.MinValue;
                    aviso.RutComprador = wobjDataRow["rutComprador"].ToString();

                    aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    aviso.Estado = wobjDataRow["estado"].ToString();

                    IAvisos.Add(aviso);
                }
            }

            return IAvisos;

        }

        public static bool ValidaEliminacionAvisos(YouCom.DTO.Avisos.AvisoDTO theAvisosDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AvisosDAL.ValidaEliminacionAviso(theAvisosDTO, ref pobjDataTable))
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