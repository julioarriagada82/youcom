using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Avisos
    {
        public static IList<YouCom.DTO.AvisosDTO> getListadoAvisos()
        {
            IList<YouCom.DTO.AvisosDTO> IAvisos = new List<YouCom.DTO.AvisosDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AvisosDAL.getListadoAvisos(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AvisosDTO aviso = new YouCom.DTO.AvisosDTO();

                    aviso.IdAviso = decimal.Parse(wobjDataRow["idAvisos"].ToString());
                    aviso.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());

                    aviso.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    aviso.TituloAviso = wobjDataRow["tituloAviso"].ToString();
                    aviso.DescripcionAviso = wobjDataRow["descripcionAviso"].ToString();
                    aviso.ImagenAviso = wobjDataRow["imagenAviso"].ToString();
                    aviso.IdTipo = decimal.Parse(wobjDataRow["idTipo"].ToString());
                    aviso.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    aviso.Precio = decimal.Parse(wobjDataRow["precio"].ToString());
                    aviso.IdMoneda = decimal.Parse(wobjDataRow["idMoneda"].ToString());
                    aviso.FechaPublicacion = DateTime.Parse(wobjDataRow["fechaPublicacion"].ToString());
                    aviso.FechaTermino = DateTime.Parse(wobjDataRow["fechaTermino"].ToString());
                    aviso.RutComprador = wobjDataRow["rutComprador"].ToString();

                    aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    aviso.Estado = wobjDataRow["estado"].ToString();

                    IAvisos.Add(aviso);
                }
            }

            return IAvisos;

        }

        public static bool ValidaEliminacionAvisos(YouCom.DTO.AvisosDTO theAvisosDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AvisosDAL.ValidaEliminacionAviso(theAvisosDTO, ref pobjDataTable))
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