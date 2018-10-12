using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class TipoCategoria
    {
        public static IList<YouCom.DTO.TipoCategoriaDTO> getListadoTipoCategoria()
        {
            IList<YouCom.DTO.TipoCategoriaDTO> ITipoCategoria = new List<YouCom.DTO.TipoCategoriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.TipoCategoriaDAL.getListadoTipoCategoria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.TipoCategoriaDTO tipo_categoria = new YouCom.DTO.TipoCategoriaDTO();

                    tipo_categoria.IdTipoCategoria = decimal.Parse(wobjDataRow["IdTipoCategoria"].ToString());
                    tipo_categoria.NombreTipoCategoria = wobjDataRow["nombreTipoCategoria"].ToString();

                    tipo_categoria.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_categoria.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_categoria.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_categoria.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_categoria.Estado = wobjDataRow["estado"].ToString();

                    ITipoCategoria.Add(tipo_categoria);
                }
            }

            return ITipoCategoria;

        }

        public static bool ValidaEliminacionTipoCategoria(YouCom.DTO.TipoCategoriaDTO theTipoCategoriaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.TipoCategoriaDAL.ValidaEliminacionTipoCategoria(theTipoCategoriaDTO, ref pobjDataTable))
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
