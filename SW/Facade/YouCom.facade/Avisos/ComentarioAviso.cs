using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade.Avisos
{
    public class ComentarioAviso
    {
        public static IList<YouCom.DTO.Avisos.ComentarioAvisoDTO> getListadoComentarioAviso()
        {
            IList<YouCom.DTO.Avisos.ComentarioAvisoDTO> IComentarioAviso = new List<YouCom.DTO.Avisos.ComentarioAvisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ComentarioAvisoDAL.getListadoComentarioAviso(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Avisos.ComentarioAvisoDTO comentarioAviso = new YouCom.DTO.Avisos.ComentarioAvisoDTO();

                    comentarioAviso.IdComentarioAviso = decimal.Parse(wobjDataRow["idComentarioAviso"].ToString());
                    comentarioAviso.IdPadre = !string.IsNullOrEmpty(wobjDataRow["idPadre"].ToString()) ? decimal.Parse(wobjDataRow["idPadre"].ToString()) : 0;

                    YouCom.DTO.Avisos.AvisoDTO myAviso = new YouCom.DTO.Avisos.AvisoDTO();
                    myAviso.IdAviso = decimal.Parse(wobjDataRow["idAvisos"].ToString());
                    comentarioAviso.TheAvisosDTO = myAviso;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    comentarioAviso.TheFamiliaDTO = myFamiliaDTO;

                    comentarioAviso.EmailComentarioAviso = wobjDataRow["emailComentarioAviso"].ToString();
                    comentarioAviso.ComentarioAviso = wobjDataRow["comentarioAviso"].ToString();
                    comentarioAviso.FechaComentarioAviso = DateTime.Parse(wobjDataRow["fechaComentarioAviso"].ToString());

                    comentarioAviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    comentarioAviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    comentarioAviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    comentarioAviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    comentarioAviso.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    comentarioAviso.TheComunidadDTO = myComunidadDTO;

                    comentarioAviso.Estado = wobjDataRow["estado"].ToString();

                    IComentarioAviso.Add(comentarioAviso);
                }
            }

            return IComentarioAviso;

        }

        public static bool ValidaEliminacionComentarioAviso(YouCom.DTO.Avisos.ComentarioAvisoDTO theComentarioAvisoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ComentarioAvisoDAL.ValidaEliminacionComentarioAviso(theComentarioAvisoDTO, ref pobjDataTable))
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
