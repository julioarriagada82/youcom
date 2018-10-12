using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class Condominio
    {
        public static IList<YouCom.DTO.Seguridad.CondominioDTO> getListadoCondominio()
        {
            IList<YouCom.DTO.Seguridad.CondominioDTO> ICondominio = new List<YouCom.DTO.Seguridad.CondominioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Seguridad.DAL.CondominioDAL.getListadoCondominio(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Seguridad.CondominioDTO condominio = new YouCom.DTO.Seguridad.CondominioDTO();

                    condominio.IdCondominio = decimal.Parse(wobjDataRow["IdCondominio"].ToString());

                    YouCom.DTO.ComunaDTO myComunaDTO = new YouCom.DTO.ComunaDTO();
                    myComunaDTO.IdComuna = decimal.Parse(wobjDataRow["idComuna"].ToString());
                    condominio.TheComunaDTO = myComunaDTO;

                    YouCom.DTO.CiudadDTO myCiudadDTO = new YouCom.DTO.CiudadDTO();
                    myCiudadDTO.IdCiudad = decimal.Parse(wobjDataRow["idCiudad"].ToString());
                    condominio.TheComunaDTO.TheCiudadDTO = myCiudadDTO;

                    YouCom.DTO.RegionDTO myRegionDTO = new YouCom.DTO.RegionDTO();
                    myRegionDTO.IdRegion = decimal.Parse(wobjDataRow["idRegion"].ToString());
                    condominio.TheComunaDTO.TheCiudadDTO.TheRegionDTO = myRegionDTO;

                    condominio.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    condominio.DireccionCondominio = wobjDataRow["direccionCondominio"].ToString();
                    condominio.EmailCondominio = wobjDataRow["correoCondominio"].ToString();
                    condominio.LatitudCondominio = wobjDataRow["latitudCondominio"].ToString();
                    condominio.LongitudCondominio = wobjDataRow["longitudCondominio"].ToString();
                    condominio.RutCondominio = wobjDataRow["rutCondominio"].ToString();
                    condominio.TelefonoCondominio = wobjDataRow["telefonoCondominio"].ToString();

                    condominio.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    condominio.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    condominio.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    condominio.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    condominio.Estado = wobjDataRow["estado"].ToString();

                    ICondominio.Add(condominio);
                }
            }

            return ICondominio;

        }

        public static bool ValidaEliminacionCondominio(YouCom.DTO.Seguridad.CondominioDTO theCondominioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Seguridad.DAL.CondominioDAL.ValidaEliminacionCondominio(theCondominioDTO, ref pobjDataTable))
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
