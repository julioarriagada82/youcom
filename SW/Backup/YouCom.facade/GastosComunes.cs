using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class GastosComunes
    {
        public static IList<YouCom.DTO.GastosComunesDTO> getListadoGastosComunes()
        {
            IList<YouCom.DTO.GastosComunesDTO> IGastosComunes = new List<YouCom.DTO.GastosComunesDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.GastosComunesDAL.getListadoGastosComunes(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.GastosComunesDTO gastos = new YouCom.DTO.GastosComunesDTO();

                    gastos.IdGastoComun = decimal.Parse(wobjDataRow["idGasto"].ToString());
                    gastos.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    gastos.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    gastos.DescripcionGasto = wobjDataRow["descripcionGasto"].ToString();
                    gastos.MontoGasto = decimal.Parse(wobjDataRow["montoGasto"].ToString());
                    gastos.FechaGasto = Convert.ToDateTime(wobjDataRow["fechaGasto"].ToString());
                    gastos.ArchivoGasto = wobjDataRow["archivoGasto"].ToString();
                    gastos.EstadoGasto = wobjDataRow["estadoGasto"].ToString();
                    gastos.FechaPagoGasto = Convert.ToDateTime(wobjDataRow["fechaPagoGasto"].ToString());
                    gastos.ComentarioGasto = wobjDataRow["comentarioGasto"].ToString();

                    gastos.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    gastos.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    gastos.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    gastos.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    gastos.Estado = wobjDataRow["estado"].ToString();

                    IGastosComunes.Add(gastos);
                }
            }

            return IGastosComunes;

        }

        public static bool ValidaEliminacionGastoComun(YouCom.DTO.GastosComunesDTO theGastosComunesDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.GastosComunesDAL.ValidaEliminacionGastoComun(theGastosComunesDTO, ref pobjDataTable))
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
