using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
   public class Evento
    {
        public static IList<YouCom.DTO.EventoDTO> getListadoEvento()
        {
            IList<YouCom.DTO.EventoDTO> IEvento = new List<YouCom.DTO.EventoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.EventoDAL.getListadoEvento(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.EventoDTO evento = new YouCom.DTO.EventoDTO();

                    evento.EventoId = decimal.Parse(wobjDataRow["evento_id"].ToString());
                    evento.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    evento.CategoriaId = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    evento.EventoTitulo = wobjDataRow["evento_titulo"].ToString();
                    evento.EventoResumen = wobjDataRow["evento_resumen"].ToString();
                    evento.EventoDetalle = wobjDataRow["evento_detalle"].ToString();
                    evento.EventoPublicacion = Convert.ToDateTime(wobjDataRow["evento_publicacion"].ToString());
                    evento.EventoInicio = Convert.ToDateTime(wobjDataRow["evento_inicio"].ToString());
                    evento.EventoExpiracion = Convert.ToDateTime(wobjDataRow["evento_expiracion"].ToString());
                    evento.EventoAutor = wobjDataRow["evento_autor"].ToString();
                    evento.EventoImagen = wobjDataRow["evento_imagen"].ToString();

                    evento.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    evento.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    evento.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    evento.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    evento.Estado = wobjDataRow["estado"].ToString();

                    IEvento.Add(evento);
                }
            }

            return IEvento;

        }

        public static bool ValidaEliminacionEvento(YouCom.DTO.EventoDTO theEventoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.EventoDAL.ValidaEliminacionEvento(theEventoDTO, ref pobjDataTable))
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
