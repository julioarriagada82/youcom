using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Foro
{
    public class ForoComunidad
    {
        public static IList<YouCom.DTO.Foro.ForoComunidadDTO> getListadoForoComunidad()
        {
            IList<YouCom.DTO.Foro.ForoComunidadDTO> IForoComunidad = new List<YouCom.DTO.Foro.ForoComunidadDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ForoComunidadDAL.getListadoForoComunidad(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Foro.ForoComunidadDTO foro_comunidad = new YouCom.DTO.Foro.ForoComunidadDTO();

                    foro_comunidad.IdForoComunidad = decimal.Parse(wobjDataRow["IdForoComunidad"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    foro_comunidad.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    foro_comunidad.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    foro_comunidad.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO = new YouCom.DTO.Foro.ForoComunidadEstadoDTO();
                    myForoComunidadEstadoDTO.IdForoComunidadEstado = decimal.Parse(wobjDataRow["idForoComunidadEstado"].ToString());
                    myForoComunidadEstadoDTO.NombreForoComunidadEstado = wobjDataRow["nombreForoComunidadEstado"].ToString();
                    foro_comunidad.TheForoComunidadEstadoDTO = myForoComunidadEstadoDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    foro_comunidad.TheCategoriaDTO = myCategoriaDTO;

                    foro_comunidad.IdPadre = !string.IsNullOrEmpty(wobjDataRow["idPadre"].ToString()) ? decimal.Parse(wobjDataRow["idPadre"].ToString()) : 0;

                    foro_comunidad.FechaForoComunidad = !string.IsNullOrEmpty(wobjDataRow["fechaForo"].ToString()) ? DateTime.Parse(wobjDataRow["fechaForo"].ToString()) : DateTime.MinValue;
                    foro_comunidad.FechaTermino = !string.IsNullOrEmpty(wobjDataRow["fechaTerminoForo"].ToString()) ? DateTime.Parse(wobjDataRow["fechaTerminoForo"].ToString()) : DateTime.MinValue;
                    foro_comunidad.FechaPublicacion = !string.IsNullOrEmpty(wobjDataRow["fechaPublicacionForo"].ToString()) ? DateTime.Parse(wobjDataRow["fechaPublicacionForo"].ToString()) : DateTime.MinValue;
                    foro_comunidad.TituloForoComunidad = wobjDataRow["tituloForo"].ToString();
                    foro_comunidad.DescripcionForoComunidad = wobjDataRow["descripcionForo"].ToString();

                    foro_comunidad.MotivoEstadoForoComunidad = wobjDataRow["motivoEstadoForo"].ToString();

                    foro_comunidad.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    foro_comunidad.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    foro_comunidad.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    foro_comunidad.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    foro_comunidad.Estado = wobjDataRow["estado"].ToString();

                    IForoComunidad.Add(foro_comunidad);
                }
            }

            return IForoComunidad;

        }

        public static bool ValidaEliminacionForoComunidad(YouCom.DTO.Foro.ForoComunidadDTO theForoComunidadDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ForoComunidadDAL.ValidaEliminacionForoComunidad(theForoComunidadDTO, ref pobjDataTable))
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
