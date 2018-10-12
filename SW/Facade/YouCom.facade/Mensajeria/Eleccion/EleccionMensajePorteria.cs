using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade.Mensajeria
{
    public class EleccionMensajePorteria
    {
        public static IList<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO> getListadoEleccionMensajePorteria()
        {
            IList<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO> IEleccionMensajePorteria = new List<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.EleccionMensajePorteriaDAL.getListadoEleccionMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO eleccion_mensaje_porteria = new YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO();

                    eleccion_mensaje_porteria.IdEleccionMensajePorteria = decimal.Parse(wobjDataRow["IdEleccionMensajePorteria"].ToString());

                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
                    myMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(wobjDataRow["idMensajePorteria"].ToString());
                    eleccion_mensaje_porteria.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    eleccion_mensaje_porteria.TheFamiliaDTO = myFamiliaDTO;

                    eleccion_mensaje_porteria.EleccionMensajePorteriaFecha = DateTime.Parse(wobjDataRow["EleccionMensajePorteriaFecha"].ToString());
                    eleccion_mensaje_porteria.EleccionMensajePorteriaMeGusta = wobjDataRow["EleccionMensajePorteriaMeGusta"].ToString();

                    IEleccionMensajePorteria.Add(eleccion_mensaje_porteria);
                }
            }

            return IEleccionMensajePorteria;

        }
    }
}
