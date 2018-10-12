using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class EleccionMensajeDirectiva
    {
        public static IList<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO> getListadoEleccionMensajeDirectiva()
        {
            IList<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO> IEleccionMensajeDirectiva = new List<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.EleccionMensajeDirectivaDAL.getListadoEleccionMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO eleccion_mensaje_directiva = new YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO();

                    eleccion_mensaje_directiva.IdEleccionMensajeDirectiva = decimal.Parse(wobjDataRow["IdEleccionMensajeDirectiva"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
                    myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(wobjDataRow["idMensajeDirectiva"].ToString());
                    eleccion_mensaje_directiva.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    eleccion_mensaje_directiva.TheFamiliaDTO = myFamiliaDTO;

                    eleccion_mensaje_directiva.EleccionMensajeDirectivaFecha = DateTime.Parse(wobjDataRow["eleccionMensajeDirectivaFecha"].ToString());
                    eleccion_mensaje_directiva.EleccionMensajeDirectivaMeGusta = wobjDataRow["eleccionMensajeDirectivaMeGusta"].ToString();
                    
                    IEleccionMensajeDirectiva.Add(eleccion_mensaje_directiva);
                }
            }

            return IEleccionMensajeDirectiva;

        }
    }
}
