using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class Giro
    {
        public static IList<YouCom.DTO.GiroDTO> getListadoGiro()
        {
            IList<YouCom.DTO.GiroDTO> IGiro = new List<YouCom.DTO.GiroDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.GiroDAL.getListadoGiro(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.GiroDTO Giro = new YouCom.DTO.GiroDTO();

                    Giro.IdGiro = decimal.Parse(wobjDataRow["IdGiro"].ToString());
                    Giro.NombreGiro = wobjDataRow["nombreGiro"].ToString();
                    Giro.DescripcionGiro = wobjDataRow["descripcionGiro"].ToString();

                    Giro.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    Giro.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    Giro.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    Giro.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    Giro.Estado = wobjDataRow["estado"].ToString();

                    IGiro.Add(Giro);
                }
            }

            return IGiro;

        }

        public static bool ValidaEliminacionGiro(YouCom.DTO.GiroDTO theGiroDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.GiroDAL.ValidaEliminacionGiro(theGiroDTO, ref pobjDataTable))
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
