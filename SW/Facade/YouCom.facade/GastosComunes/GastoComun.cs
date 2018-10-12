using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade.GastosComunes
{
    public class GastoComun
    {
        public static IList<YouCom.DTO.GastosComunes.GastoComunDTO> getListadoGastosComunes()
        {
            IList<YouCom.DTO.GastosComunes.GastoComunDTO> IGastosComunes = new List<YouCom.DTO.GastosComunes.GastoComunDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.GastosComunes.GastoComunDAL.getListadoGastosComunes(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.GastosComunes.GastoComunDTO gastos = new YouCom.DTO.GastosComunes.GastoComunDTO();

                    gastos.IdGastoComun = decimal.Parse(wobjDataRow["idGasto"].ToString());
                    
                    YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
                    myCasaDTO.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    gastos.TheCasaDTO = myCasaDTO;

                    YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO = new YouCom.DTO.GastosComunes.GastoComunEstadoDTO();
                    myGastoComunEstadoDTO.IdGastoComunEstado = decimal.Parse(wobjDataRow["idGastoComunEstado"].ToString());
                    myGastoComunEstadoDTO.NombreGastoComunEstado = wobjDataRow["nombreGastoComunEstado"].ToString();
                    gastos.TheGastoComunEstadoDTO = myGastoComunEstadoDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    gastos.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    gastos.TheComunidadDTO = myComunidadDTO;

                    gastos.DescripcionGasto = wobjDataRow["descripcionGasto"].ToString();
                    gastos.MontoGasto = decimal.Parse(wobjDataRow["montoGasto"].ToString());
                    gastos.FechaGasto = Convert.ToDateTime(wobjDataRow["fechaGasto"].ToString());
                    gastos.FechaVencimiento = Convert.ToDateTime(wobjDataRow["fechaVencimiento"].ToString());
                    gastos.ArchivoGasto = wobjDataRow["archivoGasto"].ToString();
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

        public static bool ValidaEliminacionGastoComun(YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunesDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.GastosComunes.GastoComunDAL.ValidaEliminacionGastoComun(theGastosComunesDTO, ref pobjDataTable))
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
