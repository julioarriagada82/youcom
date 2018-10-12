using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class ComentarioAviso
    {
        public static IList<YouCom.DTO.ComentarioAvisoDTO> getListadoComentarioAviso()
        {
            IList<YouCom.DTO.ComentarioAvisoDTO> IComentarioAviso = new List<YouCom.DTO.ComentarioAvisoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ComentarioAvisoDAL.getListadoComentarioAviso(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ComentarioAvisoDTO comentarioAviso = new YouCom.DTO.ComentarioAvisoDTO();

                    comentarioAviso.IdComentarioAviso = decimal.Parse(wobjDataRow["idComentarioAviso"].ToString());
                    comentarioAviso.IdAviso = decimal.Parse(wobjDataRow["idAviso"].ToString());
                    comentarioAviso.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    comentarioAviso.EmailComentarioAviso = wobjDataRow["emailComentarioAviso"].ToString();
                    comentarioAviso.ComentarioAviso = wobjDataRow["comentarioAviso"].ToString();
                    comentarioAviso.FechaComentarioAviso = DateTime.Parse(wobjDataRow["fechaComentarioAviso"].ToString());

                    comentarioAviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    comentarioAviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    comentarioAviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    comentarioAviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    comentarioAviso.Estado = wobjDataRow["estado"].ToString();

                    IComentarioAviso.Add(comentarioAviso);
                }
            }

            return IComentarioAviso;

        }

        public static bool ValidaEliminacionComentarioAviso(YouCom.DTO.ComentarioAvisoDTO theComentarioAvisoDTO)
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
