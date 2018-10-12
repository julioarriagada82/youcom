using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Vacaciones
    {
        public static IList<YouCom.DTO.VacacionesDTO> getListadoVacaciones()
        {
            IList<YouCom.DTO.VacacionesDTO> IVacaciones = new List<YouCom.DTO.VacacionesDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.VacacionesDAL.getListadoVacaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.VacacionesDTO tipo_Visita = new YouCom.DTO.VacacionesDTO();

                    tipo_Visita.IdVacaciones = decimal.Parse(wobjDataRow["IdVacaciones"].ToString());
                    tipo_Visita.IdCasa = decimal.Parse(wobjDataRow["IdCasa"].ToString());
                    tipo_Visita.IdParentesco = decimal.Parse(wobjDataRow["IdParentesco"].ToString());
                    tipo_Visita.FechaInicio = DateTime.Parse(wobjDataRow["FechaInicio"].ToString());
                    tipo_Visita.FechaTermino = DateTime.Parse(wobjDataRow["FechaTermino"].ToString());
                    tipo_Visita.DestinoVacaciones = wobjDataRow["motivo"].ToString();
                    tipo_Visita.TelefonoContacto = wobjDataRow["telefonoContacto"].ToString();
                    tipo_Visita.NombreContacto = wobjDataRow["nombreContacto"].ToString();
                    tipo_Visita.Comentario = wobjDataRow["comentarioVacaciones"].ToString();

                    tipo_Visita.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_Visita.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_Visita.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_Visita.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_Visita.Estado = wobjDataRow["estado"].ToString();

                    IVacaciones.Add(tipo_Visita);
                }
            }

            return IVacaciones;

        }

        public static bool ValidaEliminacionVacaciones(YouCom.DTO.VacacionesDTO theVacacionesDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.VacacionesDAL.ValidaEliminacionVacaciones(theVacacionesDTO, ref pobjDataTable))
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
