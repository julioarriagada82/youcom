using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class EleccionMensajePropietario
    {
        public static IList<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO> getListadoEleccionMensajePropietario()
        {
            IList<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO> IEleccionMensajePropietario = new List<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.EleccionMensajePropietarioDAL.getListadoEleccionMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO eleccion_mensaje_propietario = new YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO();

                    eleccion_mensaje_propietario.IdEleccionMensajePropietario = decimal.Parse(wobjDataRow["IdEleccionMensajePropietario"].ToString());

                    YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                    myMensajePropietarioDTO.IdMensajePropietario = decimal.Parse(wobjDataRow["idMensajePropietario"].ToString());
                    eleccion_mensaje_propietario.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    eleccion_mensaje_propietario.TheFamiliaDTO = myFamiliaDTO;

                    eleccion_mensaje_propietario.EleccionMensajePropietarioFecha = DateTime.Parse(wobjDataRow["EleccionMensajePropietarioFecha"].ToString());
                    eleccion_mensaje_propietario.EleccionMensajePropietarioMeGusta = wobjDataRow["EleccionMensajePropietarioMeGusta"].ToString();

                    IEleccionMensajePropietario.Add(eleccion_mensaje_propietario);
                }
            }

            return IEleccionMensajePropietario;

        }
    }
}
