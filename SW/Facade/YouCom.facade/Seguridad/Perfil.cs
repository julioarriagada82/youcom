using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class Perfil
    {
        public static IList<YouCom.DTO.Seguridad.PerfilDTO> getListadoPerfil()
        {
            IList<YouCom.DTO.Seguridad.PerfilDTO> IPerfil = new List<YouCom.DTO.Seguridad.PerfilDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Seguridad.DAL.PerfilDAL.getListadoPerfil(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Seguridad.PerfilDTO Perfil = new YouCom.DTO.Seguridad.PerfilDTO();

                    Perfil.IdPerfil = decimal.Parse(wobjDataRow["IdPerfil"].ToString());
                    Perfil.NombrePerfil = wobjDataRow["nombrePerfil"].ToString();
                    Perfil.DescripcionPerfil = wobjDataRow["descripcionPerfil"].ToString();

                    Perfil.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    Perfil.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    Perfil.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    Perfil.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    Perfil.Estado = wobjDataRow["estado"].ToString();

                    IPerfil.Add(Perfil);
                }
            }

            return IPerfil;

        }

        public static bool ValidaEliminacionPerfil(YouCom.DTO.Seguridad.PerfilDTO thePerfilDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Seguridad.DAL.PerfilDAL.ValidaEliminacionPerfil(thePerfilDTO, ref pobjDataTable))
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
