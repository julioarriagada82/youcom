using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Cargo
    {
        public static IList<YouCom.DTO.CargoDTO> getListadoCargo()
        {
            IList<YouCom.DTO.CargoDTO> ICargo = new List<YouCom.DTO.CargoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.CargoDAL.getListadoCargo(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.CargoDTO cargo = new YouCom.DTO.CargoDTO();

                    cargo.IdCargo = decimal.Parse(wobjDataRow["IdCargo"].ToString());
                    cargo.NombreCargo = wobjDataRow["nombreCargo"].ToString();
                    cargo.DescripcionCargo = wobjDataRow["descripcionCargo"].ToString();

                    cargo.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    cargo.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    cargo.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    cargo.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    cargo.Estado = wobjDataRow["estado"].ToString();

                    ICargo.Add(cargo);
                }
            }

            return ICargo;

        }

        public static bool ValidaEliminacionCargo(YouCom.DTO.CargoDTO theCargoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.CargoDAL.ValidaEliminacionCargo(theCargoDTO, ref pobjDataTable))
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
