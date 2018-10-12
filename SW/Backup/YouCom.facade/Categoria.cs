using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Categoria
    {
        public static IList<YouCom.DTO.CategoriaDTO> getListadoCategoria()
        {
            IList<YouCom.DTO.CategoriaDTO> ICategoria = new List<YouCom.DTO.CategoriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.CategoriaDAL.getListadoCategoria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.CategoriaDTO categoria = new YouCom.DTO.CategoriaDTO();

                    categoria.IdCategoria = decimal.Parse(wobjDataRow["IdCategoria"].ToString());
                    categoria.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    categoria.DescripcionCategoria = wobjDataRow["descripcionCategoria"].ToString();
                    categoria.IdTipoCategoria = decimal.Parse(wobjDataRow["idTipoCategoria"].ToString());

                    categoria.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    categoria.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    categoria.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    categoria.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    categoria.Estado = wobjDataRow["estado"].ToString();

                    ICategoria.Add(categoria);
                }
            }

            return ICategoria;

        }

        public static bool ValidaEliminacionCategoria(YouCom.DTO.CategoriaDTO theCategoriaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.CategoriaDAL.ValidaEliminacionCategoria(theCategoriaDTO, ref pobjDataTable))
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
