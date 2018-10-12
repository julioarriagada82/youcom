using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YouCom.DTO;

namespace YouCom.facade
{
    public class Pais
    {
        public static List<PaisDTO> ListadoPais()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.PaisDTO thePaisDTO;
            List<YouCom.DTO.PaisDTO> collPais=new List<PaisDTO>();

            if (YouCom.Comun.DAL.Accesos.Pais.ListadoPais(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    thePaisDTO=new PaisDTO();
                    thePaisDTO.IdPais = wobjDataRow["idPais"] != null ? wobjDataRow["idPais"].ToString() : string.Empty;
                    thePaisDTO.Descripcion = wobjDataRow["nombre"] != null ? wobjDataRow["nombre"].ToString() : string.Empty;
                    thePaisDTO.UsuarioIngreso = wobjDataRow["usuario_ingreso"] != null ? wobjDataRow["usuario_ingreso"].ToString() : string.Empty;
                    thePaisDTO.FechaIngreso = wobjDataRow["fecha_ingreso"] != null ? wobjDataRow["fecha_ingreso"].ToString() : string.Empty;
                    thePaisDTO.UsuarioModificacion = wobjDataRow["usuario_modificacion"] != null ? wobjDataRow["usuario_modificacion"].ToString() : string.Empty;
                    thePaisDTO.FechaModificacion = wobjDataRow["fecha_modificacion"] != null ? wobjDataRow["fecha_modificacion"].ToString() : string.Empty;
                    thePaisDTO.IdCondominio = !string.IsNullOrEmpty(wobjDataRow["empresa"].ToString())  ? decimal.Parse(wobjDataRow["empresa"].ToString()) : 0;
                    thePaisDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;
                   
                    collPais.Add(thePaisDTO);
                }
            }
            return collPais;
        }
        public static bool ValidaEliminacionPais(PaisDTO thePaisDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.mantenedores.DAL.MantenedoresDAL.ValidaEliminacionPais(thePaisDTO,ref pobjDataTable))
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
