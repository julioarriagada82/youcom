using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class Responsable
    {
        public static IList<YouCom.DTO.Servicio.ResponsableDTO> getListadoResponsable()
        {
            IList<YouCom.DTO.Servicio.ResponsableDTO> IResponsable = new List<YouCom.DTO.Servicio.ResponsableDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ResponsableDAL.getListadoResponsable(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Servicio.ResponsableDTO responsable = new YouCom.DTO.Servicio.ResponsableDTO();

                    responsable.IdResponsable = decimal.Parse(wobjDataRow["idResponsable"].ToString());

                    responsable.RutResponsable = wobjDataRow["rutResponsable"].ToString();
                    responsable.NombreResponsable = wobjDataRow["nombreResponsable"].ToString();
                    responsable.ApellidoPaternoResponsable = wobjDataRow["apellidoPaternoResponsable"].ToString();
                    responsable.ApellidoMaternoResponsable = wobjDataRow["apellidoMaternoResponsable"].ToString();

                    responsable.TelefonoResponsable = wobjDataRow["telefonoResponsable"].ToString();
                    responsable.CelularResponsable = wobjDataRow["celularResponsable"].ToString();
                    responsable.EmailResponsable = wobjDataRow["emailResponsable"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    responsable.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    responsable.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
                    myCargoDTO.IdCargo = decimal.Parse(wobjDataRow["idCargo"].ToString());
                    myCargoDTO.NombreCargo = wobjDataRow["nombreCargo"].ToString();
                    responsable.TheCargoDTO = myCargoDTO;

                    responsable.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    responsable.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    responsable.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    responsable.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    responsable.Estado = wobjDataRow["estado"].ToString();

                    IResponsable.Add(responsable);
                }
            }

            return IResponsable;

        }

        public static bool ValidaEliminacionResponsable(YouCom.DTO.Servicio.ResponsableDTO theResponsableDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ResponsableDAL.ValidaEliminacionResponsable(theResponsableDTO, ref pobjDataTable))
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
