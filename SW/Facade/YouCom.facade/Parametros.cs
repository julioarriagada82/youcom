using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class Parametros
    {
        public static IList<YouCom.DTO.ParametrosDTO> getListadoParametros()
        {
            IList<YouCom.DTO.ParametrosDTO> IParametros = new List<YouCom.DTO.ParametrosDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ParametrosDAL.getListadoParametros(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ParametrosDTO Parametros = new YouCom.DTO.ParametrosDTO();

                    Parametros.IdParametro = decimal.Parse(wobjDataRow["IdParametro"].ToString());
                    Parametros.Concepto = wobjDataRow["Concepto"].ToString();
                    Parametros.Codigo = wobjDataRow["Codigo"].ToString();

                    Parametros.Descripcion = wobjDataRow["Descripcion"].ToString();
                    Parametros.DescripcionCorta = wobjDataRow["DescripcionCorta"].ToString();
                    Parametros.Orden = int.Parse(wobjDataRow["Orden"].ToString());
                    Parametros.Estado = wobjDataRow["Estado"].ToString();

                    IParametros.Add(Parametros);
                }
            }

            return IParametros;

        }

        public static bool ValidaEliminacionParametros(YouCom.DTO.ParametrosDTO theParametrosDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ParametrosDAL.ValidaEliminacionParametros(theParametrosDTO, ref pobjDataTable))
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
