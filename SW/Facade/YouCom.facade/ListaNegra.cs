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
                    
                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    lista.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    lista.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    lista.TheFamiliaDTO = myFamiliaDTO;

                    lista.RutListaNegra = wobjDataRow["rutListaNegra"].ToString();
                    lista.NombreListaNegra = wobjDataRow["nombreListaNegra"].ToString();
                    lista.ApellidoPaternoListaNegra = wobjDataRow["apellidoPaternoListaNegra"].ToString();
                    lista.ApellidoMaternoListaNegra = wobjDataRow["apellidoMaternoListaNegra"].ToString();
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
