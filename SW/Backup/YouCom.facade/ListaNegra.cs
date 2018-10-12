using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace YouCom.facade
{
    public class ListaNegra
    {
        public static IList<YouCom.DTO.ListaNegraDTO> getListadoListaNegra()
        {
            IList<YouCom.DTO.ListaNegraDTO> IListaNegra = new List<YouCom.DTO.ListaNegraDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ListaNegraDAL.getListadoListaNegra(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ListaNegraDTO lista = new YouCom.DTO.ListaNegraDTO();

                    lista.IdListaNegra = decimal.Parse(wobjDataRow["idListaNegra"].ToString());
                    lista.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    lista.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    lista.RutListaNegra = wobjDataRow["rutListaNegra"].ToString();
                    lista.NombreListaNegra = wobjDataRow["nombreListaNegra"].ToString();
                    lista.ApellidoListaNegra = wobjDataRow["apellidoListaNegra"].ToString();
                    lista.MotivoListaNegra = wobjDataRow["motivoListaNegra"].ToString();

                    lista.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    lista.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    lista.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    lista.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    lista.Estado = wobjDataRow["estado"].ToString();

                    IListaNegra.Add(lista);
                }
            }

            return IListaNegra;

        }

        public static bool ValidaEliminacionListaNegra(YouCom.DTO.ListaNegraDTO theListaNegraDTO)
        {
            DataTable pobjDataTable = new DataTable();
            List<YouCom.DTO.ListaNegraDTO> collCasa = new List<YouCom.DTO.ListaNegraDTO>();
            bool retorno = false;
            if (YouCom.DAL.ListaNegraDAL.ValidaEliminacionListaNegra(theListaNegraDTO, ref pobjDataTable))
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
