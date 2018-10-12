using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class ForoComunidad
    {
        public static IList<YouCom.DTO.ForoComunidadDTO> getListadoForoComunidad()
        {
            IList<YouCom.DTO.ForoComunidadDTO> IForoComunidad = new List<YouCom.DTO.ForoComunidadDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ForoComunidadDAL.getListadoForoComunidad(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ForoComunidadDTO aviso = new YouCom.DTO.ForoComunidadDTO();

                    aviso.IdForoComunidad = decimal.Parse(wobjDataRow["idForoComunidad"].ToString());
                    aviso.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());

                    aviso.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    aviso.TituloForoComunidad = wobjDataRow["tituloForoComunidad"].ToString();
                    aviso.DescripcionForoComunidad = wobjDataRow["descripcionForoComunidad"].ToString();
                    aviso.IdTipo = decimal.Parse(wobjDataRow["idTipo"].ToString());
                    aviso.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    aviso.FechaPublicacion = DateTime.Parse(wobjDataRow["fechaPublicacion"].ToString());
                    aviso.FechaTermino = DateTime.Parse(wobjDataRow["fechaTermino"].ToString());
                    
                    aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    aviso.Estado = wobjDataRow["estado"].ToString();

                    IForoComunidad.Add(aviso);
                }
            }

            return IForoComunidad;

        }

        public static bool ValidaEliminacionForoComunidad(YouCom.DTO.ForoComunidadDTO theForoComunidadDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ForoComunidadDAL.ValidaEliminacionAviso(theForoComunidadDTO, ref pobjDataTable))
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