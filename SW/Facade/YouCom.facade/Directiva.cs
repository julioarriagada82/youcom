using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Directiva
    {
        public static IList<YouCom.DTO.DirectivaDTO> getListadoDirectiva()
        {
            IList<YouCom.DTO.DirectivaDTO> IDirectiva = new List<YouCom.DTO.DirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.DirectivaDAL.getListadoDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.DirectivaDTO directiva = new YouCom.DTO.DirectivaDTO();

                    directiva.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    
                    YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
                    myCargoDTO.IdCargo = decimal.Parse(wobjDataRow["idCargo"].ToString());
                    myCargoDTO.NombreCargo = wobjDataRow["nombreCargo"].ToString();
                    directiva.TheCargoDTO = myCargoDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    directiva.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    directiva.TheComunidadDTO = myComunidadDTO;
                    directiva.RutDirectiva = wobjDataRow["rutDirectiva"].ToString();
                    directiva.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
                    directiva.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
                    directiva.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
                    directiva.TelefonoDirectiva = wobjDataRow["telefonoDirectiva"].ToString();
                    directiva.ImagenDirectiva = wobjDataRow["imagenDirectiva"].ToString();
                    directiva.EmailDirectiva = wobjDataRow["correoDirectiva"].ToString();
                    directiva.FechaNacimientoDirectiva = Convert.ToDateTime(wobjDataRow["fechaNacimientoDirectiva"].ToString());

                    directiva.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    directiva.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    directiva.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    directiva.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    directiva.Estado = wobjDataRow["estado"].ToString();

                    IDirectiva.Add(directiva);
                }
            }

            return IDirectiva;

        }

        public static bool ValidaEliminacionDirectiva(YouCom.DTO.DirectivaDTO theDirectivaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.DirectivaDAL.ValidaEliminacionDirectiva(theDirectivaDTO, ref pobjDataTable))
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
