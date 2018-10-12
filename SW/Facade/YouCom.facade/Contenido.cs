using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Contenido
    {
        public static IList<YouCom.DTO.ContenidoDTO> getListadoContenido()
        {
            IList<YouCom.DTO.ContenidoDTO> IContenido = new List<YouCom.DTO.ContenidoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ContenidoDAL.getListadoContenido(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ContenidoDTO contenido = new YouCom.DTO.ContenidoDTO();

                    contenido.ContenidoId = decimal.Parse(wobjDataRow["IdCasa"].ToString());
                    contenido.ContenidoTitulo = wobjDataRow["idCondominio"].ToString();
                    contenido.ContenidoResumen = wobjDataRow["nombreCasa"].ToString();
                    contenido.ContenidoDetalle = wobjDataRow["direccionCasa"].ToString();
                    contenido.ContenidoBanner = wobjDataRow["telefonoCasa"].ToString();
                    contenido.ContenidoImagen = wobjDataRow["telefonoCasa"].ToString();

                    contenido.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    contenido.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    contenido.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    contenido.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    contenido.Estado = wobjDataRow["estado"].ToString();

                    IContenido.Add(contenido);
                }
            }

            return IContenido;

        }

        public static bool ValidaEliminacionContenido(YouCom.DTO.ContenidoDTO theContenidoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ContenidoDAL.ValidaEliminacionContenido(theContenidoDTO, ref pobjDataTable))
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
