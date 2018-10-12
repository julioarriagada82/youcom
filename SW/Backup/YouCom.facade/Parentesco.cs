using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Parentesco
    {
        public static IList<YouCom.DTO.ParentescoDTO> getListadoParentesco()
        {
            IList<YouCom.DTO.ParentescoDTO> IParentesco = new List<YouCom.DTO.ParentescoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ParentescoDAL.getListadoParentesco(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ParentescoDTO parentesco = new YouCom.DTO.ParentescoDTO();

                    parentesco.IdParentesco = decimal.Parse(wobjDataRow["IdParentesco"].ToString());
                    parentesco.NombreParentesco = wobjDataRow["nombreParentesco"].ToString();

                    parentesco.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    parentesco.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    parentesco.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    parentesco.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    parentesco.Estado = wobjDataRow["estado"].ToString();

                    IParentesco.Add(parentesco);
                }
            }

            return IParentesco;

        }

        public static bool ValidaEliminacionParentesco(YouCom.DTO.ParentescoDTO theParentescoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ParentescoDAL.ValidaEliminacionParentesco(theParentescoDTO, ref pobjDataTable))
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
