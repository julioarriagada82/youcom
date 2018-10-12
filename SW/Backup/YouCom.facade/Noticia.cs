using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Noticia
    {
        public static IList<YouCom.DTO.NoticiaDTO> getListadoNoticia()
        {
            IList<YouCom.DTO.NoticiaDTO> INoticia = new List<YouCom.DTO.NoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.NoticiaDAL.getListadoNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.NoticiaDTO noticia = new YouCom.DTO.NoticiaDTO();

                    noticia.NoticiaId = decimal.Parse(wobjDataRow["noticia_id"].ToString());
                    noticia.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    noticia.NotiTitulo = wobjDataRow["noticia_titulo"].ToString();
                    noticia.NotiResumen = wobjDataRow["noticia_resumen"].ToString();
                    noticia.NotiDetalle = wobjDataRow["noticia_detalle"].ToString();
                    noticia.CategoriaId = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    noticia.NotiPublicacion = Convert.ToDateTime(wobjDataRow["noticia_publicacion"].ToString());
                    noticia.NotiInicio = Convert.ToDateTime(wobjDataRow["noticia_inicio"].ToString());
                    noticia.NotiExpira = wobjDataRow["noticia_expira"].ToString();
                    noticia.NotiExpiracion = Convert.ToDateTime(wobjDataRow["noticia_expiracion"].ToString());
                    noticia.NotiAutor = wobjDataRow["noticia_autor"].ToString();
                    noticia.NotiImagen = wobjDataRow["noticia_imagen"].ToString();

                    noticia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    noticia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    noticia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    noticia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    noticia.Estado = wobjDataRow["estado"].ToString();

                    INoticia.Add(noticia);
                }
            }

            return INoticia;

        }

        public static bool ValidaEliminacionNoticia(YouCom.DTO.NoticiaDTO theNoticiaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.NoticiaDAL.ValidaEliminacionNoticia(theNoticiaDTO, ref pobjDataTable))
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
