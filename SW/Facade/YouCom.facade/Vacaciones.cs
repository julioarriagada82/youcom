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
                    YouCom.DTO.VacacionesDTO vacaciones = new YouCom.DTO.VacacionesDTO();

                    vacaciones.IdVacaciones = decimal.Parse(wobjDataRow["IdVacaciones"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    vacaciones.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    vacaciones.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
                    myCasaDTO.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    vacaciones.TheCasaDTO = myCasaDTO;

                    YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
                    myParentescoDTO.IdParentesco = decimal.Parse(wobjDataRow["idParentesco"].ToString());
                    vacaciones.TheParentescoDTO = myParentescoDTO;

                    vacaciones.FechaInicio = DateTime.Parse(wobjDataRow["FechaInicio"].ToString());
                    vacaciones.FechaTermino = DateTime.Parse(wobjDataRow["FechaTermino"].ToString());
                    vacaciones.DestinoVacaciones = wobjDataRow["motivo"].ToString();
                    vacaciones.TelefonoContacto = wobjDataRow["telefonoContacto"].ToString();
                    vacaciones.NombreContacto = wobjDataRow["nombreContacto"].ToString();

                    vacaciones.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    vacaciones.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    vacaciones.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    vacaciones.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    vacaciones.Estado = wobjDataRow["estado"].ToString();

                    IVacaciones.Add(vacaciones);
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
